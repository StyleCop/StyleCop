using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the class summary.
    /// </summary>
    public class DocumentationMethods
    {
        /// <summary>
        /// This is the summary for the method.
        /// </summary>
        public void ValidMethod1()
        {
        }

        /// <summary>
        /// This is the summary for the method.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        /// <returns>This is the return value.</returns>
        public Dictionary<int?, bool[]> ValidMethod2(int x, string[] y, List<int[]> z)
        {
        }

        /// <summary>
        /// This is the summary for the method.
        /// </summary>
        /// <typeparam name="T">This is the first generic parameter.</typeparam>
        /// <typeparam name="S">This is the second generic parameter.</typeparam>
        public void ValidMethod3<T, S>()
        {
        }

        /// <summary>This is the summary for the method.</summary><typeparam name="T">This is the first generic parameter.</typeparam><typeparam name="S">This is the second generic parameter.</typeparam>
        public void ValidMethod4<T, S>()
        {
        }

        /// <summary>
        /// This is the summary for the method.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        /// <returns>This is the return value.</returns>
        /// <typeparam name="T">This is the first generic parameter.</typeparam>
        /// <typeparam name="S">This is the second generic parameter.</typeparam>
        public Dictionary<int?, bool[]> ValidMethod5<T, S>(T x, S[] y, List<int[]> z)
        {
        }

        /// <summary>
        /// This is the summary. Some of the text is repeated.
        /// </summary>
        /// <typeparam name="T">The parameter is not used.</typeparam>
        /// <typeparam name="S">The parameter is not used.</typeparam>
        /// <param name="x">The parameter is not used.</param>
        /// <param name="y">The parameter is not used.</param>
        /// <returns>This is the return value.</returns>
        public bool ValidMethod6<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary for an internal method.
        /// </summary>
        internal void ValidMethod7()
        {
        }

        /// <summary>
        /// This is the summary for a protected method.
        /// </summary>
        protected void ValidMethod8()
        {
        }

        /// <summary>
        /// This is the summary for a protected internal method.
        /// </summary>
        protected internal void ValidMethod9()
        {
        }

        /// <summary>
        /// This is the summary for a private method.
        /// </summary>
        private void ValidMethod10()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the x parameter.</param>
        /// <param name="y">This is the y parameter.</param>
        /// <remarks>Adding a remarks tag.</remarks>
        /// <returns>This is the return value.</returns>
        private int ValidMethod11(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary for a static method.
        /// </summary>
        public static void ValidMethod11()
        {
        }

        /// <summary>
        /// Summary description for method.
        /// </summary>
        public void InvalidMethod1()
        {
        }

        /// <summary>
        /// This method's xml is invalid. Missing closing summary tag.
        public void InvalidMethod2()
        {
        }

        public void InvalidMethod3()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        public void InvalidMethod4()
        {
        }

        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        public void InvalidMethod5()
        {
        }

        /// <summary>
        /// Short.
        /// </summary>
        public void InvalidMethod6()
        {
        }

        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        public void InvalidMethod7()
        {
        }

        /// <summary>
        /// no capital letter.
        /// </summary>
        public void InvalidMethod8()
        {
        }

        /// <summary>
        /// No closing period
        /// </summary>
        public void InvalidMethod9()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        public void InvalidMethod10(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x"></param>
        public void InvalidMethod11(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Nospaceshereatall.</param>
        public void InvalidMethod12(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Short.</param>
        public void InvalidMethod13(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</param>
        public void InvalidMethod14(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">no capital letter.</param>
        public void InvalidMethod15(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">No closing period</param>
        public void InvalidMethod16(int x)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        public bool InvalidMethod17()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns></returns>
        public bool InvalidMethod18()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>Nospaceshereatall.</returns>
        public bool InvalidMethod19()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>Short.</returns>
        public bool InvalidMethod20()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</returns>
        public bool InvalidMethod21()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>no capital letter.</returns>
        public bool InvalidMethod22()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>No closing period</returns>
        public bool InvalidMethod23()
        {
            return true;
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        public void InvalidMethod24<T>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public void InvalidMethod25<T>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">Nospaceshereatall.</typeparam>
        public void InvalidMethod26<T>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">Short.</typeparam>
        public void InvalidMethod27<T>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</typeparam>
        public void InvalidMethod28<T>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">no capital letter.</typeparam>
        public void InvalidMethod29<T>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">No closing period</typeparam>
        public void InvalidMethod30<T>()
        {
        }

        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <typeparam name="T">This line is copied.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This is the first param.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This is the return value.</returns>
        public bool InvalidMethod31<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This is the return value.</returns>
        public bool InvalidMethod32<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This is the first param.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This line is copied.</returns>
        public bool InvalidMethod33<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This line is copied.</typeparam>
        /// <typeparam name="S">This line is copied.</typeparam>
        /// <param name="x">This is the first param.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This is the return value.</returns>
        public bool InvalidMethod34<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This line is copied.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This line is copied.</returns>
        public bool InvalidMethod35<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This line is copied.</param>
        /// <returns>This is the return value.</returns>
        public bool InvalidMethod36<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This line is copied.</returns>
        public bool InvalidMethod37<T, S>(int x, int y)
        {
        }

        /// <summary>
        /// The parameters are in the wrong order.
        /// </summary>
        /// <param name="y">This is the second param.</param>
        /// <param name="x">This is the first param.</param>
        public void InvalidMethod38(int x, int y)
        {
        }

        /// <summary>
        /// The typeparams are in the wrong order.
        /// </summary>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        public void InvalidMethod39<T, S>()
        {
        }

        /// <summary>
        /// Param tag is missing the name attribute.
        /// </summary>
        /// <param>This is the first param.</param>
        public void InvalidMethod40(int x)
        {
        }

        /// <summary>
        /// Typeparam tag is missing the name attribute.
        /// </summary>
        /// <typeparam>This is the first typeparam.</typeparam>
        public void InvalidMethod41<T>()
        {
        }

        /// <summary>
        /// There is no return value but a return tag.
        /// </summary>
        /// <returns>This is the returns description.</returns>
        public void InvalidMethod42()
        {
        }

        internal void InvalidMethod53()
        {
        }

        protected void InvalidMethod44()
        {
        }

        protected internal void InvalidMethod45()
        {
        }

        private void InvalidMethod46()
        {
        }

        public static void InvalidMethod47()
        {
        }

        /////// <summary>
        /////// This is the summary.
        /////// </summary>
        /////// <param name="x">This is the x parameter.</param>
        /////// <param name="y">This is the y parameter.</param>
        /////// <returns>This is the return value.</returns>
        /////// <remarks></remarks>
        ////protected int InvalidMethod48(int x, int y)
        ////{
        ////    return 1;
        ////}

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        protected void InvalidMethod49(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param>This is the third parameter.</param>
        protected void InvalidMethod50(int x, int y)
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first parameter.</typeparam>
        /// <typeparam name="S">This is the second parameter.</typeparam>
        /// <typeparam name="W">This is the third parameter.</typeparam>
        protected void InvalidMethod51<T, S>()
        {
        }

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first parameter.</typeparam>
        /// <typeparam name="S">This is the second parameter.</typeparam>
        /// <typeparam>This is the third parameter.</typeparam>
        protected void InvalidMethod52<T, S>()
        {
        }

        /// <summary>
        /// This is the summary. Param tag is missing for Z.
        /// </summary>
        /// <param name="x">The first param.</param>
        /// <param name="y">The second param.</param>
        public void InvalidMethod53(int x, int y, int z)
        {
        }

        class StyleCopTest<T, I> : IFooDoStuff<T, I>
            where T : FooWrapper<I>
            where I : IFooWrapped
        {
            // HACK: The following XML comment will crash StyleCop
            /// <summary>
            /// My summary content
            /// </summary>
            /// <typeparam name="E">My type param content.</typeparam>
            /// <returns>My returns content.</returns>
            E IFooDoStuff<T, I>.DoStuff<E>()
            {
                return default(E);
            }

        }

        class FooWrapper<I>
        {
        }

        interface IFooWrapped
        {
        }

        public interface IFooDoStuff<T, I>
            where T : FooWrapper<I>
            where I : IFooWrapped
        {
            E DoStuff<E>() where E : FooDoStuffConstraint;
        }

        public class FooDoStuffConstraint
        {
        }
        
        public partial class SA1601TestCode
        {
            partial void MethodName();
        }

        public partial class SA1601TestCode
        {
            partial void MethodName()
            {
            }
        }

        /// <summary>
        /// While this test case is not for documentation rules, we use this
        /// to verify the bug where multiline interpolated string results in incorrect line numbers.
        /// </summary>
        private static void TestCaseForIssue105Part1()
        {
            int value;
            var singleLineDummyString = $@"Some Text";

            // Declare dummy string.
            var dummyString = string.Format(
                $@"
Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean 
commodo ligula eget dolor. Aenean massa. Cum sociis natoque {0} 
penatibus et magnis dis parturient montes, nascetur ridiculus mus.
",
                value);

            // Do something with the dummy string.
            TransferQueue.Enqueue(dummyString);
        }

        private static void TestCaseForIssue105Part2()
        {
        }
    }
}
