//--------------------------------------------------------------------------
//  <copyright file="MockExt.cs" company="Microsoft">
//      Copyright (c) Microsoft Corporation.  All rights reserved.
//  </copyright>
//--------------------------------------------------------------------------

namespace Microsoft.VisualStudio.TestTools.MockObjects
{
    using System;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Reflection;

    /// <summary>
    /// A set of extension methods for using lambda expressions to specific expectations on mock objects.
    /// The idea is to take advantage of the compile-time verification of method calls as well as refactoring, making
    /// developing tests with mock objects less painful and making them more maintainable.
    /// </summary>
    public static class Mock
    {
        #region Public API - ImplementExpr

        /// <summary>
        /// Implements the method specified by the lambda expression (that returns void).
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        public static void ImplementExpr<T>(this Mock<T> mock, Expression<Action<T>> expression) where T : class
        {
            mock.Implement(expression, (obj, method, arguments) => null);
        }

        /// <summary>
        /// Implements the method specified by the lambda expression (that returns void), calling the given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void ImplementExpr<T>(this Mock<T> mock, Expression<Action<T>> expression, Action handler) where T : class
        {
            mock.ImplementExpr(expression, args => handler());
        }

        /// <summary>
        /// Implements the method specified by the lambda expression (that returns void), calling the given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void ImplementExpr<T>(this Mock<T> mock, Expression<Action<T>> expression, Action<object[]> handler) where T : class
        {
            mock.Implement(expression, (obj, method, arguments) =>
            {
                handler(arguments);
                return null;
            });
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="returnValue">The value to return.</param>
        public static void ImplementExpr<T, TReturn>(this Mock<T> mock, Expression<Func<T, TReturn>> expression, TReturn returnValue) where T : class
        {
            mock.Implement(expression, (obj, method, arguments) => returnValue);
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression, returning default(TReturn)
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        public static void ImplementExpr<T, TReturn>(this Mock<T> mock, Expression<Func<T, TReturn>> expression) where T : class
        {
            mock.Implement(expression, (obj, method, arguments) => default(TReturn));
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression, returning the result of the 
        /// given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void ImplementExpr<T, TReturn>(this Mock<T> mock, Expression<Func<T, TReturn>> expression, Func<TReturn> handler) where T : class
        {
            mock.Implement(expression, (obj, method, arguments) => handler());
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression, returning the result of the
        /// given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void ImplementExpr<T, TReturn>(this Mock<T> mock, Expression<Func<T, TReturn>> expression, Func<object[], TReturn> handler) where T : class
        {
            mock.Implement(expression, (obj, method, arguments) => handler(arguments));
        }

        #endregion

        #region Public API - AddExpectationExpr

        /// <summary>
        /// Implements the method specified by the lambda expression (that returns void).
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        public static void AddExpectationExpr<T>(this SequenceMock<T> mock, Expression<Action<T>> expression) where T : class
        {
            mock.AddExpectation(expression, (obj, method, arguments) => null);
        }

        /// <summary>
        /// Implements the method specified by the lambda expression (that returns void), calling the given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void AddExpectationExpr<T>(this SequenceMock<T> mock, Expression<Action<T>> expression, Action handler) where T : class
        {
            mock.AddExpectationExpr(expression, args => handler());
        }

        /// <summary>
        /// Implements the method specified by the lambda expression (that returns void), calling the given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void AddExpectationExpr<T>(this SequenceMock<T> mock, Expression<Action<T>> expression, Action<object[]> handler) where T : class
        {
            mock.AddExpectation(expression, (obj, method, arguments) =>
            {
                handler(arguments);
                return null;
            });
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="returnValue">The value to return.</param>
        public static void AddExpectationExpr<T, TReturn>(this SequenceMock<T> mock, Expression<Func<T, TReturn>> expression, TReturn returnValue) where T : class
        {
            mock.AddExpectation(expression, (obj, method, arguments) => returnValue);
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression, returning default(TReturn)
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        public static void AddExpectationExpr<T, TReturn>(this SequenceMock<T> mock, Expression<Func<T, TReturn>> expression) where T : class
        {
            mock.AddExpectation(expression, (obj, method, arguments) => default(TReturn));
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression, returning the result of the 
        /// given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void AddExpectationExpr<T, TReturn>(this SequenceMock<T> mock, Expression<Func<T, TReturn>> expression, Func<TReturn> handler) where T : class
        {
            mock.AddExpectation(expression, (obj, method, arguments) => handler());
        }

        /// <summary>
        /// Implements the method or property getter specified by the lambda expression, returning the result of the
        /// given handler.
        /// </summary>
        /// <typeparam name="T">The type being mocked.</typeparam>
        /// <typeparam name="TReturn">The return type of the method.</typeparam>
        /// <param name="mock">The mock object.</param>
        /// <param name="expression">The expression.</param>
        /// <param name="handler">The handler.</param>
        public static void AddExpectationExpr<T, TReturn>(this SequenceMock<T> mock, Expression<Func<T, TReturn>> expression, Func<object[], TReturn> handler) where T : class
        {
            mock.AddExpectation(expression, (obj, method, arguments) => handler(arguments));
        }

        #endregion

        #region Constraint Methods

        /// <summary>
        /// Call this method in a lamba expression to state that an argument to a method being mocked should not be null.
        /// </summary>
        /// <remarks>Note that ConvertibleConstraintWrapper is implicitly convertible to T, unless T is an interface. In that case,
        /// Convert() must be called on the return object.
        /// </remarks>
        /// <typeparam name="T">The type of the return value</typeparam>
        public static ConvertibleConstraintWrapper<T> NotNull<T>() where T : class
        {
            return new ConvertibleConstraintWrapper<T>(MockConstraint.IsNotNull<T>());
        }

        /// <summary>
        /// Call this method in a lamba expression to state that an argument to a method being mocked can be anything.
        /// </summary>
        /// <remarks>Note that ConvertibleConstraintWrapper is implicitly convertible to T, unless T is an interface. In that case,
        /// Convert() must be called on the return object.
        /// </remarks>
        /// <typeparam name="T">The type of the return value</typeparam>
        public static ConvertibleConstraintWrapper<T> Any<T>()
        {
            return new ConvertibleConstraintWrapper<T>(MockConstraint.IsAnything<T>());
        }

        /// <summary>
        /// Call this method in a lamba expression to state that an argument to a method being mocked must match the given regular expression
        /// pattern.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public static ConvertibleConstraintWrapper<string> Match(string pattern)
        {
            return new ConvertibleConstraintWrapper<string>(MockConstraint.IsMatch(pattern));
        }

        /// <summary>
        /// Call this method in a lamba expression to state that an argument to a method must return true when applied to the
        /// given predicate.
        /// </summary>
        /// <typeparam name="T">The return type of the method.</typeparam>
        /// <param name="predicate">The predicate.</param>
        public static ConvertibleConstraintWrapper<T> Match<T>(Predicate<T> predicate) where T : class
        {
            return new ConvertibleConstraintWrapper<T>(MockConstraint.IsMatch(predicate));
        }

        #endregion

        private static void Implement<T>(this Mock<T> mock, LambdaExpression lambda, MockDelegate handler) where T : class
        {
            object[] args;
            mock.Implement(GetMethodAndArgs(lambda, out args), args, handler);
        }

        private static void AddExpectation<T>(this SequenceMock<T> mock, LambdaExpression lambda, MockDelegate handler) where T : class
        {
            object[] args;
            mock.AddExpectation(GetMethodAndArgs(lambda, out args), args, handler);
        }

        private static MethodId GetMethodAndArgs(LambdaExpression lambda, out object[] args)
        {
            var expressionBody = lambda.Body;
            switch (expressionBody.NodeType)
            {
                case ExpressionType.Call:
                    var methodCallExpression = (MethodCallExpression)expressionBody;
                    args = methodCallExpression.Arguments.Select(a => GetCallArg(a)).ToArray();
                    return new MethodId(methodCallExpression.Method);
                case ExpressionType.MemberAccess:
                    var memberExpression = (MemberExpression)expressionBody;
                    var propertyInfo = memberExpression.Member as PropertyInfo;
                    if (propertyInfo != null)
                    {
                        args = null;
                        return new MethodId(propertyInfo.GetGetMethod(true));
                    }
                    break;
            }

            throw new NotSupportedException("Lambda expression must be a property access or method call");
        }

        private static object GetCallArg(Expression expression)
        {
            switch (expression.NodeType)
            {
                case ExpressionType.Constant:
                    return ((ConstantExpression)expression).Value;
                case ExpressionType.Convert: // strip away the call to ConvertibleConstraintWrapper.op_Implicit
                    var unaryExpression = (UnaryExpression)expression;
                    if (unaryExpression.Method != null && typeof(ConstraintWrapper).IsAssignableFrom(unaryExpression.Method.DeclaringType))
                    {
                        return GetCallArg(unaryExpression.Operand);
                    }
                    break;
                case ExpressionType.Call: // strip away call to ConvertibleConstraintWrapper.Convert()
                    var methodCallExpression = expression as MethodCallExpression;
                    var method = methodCallExpression.Method;
                    var declaringType = method.DeclaringType;
                    if (method.Name == "Convert" && declaringType.IsGenericType && declaringType.GetGenericTypeDefinition() == typeof(ConvertibleConstraintWrapper<>))
                    {
                        return GetCallArg(methodCallExpression.Object);
                    }
                    break;
            }

            var retval = Expression.Lambda(expression).Compile().DynamicInvoke();
            var convertible = retval as ConstraintWrapper;
            return convertible == null ? retval : convertible.Constraint;
        }

        /// <summary>
        /// The base class for ConvertibleConstraintWrapper. Contains a Constraint property.
        /// This class should not be used directly.
        /// </summary>
        public class ConstraintWrapper
        {
            /// <summary>
            /// Gets or sets the IMockConstraint.
            /// </summary>
            public IMockConstraint Constraint { get; private set; }

            internal ConstraintWrapper(IMockConstraint constraint)
            {
                this.Constraint = constraint;
            }
        }

        /// <summary>
        /// A ConstraintWrapper that is implictly convertible to T (if T is an interface, Convert()
        /// must be called since implicit conversion is not supported).
        /// This type should be returned by constraints, but should never otherwise be called or used in client code.
        /// </summary>
        /// <typeparam name="T">The return type.</typeparam>
        public class ConvertibleConstraintWrapper<T> : ConstraintWrapper
        {
            internal ConvertibleConstraintWrapper(IMockConstraint constraint) : base(constraint) { }

            /// <summary>
            /// A method to be used in expressions where a ConvertibleConstraintWrapper
            /// needs to be explicitly converted to T. 
            /// </summary>
            /// <returns></returns>
            public T Convert()
            {
                throw new NotSupportedException("should never be called");
            }

            /// <summary>
            /// Performs an implicit conversion from <see cref="Microsoft.VisualStudio.TestTools.MockObjects.Mock.ConvertibleConstraintWrapper&lt;T&gt;"/> to T.
            /// </summary>
            /// <param name="constraintWrapper">The constraint wrapper.</param>
            /// <returns>The result of the conversion.</returns>
            public static implicit operator T(ConvertibleConstraintWrapper<T> constraintWrapper)
            {
                throw new NotSupportedException("should never be called");
            }
        }
    }
}
