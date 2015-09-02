using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpAnalyzersTest.TestData
{
    /// <summary>
    /// This is the summary.
    /// </summary>
    public class DocumentationDelegates
    {
        /// <summary>
        /// This is the summary for the delegate.
        /// </summary>
        public delegate void ValidDelegate1();

        /// <summary>
        /// This is the summary for the delegate.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        /// <returns>This is the return value.</returns>
        public delegate Dictionary<int?, bool[]> ValidDelegate2(int x, string[] y, List<int[]> z);

        /// <summary>
        /// This is the summary for the delegate.
        /// </summary>
        /// <typeparam name="T">This is the first generic parameter.</typeparam>
        /// <typeparam name="S">This is the second generic parameter.</typeparam>
        public delegate void ValidDelegate3<T, S>();

        /// <summary>This is the summary for the delegate.</summary><typeparam name="T">This is the first generic parameter.</typeparam><typeparam name="S">This is the second generic parameter.</typeparam>
        public delegate void ValidDelegate4<T, S>();

        /// <summary>
        /// This is the summary for the delegate.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        /// <returns>This is the return value.</returns>
        /// <typeparam name="T">This is the first generic parameter.</typeparam>
        /// <typeparam name="S">This is the second generic parameter.</typeparam>
        public delegate Dictionary<int?, bool[]> ValidDelegate5<T, S>(T x, S[] y, List<int[]> z);

        /// <summary>
        /// This is the summary. Some of the text is repeated.
        /// </summary>
        /// <typeparam name="T">The parameter is not used.</typeparam>
        /// <typeparam name="S">The parameter is not used.</typeparam>
        /// <param name="x">The parameter is not used.</param>
        /// <param name="y">The parameter is not used.</param>
        /// <returns>This is the return value.</returns>
        public delegate bool ValidDelegate6<T, S>(int x, int y);

        /// <summary>
        /// This is the summary for an internal delgate.
        /// </summary>
        internal delegate void ValidDelegate7();

        /// <summary>
        /// This is the summary for a protected delgate.
        /// </summary>
        protected delegate void ValidDelegate8();

        /// <summary>
        /// This is the summary for a protected internal delegate.
        /// </summary>
        protected internal delegate void ValidDelegate9();

        /// <summary>
        /// This is the summary for a private delgate.
        /// </summary>
        private delegate void ValidDelegate10();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the x parameter.</param>
        /// <param name="y">This is the y parameter.</param>
        /// <remarks>Adding a remarks tag.</remarks>
        /// <returns>This is the return value.</returns>
        private delegate int ValidDelegate11(int x, int y);

        /// <summary>
        /// Summary description for delegate.
        /// </summary>
        public delegate void InvalidDelegate1();

        /// <summary>
        /// This delgate's xml is invalid. Missing closing summary tag.
        public delegate void InvalidDelegate2();

        public delegate void InvalidDelegate3();

        /// <summary>
        /// 
        /// </summary>
        public delegate void InvalidDelegate4();

        /// <summary>
        /// Nospaceshereatall.
        /// </summary>
        public delegate void InvalidDelegate5();

        /// <summary>
        /// Short.
        /// </summary>
        public delegate void InvalidDelegate6();

        /// <summary>
        /// A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.
        /// </summary>
        public delegate void InvalidDelegate7();

        /// <summary>
        /// no capital letter.
        /// </summary>
        public delegate void InvalidDelegate8();

        /// <summary>
        /// No closing period
        /// </summary>
        public delegate void InvalidDelegate9();

        /// <summary>
        /// This is the summary.
        /// </summary>
        public delegate void InvalidDelegate10(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x"></param>
        public delegate void InvalidDelegate11(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Nospaceshereatall.</param>
        public delegate void InvalidDelegate12(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">Short.</param>
        public delegate void InvalidDelegate13(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</param>
        public delegate void InvalidDelegate14(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">no capital letter.</param>
        public delegate void InvalidDelegate15(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">No closing period</param>
        public delegate void InvalidDelegate16(int x);

        /// <summary>
        /// This is the summary.
        /// </summary>
        public delegate bool InvalidDelegate17();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns></returns>
        public delegate bool InvalidDelegate18();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>Nospaceshereatall.</returns>
        public delegate bool InvalidDelegate19();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>Short.</returns>
        public delegate bool InvalidDelegate20();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</returns>
        public delegate bool InvalidDelegate21();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>no capital letter.</returns>
        public delegate bool InvalidDelegate22();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <returns>No closing period</returns>
        public delegate bool InvalidDelegate23();

        /// <summary>
        /// This is the summary.
        /// </summary>
        public delegate void InvalidDelegate24<T>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public delegate void InvalidDelegate25<T>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">Nospaceshereatall.</typeparam>
        public delegate void InvalidDelegate26<T>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">Short.</typeparam>
        public delegate void InvalidDelegate27<T>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">A)(@)*23408234082308230823048230940238409283409234098230498234not enough letters.</typeparam>
        public delegate void InvalidDelegate28<T>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">no capital letter.</typeparam>
        public delegate void InvalidDelegate29<T>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">No closing period</typeparam>
        public delegate void InvalidDelegate30<T>();

        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <typeparam name="T">This line is copied.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This is the first param.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This is the return value.</returns>
        public delegate bool InvalidDelegate31<T, S>(int x, int y);

        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This is the return value.</returns>
        public delegate bool InvalidDelegate32<T, S>(int x, int y);

        /// <summary>
        /// This line is copied.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This is the first param.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This line is copied.</returns>
        public delegate bool InvalidDelegate33<T, S>(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This line is copied.</typeparam>
        /// <typeparam name="S">This line is copied.</typeparam>
        /// <param name="x">This is the first param.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This is the return value.</returns>
        public delegate bool InvalidDelegate34<T, S>(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This line is copied.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This line is copied.</returns>
        public delegate bool InvalidDelegate35<T, S>(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This line is copied.</param>
        /// <returns>This is the return value.</returns>
        public delegate bool InvalidDelegate36<T, S>(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <param name="x">This line is copied.</param>
        /// <param name="y">This is the second param.</param>
        /// <returns>This line is copied.</returns>
        public delegate bool InvalidDelegate37<T, S>(int x, int y);

        /// <summary>
        /// The parameters are in the wrong order.
        /// </summary>
        /// <param name="y">This is the second param.</param>
        /// <param name="x">This is the first param.</param>
        public delegate void InvalidDelegate38(int x, int y);

        /// <summary>
        /// The typeparams are in the wrong order.
        /// </summary>
        /// <typeparam name="S">The is the second typeparam.</typeparam>
        /// <typeparam name="T">This is the first typeparam.</typeparam>
        public delegate void InvalidDelegate39<T, S>();

        /// <summary>
        /// Param tag is missing the name attribute.
        /// </summary>
        /// <param>This is the first param.</param>
        public delegate void InvalidDelegate40(int x);

        /// <summary>
        /// Typeparam tag is missing the name attribute.
        /// </summary>
        /// <typeparam>This is the first typeparam.</typeparam>
        public delegate void InvalidDelegate41<T>();

        /// <summary>
        /// There is no return value but a return tag.
        /// </summary>
        /// <returns>This is the returns description.</returns>
        public delegate void InvalidDelegate42();

        internal delegate void InvalidDelegate53();

        protected delegate void InvalidDelegate44();

        protected internal delegate void InvalidDelegate45();

        private delegate void InvalidDelegate46();

        /////// <summary>
        /////// This is the summary.
        /////// </summary>
        /////// <param name="x">This is the x parameter.</param>
        /////// <param name="y">This is the y parameter.</param>
        /////// <returns>This is the return value.</returns>
        /////// <remarks></remarks>
        ////protected delegate int InvalidDelegate48(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param name="z">This is the third parameter.</param>
        protected delegate void InvalidDelegate49(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <param name="x">This is the first parameter.</param>
        /// <param name="y">This is the second parameter.</param>
        /// <param>This is the third parameter.</param>
        protected delegate void InvalidDelegate50(int x, int y);

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first parameter.</typeparam>
        /// <typeparam name="S">This is the second parameter.</typeparam>
        /// <typeparam name="W">This is the third parameter.</typeparam>
        protected delegate void InvalidDelegate51<T, S>();

        /// <summary>
        /// This is the summary.
        /// </summary>
        /// <typeparam name="T">This is the first parameter.</typeparam>
        /// <typeparam name="S">This is the second parameter.</typeparam>
        /// <typeparam>This is the third parameter.</typeparam>
        protected delegate void InvalidDelegate52<T, S>();

        /// <summary>
        /// This is the summary. Param tag is missing for Z.
        /// </summary>
        /// <param name="x">The first param.</param>
        /// <param name="y">The second param.</param>
        public delegate void InvalidDelegate53(int x, int y, int z);

        /// <summary>
        /// This is a summary for the delegate.
        /// </summary>
        /// <typeparam name="T">This is the first generic parameter.</typeparam>
        public delegate void ValidCovariantDelegate<out T>();

        /// <summary>
        /// This is a summary for the delegate.
        /// </summary>
        /// <typeparam name="T">This is the first generic parameter.</typeparam>
        public delegate void ValidContravariantDelegate<in T>();

        /// <summary>
        /// This is a summary for the delegate.
        /// </summary>
        /// <typeparam name="S">This is the first generic parameter.</typeparam>
        /// <typeparam name="T">This is the first second parameter.</typeparam>
        public delegate void ValidCovariantContravariantDelegate<out S, in T>();

        /// <summary>
        /// This is a summary for the delegate.
        /// </summary>
        public delegate void InvalidCovariantDelegate<out T>();

        /// <summary>
        /// This is a summary for the delegate.
        /// </summary>
        public delegate void InvalidContravariantDelegate<in T>();

        /// <summary>
        /// This is a summary for the delegate.
        /// </summary>
        /// <typeparam name="S">This is the first second parameter.</typeparam>
        public delegate void InvalidCovariantContravariantDelegate<out S, in T>();
    }
}
