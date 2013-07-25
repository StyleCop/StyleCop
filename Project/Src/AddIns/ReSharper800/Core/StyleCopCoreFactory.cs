// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopCoreFactory.cs" company="http://stylecop.codeplex.com">
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
// <summary>
//   The style cop core factory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.ReSharper800.Core
{
    #region Using Directives

    using StyleCop.Diagnostics;

    #endregion

    /// <summary>
    /// The style cop core factory.
    /// </summary>
    public static class StyleCopCoreFactory
    {
        #region Public Methods and Operators

        /// <summary>
        /// The create.
        /// </summary>
        /// <returns>
        /// A new StyleCopCore object.
        /// </returns>
        public static StyleCopCore Create()
        {
            StyleCopTrace.In();

            ProjectSettingsFactory projectSettingsFactory = new ProjectSettingsFactory();
            SourceCodeFactory sourceCodeFactory = new SourceCodeFactory();

            ObjectBasedEnvironment environment = new ObjectBasedEnvironment(sourceCodeFactory.Create, projectSettingsFactory.Create);

            StyleCopObjectConsole styleCop = new StyleCopObjectConsole(environment, null, null, true);

            projectSettingsFactory.StyleCopCore = styleCop.Core;

            return StyleCopTrace.Out(styleCop.Core);
        }

        #endregion
    }
}