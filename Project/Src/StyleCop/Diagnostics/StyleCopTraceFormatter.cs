// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StyleCopTraceFormatter.cs" company="http://stylecop.codeplex.com">
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
//   Style cop trace.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace StyleCop.Diagnostics
{
    #region Using Directives

    using System;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Security.Principal;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    #endregion

    /// <summary>
    /// Style cop trace.
    /// </summary>
    /// <content>StyleCopTrace.</content>
    public partial class StyleCopTrace
    {
        /// <summary>
        /// A trace formatter class to perform the work of creating trace output strings on behalf of the <see cref="StyleCopTrace"/> class.
        /// </summary>
        [DebuggerStepThrough]
        private sealed class StyleCopTraceFormatter
        {
            #region Constants and Fields

            /// <summary>
            /// A regular expression to extract the names of members used with a <see cref="DebuggerDisplayAttribute"/> format string.
            /// </summary>
            private static readonly Regex DebuggerDisplayFormatRegex = new Regex(@"\{[^\{]+\}", RegexOptions.Compiled | RegexOptions.Singleline | RegexOptions.ExplicitCapture);

            /// <summary>
            /// Caches the calling method.
            /// </summary>
            private readonly MethodBase callingMethod;

            /// <summary>
            /// Caches whether the calling method is marked as sensitive.
            /// </summary>
            private readonly bool sensitiveMethod;

            /// <summary>
            /// Caches the stack depth of the calling method.
            /// </summary>
            private readonly int stackDepth;

            /// <summary>
            /// The buffer in which trace output is constructed.
            /// </summary>
            private StringBuilder buffer;

            #endregion

            #region Constructors and Destructors

            /// <summary>
            /// Initializes a new instance of the <see cref="StyleCopTraceFormatter"/> class, which captures the calling method.
            /// </summary>
            public StyleCopTraceFormatter()
            {
                this.callingMethod = GetCallingMethod(out this.stackDepth);
                this.sensitiveMethod = this.IsAttributeDefined(typeof(SensitiveDataAttribute));
            }

            #endregion

            #region Public Methods

            /// <summary>
            /// Writes a trace string for method entry.
            /// </summary>
            /// <param name="arguments">
            /// Arguments that were passed into the method, which may be <c>null</c> if the method had no arguments.
            /// </param>
            public void WriteTraceIn(object[] arguments)
            {
                this.InitializeBuffer("In");
                this.buffer.Append('(');

                var parameters = this.callingMethod.GetParameters();
                for (var i = 0; i < parameters.Length; i++)
                {
                    if (i != 0)
                    {
                        this.buffer.Append(", ");
                    }

                    object argument;
                    if (arguments != null && i < arguments.Length)
                    {
                        argument = arguments[i];
                    }
                    else
                    {
                        argument = Missing.Value;
                    }

                    this.AppendParameter(parameters[i], argument);
                }

                this.buffer.Append(')');
                Trace.WriteLine(this.buffer.ToString());
            }

            /// <summary>
            /// Writes a trace string containing a message.
            /// </summary>
            /// <param name="qualifier">
            /// The qualifier indicating the severity of the message, e.g. <c>Info</c> or <c>Warn</c>.
            /// </param>
            /// <param name="message">
            /// The message to write.
            /// </param>
            public void WriteTraceMessage(string qualifier, string message)
            {
                this.InitializeBuffer(qualifier);
                this.buffer.Append(": ");
                this.buffer.Append(message);

                Trace.WriteLine(this.buffer.ToString());
            }

            /// <summary>
            /// Writes a trace string containing a message.
            /// </summary>
            /// <param name="qualifier">
            /// The qualifier indicating the severity of the message, e.g. <c>Info</c> or <c>Warn</c>.
            /// </param>
            /// <param name="format">
            /// The format of the message to write.
            /// </param>
            /// <param name="args">
            /// Arguments to insert into <paramref name="format"/>.
            /// </param>
            public void WriteTraceMessage(string qualifier, string format, object[] args)
            {
                this.InitializeBuffer(qualifier);
                try
                {
                    this.buffer.Append(": ");
                    this.buffer.AppendFormat(format, args);
                }
                catch (ArgumentNullException ex)
                {
                    this.buffer.AppendFormat("** TRACE MESSAGE FORMATTING ERROR: {0} **", ex.Message);
                }
                catch (FormatException ex)
                {
                    this.buffer.AppendFormat("** TRACE MESSAGE FORMATTING ERROR: {0} **", ex.Message);
                }
                catch (ArgumentOutOfRangeException ex)
                {
                    this.buffer.AppendFormat("** TRACE MESSAGE FORMATTING ERROR: {0} **", ex.Message);
                }

                Trace.WriteLine(this.buffer.ToString());
            }

            /// <summary>
            /// Writes a trace string for method exit.
            /// </summary>
            /// <param name="returnValue">
            /// The return value of the method, which may be <c>null</c> if the method has no return type.
            /// </param>
            public void WriteTraceOut(object returnValue)
            {
                this.InitializeBuffer("Out");
                this.buffer.Append("()");

                var methodInfo = this.callingMethod as MethodInfo;
                if (methodInfo != null && methodInfo.ReturnType != null && methodInfo.ReturnType != typeof(void))
                {
                    this.AppendParameter(methodInfo.ReturnParameter, returnValue);
                }

                Trace.WriteLine(this.buffer.ToString());
            }

            #endregion

            #region Methods

            /// <summary>
            /// Gets the method that originally called into the <see cref="StyleCopTrace"/> class.
            /// </summary>
            /// <param name="stackDepth">
            /// When the method returns, contains the stack depth of the calling method.
            /// </param>
            /// <returns>
            /// A <see cref="MethodBase"/> detailing the calling method.
            /// </returns>
            private static MethodBase GetCallingMethod(out int stackDepth)
            {
                var stack = new StackTrace(3); // minimum call depth is 3 as we have this method, the constructor, and the public StyleCopTrace wrapper
                var frames = stack.GetFrames();
                Debug.Assert(frames != null, "Failed to get stack frames");

                var frameIndex = 0;
                MethodBase method = null;
                while (frameIndex < frames.Length)
                {
                    method = frames[frameIndex].GetMethod();
                    if (method.DeclaringType != typeof(StyleCopTrace))
                    {
                        break;
                    }

                    frameIndex++;
                }

                stackDepth = frames.Length - frameIndex - 1;
                return method;
            }

            /// <summary>
            /// Appends a parameter to the buffer.
            /// </summary>
            /// <param name="parameter">
            /// Information about the parameter to append.
            /// </param>
            /// <param name="argument">
            /// The argument that was passed to the parameter.
            /// </param>
            private void AppendParameter(ParameterInfo parameter, object argument)
            {
                var sensitive = this.sensitiveMethod || parameter.IsDefined(typeof(SensitiveDataAttribute), false);

                try
                {
                    if (!parameter.IsReturnValue())
                    {
                        this.buffer.Append(parameter.Name);
                    }

                    this.buffer.Append('=');

                    if (argument == null)
                    {
                        this.buffer.Append("<null>");
                        return;
                    }

#if DEBUG

                    // in debug builds sensitive data may be traced with the appropriate switch; in release builds it may not
                    if (sensitive && !StyleCopTrace.Switch.TraceSensitiveData)
#else
                    if (sensitive) 
#endif
                    {
                        this.buffer.Append("<obscured>");
                        return;
                    }

                    // if the argument is a string then print it with quotes
                    if (argument is string)
                    {
                        this.buffer.Append("\"" + argument + "\"");
                        return;
                    }

                    // if the argument is a type then print it as a typeof
                    if (argument is Type)
                    {
                        this.buffer.Append("typeof(" + ((Type)argument).Name + ")");
                        return;
                    }

                    // if the argument is a primitive (or pseudo-primitive) type then print it 'as is'
                    var argumentType = argument.GetType();
                    if (argumentType.IsPrimitive || argumentType == typeof(decimal))
                    {
                        this.buffer.Append(argument.ToString());
                        return;
                    }

                    // if it has an overridden ToString method print it in curly brackets
                    var stringMethod = argumentType.GetMethod("ToString", BindingFlags.Public | BindingFlags.Instance, null, Type.EmptyTypes, null);
                    if (stringMethod.GetBaseDefinition().DeclaringType != stringMethod.DeclaringType)
                    {
                        this.buffer.Append("{" + argument + "}");
                        return;
                    }

                    // if the argument type has a DebuggerDisplayAttribute then format and print in square brackets
                    var displayAttribute = (DebuggerDisplayAttribute)argumentType.GetCustomAttributes(typeof(DebuggerDisplayAttribute), true).FirstOrDefault();
                    if (displayAttribute != null)
                    {
                        MatchEvaluator evaluator = match =>
                        {
                            var memberName = match.Value.Replace("{", null).Replace("}", null);
                            var propertyInfo = argumentType.GetProperty(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
                            if (propertyInfo != null)
                            {
                                return Convert.ToString(propertyInfo.GetValue(argument, null), CultureInfo.InvariantCulture);
                            }

                            FieldInfo fieldInfo;
                            var typeToInspect = argumentType;
                            do
                            {
                                fieldInfo = typeToInspect.GetField(memberName, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                                typeToInspect = typeToInspect.BaseType;
                            }
                            while (fieldInfo == null && typeToInspect != typeof(object));
                            return fieldInfo != null ? Convert.ToString(fieldInfo.GetValue(argument), CultureInfo.InvariantCulture) : "?";
                        };

                        var displayString = DebuggerDisplayFormatRegex.Replace(displayAttribute.Value, evaluator);
                        this.buffer.Append('[');
                        this.AppendTypeName(argumentType);
                        this.buffer.Append(": ").Append(displayString).Append(']');
                        return;
                    }

                    // did somebody forget to supply the parameter?
                    if (argument == Missing.Value)
                    {
                        this.buffer.Append("<missing>");
                        return;
                    }

                    // catch all - just display the type name
                    this.buffer.Append('[');
                    this.AppendTypeName(argumentType);
                    this.buffer.Append(']');
                }
                catch
                {
                    this.buffer.Append("<error>");
                }
            }

            /// <summary>
            /// Appends a 'prettily' formatted type name to the buffer.
            /// </summary>
            /// <param name="type">
            /// The type to append the name of.
            /// </param>
            private void AppendTypeName(Type type)
            {
                var genericArgs = type.GetGenericArguments();
                if (genericArgs.Length == 0)
                {
                    this.buffer.Append(type.Name);
                }
                else
                {
                    var backtickIndex = type.Name.IndexOf('`');
                    if (backtickIndex == -1)
                    {
                        this.buffer.Append(type.Name);
                    }
                    else
                    {
                        this.buffer.Append(type.Name.Substring(0, backtickIndex));
                    }

                    this.buffer.Append('<');

                    for (var i = 0; i < genericArgs.Length; i++)
                    {
                        if (i != 0)
                        {
                            this.buffer.Append(',');
                        }

                        this.AppendTypeName(genericArgs[i]);
                    }

                    this.buffer.Append('>');
                }
            }

            /// <summary>
            /// Initializes the buffer with a specified qualifier.
            /// </summary>
            /// <param name="qualifier">
            /// The trace qualifier, e.g. <c>In</c> or <c>Err</c>.
            /// </param>
            private void InitializeBuffer(string qualifier)
            {
                this.buffer = new StringBuilder(1024).Append(DateTime.UtcNow.ToString("u", CultureInfo.CurrentCulture)).Append(" : ");

                var privateMemory = StyleCopTrace.GetPrivateBytes();
                this.buffer.Append("PB = " + privateMemory);
                
                this.buffer.AppendFormat(" : {0,-4} :", qualifier);

                if (StyleCopTrace.Switch.TraceThreadId)
                {
                    this.buffer.Append(" [");
                    this.buffer.Append(Thread.CurrentThread.ManagedThreadId);
                    this.buffer.Append(']');
                }

                if (StyleCopTrace.Switch.TraceThreadName)
                {
                    this.buffer.Append(" [");
                    this.buffer.Append(Thread.CurrentThread.Name);
                    this.buffer.Append(']');
                }

                this.buffer.Append(' ');
                for (var i = 0; i < this.stackDepth; i++)
                {
                    this.buffer.Append('-');
                }

                this.buffer.Append(' ');
                this.buffer.Append(this.callingMethod.DeclaringType.FullName);
                this.buffer.Append(".");
                this.buffer.Append(this.callingMethod.Name);

                var methodInfo = this.callingMethod as MethodInfo;
                if (methodInfo != null && methodInfo.IsGenericMethod)
                {
                    this.buffer.Append('<');

                    var genericArgs = methodInfo.GetGenericArguments();
                    for (var i = 0; i < genericArgs.Length; i++)
                    {
                        if (i != 0)
                        {
                            this.buffer.Append(',');
                        }

                        this.AppendTypeName(genericArgs[i].GetGenericParameterDefinition());
                    }

                    this.buffer.Append('>');
                }
            }

            /// <summary>
            /// Gets whether an attribute is defined on a method, or if that method is part of a property
            /// whether the attribute is defined on the containing property.
            /// </summary>
            /// <param name="attributeType">
            /// The type of attribute to find.
            /// </param>
            /// <returns>
            /// <b>True</b> if the attribute is defined, or <b>False</b> otherwise.
            /// </returns>
            private bool IsAttributeDefined(Type attributeType)
            {
                Debug.Assert(this.callingMethod != null, "callingMethod field must not be null");

                // when a method is actually part of a property, i.e. it is the get_PropName or set_PropName then any custom attributes 
                // are associated in the metadata with the property definition and not the method itself. there's no easy way to get this 
                // from the method so here we check for a special name which isn't a constructor and the two defined special name starting 
                // tags then try and get the property on the type and see if it has the attribute defined
                var defined = this.callingMethod.IsDefined(attributeType, true);
                if (!defined && this.callingMethod.IsSpecialName && !this.callingMethod.IsConstructor && (this.callingMethod.Name.StartsWith("get_") || this.callingMethod.Name.StartsWith("set_")))
                {
                    var flags = (this.callingMethod.IsStatic ? BindingFlags.Static : BindingFlags.Instance) | (this.callingMethod.IsPublic ? BindingFlags.Public : BindingFlags.NonPublic);
                    var propertyInfo = this.callingMethod.DeclaringType.GetProperty(this.callingMethod.Name.Substring(4), flags);
                    if (propertyInfo != null)
                    {
                        defined = propertyInfo.IsDefined(attributeType, true);
                    }
                }

                return defined;
            }

            #endregion
        }
    }
}