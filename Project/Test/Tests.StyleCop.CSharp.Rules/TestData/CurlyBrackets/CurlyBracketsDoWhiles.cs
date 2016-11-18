using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    public class CurlyBracketsDoWhiles
    {
        public void TestDoWhile()
        {
            int x = 0;

            // Invalid do-whiles
            do { } while (x == 0);
            do { x = 2; } while (x == 0);

            do
            {
                x = 2; } while (x == 0);

            do
            {
                x = 2; }
            while (x == 0);

            do {
                x = 2; 
            } while (x == 0);

            do {
                x = 2;
            }
            while (x == 0);

            do {
                x = 2; } while (x == 0);

            do {
                x = 2; }
            while (x == 0);

            do
            { x = 2;
            } while (x == 0);

            do
            { x = 2;
            }
            while (x == 0);

            do
            { x = 2; } while (x == 0);

            do
            { x = 2; }
            while (x == 0);

            do
            {
            } while (x == 0);

            do
            {
                x = 2;
            } while (x == 0);

            // Valid do-whiles
            do
            {
            } 
            while (x == 0);

            do
            {
                x = 2;
            }
            while (x == 0);
        }
    }
}