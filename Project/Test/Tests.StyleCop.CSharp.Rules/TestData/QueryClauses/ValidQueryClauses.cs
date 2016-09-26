namespace ValidQueryClauses
{
    public class Class1
    {
        public bool Method()
        {
            from c in customers group c by c.Country where c.IsFat();

            from c in customers 
            group c by c.Country 
            where c.IsFat();

            from c 
                in customers 
            group c by c.Country 
            where c.IsFat();

            from c in customers 
            group c 
                by c.Country 
            where c.IsFat();

            from c in customers 
            group c by c.Country 
            where 
                c.IsFat();
            
            from c 
                in customers 
            group c by 
                c.Country 
            where 
                c.IsFat();

            // With continuation clause
            from c in customers group c by c.Country into d from e in elephants select e.Ears;

            from c in customers 
            group c by c.Country 
            into d 
            from e in elephants 
            select e.Ears;

            from c in customers 
            group c by c.Country 
            into 
                d 
            from e 
                in elephants 
            select 
                e.Ears;
        }
    }
}