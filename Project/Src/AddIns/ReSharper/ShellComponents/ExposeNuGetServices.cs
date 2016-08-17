// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ExposeNuGetServices.cs" company="http://stylecop.codeplex.com">
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
//   Exposes NuGet services to ReSharper's Component Model
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.ReSharper.ShellComponents
{
    using JetBrains.Platform.VisualStudio.SinceVs10.Interop;
    using JetBrains.VsIntegration.Shell;

    using NuGet.VisualStudio;

    /// <summary>
    ///     Exposes NuGet services to ReSharper's Component Model
    /// </summary>
    [WrapVsInterfaces]
    public class ExposeNuGetServices : IExposeVsServices
    {
        /// <summary>
        ///     Registers the services with the Component Model
        /// </summary>
        /// <param name="map">The Visual Studio service map</param>
        public void Register(VsServiceProviderResolver.VsServiceMap map)
        {
            // These services are also added to the Component Model in SinceVs10.dll,
            // but they're added as embedded interop types, just as we're doing here.
            // The Component Model doesn't do type equivalence, so treats the embedded
            // types as different. We can't use the embedded types in SinceVs10.dll,
            // as the compiler doesn't let us use them. So, there's no way to get the
            // interfaces that SinceVs10.dll adds. Since the Component Model treats
            // these as different types, it's safe to add them again.
            map.OptionalMef<IVsPackageInstallerServices>();
            map.OptionalMef<IVsPackageInstallerEvents>();
        }
    }
}