//--------------------------------------------------------------------------
//  <copyright file="LocalizableProperties.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
//  <summary>
//  </summary>
//--------------------------------------------------------------------------
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VisualStudio.Designer.Interfaces;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml;
using System.Diagnostics;

namespace Microsoft.VisualStudio.Shell
{
    /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties]/*' />
    [ComVisible(true)]
    public class LocalizableProperties : ICustomTypeDescriptor
	{
        #region ICustomTypeDescriptor
        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetAttributes]/*' />
        public AttributeCollection GetAttributes() 
		{
            AttributeCollection col = TypeDescriptor.GetAttributes(this, true);
            return col;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetDefaultEvent]/*' />
        public EventDescriptor GetDefaultEvent() 
		{
            EventDescriptor ed = TypeDescriptor.GetDefaultEvent(this, true);
            return ed;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetDefaultProperty]/*' />
        public PropertyDescriptor GetDefaultProperty() 
		{
            PropertyDescriptor pd = TypeDescriptor.GetDefaultProperty(this, true);
            return pd;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetEditor]/*' />
        public object GetEditor(Type editorBaseType) 
		{
            object o = TypeDescriptor.GetEditor(this, editorBaseType, true);
            return o;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetEvents]/*' />
        public EventDescriptorCollection GetEvents() 
		{
            EventDescriptorCollection edc = TypeDescriptor.GetEvents(this, true);
            return edc;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetEvents1]/*' />
        public EventDescriptorCollection GetEvents(System.Attribute[] attributes) 
		{
            EventDescriptorCollection edc = TypeDescriptor.GetEvents(this, attributes, true);
            return edc;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetPropertyOwner]/*' />
        public object GetPropertyOwner(PropertyDescriptor pd) 
		{
            return this;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetProperties]/*' />
        public PropertyDescriptorCollection GetProperties() 
		{
            PropertyDescriptorCollection pcol = GetProperties(null);
            return pcol;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetProperties1]/*' />
        public PropertyDescriptorCollection GetProperties(System.Attribute[] attributes) 
		{
            ArrayList newList = new ArrayList();
            PropertyDescriptorCollection props = TypeDescriptor.GetProperties(this, attributes, true);

            for (int i = 0; i < props.Count; i++)
                newList.Add(CreateDesignPropertyDescriptor(props[i]));

            return new PropertyDescriptorCollection((PropertyDescriptor[])newList.ToArray(typeof(PropertyDescriptor)));;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.CreateDesignPropertyDescriptor]/*' />
        public virtual DesignPropertyDescriptor CreateDesignPropertyDescriptor(PropertyDescriptor p) 
		{
            return new DesignPropertyDescriptor(p);
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetComponentName]/*' />
        public string GetComponentName() 
		{
            string name = TypeDescriptor.GetComponentName(this, true);
            return name;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetConverter]/*' />
        public virtual TypeConverter GetConverter() 
		{
            TypeConverter tc = TypeDescriptor.GetConverter(this, true);
            return tc;
        }

        /// <include file='doc\LocalizableProperties.uex' path='docs/doc[@for=LocalizableProperties.GetClassName]/*' />
        public virtual string GetClassName() 
		{
			return this.GetType().FullName;
		}

        #endregion ICustomTypeDescriptor
    }
}
