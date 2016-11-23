// --------------------------------------------------------------------------------------------------------------------
// <copyright file="TypeExtensions.cs" company="https://github.com/StyleCop">
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
//   Extension methods for the  class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------
namespace System
{
    #region Using Directives

    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;

    #endregion

    /// <summary>
    /// Extension methods for the <see cref="Type"/> class.
    /// </summary>
    public static class TypeExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets all the types that a <see cref="Type"/> is assignable to, including itself, base types, and implemented interfaces.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> definition.
        /// </param>
        /// <returns>
        /// An enumerable list of assignable to types.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="type"/>is <c>null</c>.
        /// </exception>
        public static IEnumerable<Type> GetAssignableToTypes(this Type type)
        {
            for (Type baseType = type; baseType != null && baseType != typeof(object); baseType = baseType.BaseType)
            {
                yield return baseType;
            }

            foreach (Type interfaceType in type.GetInterfaces())
            {
                yield return interfaceType;
            }
        }

        /// <summary>
        /// Gets the generic parameter definition for a <see cref="Type"/> that represents a type parameter in the definition of 
        /// a generic type or method.
        /// </summary>
        /// <param name="parameterType">
        /// The parameter <see cref="Type"/>.
        /// </param>
        /// <returns>
        /// The generic parameter definition for <paramref name="parameterType"/>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="parameterType"/>is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="parameterType"/>is not a generic parameter (i.e. <see cref="Type.IsGenericParameter"/> is <c>false</c>).
        /// </exception>
        public static Type GetGenericParameterDefinition(this Type parameterType)
        {
            Type genericParameterType = null;
            if (parameterType.DeclaringMethod.IsGenericMethod)
            {
                genericParameterType = parameterType.DeclaringMethod.GetGenericArguments().FirstOrDefault(t => t.Name == parameterType.Name);
            }

            if (genericParameterType == null && parameterType.DeclaringType.IsGenericType)
            {
                genericParameterType = parameterType.DeclaringType.GetGenericArguments().FirstOrDefault(t => t.Name == parameterType.Name);
            }

            return genericParameterType;
        }

