/***************************************************************************
Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using Microsoft.VisualStudio;

namespace PropertyPageBase
{
	public class PageView : UserControl, IPageView, IPropertyPageUI
	{
		[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
		public PageView()
		{
		}

		public PageView(IPageViewSite pageViewSite)
		{
			m_propertyControlMap = new PropertyControlMap(pageViewSite, this, PropertyControlTable);
		}

		private PropertyControlMap m_propertyControlMap;

		virtual protected PropertyControlTable PropertyControlTable
		{
			get
			{
				throw new NotImplementedException();
			}
		}

        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            TextBox senderTextBox = sender as TextBox;
            if (UserEditComplete != null)
                UserEditComplete(senderTextBox, senderTextBox.Text);
        }

		void CheckBox_CheckedChanged(object sender, EventArgs e)
		{
			CheckBox senderCheckBox = sender as CheckBox;
			if (UserEditComplete != null)
				UserEditComplete(senderCheckBox, senderCheckBox.Checked.ToString());
		}

		#region IPropertyPageUI Members

		public event UserEditCompleteHandler UserEditComplete;

		public virtual string GetControlValue(Control control)
		{
			CheckBox checkboxWithValue = control as CheckBox;
			if (null != checkboxWithValue)
			{
				return checkboxWithValue.Checked.ToString();
			}
			TextBox textboxWithValue = control as TextBox;
			if (null != textboxWithValue)
			{
				return textboxWithValue.Text;
			}
			throw new ArgumentOutOfRangeException();
		}

		public virtual void SetControlValue(Control control, string value)
		{
			CheckBox checkboxToChange = control as CheckBox;
			if (null != checkboxToChange)
			{
				bool boxIsChecked;
				if (!bool.TryParse(value, out boxIsChecked))
					boxIsChecked = false;
				checkboxToChange.Checked = boxIsChecked;
				return;
			}
			TextBox textboxToChange = control as TextBox;
			if (null != textboxToChange)
			{
				textboxToChange.Text = value;
				return;
			}
		}

		#endregion

		#region IPageView Members

		public virtual void Initialize(System.Windows.Forms.Control parentControl, System.Drawing.Rectangle rectangle)
		{
			this.SetBounds(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height);
			this.Parent = parentControl;
			m_propertyControlMap.InitializeControls();
			foreach (Control boundControl in PropertyControlTable.GetControls())
			{
				TextBox boundTextBox = boundControl as TextBox;
				if (null != boundTextBox)
				{
					boundTextBox.TextChanged += new EventHandler(TextBox_TextChanged);
					continue;
				}

				CheckBox boundCheckBox = boundControl as CheckBox;
				if (null != boundCheckBox)
				{
					boundCheckBox.CheckedChanged += new EventHandler(CheckBox_CheckedChanged);
					continue;
				}
			}

			// Once done, give the derived class the ability to perform some initialization.
			OnInitialize();
		}

		protected virtual void OnInitialize() { }

		public void MoveView(System.Drawing.Rectangle rectangle)
		{
			this.Location = new Point(rectangle.X, rectangle.Y);
			this.Size = new Size(rectangle.Width, rectangle.Height);
		}

		public void ShowView()
		{
			this.Show();
		}

		public void HideView()
		{
			this.Hide();
		}

		public new void Dispose()
		{
			base.Dispose();
		}

		public int ProcessAccelerator(ref Message keyboardMessage)
		{
			Control destinationControl = Control.FromHandle(keyboardMessage.HWnd);
			bool messageProccessed = destinationControl.PreProcessMessage(ref keyboardMessage);
			if (messageProccessed)
				return VSConstants.S_OK;
			else
				return VSConstants.S_FALSE;
		}

		public Size ViewSize
		{
			get { return Size; }
		}

		public void RefreshPropertyValues()
		{
			m_propertyControlMap.InitializeControls();
		}

		#endregion
	}
}
