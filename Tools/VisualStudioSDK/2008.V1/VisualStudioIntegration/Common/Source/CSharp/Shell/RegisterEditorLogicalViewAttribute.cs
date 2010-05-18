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
    [Obsolete("RegisterEditorLogicalViewAttribute has been deprecated. Please use ProvideEditorLogicalViewAttribute instead.")]
	[AttributeUsage(AttributeTargets.Class, AllowMultiple=true, Inherited=true)]
    public sealed class RegisterEditorLogicalViewAttribute : RegistrationAttribute
    {
        private Guid factory;
        private Guid logicalView;

        /// <summary>
        /// Creates a new RegisterEditorLogicalView attribute to register a logical
        /// view provided by your editor.
        /// </summary>
        /// <param name="factoryType">The type of factory; can be a Type, a GUID or a string representation of a GUID</param>
        /// <param name="logicalViewGuid">The guid of the logical view to register.</param>
        public RegisterEditorLogicalViewAttribute(object factoryType, string logicalViewGuid)
        {
            this.logicalView = new Guid(logicalViewGuid);
			
            // figure out what type of object they passed in and get the GUID from it
            if (factoryType is string)
                this.factory = new Guid((string)factoryType);
            else if (factoryType is Type)
                this.factory = ((Type)factoryType).GUID;
            else if (factoryType is Guid)
                this.factory = (Guid)factoryType;
            else
                throw new ArgumentException(SR.GetString(SR.Attributes_InvalidFactoryType, factoryType));

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

        private string LogicalViewPath
        {
            get { return string.Format(CultureInfo.InvariantCulture, "Editors\\{0}\\LogicalViews", factory.ToString("B")); }
        }


        /// <summary>
        ///     Called to register this attribute with the given context.  The context
        ///     contains the location where the registration inforomation should be placed.
        ///     It also contains other information such as the type being registered and path information.
        /// </summary>
        public override void Register(RegistrationContext context)
        {
            context.Log.WriteLine(SR.GetString(SR.Reg_NotifyEditorView, logicalView.ToString("B")));

            using (Key childKey = context.CreateKey( LogicalViewPath ))
            {
                childKey.SetValue(logicalView.ToString("B"), "");
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
