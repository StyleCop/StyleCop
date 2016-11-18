// <copyright file="ClassMembersPrefixLocalCallsWithThis2.cs" company="My Company">
// </copyright>

namespace CSharpAnalyzersTest.TestData.ClassMembers
{
    using System;
    using System.Linq;

    /// <summary>
    /// A class demonstrating a problem with SA1101
    /// </summary>
    public class ClassMembersPrefixLocalCallsWithThis2 : IEquatable<ClassMembersPrefixLocalCallsWithThis2>
    {
        /// <summary>
        /// Gets or sets the prop1.
        /// </summary>
        /// <value>
        /// The prop1.
        /// </value>
        public string Prop1 { get; set; }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(ClassMembersPrefixLocalCallsWithThis2 other)
        {
            if (object.ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return Equals(other.Prop1, this.Prop1);
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with this instance.</param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != typeof(ClassMembersPrefixLocalCallsWithThis2))
            {
                return false;
            }

            return this.Equals((ClassMembersPrefixLocalCallsWithThis2)obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table. 
        /// </returns>
        public override int GetHashCode()
        {
            return this.Prop1 != null ? this.Prop1.GetHashCode() : 0;
        }
    }

    public class Class1
    {
        public void A(int i)
        {
        }

        public void A()
        {
            A(1);
        }
    }

    public class Class2
    {
        public void A()
        {
            A(1);
        }

        public void A(int i)
        {
        }
    }

    public class Class3
    {
        public bool A<T>()
        {
            return B<T>();
        }

        private bool B<T>()
        {
            return true;
        }
    }

    public class Class4
    {
        public bool A<T>()
        {
            return B();
        }

        private bool B()
        {
            return true;
        }
    }
    
    public class Class5
    {
        public int Method1(int i)
        {
            var a = typeof(IDoStuff<>);
        }

        public interface IDoStuff<T>
        {
            IService<T, int> Service { get; }
        }
     }
}