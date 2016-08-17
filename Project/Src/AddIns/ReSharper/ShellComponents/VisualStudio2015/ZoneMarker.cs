// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ZoneMarker.cs" company="http://stylecop.codeplex.com">
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
//   Zone marker for the Visual Studio specific components
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.ShellComponents.VisualStudio2015
{
    using JetBrains.Application.BuildScript.Application.Zones;
    using JetBrains.VsIntegration.Shell.Zones;

    /// <summary>
    /// Zone marker for the Visual Studio specific components
    /// </summary>
    [ZoneMarker]
    public class ZoneMarker : IRequire<IVisualStudioZone>
    {
    }
}