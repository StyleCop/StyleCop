namespace CSharpAnalyzersTest.TestData
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class PrefixLocalCallsWithThis
    {
        private string firstName = string.Empty;
        private string lastName = string.Empty;
        private int value = 2;

        private void Method1(int x)
        {
            // Violations
            firstName = null;
            lastName = null;

            // Violations
            string x = firstName.Length.ToString();
            string y = lastName.Length.ToString();

            // Violations
            if (x == firstName || x == lastName)
            {
            }

            // Define a local called firstName.
            for (string firstName = null; firstName != null; firstName += "x")
            {
                // No violations for firstName, but violations for lastName.
                firstName = null;
                lastName = null;

                string a = firstName.Length.ToString();
                string b = lastName.Length.ToString();

                while (a == firstName || a == lastName)
                {
                    a = null;
                }
            }

            // Violations
            firstName = null;
            lastName = null;

            // Violations
            string x = firstName.Length.ToString();
            string y = lastName.Length.ToString();

            // Violations
            if (x == firstName || x == lastName)
            {
            }

            // Define a local called lastName;
            int lastName = 0;
            int c = lastName; // no violation.
            int d = firstName.Length; // violation.
        }

        private void Method2(string firstName)
        {
            int x = firstName.Length; // no violation
            int y = lastName.Length; // violation

            string lastName = "";
            int z = lastName.Length; // no violation.
        }

        private int this[double lastName]
        {
            get
            {
                int x = firstName.Length; // violation
                int y = lastName.Length; // no violation

                string firstName = "";
                int z = firstName.Length; // no violation.

                int xx = value; // violation.
            }

            set
            {
                int x = firstName.Length; // violation
                int y = lastName.Length; // no violation

                // violation for firstName, not for lastName.
                foreach (int yy in new int[] 
                    { 
                        firstName.Length, 
                        lastName.Length 
                    })
                {
                }

                string firstName = "";
                int z = firstName.Length; // no violation.

                int xx = value; // no violation since value is an implicit variable in the set clause.
            }
        }

        private void QueryExpressionsMethod()
        {
            // Violation for use of firstName and lastName.
            from Customer c in firstName.Length
            let x = lastName;

            // Violation only for use of firstName.
            from Customer lastName in firstName.Length
            let x = lastName;

            // Violation only for use of lastName.
            from Customer firstName in firstName.Length
            let x = lastName;

            // Violation for use of firstName.
            from Customer c in x
            let y = z
            where firstName != null;

            // No violations.
            from Customer c in x
            let firstName = z
            where firstName != null;

            // No violations. Included continuation clause.
            from Customer c in x
            let firstName = z
            into lastName
            where firstName != null && lastName != null;

            // Violation for use of firstName.
            from Customer c in x
            join y in a on b equals z
            where firstName != null;

            // No violations.
            from Customer c in x
            join firstName in a on b equals z
            where firstName != null;

            // No violations.
            from Customer c in x
            join y in a on b equals z into firstName
            where firstName != null;

            // Violation for use of firstName.
            from c in x
            select firstName;

            // No violations.
            from firstName in x
            select firstName;

            // Violation for use of firstName.
            from c in x
            group firstName by z;

            // Violation for use of firstName.
            from c in x
            group z by firstName;

            // No violations.
            from firstName in x
            group firstName by z;

            // No Violations
            from firstName in x
            group z by firstName;

            // Violation for use of firstName.
            from c in x
            into z
            select firstName;

            // No violations
            from c in x
            into firstName
            select firstName;
        }

        public void VariablesUsedAfterQueryClauses()
        {
            // No violations. Included continuation clause.
            from Customer c in x
            let firstName = z
            into lastName
            where firstName != null && lastName != null;

            // Even though a variable called firstName and lastName are defined in the query
            // clause, when we use them now we should get a violation becuase they were 
            // local to the query clause.
            firstName = null;
            lastName = null;
        }

        public void VariablesUsedAfterQueryClauses()
        {
            // Even though a variable called firstName and lastName are defined in the query
            // clause, when we use them now we should get a violation becuase they were 
            // local to the query clause, and also these are used before the query clause.
            firstName = null;
            lastName = null;

            // No violations. Included continuation clause.
            from Customer c in x
            let firstName = z
            into lastName
            where firstName != null && lastName != null;

        }
    }
}
