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
using System.Collections.Generic;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.VsSDK.UnitTestLibrary;
using Microsoft.VisualStudio.Shell;
using System.Collections;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.VsSDK.UnitTestLibrary
{
    
    public class RegistrationKeyMock : RegistrationAttribute.Key
    {
        private Hashtable _table = new Hashtable();

        /// <summary>
        /// Constructor
        /// </summary>
        public RegistrationKeyMock()
        {

        }

        /// <summary>
        /// Collection of keys that are added.
        /// </summary>
        public Hashtable Keys
        {
            get
            {
                return _table;
            }
        }

        /// <summary>
        /// Close the key
        /// </summary>
        public override void Close()
        {
            return;
        }

        /// <summary>
        /// Create a sub key under the key with name
        /// </summary>
        /// <param name="name">name of the sub key</param>
        /// <returns>Key instance</returns>
        [SuppressMessage("Microsoft.Globalization", "CA1303:DoNotPassLiteralsAsLocalizedParameters")]
        public override RegistrationAttribute.Key CreateSubkey(string name)
        {
            throw new NotImplementedException("The method or operation is not implemented.");
        }

        /// <summary>
        /// Set the reg key value
        /// </summary>
        /// <param name="valueName">name of the value</param>
        /// <param name="value">value</param>
        [SuppressMessage("Microsoft.Performance", "CA1807:AvoidUnnecessaryStringCreation")]
        [SuppressMessage("Microsoft.Design", "CA1062:ValidateArgumentsOfPublicMethods")]
        public override void SetValue(string valueName, object value)
        {
            string val = value.ToString().ToUpperInvariant();
            string name = valueName.ToUpperInvariant();
            if (!_table.Contains(name))
                _table.Add(name, val);
            else
                _table[name] = val;
        }

        internal void RemoveValue(string valueName)
        {
            string name = valueName.ToUpperInvariant();
            if (_table.Contains(name))
                _table.Remove(name);
        }

        internal bool IsEmpty()
        {
            return _table.Count == 0;
        }
    }
}
