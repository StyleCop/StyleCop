namespace N
{
    class Incorrect
    {
        private bool _b1 = 1 == 0;
        private bool _bx = 24 * 60 > 1000 == _b1; // Violation
        private bool _b2 = true == _b1, _b3 = (false) == (_b1), _b4 = true == (_b1 != false); // Violation

        private string s;
        private bool _b5 = "abcd" == s; // Violation

        private void F()
        {
            int a = 1 + 1;

            if (5 == a) // Violation
            {
            }

            for (int j = 0; (5 * 1024) + 1 > j; j++) // Violation
            {
            }

            object x;
            if (null == x) // Violation
            {
            }

            bool b;
            if (true == b) // Violation
            {
            }

            if (false == b) // Violation
            {
            }

            while (true == b) // Violation
            {
            }

            do
            {
            }
            while (1 < a); // Violation

            if (true == b || a == 0) // Violation
            {
            }

            if (a == 0 && (true == b) && null == x) // Violation
            {
            }

            if (b || true || null != x) // Violation
            {
            }

            if (null == x && 1 == a) // Violation
            {
            }

            if (a == 1)
            {
            }
            else if (false == b) // Violation
            {
            }
        }
    }

    class Correct
    {
        private bool _b1 = 1 == 0;
        private bool _bx = _b1 == 24 * 60 > 1000;
        private bool _b2 = _b1 == true, _b3 = (_b1) == (false), _b4 = (_b1 != false) == true;

        private string s;
        private bool _b5 = s == "abcd";

        private void F()
        {
            int a = 0;

            if (a == 5)
            {
            }

            object x;
            if (x == null)
            {
            }

            bool b;
            if (b == true)
            {
            }

            if (b == false)
            {
            }

            while (b == true)
            {
            }

            do
            {
            }
            while (a > 1);

            if (b == true || a == 0)
            {
            }

            if (a == 0 && (b == true) && x == null)
            {
            }

            if (b || true || x != null)
            {
            }

            if (x == null && a == 1)
            {
            }

            if (a == 1)
            {
            }
            else if (b == false)
            {
            }
        }
    }
}