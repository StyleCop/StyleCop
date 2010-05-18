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

namespace PropertyPageBase
{
	public class PropertyControlMap
	{
		private IPageViewSite m_pageViewSite;
		private PropertyControlTable m_propertyControlTable;
		private IPropertyPageUI m_propertyPageUI;

		public PropertyControlMap(IPageViewSite pageViewSite, IPropertyPageUI propertyPageUI, PropertyControlTable propertyControlTable)
		{
			m_propertyControlTable = propertyControlTable;
			m_pageViewSite = pageViewSite;
			m_propertyPageUI = propertyPageUI;
		}

		void m_propertyPageUI_UserEditComplete(Control control, string value)
		{
			string propertyName = m_propertyControlTable.GetPropertyNameFromControl(control);
			m_pageViewSite.PropertyChanged(propertyName, value);
		}

		public void InitializeControls()
		{
			m_propertyPageUI.UserEditComplete -= new UserEditCompleteHandler(m_propertyPageUI_UserEditComplete);
			List<string> propertyNames = m_propertyControlTable.GetPropertyNames();
			foreach (string propertyName in propertyNames)
			{
				string propertyValue = m_pageViewSite.GetValueForProperty(propertyName);
				Control control = m_propertyControlTable.GetControlFromPropertyName(propertyName);
				m_propertyPageUI.SetControlValue(control, propertyValue);
			}
			m_propertyPageUI.UserEditComplete += new UserEditCompleteHandler(m_propertyPageUI_UserEditComplete);
		}
	}
}
