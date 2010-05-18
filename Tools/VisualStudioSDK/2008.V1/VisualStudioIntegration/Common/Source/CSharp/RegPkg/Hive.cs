/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/
using System;
using System.Collections;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Text;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudio.Tools {

    public abstract class Hive {

        public abstract string RootFolder { get; }
        public abstract string Root { get; }
        public abstract RegistrationAttribute.Key CreateKey(string name);

        public abstract void RemoveKey(string name);
        public abstract void RemoveKeyIfEmpty(string name);
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "1#valuename")]
        public abstract void RemoveValue(string name, string valuename);

        protected static string EscapePath(string path) {
            return path;
        }

        public virtual string GetComponentPath(Type componentType) {
            if (componentType != null) {
                string path = componentType.Assembly.EscapedCodeBase;
                path = new Uri(path).LocalPath;
                path = Path.GetDirectoryName(path);
                return path;
            }
            return null;
        }

        public virtual string GetCodeBase(Type componentType) {
            if (componentType != null) {
               string codeBase = componentType.Assembly.EscapedCodeBase;
               codeBase = new Uri(codeBase).LocalPath;
               return codeBase;
            }
            return null;
        }

        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")]
        [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Inproc")]
        [System.Security.Permissions.SecurityPermission(System.Security.Permissions.SecurityAction.Demand)]
        public virtual string GetInprocServerPath(Type componentType) {

            if (componentType != null) {
                string module = "mscoree.dll";
                string path = module;

                try {
                    ProcessModuleCollection modules = Process.GetCurrentProcess().Modules;
                    foreach (ProcessModule m in ((IEnumerable)modules)) {
                        if (string.Compare(m.ModuleName, module, StringComparison.OrdinalIgnoreCase) == 0) {
                            path = m.FileName;
                            break;
                        }
                    }
                }
                catch (Exception) {
                }

                return path;
            }

            return null;
        }
    }

}
