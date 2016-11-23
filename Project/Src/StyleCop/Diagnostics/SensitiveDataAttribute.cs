// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SensitiveDataAttribute.cs" company="https://github.com/StyleCop">
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
//   Marks an item as either containing or handing sensitive data which should be obscured
//   in trace output.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop.Diagnostics
{
    #region Using Directives

    using System;

    #endregion

    /// <summary>
    /// Marks an item as either containing or handing sensitive data which should be obscured
    /// in trace output.
    /// </summary>
    /// <remarks>
    /// <para>
    /// This attribute may be applied to parameters or return values of methods to indicate that they
    /// contain sensitive data and should be obscured in the trace output. Alternatively entire properties,
    /// methods or constructors may be marked with this attribute and any input or output will be obscured
    /// from the trace. Note that this attribute only has an effect on the <see cref="StyleCopTrace.In"/> 
    /// method which takes a parameter array, and the <see cref="StyleCopTrace.Out{T}"/> methods that take
    /// a parameter array or return value.
    /// </para>
    /// <para>
    /// Note that in <strong>DEBUG</strong> builds when the <see cref="TraceTypes.SensitiveData"/> trace
    /// flag is used, the sensitive data can be printed out without being obscured which is useful for
    /// debugging. This flag is ignored in <strong>RELEASE</strong> builds to ensure that sensitive data
    /// cannot be traced on production systems.
    /// </para>
    /// </remarks>
    /// <example>
    /// This example shows the attributes being applied to a parameter and return value of a method and
    /// then traced using the <see cref="StyleCopTrace"/> class.
    /// <code>
    /// [return: SensitiveData]
    /// public string MyMethod([SensitiveData] string sensitiveVal, string publicVal)
    /// {
    ///     StyleCopTrace.In(sensitiveVal, publicVal)
    ///     // ...
    ///     return StyleCopTrace.Out(otherSensitiveVal);
    /// }
    /// </code>
    /// The trace output from this will be as follows when the data is obscured:
    /// <code>
    /// ... In  : MyNamespace.MyClass.MyMethod("&lt;******&gt;", "PublicValueText")
    /// ... Out : MyNamespace.MyClass.MyMethod()="&lt;******&gt;"
    /// </code>
    /// </example>
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.ReturnValue | AttributeTargets.Property | AttributeTargets.Method | AttributeTargets.Constructor)]
    public sealed class SensitiveDataAttribute : Attribute
    {
    }
}