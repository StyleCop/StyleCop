/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Text;
using System.IO;

namespace Microsoft.VisualStudio.Shell
{
    /// <summary>
    /// Used to indicate that a custom XML designer should not allow SxS editing
    /// with the standard text-based XML editor.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = true)]
    public sealed class ProvideXmlEditorChooserBlockSxSWithXmlEditorAttribute : RegistrationAttribute
    {
        const string XmlChooserFactory = "XmlChooserFactory";

        private string name;
        private Guid editorFactory;

        /// <summary>
        /// Constructor for ProvideXmlEditorChooserBlockSxSWithXmlEditorAttribute.
        /// </summary>
        /// <param name="name">The registry key name for your XML editor. For example "RESX", "Silverlight", "Workflow", etc...</param>
        /// <param name="editorFactory">A Type, Guid, or String object representing the editor factory.</param>
        public ProvideXmlEditorChooserBlockSxSWithXmlEditorAttribute(string name, object editorFactory)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("Editor description cannot be null or empty.", "editorDescription");
            }

            this.name = name;
            this.editorFactory = TryGetGuidFromObject(editorFactory);
        }

        public override void Register(RegistrationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            using (Key key = context.CreateKey(GetKeyName()))
            {
                key.SetValue("XmlEditorBlockSxS", editorFactory.ToString("B").ToUpperInvariant());
            }
        }

        private Guid TryGetGuidFromObject(object guidObject)
        {
            // figure out what type of object they passed in and get the GUID from it
            if (guidObject is string)
                return new Guid((string)guidObject);
            else if (guidObject is Type)
                return ((Type)guidObject).GUID;
            else if (guidObject is Guid)
                return (Guid)guidObject;
            else
                throw new ArgumentException("Could not determine Guid from supplied object.", "guidObject");
        }

        public override void Unregister(RegistrationContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            context.RemoveKey(GetKeyName());
        }

        private string GetKeyName()
        {
            return Path.Combine(XmlChooserFactory, name);
        }
    }
}
