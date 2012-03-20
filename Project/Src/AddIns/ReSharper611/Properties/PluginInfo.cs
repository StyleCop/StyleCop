// --------------------------------------------------------------------------------------------------------------------
// <copyright file="PluginInfo.cs" company="http://stylecop.codeplex.com">
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
//   PluginInfo.cs
// </summary>
// --------------------------------------------------------------------------------------------------------------------

#region Using Directives

using JetBrains.Application.PluginSupport;

using StyleCop.ReSharper611.Properties;

#endregion

[assembly: PluginTitle(StyleCop.AssemblyVersion.ProductNameWithVersion)]
[assembly: PluginVendor(Constants.Vendor)]
[assembly: PluginDescription(Constants.DescriptionLong)]