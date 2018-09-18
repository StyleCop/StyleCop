namespace StyleCop.CSharpParserTest.TestData
{
    using System;

    public class QueryExpressions
    {
        public void Method()
        {
            // A simple from clause with no body.
            from c in customers;
            
            // A simple from clause with no body and an explicit variable type.
            from int[] c in customers;

            // Two from clauses.
            from int[] c in customers
            from d in deltas;

            // Multiple let clauses.
            from c in customers
            let address = c.Address
            let area = c.PhoneNumber.AreaCode;

            // A join clause.
            from c in customers
            join a in address on c.ZipCode equals a.ZipCode;

            // A join clause with an into variable.
            from c in customers
            join a in address on c.ZipCode equals a.ZipCode into g;

            // Multiple join clauses.
            from c in customers
            join a in address on c.ZipCode equals a.ZipCode
            join n in phonenumber on c.AreaCode equals n.AreaCode into x;

            // A simple order-by clause.
            from c in customers
            orderby c.LastName;

            // An order-by clause with a direction keyword.
            from c in customers
            orderby c.LastName ascending;

            // Two orderings.
            from c in customers
            orderby c.LastName, c.FirstName;

            // Two orderings with direction keywords.
            from c in customers
            orderby c.LastName descending, c.FirstName ascending;

            // Multiple order-by clauses.
            from c in customers
            orderby c.LastName descending, c.FirstName ascending
            orderby c.Address;

            // A select clause.
            from c in customers
            select c.Name;

            // A group clause.
            from c in customers
            group c by c.Country;

            // A simple query continuation clause.
            from c in customers
            group c by c.Country into g
            select g.Key;

            // A query expression with a complex let-clause followed by another query clause.
            var test =
            from itm in new int[] { 1, 2, 3, 4, 5 }
            let i = itm == 1 ? 1 : 0
            select i;
            
            // Bug 6711 This was failing because the check for casting thought b.Equals was a cast of select
            var a = (from b in new int[] { 1, 2, 3, 4, 5}
            where true && (b.Equals)select b).First();

            // Bug 6711 This was failing because the check for casting thought b.Equals was a cast of select
            var a = (from b in new int[] { 1, 2, 3, 4, 5}
            where true || (b.Equals)select b).First();

            // Bug 6711 This was failing because the check for casting thought b.Equals was a cast of select
            var a = (from b in new int[] { 1, 2, 3, 4, 5}
            where true != (b.Equals)select b).First();

            // Issue 171, Regression from handling pattern matching
            result = (from p in layout.Elements where p is IMetaPropertyLink select (IMetaPropertyLink)p).ToList();
        }
    }
}
