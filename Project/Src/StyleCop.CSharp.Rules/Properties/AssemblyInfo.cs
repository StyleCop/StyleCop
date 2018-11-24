// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs" company="https://github.com/StyleCop">
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

using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("StyleCop C# Analyzers")]
[assembly: AssemblyDescription("Source code analyzers for use with StyleCop")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("StyleCop")]
[assembly: AssemblyCopyright("MS-PL")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM componenets.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]
[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("B2C1C895-B8DD-4A2B-8671-77F9E2E8C511")]
[assembly: NeutralResourcesLanguage("en-US")]

[assembly: AssemblyVersion("0.0.1")]
[assembly: AssemblyFileVersion("0.0.1")]
[assembly: AssemblyInformationalVersion("0.0.1-unofficial")]

// Suppress message about assembly not having a strong name. This is known since assemblies are delay-signed.
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "Reviewed. This is OK.")]