        /// <summary>
        /// Gets the hierarchy for a <see cref="Type"/>, including itself and all base types except <see cref="object"/>.
        /// </summary>
        /// <param name="type">
        /// The type to get the hierarchy for.
        /// </param>
        /// <returns>
        /// An enumerable list of types, with most derived type first.
        /// </returns>
        public static IEnumerable<Type> GetTypeHierarchy(this Type type)
        {
            do
            {
                yield return type;
                type = type.BaseType;
            }
            while (type != null);
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> has a particular <see cref="Type"/> of custom <see cref="Attribute"/> defined.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <param name="attributeType">
        /// The <see cref="Type"/> of custom <see cref="Attribute"/>.
        /// </param>
        /// <param name="inherit">
        /// Whether to search the <see cref="Type"/>'s inheritance chain to find the attributes.
        /// </param>
        /// <returns>
        /// <c>true</c>if the <see cref="Type"/> has any of the specified custom attributes; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="type"/> or <paramref name="attributeType"/> is <c>null</c>.
        /// </exception>
        public static bool HasCustomAttribute(this Type type, Type attributeType, bool inherit)
        {
            return type.GetCustomAttributes(attributeType, inherit).Any();
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> represents an integer.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="type"/> represents <see cref="byte"/>, <see cref="sbyte"/>, <see cref="short"/>, <see cref="ushort"/>,
        /// <see cref="int"/>, <see cref="uint"/>, <see cref="long"/> or <see cref="ulong"/>; otherwise <c>false.</c>
        /// </returns>
        public static bool IsInteger(this Type type)
        {
            return type.IsSignedInteger() || type.IsUnsignedInteger();
        }

        /// <summary>
        /// Determines whether <see cref="Nullable{T}"/> is assignable from a <see cref="Type"/>.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <returns>
        /// <c>true</c>if <see cref="Nullable{T}"/> is assignable from <paramref name="type"/>; otherwise <c>false</c>.
        /// </returns>
        public static bool IsNullableT(this Type type)
        {
            return type.IsGenericType && typeof(Nullable<>).IsAssignableFrom(type.GetGenericTypeDefinition());
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> represents a signed integer.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="type"/> represents <see cref="sbyte"/>, <see cref="short"/>, <see cref="int"/> or 
        /// <see cref="long"/>; otherwise <c>false.</c>
        /// </returns>
        public static bool IsSignedInteger(this Type type)
        {
            return type == typeof(sbyte) || type == typeof(short) || type == typeof(int) || type == typeof(long);
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> represents an unsigned integer.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="type"/> represents <see cref="byte"/>, <see cref="ushort"/>, <see cref="uint"/> or 
        /// <see cref="ulong"/>; otherwise <c>false.</c>
        /// </returns>
        public static bool IsUnsignedInteger(this Type type)
        {
            return type == typeof(byte) || type == typeof(ushort) || type == typeof(uint) || type == typeof(ulong);
        }

        /// <summary>
        /// Determines whether a <see cref="Type"/> meets the constraints for a generic parameter, i.e. whether it could be used 
        /// as the concrete type for a generic parameter.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <param name="parameterType">
        /// The generic parameter <see cref="Type"/>.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="type"/> meets the generic constraints; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="type"/> or <paramref name="parameterType"/> is <c>null</c>.
        /// </exception>
        /// <exception cref="ArgumentException">
        /// <paramref name="parameterType"/>is not a generic parameter (i.e. <see cref="Type.IsGenericParameter"/> is <c>false</c>).
        /// </exception>
        public static bool MeetsGenericParameterConstraints(this Type type, Type parameterType)
        {
            if ((parameterType.GenericParameterAttributes & GenericParameterAttributes.ReferenceTypeConstraint) != 0 && type.IsValueType)
            {
                return false;
            }

            if ((parameterType.GenericParameterAttributes & GenericParameterAttributes.NotNullableValueTypeConstraint) != 0 && (!type.IsValueType || type.IsNullableT()))
            {
                return false;
            }

            if ((parameterType.GenericParameterAttributes & GenericParameterAttributes.DefaultConstructorConstraint) != 0 && !type.IsValueType
                && type.GetConstructor(Type.EmptyTypes) == null)
            {
                return false;
            }

            foreach (Type constraintType in parameterType.GetGenericParameterConstraints())
            {
                if (!type.MeetsGenericParameterConstraint(constraintType))
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Removes the by-ref modifier from a type.
        /// </summary>
        /// <param name="type">
        /// The type to remove the modifier from.
        /// </param>
        /// <returns>
        /// A type without the by-ref modifier.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="type"/>is <c>null</c>.
        /// </exception>
        public static Type RemoveByRefModifier(this Type type)
        {
            return type.IsByRef ? type.GetElementType() : type;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Determines whether a <see cref="Type"/> meets a type constraint for a generic parameter.
        /// </summary>
        /// <param name="type">
        /// The <see cref="Type"/> to check.
        /// </param>
        /// <param name="constraintType">
        /// The generic parameter type constraint.
        /// </param>
        /// <returns>
        /// <c>true</c>if <paramref name="type"/> meets the generic parameter type constraint; otherwise <c>false</c>.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Either <paramref name="type"/> or <paramref name="constraintType"/> is <c>null</c>.
        /// </exception>
        private static bool MeetsGenericParameterConstraint(this Type type, Type constraintType)
        {
            bool result = false;
            if (constraintType.IsAssignableFrom(type))
            {
                // if the value is assignable then return it directly
                result = true;
            }
            else if (constraintType.IsGenericType && constraintType.ContainsGenericParameters)
            {
                // if the constraint is an open generic type then we need to check if this is an open self-referential constraint,
                // for example "where T : IComparable<T>" so we need to check whether the type meets the generic constraints of 
                // the generic type definition (i.e. that it is suitable to be the T in the generic type definition) and if so 
                // whether the constructed generic type is assignable from the value
                Type constraintTypeDefinition = constraintType.GetGenericTypeDefinition();
                Type[] constraintTypeDefinitionArgs = constraintTypeDefinition.GetGenericArguments();
                if (constraintTypeDefinitionArgs.Length == 1 && type.MeetsGenericParameterConstraints(constraintTypeDefinitionArgs[0]))
                {
                    result = constraintTypeDefinition.MakeGenericType(type).IsAssignableFrom(type);
                }
            }

            return result;
        }

        #endregion
    }
}