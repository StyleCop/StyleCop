/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudio.Tools {

    internal class WixRegHive : Hive {
        internal const int WixTabSize = 2;

        private class WixRegKey : RegistrationKeyBase {
            private bool isUserKey;

            public WixRegKey(string keyPath, bool isUserKey) : base(keyPath) {
                this.isUserKey = isUserKey;
            }

            protected override RegistrationKeyBase CreateKey(string keyPath) {
                return new WixRegKey(keyPath, isUserKey);
            }

            public override string CreateRegistrationScript(int marginSize) {
                StringBuilder builder = new StringBuilder();
                string root = isUserKey ? "HKCU" : "HKLM";

                // Create the reg key for this element. Note that if this key has no default value
                // and not values set inside it we want to create an entry for it only if it has
                // no sub keys, otherwise the creation of the sub keys will create also this one.
                if (ShouldCreateRegistryEntry) {
                    builder.AppendLine("");
                    // Set the margin.
                    builder.Append(' ', marginSize);
                    // Add the constant part of the registry key creation.
                    builder.Append("<Registry Root=\"");
                    builder.Append(root);
                    builder.Append("\" Key=\"");
                    // Add the path of the key.
                    builder.Append(Path);
                    // Close the double quotes for the path.
                    builder.Append("\"");

                    // If there is a default value we have to set it here.
                    if (null != DefaultValue) {
                        builder.Append(" Value=\"");
                        builder.Append(DefaultValue.ToString());
                        // Close the double quotes and add the type that can only be string.
                        builder.Append("\" Type=\"string\"");
                    }

                    // Done with the definition of this XML tag and its attributes; now we have to
                    // figure out if any sub-tag is needed for the values or if this tag can be closed
                    if (0 == Values.Count) {
                        // If there is no value to add, then the tag can be closed.
                        builder.AppendLine(" />");
                    } else {
                        // Add the nested tags for the values.
                        builder.AppendLine(">");
                        foreach (string label in Values.Keys) {
                            builder.Append(' ', marginSize + WixRegHive.WixTabSize);
                            builder.Append("<Registry Name=\"");
                            builder.Append(label);
                            builder.Append("\" ");
                            // Find the type of the value.
                            object value = Values[label];
                            if (null == value) {
                                builder.AppendLine("/>");
                                continue;
                            }
                            // The packages are supposed to be registered only on the 32 bit registry,
                            // so the integer type is 32 bit.
                            if ((value is Int16) || (value is UInt16) ||
                                (value is Int32) || (value is UInt32)) {
                                UInt32 intValue = Convert.ToUInt32(value, System.Globalization.CultureInfo.InvariantCulture);
                                builder.Append("Value=\"");
                                builder.Append(intValue.ToString(System.Globalization.CultureInfo.InvariantCulture));
                                builder.AppendLine("\" Type=\"integer\" />");
                                continue;
                            }
                            
                            // Now we assume that anything else is a string.
                            string stringValue = Values[label].ToString();
                            if (string.IsNullOrEmpty(stringValue)) {
                                builder.AppendLine("/>");
                            } else {
                                builder.Append("Value=\"");
                                builder.Append(stringValue);
                                builder.AppendLine("\" Type=\"string\" />");
                            }
                        }
                        // Close the parent tag.
                        builder.Append(' ', marginSize);
                        builder.AppendLine("</Registry>");
                    }
                }

                // Add the registration scripts for the sub-keys.
                foreach (RegistrationKeyBase key in SubKeys.Values) {
                    builder.Append(key.CreateRegistrationScript(marginSize));
                }

                return builder.ToString();
            }

            private bool ShouldCreateRegistryEntry {
                get {
                    // This is the function that contains the logic to find out if this key should
                    // create an entry inside the registration script.

                    // If there is a default value, then we should create the registration entry.
                    if (null != DefaultValue) {
                        return true;
                    }

                    // The same is true if there is at least one label to set.
                    if (Values.Count > 0) {
                        return true;
                    }

                    // If there are no sub key then we should create this entry.
                    if (SubKeys.Count == 0) {
                        return true;
                    }

                    // Otherwise do not create an entry for this key: the creation of the sub-keys
                    // will force the creation of this one.
                    return false;
                }
            }
        }

        private WixRegKey registryRoot;
        private string fileName;
        public WixRegHive(RegistryRoot registryRoot, string fileName) {
            if (null == registryRoot) {
                throw new ArgumentNullException("registryRoot");
            }
            if (string.IsNullOrEmpty(fileName)) {
                throw new ArgumentNullException("fileName");
            }
            this.registryRoot = new WixRegKey(registryRoot.RegistryRootPath, registryRoot.IsRANU);
            this.fileName = System.IO.Path.GetFileName(fileName);
        }

        public override string GetCodeBase(Type componentType) {
            return string.Format(CultureInfo.InvariantCulture, "[#File_{0}]", fileName);
        }

        public override string GetComponentPath(Type componentType) {
            return "[$ComponentPath]";
        }

        public override string GetInprocServerPath(Type componentType) {
            return "[SystemFolder]mscoree.dll";
        }

        public override string Root {
            get { return registryRoot.Path; }
        }

        public override string RootFolder {
            get { return "[RootFolder]"; }
        }

        public override RegistrationAttribute.Key CreateKey(string name) {
            return registryRoot.CreateSubkey(name);
        }

        // Functions used to unregister a component. We do not do anything in this case.
        public override void RemoveKey(string name) { }
        public override void RemoveKeyIfEmpty(string name) { }
        public override void RemoveValue(string name, string valuename) { }

        public override string ToString() {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("<Include>");
            builder.Append(registryRoot.CreateRegistrationScript(WixTabSize));
            builder.AppendLine("</Include>");

            return builder.ToString();
        }
    }
}
