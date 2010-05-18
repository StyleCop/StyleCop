/***************************************************************************

Copyright (c) Microsoft Corporation. All rights reserved.
This code is licensed under the Visual Studio SDK license terms.
THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.

***************************************************************************/

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VsSDK.UnitTestLibrary;
using Microsoft.VisualStudio.Shell;
using System.Collections;
using System.Reflection;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.VsSDK.UnitTestLibrary
{
    
    public class BaseRegistrationContextMock : RegistrationAttribute.RegistrationContext
    {

        private Hashtable _keys = new Hashtable();
        
        /// <summary>
        /// Constructor
        /// </summary>
        public BaseRegistrationContextMock()
        {

        }

        /// <summary>
        /// THe hash table containing all the values that are being added.
        /// </summary>
        public Hashtable RegistryEntries
        {
            get
            {
                return _keys;
            }
        }

        /// <summary>
        /// Returns the code base to be used for the context
        /// </summary>
        public override string CodeBase
        {
            get { return Assembly.GetExecutingAssembly().EscapedCodeBase; }
        }

        /// <summary>
        /// Returns the component path
        /// </summary>
         public override string ComponentPath
        {
            get { return Path.GetDirectoryName(Assembly.GetCallingAssembly().EscapedCodeBase); }
        }

        /// <summary>
        /// Returns the component type
        /// </summary>
        public override Type ComponentType
        {
            get { return this.GetType(); }
        }

        /// <summary>
        /// Returns the root folder of the target host
        /// </summary>
        public override string RootFolder
        {
            [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        /// <summary>
        /// Creates the key
        /// </summary>
        /// <param name="name">name of the key</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Performance", "CA1807:AvoidUnnecessaryStringCreation")]
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public override RegistrationAttribute.Key CreateKey(string name)
        {
            string keyName = name.ToUpperInvariant();
            if (!_keys.Contains(name))
            {
                RegistrationKeyMock key = new RegistrationKeyMock();
                _keys.Add(keyName, key);
            }
            return (RegistrationAttribute.Key)_keys[keyName];
        }

        /// <summary>
        /// Sets the escape path
        /// </summary>
        /// <param name="str">escape string</param>
        /// <returns>output after applying the escape string</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public override string EscapePath(string str)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        /// <summary>
        /// Inprocserver path
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public override string InprocServerPath
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }

        /// <summary>
        /// Logger if looging is needed.
        /// </summary>
        public override TextWriter Log
        {
            get 
            { 
                return new TextWriterMock(null); 
            }
        }

        /// <summary>
        /// Registration method to use
        /// </summary>
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public override RegistrationMethod RegistrationMethod
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }


        [SuppressMessage("Microsoft.Performance", "CA1807:AvoidUnnecessaryStringCreation")]
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public override void RemoveKey(string name)
        {
            foreach (string keyName in _keys.Keys.Cast<string>().ToArray()) //Copy to an array since we'll be modifying the underlying Hashtable holding the keys.
            {
                if (keyName.StartsWith(name.ToUpperInvariant()))
                    _keys.Remove(keyName);
            }
            return;
        }

        public override void RemoveKeyIfEmpty(string name)
        {
            string upperKeyName = name.ToUpperInvariant();
            if (((RegistrationKeyMock)_keys[upperKeyName]).IsEmpty())
            {
                RemoveKey(upperKeyName);
            }
        }

        public override void RemoveValue(string keyname, string valuename)
        {
            string upperKeyName = keyname.ToUpperInvariant();
            ((RegistrationKeyMock)_keys[upperKeyName]).RemoveValue(valuename);
        }
    }
}
