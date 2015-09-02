namespace InvalidContinuationQueryClauses
{
    public class Class1
    {
        public bool Method()
        {
            // A blank line between two query clauses.
            from c in customers 
            group c by c.Country 
            into d

            select c.Name;

            // A blank line between two query clauses.
            from c in customers 
            group c by c.Country 
            into d
            from e in elephants

            select c.Name;

            // Clauses on the same line and on separate lines.
            from c in customers group c by c.Country into d
            select c.Name;

            from c in customers group c by c.Country into d from e in elephants
            select c.Name;

            // A clause spanning multiple lines with another clause attached to the same line.
            from c in customers group c by c.Country into 
                d select c.Name;

            from c in customers group c by c.Country into d select 
                c.Name;

            from c in customers group c by c.Country into d select c.Name from e
                in elephants;
        }
    }
}