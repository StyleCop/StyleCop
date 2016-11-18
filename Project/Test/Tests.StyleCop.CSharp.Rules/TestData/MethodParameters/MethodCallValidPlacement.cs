namespace MethodCallValidPlacement1
{
    using System;

    #region known error

    public class KnownError
    {
        public void TestMethod()
        {
            // create one error. The test will check to make sure that this is the only
            // violation seen within this file.
            SomeClass.Method1(
                );
        }
    }

    #endregion known error

    #region Normal Methods
    
    public class NormalMethods1
    {
        public void TestMethod()
        {
            int x, y;

            // Valid placement
            SomeClass.Method1();

            SomeClass.Method2(x);

            SomeClass.Method3(
                x);

            SomeClass.Method4(x, y);

            SomeClass.Method5(x,y);

            SomeClass.Method6(x,  y);

            SomeClass.Method7(
                x, y);

            SomeClass.Method8(
                x,y);

            SomeClass.Method9(
                x,
                y);

            // These are valid because the first parameter is allowed to span multiple lines.
            SomeClass.Method10("this is" +
                "a string");

            SomeClass.Method12(out 
                x);
        }
    }

    #endregion Normal Methods

    #region Comments

    public class Comments
    {
        public void TestMethod()
        {
            int x, y, z;
            SomeClass.Method1(/* */);

            SomeClass.Method2(/*
             */
               );

            SomeClass.Method3(
                x /*
                       */);






            SomeClass.Method5(/* This is a comment */x);

            SomeClass.Method6(
                /* This is a comment */x);

            SomeClass.Method7(
                // This is a comment
                /* This is a comment */
                x);

            SomeClass.Method8(/* This is a comment */ x, /* This is a comment */y);

            SomeClass.Method9(
                /* This is a comment */x, /* This is a comment */ y);

            SomeClass.Method10(
                /* This is a comment */ x,
                /* This is a comment */ y);

            SomeClass.Method11(
                /* This is a comment */
                // This is a comment
                x,
                // This is a comment
                /* This is a comment */ 
                y);

            SomeClass.Method12(
                /* This is a 
                 * comment */     x,
                /* This is a 
                 * comment */     y);

            SomeClass.Method13(
                // This is a comment
                /* This is a 
                 * comment */
                x,
                /* This is a 
                 * comment */
                // This is a comment
                y);

            // These are valid because the first parameter is allowed to span multiple lines.
            SomeClass.Method14(/* This is a comment */"this is " +
                "a string");

            SomeClass.Method15(/* This is a comment */
                "this is" +
                "a string");

            SomeClass.Method16(
                /* This is a comment */"this is" +
                "a string");

            SomeClass.Method17(
                /* This is a comment */
                "this is " +
                "a string");

            SomeClass.Method18(
                /* This is a 
                 * comment */
                // This is a comment
                "this is "+
                "a string");

            SomeClass.Method19(/* This is a comment */out 
                x);

            SomeClass.Method20(/* This is a comment */
                out 
                x);

            SomeClass.Method22(
                // This is a comment
                /* This is a comment */
                out
                x);

            SomeClass.Method23(
                /* This is a 
                 * comment */
                // This is a comment
                out
                x);

            SomeClass.Method24(
                /* This is a 
                 * comment */
                // This is a comment
                out
                x/*
                  
                  
                  */);
        }
    }

    #endregion Comments

    #region Anonymous methods

    /// <summary>
    /// Inline delegates are allowed to be multiple lines no matter what
    /// position they are at in the parameter list.
    /// </summary>
    public class Delegates
    {
        public void TestMethod()
        {
            SomeClass.Method1(delegate
            {
                int y = 0;
            });

            SomeClass.Method2(
                0,
                delegate
                {
                    int y = 0;
                });

            SomeClass.Method3(
                0,
                1,
                delegate
                {
                    int y = 0;
                });

            SomeClass.Method3(
                delegate
                {
                    int x = 0;
                },
                delegate
                {
                    int y = 0;
                },
                delegate
                {
                    int z = 0;
                });

            SomeClass.Method4(
                " a string " +
                " more string",
                delegate
                {
                    int y = 0;
                },
                delegate
                {
                    int z = 0;
                },
                0);
        }
    }

    #endregion Anonymous methods

    #region Lambda expressions

    /// <summary>
    /// Lambda expressions are allowed to be multiple lines no matter what
    /// position they are at in the parameter list.
    /// </summary>
    public class Delegates
    {
        public void TestMethod()
        {
            SomeClass.Method1((a, b) =>
            {
                int y = 0;
            });

            SomeClass.Method2(
                0,
                (a, b) =>
                {
                    int y = 0;
                });

            SomeClass.Method3(
                0,
                1,
                (a, b) =>
                {
                    int y = 0;
                });

            SomeClass.Method3(
                (a, b) =>
                {
                    int x = 0;
                },
                (a, b) =>
                {
                    int y = 0;
                },
                (a, b) =>
                {
                    int z = 0;
                });

            SomeClass.Method4(
                " a string " +
                " more string",
                (a, b) =>
                {
                    int y = 0;
                },
                (a, b) =>
                {
                    int z = 0;
                },
                0);
        }
    }

    #endregion Lambda Expressions

    #region SubMethods

    public class SubMethods
    {
        public void TestMethod()
        {
            int x, y;
            SomeMethod.Method1(
                SomeMethod.Method2(
                    SomeMethod.Method3(
                        delegate
                        {
                            int y = 0;
                        },
                        delegate
                        {
                            int y = 0;
                        }),
                    delegate
                    {
                        int y = 0;
                    },
                    delegate
                    {
                        int y = 0;
                    }),
                delegate
                {
                    int y = 0;
                },
                delegate
                {
                    int y = 0;
                });

            SomeMethod.Method1(
                SomeMethod.Method2(
                    SomeMethod.Method3(
                        "this is " +
                        " a string",
                        y),
                        0,
                        1),
                    x,
                    y);
        }
    }

    #endregion SubMethods

    #region Other

    public class Other
    {
        public void Method1()
        {
            // Method call with a complex method name.
            ((SomeType)item).SomeMethod<OtherType>(
                new AnotherType<OtherType>(this.AnotherMethod),
                item2);
        }
    }
    #endregion
}
