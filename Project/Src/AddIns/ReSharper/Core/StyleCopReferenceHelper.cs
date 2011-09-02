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

namespace StyleCop.ReSharper.Core
{
    #region Using Directives

    using System;
    using System.IO;
    using System.Reflection;

    using StyleCop.Diagnostics;
    using StyleCop.ReSharper.Options;

    #endregion

    /// <summary>
    /// Helper class to allow the StyleCop assembly references 
    /// to be resolved to the StyleCop installation directory. 
    /// This means that the plugin does not need local copies 
    /// of the StyleCop assemblies.
    /// </summary>
    public class StyleCopReferenceHelper
    {
        #region Constants and Fields

        /// <summary>
        /// The name of the StyleCop assembly which should be loaded.
        /// </summary>
        public const string StyleCopAssemblyName = "StyleCop.dll";

        /// <summary>
        /// SyncRoot object to lock access to the assembly.
        /// </summary>
        private static readonly object assemblySyncRoot = new object();

        /// <summary>
        /// SyncRoot object to lock access to the reference.
        /// </summary>
        private static readonly object referenceSyncRoot = new object();

        /// <summary>
        /// Flag to indicate if the system has already attempted to load the StyleCop assembly.
        /// </summary>
        private static bool assemblyLoadAttempted;

        /// <summary>
        /// Flag to show whehter the references were added.
        /// </summary>
        private static bool referencesAdded;

        /// <summary>
        /// The located StyleCop assembly.
        /// </summary>
        private static Assembly styleCopAssembly;

        #endregion

        #region Constructors and Destructors

        /// <summary>
        /// Initializes static members of the StyleCopReferenceHelper class. 
        /// </summary>
        static StyleCopReferenceHelper()
        {
            assemblyLoadAttempted = false;
            referencesAdded = false;
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
                    lock (assemblySyncRoot)
                    {
                        if (!assemblyLoadAttempted)
                        {
                            try
                            {
                                var styleCopAssemblyPath = StyleCopOptions.Instance.GetAssemblyPath();

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

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets a StyleCopCore instance.
        /// </summary>
        /// <returns>
        /// A new StyleCopCore insance.
        /// </returns>
        public static StyleCopCore GetStyleCopCore()
        {
            AddStyleCopReferencesIfNeeded();

            return new StyleCopCore();
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

            var filename = Path.GetFileName(assemblyPath);

            if (string.IsNullOrEmpty(filename) || filename.ToUpper() != StyleCopAssemblyName.ToUpper())
            {
                return false;
            }

            return File.Exists(assemblyPath);
        }

        /// <summary>
        /// Checks if StyleCop is available (i.e. the assembly has been found).
        /// </summary>
        /// <returns>
        /// A boolean to say if StyleCop is available.
        /// </returns>
        public static bool StyleCopIsAvailable()
        {
            StyleCopTrace.In();

            if (StyleCopAssembly != null)
            {
                return StyleCopTrace.Out(true);
            }

            AddStyleCopReferencesIfNeeded();

            return StyleCopTrace.Out(StyleCopAssembly != null);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Adds the style cop references by hooking into the assembly 
        /// resolution event.
        /// </summary>
        private static void AddStyleCopReferencesIfNeeded()
        {
            StyleCopTrace.In();

            if (!referencesAdded)
            {
                lock (referenceSyncRoot)
                {
                    if (!referencesAdded)
                    {
                        HookAssemblyResolveEvent();
                        referencesAdded = true;
                    }
                }
            }

            StyleCopTrace.Out();
        }

        /// <summary>
        /// Hooks the assembly resolve event to add the StyleCop references.
        /// </summary>
        private static void HookAssemblyResolveEvent()
        {
            StyleCopTrace.In();
            AppDomain.CurrentDomain.AssemblyResolve += OnEventHandler;
            StyleCopTrace.Out();
        }

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
            StyleCopTrace.In();
            var styleCopAssemblyPath = StyleCopOptions.Instance.GetAssemblyPath();
            var assemblyName = Path.GetFileNameWithoutExtension(styleCopAssemblyPath) + ",";

            if (args.Name.StartsWith(assemblyName))
            {
                return StyleCopTrace.Out(StyleCopAssembly);
            }

            StyleCopTrace.Out();
            return null;
        }

        #endregion
    }
}