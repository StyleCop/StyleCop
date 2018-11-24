//-----------------------------------------------------------------------
// <copyright file="AssemblyInfo.cs">
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
//-----------------------------------------------------------------------
using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using System.Resources;
using System.Runtime.InteropServices;

// General Information about an assembly is controlled through the following 
// set of attributes. Change these attribute values to modify the information
// associated with an assembly.
[assembly: AssemblyTitle("StyleCop Settings Editor")]
[assembly: AssemblyDescription("Displays StyleCop project settings")]
[assembly: AssemblyConfiguration("")]
[assembly: AssemblyCompany("")]
[assembly: AssemblyProduct("StyleCop")]
[assembly: AssemblyCopyright("MS-PL")]
[assembly: AssemblyTrademark("")]
[assembly: AssemblyCulture("")]

// Setting ComVisible to false makes the types in this assembly not visible 
// to COM components.  If you need to access a type in this assembly from 
// COM, set the ComVisible attribute to true on that type.
[assembly: ComVisible(false)]

[assembly: CLSCompliant(true)]

// The following GUID is for the ID of the typelib if this project is exposed to COM
[assembly: Guid("f9cd640f-ca1d-4e37-a8e8-6594764e1c31")]
[assembly: NeutralResourcesLanguageAttribute("en-US")]

[assembly: AssemblyVersion("0.0.1")]
[assembly: AssemblyFileVersion("0.0.1")]
[assembly: AssemblyInformationalVersion("0.0.1-unofficial")]

// Suppress message about assembly not having a strong name. This is known since assemblies are delay-signed.
[assembly: SuppressMessage("Microsoft.Design", "CA2210:AssembliesShouldHaveValidStrongNames", Justification = "This assembly is delay signed.")]