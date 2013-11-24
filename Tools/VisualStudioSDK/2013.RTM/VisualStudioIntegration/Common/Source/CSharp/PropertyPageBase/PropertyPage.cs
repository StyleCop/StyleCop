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
using System.Windows.Forms;
using System.Drawing;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio;
using System.Runtime.InteropServices;

namespace PropertyPageBase
{
	abstract public class PropertyPage : Microsoft.VisualStudio.OLE.Interop.IPropertyPage2, IPageViewSite
	{
		private KeyValuePair<string, string>? propertyToBePersisted;
		private IPropertyPageSite m_IPropertyPageSite;
		public Microsoft.VisualStudio.OLE.Interop.IPropertyPageSite IPropertyPageSite
		{
			get
			{
				return m_IPropertyPageSite;
			}
			set
			{
				m_IPropertyPageSite = value;
			}
		}

		private IPropertyStore m_IPropertyStore;
		public IPropertyStore IPropertyStore
		{
			get
			{
				return m_IPropertyStore;
			}
			set
			{
				m_IPropertyStore = value;
			}
		}

		abstract public string Title { get; }

		#region IPropertyPage2 Members

		public void Activate(IntPtr hWndParent, RECT[] pRect, int bModal)
		{
            if ((null == pRect) || (0 == pRect.Length))
            {
                throw new ArgumentNullException("pRect");
            }
			Control parentControl = Control.FromHandle(hWndParent);
			RECT pageRectangle = pRect[0];
			MyPageView.Initialize(parentControl, Rectangle.FromLTRB(pageRectangle.left, pageRectangle.top, pageRectangle.right, pageRectangle.bottom));
		}

		protected PropertyPageBase.IPageView myPageView;

		public PropertyPageBase.IPageView MyPageView
		{
			get 
			{
				if (myPageView == null)
				{
					IPageView concretePageView = GetNewPageView();
					this.MyPageView = concretePageView;
				}
				return myPageView; 
			}
			set { myPageView = value; }
		}


		abstract protected PropertyPageBase.IPageView GetNewPageView();

		abstract protected IPropertyStore GetNewPropertyStore();

		public void Apply()
		{
			if (propertyToBePersisted.HasValue)
			{
				IPropertyStore.Persist(propertyToBePersisted.Value.Key, propertyToBePersisted.Value.Value);
				propertyToBePersisted = null;
			}
		}

		public void Deactivate()
		{
            if (null != myPageView)
            {
                myPageView.Dispose();
                myPageView = null;
            }
		}

		public void EditProperty(int DISPID)
		{
			
		}

		public void GetPageInfo(Microsoft.VisualStudio.OLE.Interop.PROPPAGEINFO[] pPageInfo)
		{
            if ((null == pPageInfo) || (0 == pPageInfo.Length))
            {
                throw new ArgumentNullException("pPageInfo");
            }

			PROPPAGEINFO pageInfo;

			pageInfo.cb = (uint)Marshal.SizeOf(typeof(PROPPAGEINFO));
			pageInfo.dwHelpContext = 0;
			pageInfo.pszDocString = null;
			pageInfo.pszHelpFile = null;
			pageInfo.pszTitle = Title;
			pageInfo.SIZE.cx = MyPageView.ViewSize.Width;
			pageInfo.SIZE.cy = MyPageView.ViewSize.Height;

			pPageInfo[0] = pageInfo;
		}

		abstract protected string HelpKeyword { get; }

		public void Help(string pszHelpDir)
		{
			System.IServiceProvider serviceProvider = IPropertyPageSite as System.IServiceProvider;

            if (null != serviceProvider)
            {
                Microsoft.VisualStudio.VSHelp.Help helpService = serviceProvider.GetService(typeof(Microsoft.VisualStudio.VSHelp.Help)) as Microsoft.VisualStudio.VSHelp.Help;
                if (null != helpService)
                {
                    helpService.DisplayTopicFromF1Keyword(HelpKeyword);
                }
            }
		}

		public int IsPageDirty()
		{
			return propertyToBePersisted.HasValue ? VSConstants.S_OK : VSConstants.S_FALSE;
		}

		public void Move(Microsoft.VisualStudio.OLE.Interop.RECT[] pRect)
		{
			MyPageView.MoveView(Rectangle.FromLTRB(pRect[0].left, pRect[0].top, pRect[0].right, pRect[0].bottom));
		}

		public void SetObjects(uint cObjects, object[] ppunk)
		{
			if (ppunk == null || cObjects == 0)
			{
                if (null != IPropertyStore)
                {
                    IPropertyStore.Dispose();
                    IPropertyStore = null;
                }
			}
			else
			{
				bool needToRefresh = false;
				if (IPropertyStore != null)
					needToRefresh = true;
				IPropertyStore = GetNewPropertyStore();
				IPropertyStore.Initialize(ppunk);
				if (needToRefresh)
					MyPageView.RefreshPropertyValues();
			}
		}

		public void SetPageSite(Microsoft.VisualStudio.OLE.Interop.IPropertyPageSite pPageSite)
		{
			IPropertyPageSite = pPageSite;
		}

		public void Show(uint nCmdShow)
		{
			switch (nCmdShow)
			{
				case Constants.SW_HIDE:
					MyPageView.HideView();
					break;
				case Constants.SW_SHOW:
				case Constants.SW_SHOWNORMAL:
					MyPageView.ShowView();
					break;
				default:
					break;
			}
		}

		public int TranslateAccelerator(Microsoft.VisualStudio.OLE.Interop.MSG[] pMsg)
		{
			Message keyboardMessage = Message.Create(pMsg[0].hwnd, (int)pMsg[0].message, pMsg[0].wParam, pMsg[0].lParam);
			int hr = MyPageView.ProcessAccelerator(ref keyboardMessage);
			pMsg[0].lParam = keyboardMessage.LParam;
			pMsg[0].wParam = keyboardMessage.WParam;
			return hr;
		}

		#endregion

		#region IPropertyPage Members


		int IPropertyPage.Apply()
		{
			Apply();
			return VSConstants.S_OK;
		}

		#endregion

		#region IPageViewSite Members

		public void PropertyChanged(string propertyName, string propertyValue)
		{
            // If there is no store, then there is no point in changing the property value.
            if (null == IPropertyStore)
            {
                return;
            }
			propertyToBePersisted = new KeyValuePair<string, string>(propertyName, propertyValue);
            if (null != IPropertyPageSite)
            {
                IPropertyPageSite.OnStatusChange((uint)(PROPPAGESTATUS.PROPPAGESTATUS_DIRTY | PROPPAGESTATUS.PROPPAGESTATUS_VALIDATE));
            }
		}

		public string GetValueForProperty(string propertyName)
		{
            if (null != IPropertyStore)
            {
                return IPropertyStore.PropertyValue(propertyName);
            }
            return null;
		}

		#endregion
	}
}
