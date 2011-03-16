//-----------------------------------------------------------------------
// <copyright file="MockDTEGlobals.cs">
//   MS-PL
// </copyright>
// <license>
//   This source code is subject to terms and conditions of the Microsoft 
//   Public License. A copy of the license can be found in the License.html 
//   file at the root of this distribution. 
//   By using this source code in any fashion, you are agreeing to be bound 
//   by the terms of the Microsoft Public License. You must not remove this 
//   notice, or any other, from this software.
// </license>
//-----------------------------------------------------------------------
namespace VSPackageUnitTest.Mocks
{
    using System;
    using System.Collections.Generic;

    internal class MockDTEGlobals : EnvDTE.Globals
    {
        Dictionary<string, object> _variables = new Dictionary<string, object>();
        readonly List<string> _persisted = new List<string>();

        public void ClearNonPersistedVariables()
        {
            Dictionary<string, object> result = new Dictionary<string, object>();

            foreach (string key in _variables.Keys)
            {
                if (_persisted.Contains(key))
                {
                    result.Add(key, _variables[key]);
                }
            }

            _variables = result;
        }

        public void ClearAll()
        {
            _variables.Clear();
            _persisted.Clear();
        }

        #region Globals Members

        public EnvDTE.DTE DTE
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object Parent
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public object VariableNames
        {
            get { throw new Exception("The method or operation is not implemented."); }
        }

        public bool get_VariableExists(string Name)
        {
            return _variables.ContainsKey(Name);
        }

        public bool get_VariablePersists(string VariableName)
        {
            return _persisted.Contains(VariableName);
        }

        public void set_VariablePersists(string VariableName, bool pVal)
        {
            if (pVal)
            {
                if (!_persisted.Contains(VariableName))
                {
                    _persisted.Add(VariableName);
                }
            }
            else
            {
                _persisted.Remove(VariableName);
            }
        }

        public object this[string VariableName]
        {
            get
            {
                return _variables[VariableName];
            }
            set
            {
                _variables[VariableName] = value;
            }
        }

        #endregion
    }
}
