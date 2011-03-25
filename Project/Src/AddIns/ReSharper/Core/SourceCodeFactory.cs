//-----------------------------------------------------------------------
// <copyright file="">
//   MS-PL
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

namespace StyleCop.ReSharper.Core
{
    #region Using Directives

    using StyleCop;

    using StyleCop.ReSharper.Diagnostics;

    #endregion

    public class SourceCodeFactory
    {
        public SourceCode Create(string path, CodeProject project, SourceParser parser, object context)
        {
            StyleCopTrace.In();

            var source = (string)context;
            
            StyleCopTrace.Out();

            return new StringBasedSourceCode(project, parser, path, source);
        }
    }
}