// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ClassMembersDerivedWithBase.cs" company="StyleCop">
//   StyleCop
// </copyright>
// <summary>
//   The derived class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace CSharpAnalyzersTest.TestData.ClassMembers
{
    /// <summary>
    /// The derived class.
    /// </summary>
    public class ClassMembersDerivedWithBase : BaseTest
    {
        /// <inheritdoc/>
        protected override bool Generic<T>(double value)
        {
            value += 2.0;
            return Generic<T>(value);
        }

        /// <inheritdoc/>
        protected override bool GenericBase<T>(double value)
        {
            value += 2.0;
            return base.GenericBase<T>(value);
        }

        /// <inheritdoc/>
        protected override bool GenericThis<T>(double value)
        {
            value += 2.0;
            return this.GenericThis<T>(value);
        }

        /// <inheritdoc/>
        protected override bool NonGeneric(int value)
        {
            value += 2;
            return NonGeneric(value);  // SA1101 raised as expected
        }

        /// <inheritdoc/>
        protected override bool NonGenericBase(int value)
        {
            value += 2;
            return base.NonGenericBase(value);
        }

        /// <inheritdoc/>
        protected override bool NonGenericThis(int value)
        {
            value += 2;
            return this.NonGenericThis(value);
        }
    }

    /// <summary>
    /// The base class.
    /// </summary>
    public class BaseTest
    {
        /// <summary>Generic method.</summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        protected virtual bool Generic<T>(double value)
        {
            return false;
        }

        /// <summary>Generic method.</summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        protected virtual bool GenericBase<T>(double value)
        {
            return false;
        }

        /// <summary>Generic method.</summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        protected virtual bool GenericThis<T>(double value)
        {
            return false;
        }

        /// <summary>Non-generic method.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        protected virtual bool NonGeneric(int value)
        {
            return false;
        }

        /// <summary>Non-generic method.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        protected virtual bool NonGenericBase(int value)
        {
            return false;
        }

        /// <summary>Non-generic method.</summary>
        /// <param name="value">The value.</param>
        /// <returns>The result.</returns>
        protected virtual bool NonGenericThis(int value)
        {
            return false;
        }
    }

    public partial class Derived2
    {
        public override bool Equals(object obj)
        {
            var a = base.Equals(obj); // base is valid here
            if (a)
            {
                return false;
            }

            return true;
        }
    }
}
