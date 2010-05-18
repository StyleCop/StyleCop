//--------------------------------------------------------------------------
// <copyright file="MockWindows.cs" company="Microsoft">
//   Copyright (c) Microsoft Corporation.
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
//-----------------------------------------------------------------------
namespace VSPackageUnitTest.Mocks
{
    internal class MockWindows : EnvDTE.Windows
    {
        #region Windows Members

        public int Count
        {
            get { return 0; }
        }

        public EnvDTE.Window CreateLinkedWindowFrame(EnvDTE.Window Window1, EnvDTE.Window Window2, EnvDTE.vsLinkedWindowType Link)
        {
            throw new System.NotImplementedException();
        }

        public EnvDTE.Window CreateToolWindow(EnvDTE.AddIn AddInInst, string ProgID, string Caption, string GuidPosition, ref object DocObj)
        {
            throw new System.NotImplementedException();
        }

        public EnvDTE.DTE DTE
        {
            get { throw new System.NotImplementedException(); }
        }

        public System.Collections.IEnumerator GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        public EnvDTE.Window Item(object index)
        {
            throw new System.NotImplementedException();
        }

        public EnvDTE.DTE Parent
        {
            get { throw new System.NotImplementedException(); }
        }

        #endregion
    }
}
