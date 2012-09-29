// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="http://stylecop.codeplex.com">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. If you cannot locate the  
//   Microsoft Public License, please send an email to dlr@microsoft.com. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
// <summary>
//   AssemblyInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using System;
using System.Reflection;
using System.Runtime.InteropServices;

using JetBrains.Application.PluginSupport;
using JetBrains.ReSharper.Daemon;

#endregion

[assembly: AssemblyTitle("StyleCop R# 6.1.1 Plugin")]
[assembly: AssemblyDescription("R# plugin for StyleCop")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct(StyleCop.Constants.ProductName)]
[assembly: AssemblyCopyright("MS-PL")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]
[assembly: ComVisible(false)]

// Many of the R# base types are not CLS compliant so we can't be.
[assembly: CLSCompliant(false)]

[assembly: Guid("B566919A-1C80-4778-BA87-A6B7052B525A")]

[assembly: RegisterConfigurableSeverity("StyleCop.DefaultSeverity", null, HighlightingGroupIds.CodeSmell, "item title", "item description", Severity.WARNING, false)]

[assembly: PluginTitle(StyleCop.Constants.ProductNameWithVersion)]
[assembly: PluginVendor(StyleCop.Constants.Vendor)]
[assembly: PluginDescription("R# plugin for StyleCop. This plugin allows StyleCop to be run as you type, generating real-time syntax highlighting of violations. It also provides a series of Quick-Fixes and Code Clean Up Modules to help automatically fix violations. See http://stylecop.codeplex.com for more info.")]
