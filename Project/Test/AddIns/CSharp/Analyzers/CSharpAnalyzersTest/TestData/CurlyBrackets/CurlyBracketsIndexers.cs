using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsIndexers
    {
        // Invalid indexers.
        public bool this[int a]
        {
            get { return true; }

            set
            {
                value = value;
            }
        }

        public bool this[bool a]
        {
            get
            {
                return true;
            }

            set { value = value; }
        }

        public bool this[string a]
        {
            get { 
                return true; }

            set {
                value = value; }
        }

        public bool this[float a]
        {
            get {
                return true;
            }

            set {
                value = value;
            }
        }

        public bool this[double a]
        {
            get
            {
                return true; }

            set
            {
                value = value; }
        }

        public bool this[DateTime[] a]
        {
            get
            { return true; 
            }

            set
            { value = value;
            }
        }

        public bool this[DateTime a]
        {
            get 
            { return true; }

            set 
            { value = value; }
        }

        public bool this[int[] a] { get { return true; } }

        public bool this[char a]
        {
            get { return true; } }

        public bool this[long[] a] {
            get { return true; } }

        public bool this[byte a] {
            get { return true; }
        }

        public bool this[char[] a]
        { get { return true; }
        }
            
        public bool this[short[] a]
        { get { return true; } }

        // Valid indexers.
        public bool this[short a]
        {
            get { return true; }
            set { value = value; }
        }

        public bool this[long a]
        {
            get
            {
                return true;
            }

            set
            {
                value = value;
            }
        }
    }

    interface IFoo
    {
        int this[int index] { get; set; }
    }
}