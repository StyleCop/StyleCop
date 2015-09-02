namespace StatementsMultipleStatementsOnOneLine
{
    public class Class1
    {
        public bool Method1()
        {
            int a = 0;
            int b = 0; int c = 0;
            int d = 0; int e = 0; int f = 0;

            if (true) return false; if (false) return true;

            if (true) { return false; } if (false) { return true; }

            if (true) 
                { return false; } if (false) { return true; }

            if (true)
            { 
                return false; 
            } if (false) { return true; }

            if (true)
            { 
                return false; 
            } if (false) 
            { 
                return true; 
            }
        }
    }
}