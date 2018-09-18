namespace CloseParenthesisSpacing
{
    public class Class1
    {
        public void ClosingParensPrecededByWhitespace()
        {
            string a = (string)null;

            string b = (string )null;

            string c = (string
                )null;

            string d = (string
)null;

            string e = (string)null;

            if (true)
            {
            }

            if (true )
            {
            }

            if (true
                )
            {
            }

            if (true
)
            {
            }

            int f = (2 + (2 - (4 - (5))));
            int g = (2 + (2 - (4 - (5))) );
            int h = (2 + (2 - (4 - (5)) ));
            int i = (2 + (2 - (4 - (5) )));
            int j = (2 + (2 - (4 - (5 ))));
        }

        public void CastsFollowedByWhitespace()
        {
            string a = (string)null;
            string b = (string) null;
            string c = (string)
                null;

            string d = (string)
null;

            string e = (string)(object)null;
            string f = (string) (object)null;
        }

        public void NonCastFollowedByWhitespace()
        {
            int x = (2 + (2 + 2)); // valid
            int x = (2 + (2 + 2) ); // close paren followed by space followed by close paren.
            int x = (2 + (2 + 2)) ; // close paren followed by space followed by semicolon.
            SomeMethod((2 + (2 + 2)), 2); // valid
            SomeMethod((2 + (2 + 2)) , 2); // close paren followed by space followed by comma.
            int x = (x)[2]; // valid
            int x = (x) [2]; // close paren followed by space followed by open square bracket.
            int x = x[(2)]; // valid
            int x = x[(2) ]; // close paren followed by space followed by close square bracket.
        }

        public void SpaceBetweenParensInMethodDeclaration( )
        {
        }

        public void Colon()
        {
            int x = 2;
            switch (x)
            {
                case (2): // valid
                    break;

                case (2) : // invalid
                    break;
            }

            int a = true ? (1): 2; // invalid
            int a = true ? (1) : 2; // valid
        }

        public void NonCastNotFollowedByWhitespace()
        {
            // Everything below is invalid because the close paren should never be followed by whitespace.
            int a = (true)? 1 : 2;
            int a = true ? (1): 2;
            int a = (2)+ 3;
            int a = (2)- 3;
            int a = (2)* 3;
            int a = (2)/ 3;
        }

        public void Others()
        {
            // Allowed
            value.ToString().ToString();
            value.ToString()
                .ToString();

            (value)++;
            (value)
                ++;

            (value)--;
            (value)
                --;

            // Not Allowed
            value.ToString() .ToString();
            (value) ++;
            (value) --;

            unsafe
            {
                // Allowed
                int* something;
                (something)->ToString();
                (something)
                    ->ToString();

                // Not allowed
                (something) ->ToString();
            }
        }
    }

    [SomeAttribute("value")]
    [SomeAttribute("value") ]
    class CWA
    {
    }

    public class Class21
    {     
        public static void Test<T>(T value = default(T) )
        {
        }

        public void TestForIssue141()
        {
            List<(string, int)> listOfTuple = new List<(string, int)>();

            // The following should raise a violation
            List<(string, int) > listOfTuple1;
            List<(string, int )> listOfTuple1;
        }
    }
}
