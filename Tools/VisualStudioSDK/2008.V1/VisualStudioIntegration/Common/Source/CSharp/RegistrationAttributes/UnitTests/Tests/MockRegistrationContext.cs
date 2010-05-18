//***************************************************************************
//
//    Copyright (c) Microsoft Corporation. All rights reserved.
//    This code is licensed under the Visual Studio SDK license terms.
//    THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF
//    ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY
//    IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR
//    PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT.
//
//***************************************************************************

using System;
using System.IO;
using Microsoft.VisualStudio.Shell;

namespace Microsoft.VisualStudio.Shell.UnitTests
{
    /// <summary>
    /// Helper code to create RegistrationContext mock
    /// </summary>
    public class MockRegistrationContext : RegistrationAttribute.RegistrationContext, IDisposable
    {
        StreamWriter streamWriter;
        public override string ComponentPath
        {
            get { return "tt"; }

        }
        public override string CodeBase
        {
            get { return "tt"; }

        }
        public override Type ComponentType
        {
            get { return (new Int32()).GetType(); }

        }
        public override string InprocServerPath
        {
            get { return "tt"; }

        }
        public override string RootFolder
        {
            get { throw new NotImplementedException("The method or operation is not implemented."); }
        }
        public override RegistrationMethod RegistrationMethod
        {
            get { return new RegistrationMethod(); }
        }
        public override TextWriter Log
        {

            get { String writer = "C:\\21.txt"; streamWriter = new StreamWriter(writer); return streamWriter; }

        }
        public override RegistrationAttribute.Key CreateKey(string name)
        {
            MockKey key = new MockKey();
            return key;
        }
        public override string EscapePath(string str)
        {
            return "EscapePath";
        }
        public override void RemoveKey(string name)
        {

        }
        public override void RemoveKeyIfEmpty(string name)
        {

        }
        public override void RemoveValue(string keyname, string valuename)
        {

        }

        #region IDisposable Members
        /// <summary>
        /// IDisposable interface implementation to dispose StreamWriter member that it owns
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        /// <summary>
        /// IDisposable pattern Implementation
        /// </summary>
        /// <param name="disposing"></param>
        private void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                    streamWriter = null;
                }
            }
        }
    }

    internal class MockKey : RegistrationAttribute.Key
    {
        public override RegistrationAttribute.Key CreateSubkey(String value) { return null; }
        public override void SetValue(String value, Object objectValue) { ; }
        public override void Close() { ; }
    }
}
