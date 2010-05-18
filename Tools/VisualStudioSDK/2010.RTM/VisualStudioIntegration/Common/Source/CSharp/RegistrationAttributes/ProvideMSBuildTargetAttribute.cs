/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;

namespace Microsoft.VisualStudio.Shell
{
    /// <summary>
    /// This attribute register a custom .targets files to the list of the
    /// targets known and trusted by MSBuild.
    /// 
    /// The registry entries created are:
    ///   [%RegistryRoot%\MSBuild\SafeImports]
    ///			"TargetsLabel"="PathToTheTargetsFile"
    /// 
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ProvideMSBuildTargetsAttribute : RegistrationAttribute
    {
        private const string MSBuildSafeImportsPath = @"MSBuild\SafeImports";
        private string targetsLabel;
        private string targetsPath;

        /// <summary>
        /// Creates a new ProvideMSBuildTargets attribute to register a targets file
        /// to the list of the MSBuild safe imports.
        /// </summary>
        /// <param name="targetsLabel">Label to identify the targets.</param>
        /// <param name="targetsPath">Full path to the targets file.</param>
        public ProvideMSBuildTargetsAttribute(string targetsLabel, string targetsPath)
        {
            if (string.IsNullOrEmpty(targetsLabel))
            {
                throw new ArgumentNullException("targetsLabel");
            }
            if (string.IsNullOrEmpty(targetsPath))
            {
                throw new ArgumentNullException("targetsPath");
            }
            this.targetsLabel = targetsLabel;
            this.targetsPath = targetsPath;
        }

        /// <summary>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     It also contains other information such as the type being registered and path information.
        /// </summary>
        public override void Register(RegistrationContext context)
        {
            if (null == context) {
                new ArgumentNullException("context");
            }
            using (Key safeImportsKey = context.CreateKey(MSBuildSafeImportsPath))
            {
                safeImportsKey.SetValue(targetsLabel, targetsPath);
            }

        }

        /// <summary>
        /// Unregister this file extension.
        /// </summary>
        /// <param name="context"></param>
        public override void Unregister(RegistrationContext context)
        {
            if (null != context)
            {
                context.RemoveValue(MSBuildSafeImportsPath, targetsLabel);
            }
        }
    }
}
