using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsIfs
    {
        public void TestIf()
        {
            int x = 0;

            // Invalid ifs
            if (x == 0) { }
            if (x == 0) { x = 2; }

            if (x == 0)
            {
                x = 2; }

            if (x == 0) {
                x = 2; 
            }

            if (x == 0) {
                x = 2; }

            if (x == 0) 
            { x = 2; 
            }

            if (x == 0)
            { x = 2; }

            if (x == 0) x = 2;

            if (x == 0)
                x = 2;

            // Valid ifs
            if (x == 0)
            {
            }

            if (x == 0)
            {
                x = 2; 
            }
        }

        public void TestElse()
        {
            int x = 0;

            // Invalid elses
            if (x == 0)
            {
            }
            else { }

            if (x == 0)
            {
            }
            else { x = 2; }

            if (x == 0)
            {
            }
            else {
                x = 2; 
            }

            if (x == 0)
            {
            }
            else {
                x = 2; }

            if (x == 0)
            {
            }
            else
            {
                x = 2; }

            if (x == 0)
            {
            }
            else
            { x = 2;
            }

            if (x == 0)
            {
            }
            else
            { x = 2; }

            if (x == 0)
            {
            }
            else x = 2;

            if (x == 0)
            {
            }
            else
                x = 2;

            // Valid elses
            if (x == 0)
            {
            }
            else
            { 
            }

            if (x == 0)
            {
            }
            else
            {
                x = 2;
            }
        }

        public void TestIfStack(int y)
        {
            // Invalid if stack
            if (y == 1)
            if (y == 2)
            if (y == 3)
            {
                y = 4;
            }
        }
    }
}