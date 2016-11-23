// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Param.cs" company="https://github.com/StyleCop">
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
//   Delegate used for getting error text.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace StyleCop
{
    using System;
    using System.Collections;
    using System.Diagnostics;
    using System.Diagnostics.CodeAnalysis;
    using System.Globalization;

    /// <summary>
    /// Delegate used for getting error text.
    /// </summary>
    /// <returns>Returns the error text.</returns>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param", 
        Justification = "This name represents a Parameter, and should be short as it is used often.")]
    public delegate string ParamErrorTextHandler();

    /// <summary>
    /// Used to verify method parameters.
    /// </summary>
    /// <exclude/>
    [SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Param", 
        Justification = "This name represents a Parameter, and should be short as it is used often.")]
    public sealed class Param
    {
        #region Constructors and Destructors

        /// <summary>
        /// Prevents a default instance of the <see cref="Param"/> class from being created.
        /// </summary>
        private Param()
        {
        }

        #endregion

        #region Public Methods and Operators

        /// <summary>
        /// Asserts on the given value. This is meant to be used in non-public facing methods.
        /// </summary>
        /// <param name="test">
        /// The boolean state of the parameter test.
        /// </param>
        /// <param name="parameterName">
        /// Name of the parameter.
        /// </param>
        /// <param name="exceptionMessage">
        /// Message of the exception to create.
        /// </param>
        [Conditional("DEBUG")]
        public static void Assert(bool test, string parameterName, string exceptionMessage)
        {
            Param.Require(test, parameterName, exceptionMessage);
        }

        /// <summary>
        /// Asserts that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThan(int number, int minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThan(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThan(long number, long minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThan(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThan(short number, short minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThan(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThan(double number, double minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThan(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThan(float number, float minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThan(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualTo(int number, int minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualTo(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualTo(long number, long minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualTo(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualTo(short number, short minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualTo(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualTo(double number, double minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualTo(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualTo(float number, float minimum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualTo(number, minimum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualToZero(int number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualToZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualToZero(long number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualToZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualToZero(short number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualToZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualToZero(double number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualToZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanOrEqualToZero(float number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanOrEqualToZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanZero(int number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanZero(long number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanZero(short number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanZero(double number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertGreaterThanZero(float number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireGreaterThanZero(number, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThan(int number, int maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThan(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThan(long number, long maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThan(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThan(short number, short maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThan(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThan(double number, double maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThan(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThan(float number, float maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThan(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThanOrEqualTo(int number, int maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThanOrEqualTo(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThanOrEqualTo(long number, long maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThanOrEqualTo(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThanOrEqualTo(short number, short maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThanOrEqualTo(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThanOrEqualTo(double number, double maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThanOrEqualTo(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertLessThanOrEqualTo(float number, float maximum, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireLessThanOrEqualTo(number, maximum, parameterName);
        }

        /// <summary>
        /// Asserts that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to check for null.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertNotNull(object parameter, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireNotNull(parameter, parameterName);
        }

        /// <summary>
        /// Asserts that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to check for null.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="exceptionMessage">
        /// Message of the exception to create.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertNotNull(object parameter, string parameterName, string exceptionMessage)
        {
            Param.Ignore(parameterName);
            Param.RequireNotNull(parameter, parameterName, exceptionMessage);
        }

        /// <summary>
        /// Asserts that the given collection is not null or empty.
        /// </summary>
        /// <param name="parameter">
        /// The collection to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the collection parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValidCollection(ICollection parameter, string parameterName)
        {
            Param.Ignore(parameter);
            Param.RequireValidCollection(parameter, parameterName);
        }

        /// <summary>
        /// Asserts that an index be between a valid range. 
        /// </summary>
        /// <param name="test">
        /// The test for validity.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="exceptionMessage">
        /// Message of the exception to create.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValidIndex(bool test, string parameterName, string exceptionMessage)
        {
            Param.Ignore(test, parameterName, exceptionMessage);
            if (test == false)
            {
                Debug.Assert(test, parameterName, exceptionMessage);
                throw new ArgumentOutOfRangeException(exceptionMessage, parameterName);
            }
        }

        /// <summary>
        /// Asserts that the given string is not null or empty.
        /// </summary>
        /// <param name="parameter">
        /// The string to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the string parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValidString(string parameter, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidString(parameter, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValueBetween(int number, int low, int high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValueBetween(number, low, high, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValueBetween(long number, long low, long high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValueBetween(number, low, high, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValueBetween(short number, short low, short high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValueBetween(number, low, high, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValueBetween(double number, double low, double high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValueBetween(number, low, high, parameterName);
        }

        /// <summary>
        /// Asserts that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        [Conditional("DEBUG")]
        public static void AssertValueBetween(float number, float low, float high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValueBetween(number, low, high, parameterName);
        }

        /// <summary>
        /// Provides a list of parameters to ignore. These are parameters that do not need to
        /// be verified.
        /// </summary>
        /// <param name="values">
        /// The list of parameters to ignore.
        /// </param>
        [Conditional("DEBUG")]
        public static void Ignore(params object[] values)
        {
        }

        /// <summary>
        /// Checks an individual parameter and throws an ArgumentException if it is not correct.
        /// This is meant to be used in public facing methods.
        /// </summary>
        /// <param name="test">
        /// The boolean state of the parameter test.
        /// </param>
        /// <param name="parameterName">
        /// Name of the parameter.
        /// </param>
        /// <param name="errorTextHandler">
        /// Delegate for getting the error text.
        /// </param>
        /// <remarks>
        /// It is more efficient to pass the error text through a delegate if the text is extracted
        /// from a resource file. The text will only be loaded if it is actually needed.
        /// </remarks>
        public static void Require(bool test, string parameterName, ParamErrorTextHandler errorTextHandler)
        {
            Param.Ignore(test, parameterName, errorTextHandler);
            if (test == false)
            {
                string message = string.Empty;
                if (errorTextHandler != null)
                {
                    message = errorTextHandler();
                }

                Debug.Assert(test, parameterName, message);
                throw new ArgumentException(message, parameterName);
            }
        }

        /// <summary>
        /// Checks an individual parameter and throws an ArgumentException if it is not correct.
        /// This is meant to be used in public facing methods.
        /// </summary>
        /// <param name="test">
        /// The boolean state of the parameter test.
        /// </param>
        /// <param name="parameterName">
        /// Name of the parameter.
        /// </param>
        /// <param name="exceptionMessage">
        /// Message of the exception to create.
        /// </param>
        public static void Require(bool test, string parameterName, string exceptionMessage)
        {
            Param.Ignore(test, parameterName, exceptionMessage);
            if (test == false)
            {
                Debug.Assert(test, parameterName, exceptionMessage);
                throw new ArgumentException(exceptionMessage, parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThan(int number, int minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThan(long number, long minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThan(short number, short minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThan(double number, double minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThan(float number, float minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number <= minimum)
            {
                string message = Strings.MustBeGreaterThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualTo(int number, int minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualTo(long number, long minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualTo(short number, short minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualTo(double number, double minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="minimum">
        /// The number must be greater than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualTo(float number, float minimum, string parameterName)
        {
            Param.Ignore(number, minimum, parameterName);
            if (number < minimum)
            {
                string message = Strings.MustBeGreaterThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, minimum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, minimum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualToZero(int number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualToZero(long number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualToZero(short number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualToZero(double number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than or equal to zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanOrEqualToZero(float number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number >= 0, parameterName, delegate { return Strings.MustBeGreaterThanOrEqualToZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanZero(int number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanZero(long number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanZero(short number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanZero(double number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is greater than zero.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireGreaterThanZero(float number, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(number > 0, parameterName, delegate { return Strings.MustBeGreaterThanZero; });
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThan(int number, int maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThan(long number, long maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThan(short number, short maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThan(double number, double maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThan(float number, float maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number >= maximum)
            {
                string message = Strings.MustBeLessThan;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThanOrEqualTo(int number, int maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThanOrEqualTo(long number, long maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThanOrEqualTo(short number, short maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThanOrEqualTo(double number, double maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given number is less than or equal to the given value.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="maximum">
        /// The number must be less than or equal to this value.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireLessThanOrEqualTo(float number, float maximum, string parameterName)
        {
            Param.Ignore(number, maximum, parameterName);
            if (number > maximum)
            {
                string message = Strings.MustBeLessThanOrEqualTo;
                Debug.Assert(false, parameterName, string.Format(CultureInfo.CurrentCulture, message, maximum));
                throw new ArgumentOutOfRangeException(string.Format(CultureInfo.CurrentCulture, message, maximum), parameterName);
            }
        }

        /// <summary>
        /// Requires that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to check for null.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        public static void RequireNotNull(object parameter, string parameterName)
        {
            Param.Ignore(parameter, parameterName);
            RequireNotNull(parameter, parameterName, delegate { return Strings.CannotBeNull; });
        }

        /// <summary>
        /// Requires that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to check for null.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="errorTextHandler">
        /// Delegate for getting the error text.
        /// </param>
        /// <remarks>
        /// It is more efficient to pass the error text through a delegate if the text is extracted
        /// from a resource file. The text will only be loaded if it is actually needed.
        /// </remarks>
        public static void RequireNotNull(object parameter, string parameterName, ParamErrorTextHandler errorTextHandler)
        {
            Param.Ignore(parameter, parameterName, errorTextHandler);
            if (parameter == null)
            {
                string message = string.Empty;
                if (errorTextHandler != null)
                {
                    message = errorTextHandler();
                }

                Debug.Assert(false, parameterName, message);
                throw new ArgumentNullException(message, parameterName);
            }
        }

        /// <summary>
        /// Requires that the given parameter must not be null.
        /// </summary>
        /// <param name="parameter">
        /// The parameter to check for null.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="exceptionMessage">
        /// Message of the exception to create.
        /// </param>
        public static void RequireNotNull(object parameter, string parameterName, string exceptionMessage)
        {
            Param.Ignore(parameter, parameterName, exceptionMessage);
            if (parameter == null)
            {
                throw new ArgumentNullException(exceptionMessage, parameterName);
            }
        }

        /// <summary>
        /// Requires that the given collection is not null or empty.
        /// </summary>
        /// <param name="parameter">
        /// The collection to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the collection parameter.
        /// </param>
        public static void RequireValidCollection(ICollection parameter, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.Require(parameter != null && parameter.Count > 0, parameterName, delegate { return Strings.CollectionCannotBeEmptyOrNull; });
        }

        /// <summary>
        /// Requires that an index be between a valid range. 
        /// </summary>
        /// <param name="test">
        /// The test for validity.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="exceptionMessage">
        /// Message of the exception to create.
        /// </param>
        public static void RequireValidIndex(bool test, string parameterName, string exceptionMessage)
        {
            Param.Ignore(test, parameterName, exceptionMessage);
            if (test == false)
            {
                Debug.Assert(test, parameterName, exceptionMessage);
                throw new ArgumentOutOfRangeException(exceptionMessage, parameterName);
            }
        }

        /// <summary>
        /// Requires that an index be between a valid range. 
        /// </summary>
        /// <param name="test">
        /// The test for validity.
        /// </param>
        /// <param name="parameterName">
        /// The name of the parameter.
        /// </param>
        /// <param name="errorTextHandler">
        /// Delegate for getting the error text.
        /// </param>
        /// <remarks>
        /// It is more efficient to pass the error text through a delegate if the text is extracted
        /// from a resource file. The text will only be loaded if it is actually needed.
        /// </remarks>
        public static void RequireValidIndex(bool test, string parameterName, ParamErrorTextHandler errorTextHandler)
        {
            Param.Ignore(test, parameterName, errorTextHandler);
            if (test == false)
            {
                string message = string.Empty;
                if (errorTextHandler != null)
                {
                    message = errorTextHandler();
                }

                Debug.Assert(test, parameterName, message);
                throw new ArgumentOutOfRangeException(message, parameterName);
            }
        }

        /// <summary>
        /// Requires that the given string is not null or empty.
        /// </summary>
        /// <param name="parameter">
        /// The string to check.
        /// </param>
        /// <param name="parameterName">
        /// The name of the string parameter.
        /// </param>
        public static void RequireValidString(string parameter, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.Require(parameter != null && parameter.Length > 0, parameterName, delegate { return Strings.StringCannotBeEmptyOrNull; });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireValueBetween(int number, int low, int high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(
                number >= low && number <= high, parameterName, delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, low, high); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireValueBetween(long number, long low, long high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(
                number >= low && number <= high, parameterName, delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, low, high); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireValueBetween(short number, short low, short high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(
                number >= low && number <= high, parameterName, delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, low, high); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireValueBetween(double number, double low, double high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(
                number >= low && number <= high, parameterName, delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, low, high); });
        }

        /// <summary>
        /// Requires that the given number is between the two given values.
        /// </summary>
        /// <param name="number">
        /// The number to check.
        /// </param>
        /// <param name="low">
        /// The valid low end range.
        /// </param>
        /// <param name="high">
        /// The valid high end range.
        /// </param>
        /// <param name="parameterName">
        /// The name of the number parameter.
        /// </param>
        public static void RequireValueBetween(float number, float low, float high, string parameterName)
        {
            Param.Ignore(parameterName);
            Param.RequireValidIndex(
                number >= low && number <= high, parameterName, delegate { return string.Format(CultureInfo.CurrentCulture, Strings.MustBeBetween, low, high); });
        }

        #endregion
    }
}