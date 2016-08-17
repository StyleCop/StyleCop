namespace InvalidQueryClauses
{
    public class Class1
    {
        public bool Method()
        {
            // A blank line between two query clauses.
            from c in customers 

            group c by c.Country 
            where c.IsFat();

            // A blank line between two query clauses.
            from c in customers 
            group c by c.Country 

            where c.IsFat();

            // A blank line between two query clauses.
            from c in customers 


            group c by c.Country 

            where c.IsFat();

            // Clauses on the same line and on separate lines.
            from c in customers group c by c.Country 
            where c.IsFat();

            // Clauses on the same line and on separate lines.
            from c in customers 
            group c by c.Country where c.IsFat();

            // A clause spanning multiple lines with another clause attached to the same line.
            from c in 
            customers group c by c.Country where c.IsFat();

            // A clause in the middle spanning multiple lines, on the same line as the previous
            // clause, with another clause tacked to the end.
            from c in customers group c by 
            c.Country where c.IsFat();

            // The last attached clause spanning multiple lines.
            from c in customers group c by c.Country where 
            c.IsFat();
        }
    }
}