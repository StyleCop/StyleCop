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

    using System.Collections.Generic;

    using StyleCop;

    using StyleCop.ReSharper.Diagnostics;

    #endregion

    public static class StyleCopCoreFactory
    {
        public static StyleCopCore Create()
        {
            StyleCopTrace.In();

            var projectSettingsFactory = new ProjectSettingsFactory();
            var sourceCodeFactory = new SourceCodeFactory();

            var environment = new ObjectBasedEnvironment(sourceCodeFactory.Create, projectSettingsFactory.Create);

            var styleCop = new StyleCopObjectConsole(environment, null, null, true);

            projectSettingsFactory.StyleCopCore = styleCop.Core;

            return StyleCopTrace.Out(styleCop.Core);
        }
    }
}