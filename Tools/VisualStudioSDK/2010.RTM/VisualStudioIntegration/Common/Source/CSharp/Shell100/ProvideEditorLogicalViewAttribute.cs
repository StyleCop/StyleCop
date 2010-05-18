//------------------------------------------------------------------------------
// <copyright from='2003' to='2004' company='Microsoft Corporation'>           
//  Copyright (c) Microsoft Corporation, All rights reserved.             
//  This code sample is provided "AS IS" without warranty of any kind, 
//  it is not recommended for use in a production environment.
// </copyright>                                                                
//------------------------------------------------------------------------------

using System;
using System.Globalization;

namespace Microsoft.VisualStudio.Shell
{
    /// <summary>
    /// This attribute adds a logical view to the editor created by an editor factory.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class ProvideEditorLogicalViewAttribute : RegistrationAttribute
    {
        private Guid factory;
        private Guid logicalView;
        private bool isTrusted;

        /// <summary>
        /// Creates a new RegisterEditorLogicalView attribute to register a logical
        /// view provided by your editor.
        /// </summary>
        /// <param name="factoryType">The type of factory; can be a Type, a GUID or a string representation of a GUID</param>
        /// <param name="logicalViewGuid">The guid of the logical view to register.</param>
        public ProvideEditorLogicalViewAttribute(object factoryType, string logicalViewGuid)
        {
            this.isTrusted = true;
            this.logicalView = new Guid(logicalViewGuid);
			
            // figure out what type of object they passed in and get the GUID from it
            if (factoryType is string)
                this.factory = new Guid((string)factoryType);
            else if (factoryType is Type)
                this.factory = ((Type)factoryType).GUID;
            else if (factoryType is Guid)
                this.factory = (Guid)factoryType;
            else
                throw new ArgumentException(string.Format(Resources.Culture, Resources.Attributes_InvalidFactoryType, factoryType));

        }

        /// <summary>
        /// Get the Guid representing the type of the editor factory
        /// </summary>
        public Guid FactoryType
        {
            get {return factory;}
        }

        /// <summary>
        /// Get the Guid representing the logical view
        /// </summary>
        public Guid LogicalView
        {
            get {return logicalView;}
        }

        /// <summary>
        /// Get or set the trust flag for this logical view. If a view is not trusted, it can not be opened
        /// from a wizard or automation code.
        /// </summary>
        public bool IsTrusted
        {
            get { return isTrusted; }
            set { isTrusted = value; }
        }

        private string EditorPath
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Editors\\{0}", factory.ToString("B")); }
        }

        private string LogicalViewPath
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0}\\LogicalViews", EditorPath); }
        }

        private string UntrustedViewsPath
        {
            get { return string.Format(CultureInfo.InvariantCulture, "{0}\\UntrustedLogicalViews", EditorPath); }
        }

        /// <summary>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     It also contains other information such as the type being registered and path information.
        /// </summary>
        public override void Register(RegistrationContext context)
        {
            context.Log.WriteLine(string.Format(Resources.Culture, Resources.Reg_NotifyEditorView, logicalView.ToString("B")));

            using (Key childKey = context.CreateKey( LogicalViewPath ))
            {
                childKey.SetValue(logicalView.ToString("B"), "");
            }

            // Check if this view can be trusted for automation code.
            if (!IsTrusted)
            {
                // This logical view is not trusted, so we have to add it to the list of the untrusted ones.
                using (Key untrustedViewsKey = context.CreateKey(UntrustedViewsPath))
                {
                    untrustedViewsKey.SetValue(logicalView.ToString("B"), "");
                }

                // Now we should to check the trust level of the editor: if it has an untrusted view its tust
                // level can not be full trust. The problem is that the Key object provided by the context has
                // no GetValue method, so we can not do any check on the previous value of the trust level and
                // all we can do is overwrite it with ETL_HasUntrustedLogicalViews.
                using (Key editorKey = context.CreateKey(EditorPath))
                {
                    editorKey.SetValue("EditorTrustLevel", (int)Microsoft.VisualStudio.Shell.Interop.__VSEDITORTRUSTLEVEL.ETL_HasUntrustedLogicalViews);
                }
            }
        }

        /// <summary>
        /// Unregister this logical view.
        /// </summary>
        /// <param name="context"></param>
        public override void Unregister(RegistrationContext context)
        {
            context.RemoveValue(LogicalViewPath, logicalView.ToString("B"));
        }
    }
}
