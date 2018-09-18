namespace MethodCallMultiLineParameter
{
    using System;

    public class Class1
    {
        public void Method1()
        {
            SomeClass.Method1(
                0,
                " this string " +
                " is illegal",
                1);

            SomeClass.Method2(
                0,
                1,
                " this string " +
                " is illegal");

            SomeClass.Method3(
                " this string " +
                " is legal",
                " this string " +
                " is illegal",
                " this string " +
                " is illegal");

            SomeClass.Method4(
                " this string " +
                " is legal",

                " this string " +
                " is illegal",
                
                " this string " +
                " is illegal");

            SomeClass.Method5(
            " this string " +
            " is legal",
            x,
            " this string " +
            " is illegal");

            SomeClass.Method6(
                " this string " +
                " is legal",
                delegate
                {
                    int x = 0;
                },
                " this string " +
                " is illegal");

            SomeClass.Method7(
                " this string " +
                " is legal",
                SomeClass.MethodX(0, 1 , 2),
                " this string " +
                " is illegal");

            SomeClass.Method8(
                SomeClass.MethodX(0, 1, 2),
                SomeClass.MethodX(0, 1, 2),
                SomeClass.MethodX(0, 1, 2));

            SomeClass.Method9(
                SomeClass.MethodX(
                    0, 
                    1, 
                    2),
                SomeClass.MethodX(
                    0, 
                    1, 
                    2),
                SomeClass.MethodX(
                    0, 
                    1, 
                    2));

            SomeClass.Method10(
                SomeClass.MethodX(
                    0,
                    1,
                    2),

                 SomeClass.MethodX(
                    0,
                    1,
                    2),

                 SomeClass.MethodX(
                    0,
                    1,
                    2));

            SomeClass.Method10(
                    SomeClass.MethodX(
                        0,
                        1,
                        2),
                     SomeClass.MethodX(
                        0,
                        "string " +
                        "string2",
                        2));

            report.Render(
                this.Options.FileFormat,
                this.Options.FileMetadata,
                out string mimeType,
                out string encoding,
                out string fileNameExtension,
                out string[] streams,
                out Warning[] warnings);
        }
    }
}
