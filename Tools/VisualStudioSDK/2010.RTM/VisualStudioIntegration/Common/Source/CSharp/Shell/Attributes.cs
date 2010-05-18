//--------------------------------------------------------------------------
//  <copyright file="Attributes.cs" company="Microsoft">
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
using SR=Microsoft.VisualStudio.Shell.SR;

namespace Microsoft.VisualStudio.Shell
{ 
    /// <include file='doc\Attributes.uex' path='docs/doc[@for="PropertyPageTypeConverterAttribute"]' />
	/// <summary>
	/// Defines our type converter.
	/// </summary>
	/// <remarks>This is needed to get rid of the type TypeConverter type that could not give back the Type we were passing to him.
	/// We do not want to use reflection to get the type back from the  ConverterTypeName. Also the GetType mthos does not spwan converters from other assemblies.</remarks>
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field)]
	public sealed class PropertyPageTypeConverterAttribute : Attribute
	{
		Type converterType;
        /// <include file='doc\Attributes.uex' path='docs/doc[@for="PropertyPageTypeConverterAttribute.PropertyPageTypeConverterAttribute"]' />
        public PropertyPageTypeConverterAttribute(Type t)
		{
			this.converterType = t;
		}

        /// <include file='doc\Attributes.uex' path='docs/doc[@for="PropertyPageTypeConverterAttribute.ConverterType"]' />
        public Type ConverterType
		{
			get
			{
				return this.converterType;
			}
		}
	}

    /// <include file='doc\Attributes.uex' path='docs/doc[@for="LocDisplayNameAttribute"]' />
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Property | AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
	public sealed class LocDisplayNameAttribute : DisplayNameAttribute
	{
		string name;

        /// <include file='doc\Attributes.uex' path='docs/doc[@for="LocDisplayNameAttribute.LocDisplayNameAttribute"]' />
        public LocDisplayNameAttribute(string name)
		{
			this.name = name;
		}

        /// <include file='doc\Attributes.uex' path='docs/doc[@for="LocDisplayNameAttribute.DisplayName"]' />
        public override string DisplayName
		{
			get
			{
				string result = SR.GetString(this.name);
				if (result == null)
				{
					Debug.Assert(false, "String resource '" + this.name + "' is missing");
					result = this.name;
				}
				return result;
			}
		}
	}
}
