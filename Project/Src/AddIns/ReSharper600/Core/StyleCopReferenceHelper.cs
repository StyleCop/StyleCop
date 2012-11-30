// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopReferenceHelper.cs" company="http://stylecop.codeplex.com">
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
//   Helper class to allow the StyleCop assembly references
//   to be resolved to the StyleCop installation directory.
//   This means that the plugin does not need local copies
//   of the StyleCop assemblies.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
extern alias JB;

namespace StyleCop.ReSharper600.Core
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Reflection;

    using StyleCop.ReSharper600.Options;

    #endregion

    /// <summary>
    /// Helper class to allow the StyleCop assembly references 
    /// to be resolved to the StyleCop installation directory. 
    /// This means that the plugin does not need local copies 
    /// of the StyleCop assemblies.
    /// </summary>
    public class StyleCopReferenceHelper
    {
        #region Static Fields

        /// <summary>
        /// SyncRoot object to lock access to the assembly.
        /// </summary>
        private static readonly object AssemblySyncRoot = new object();

        /// <summary>
        /// SyncRoot object to lock access to the reference.
        /// </summary>
        private static readonly object ReferenceSyncRoot = new object();

        /// <summary>
        /// Flag to indicate if the system has already attempted to load the StyleCop assembly.
        /// </summary>
        private static bool assemblyLoadAttempted;

        /// <summary>
        /// Flag to indicate if the system has already attempted to load the StyleCop.CSharp.Rules assembly.
        /// </summary>
        private static bool assemblyRulesLoadAttempted;

        /// <summary>
        /// The located StyleCop assembly.
        /// </summary>
        private static Assembly styleCopAssembly;

        /// <summary>
        /// The located StyleCop.CSharp.Rules assembly.
        /// </summary>
        private static Assembly styleCopCSharpRulesAssembly;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the StyleCopReferenceHelper class. 
        /// </summary>
        static StyleCopReferenceHelper()
        {
            assemblyLoadAttempted = false;
            AppDomain.CurrentDomain.AssemblyResolve += OnEventHandler;
        }

        #endregion

        #region Properties

        /// <summary>
        /// Gets the StyleCop Assembly from the install location.
        /// </summary>
        private static Assembly StyleCopAssembly
        {
            get
            {
                if (!assemblyLoadAttempted)
                {
                    lock (AssemblySyncRoot)
                    {
                        if (!assemblyLoadAttempted)
                        {
                            try
                            {
                                string styleCopAssemblyPath = StyleCopOptions.Instance.GetAssemblyPath();

                                if (!string.IsNullOrEmpty(styleCopAssemblyPath))
                                {
                                    styleCopAssembly = Assembly.LoadFrom(styleCopAssemblyPath);
                                }

                                assemblyLoadAttempted = true;
                            }
                            catch (Exception exception)
                            {
                                JB::JetBrains.Util.Logger.LogException(exception);
                            }
                        }
                    }
                }

                return styleCopAssembly;
            }
        }

        /// <summary>
        /// Gets the StyleCop.CSharp.Rules Assembly from the install location.
        /// </summary>
        private static Assembly StyleCopCSharpRulesAssembly
        {
            get
            {
                if (!assemblyRulesLoadAttempted)
                {
                    lock (AssemblySyncRoot)
                    {
                        if (!assemblyRulesLoadAttempted)
                        {
                            try
                            {
                                string styleCopAssemblyPath = StyleCopOptions.Instance.GetAssemblyPath();

                                if (!string.IsNullOrEmpty(styleCopAssemblyPath))
                                {
                                    string rulesPath = Path.GetDirectoryName(styleCopAssemblyPath);
                                    styleCopCSharpRulesAssembly = Assembly.LoadFrom(Path.Combine(rulesPath, "StyleCop.CSharp.Rules.dll"));
                                }

                                assemblyRulesLoadAttempted = true;
                            }
                            catch (Exception exception)
                            {
                                JB::JetBrains.Util.Logger.LogException(exception);
                            }
                        }
                    }
                }

                return styleCopCSharpRulesAssembly;
            }
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Checks if StyleCop is available (i.e. the assembly has been found) and loads it if required.
        /// </summary>
        /// <returns>
        /// A boolean to say if StyleCop is available.
        /// </returns>
        public static bool EnsureStyleCopIsLoaded()
        {
            return StyleCopAssembly != null;
        }

        /// <summary>
        /// Checks if the path is a valid StyleCop assembly path.
        /// </summary>
        /// <param name="assemblyPath">
        /// The assembly path.
        /// </param>
        /// <returns>
        /// A boolean to say if this as a valid path to a StyleCop assembly.
        /// </returns>
        public static bool LocationValid(string assemblyPath)
        {
            if (assemblyPath == null)
            {
                return false;
            }

            string filename = Path.GetFileName(assemblyPath);

            if (string.IsNullOrEmpty(filename) || filename.ToUpper() != Constants.StyleCopAssemblyName.ToUpper())
            {
                return false;
            }

            return File.Exists(assemblyPath);
        }

        #endregion

        #region Methods

        /// <summary>
        /// On event handler.
        /// </summary>
        /// <param name="sender">
        /// The sender to the event handler.
        /// </param>
        /// <param name="args">
        /// The ResolveEventArgs for this event.
        /// </param>
        /// <returns>
        /// The assembly required.
        /// </returns>
        private static Assembly OnEventHandler(object sender, ResolveEventArgs args)
        {
            string styleCopAssemblyPath = StyleCopOptions.Instance.GetAssemblyPath();
            string assemblyName = Path.GetFileNameWithoutExtension(styleCopAssemblyPath) + ",";

            if (args.Name.StartsWith(assemblyName))
            {
                return StyleCopAssembly;
            }

            if (args.Name.StartsWith("StyleCop.CSharp.Rules,"))
            {
                return StyleCopCSharpRulesAssembly;
            }

            return null;
        }

        #endregion
    }
}