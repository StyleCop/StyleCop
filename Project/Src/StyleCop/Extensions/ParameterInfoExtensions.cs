// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ParameterInfoExtensions.cs" company="https://github.com/StyleCop">
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
//   Extension methods for the  type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace System.Reflection
{
    #region Using Directives

    using System.Linq;

    #endregion

    /// <summary>
    /// Extension methods for the <see cref="ParameterInfo"/> type.
    /// </summary>
    public static class ParameterInfoExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Determines whether a <see cref="ParameterInfo"/> has a particular <see cref="ParameterInfo"/> of custom <see cref="Attribute"/> defined.
        /// </summary>
        /// <param name="parameterInfo">
        /// The <see cref="ParameterInfo"/> to check.
        /// </param>
        /// <param name="attributeType">
        /// The <see cref="ParameterInfo"/> of custom <see cref="Attribute"/>.
        /// </param>
        /// <param name="inherit">
        /// Whether to search the <see cref="ParameterInfo"/>'s inheritance chain to find the attributes.
        /// </param>
        /// <returns>
        /// <c>true</c>if the <see cref="ParameterInfo"/> has any of the specified custom attributes; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="parameterInfo"/> or <paramref name="attributeType"/> is <c>null</c>.
        /// </exception>
        public static bool HasCustomAttribute(this ParameterInfo parameterInfo, Type attributeType, bool inherit)
        {
            return parameterInfo.GetCustomAttributes(attributeType, inherit).Any();
        }

        /// <summary>
        /// Determines whether a <see cref="ParameterInfo"/> is by-reference or output.
        /// </summary>
        /// <param name="parameterInfo">
        /// The parameter information.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="parameterInfo"/> is by-reference or output; otherwise <c>false</c>.
        /// </returns>
        public static bool IsByRefOrOut(this ParameterInfo parameterInfo)
        {
            return parameterInfo.IsOut || parameterInfo.ParameterType.IsByRef;
        }

        /// <summary>
        /// Determines whether a <see cref="ParameterInfo"/> is by-reference, output or a return value.
        /// </summary>
        /// <param name="parameterInfo">
        /// The parameter information.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="parameterInfo"/> is by-reference, output or a return value; otherwise <c>false</c>.
        /// </returns>
        public static bool IsByRefOutOrReturnValue(this ParameterInfo parameterInfo)
        {
            return parameterInfo.IsByRefOrOut() || parameterInfo.IsReturnValue();
        }

        /// <summary>
        /// Determines whether a <see cref="ParameterInfo"/> is input or by-reference.
        /// </summary>
        /// <param name="parameterInfo">
        /// The parameter information.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="parameterInfo"/> is input or by-reference; otherwise <c>false</c>.
        /// </returns>
        public static bool IsInOrByRef(this ParameterInfo parameterInfo)
        {
            return !parameterInfo.IsOut && !parameterInfo.IsReturnValue();
        }

        /// <summary>
        /// Determines whether a <see cref="ParameterInfo"/> is a return value.
        /// </summary>
        /// <param name="parameterInfo">
        /// The parameter information.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="parameterInfo"/> is a return value; otherwise <c>false</c>.
        /// </returns>
        /// <remarks>
        /// Although the <see cref="ParameterInfo"/> type has an <see cref="ParameterInfo.IsRetval"/> property which should serve 
        /// this purpose, it appears to return <c>false</c> in some cases even when the parameter is a return value (the MSDN 
        /// documentation for this value indicates that it is a flag inserted by compilers, however they are not obliged to do so). 
        /// We can check more reliably whether it is a return value by checking whether the <see cref="ParameterInfo.Position"/> 
        /// is -1 (although this doesn't appear to be documented anywhere).
        /// </remarks>
        public static bool IsReturnValue(this ParameterInfo parameterInfo)
        {
            return parameterInfo.Position == -1;
        }

        #endregion
    }
}