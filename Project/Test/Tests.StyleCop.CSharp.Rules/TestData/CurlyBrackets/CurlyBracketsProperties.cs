using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsProperties
    {
        // Invalid properties.
        public bool InvalidProperty1
        {
            get { return true; }

            set
            {
                value = value;
            }
        }

        public bool InvalidProperty2
        {
            get
            {
                return true;
            }

            set { value = value; }
        }

        public bool InvalidProperty3
        {
            get {
                return true; }

            set {
                value = value; }
        }

        public bool InvalidProperty4
        {
            get {
                return true;
            }

            set {
                value = value;
            }
        }

        public bool InvalidProperty5
        {
            get
            {
                return true; }

            set
            {
                value = value; }
        }

        public bool InvalidProperty6
        {
            get
            { return true;
            }

            set
            { value = value;
            }
        }

        public bool InvalidProperty7
        {
            get
            { return true; }

            set
            { value = value; }
        }

        public bool InvalidProperty8 { get { return true; } }

        public bool InvalidProperty9
        {
            get { return true; } }

        public bool InvalidProperty10 {
            get { return true; } }

        public bool InvalidProperty11 {
            get { return true; }
        }

        public bool InvalidProperty12
        { get { return true; }
        }

        public bool InvalidProperty13
        { get { return true; } }

        public bool InvalidProperty14 {
            get;
        } = GetPropertyValue();

        public bool InvalidProperty15 { get;
        } = GetPropertyValue();

        public bool InvalidProperty16
        {
            get; } = GetPropertyValue();

        // Valid properties.
        public bool ValidProperty1
        {
            get { return true; }
            set { value = value; }
        }

        public bool ValidProperty2
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

        public bool ValidProperty3 { get; }

        public bool ValidProperty4 { set;  }

        public bool ValidProperty5 { get; set; }

        public bool ValidProperty6
        {
            get; set; 
        }

        public bool ValidProperty7
        {
            get;
            set;
        }

        public bool ValidProperty8 { get; } = GetPropertyValue();

        public bool ValidProperty9 { get; }
            = GetPropertyValue();

        public bool ValidProperty10 { get; } =
            GetPropertyValue();

        public int[] ValidProperty11 => new int[] { };
    }
}