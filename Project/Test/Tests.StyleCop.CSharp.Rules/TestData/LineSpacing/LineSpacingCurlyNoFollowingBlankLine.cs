#region Namespaces

namespace LineSpacingCurlyNoFollowingBlankLine1
{
}
namespace LineSpacingCurlyNoFollowingBlankLine2
{
}

#endregion Namespaces

#region Class, Struct, Interface

namespace LineSpacingCurlyNoFollowingBlankLine3
{
    public class Class1
    {
    }
    public class Class2
    {
    }

    public struct Struct1
    {
    }
    public struct Struct2
    {
    }

    public interface Interface1
    {
    }
    public interface Interface2
    {
    }
}

#endregion Class, Struct, Interface

#region Method, Property, Enum, etc

namespace LineSpacingCurlyNoFollowingBlankLine4
{
    public class Class1
    {
        // Constructors
        public Class1()
        {
        }
        public Class1()
        {
        }

        // Destructors
        ~Class1()
        {
        }
        ~Class1()
        {
        }

        // Methods
        public void Method1()
        {
        }
        public void Method2()
        {
        }

        // Properties
        public bool Property1
        {
        }
        public bool Property2
        {
        }

        public bool Property3
        {
            get
            {
            }
            set 
            { 
            }
        }

        public bool Property4
        {
            set 
            { 
            }
            get
            {
            }
        }

        // Indexers
        public bool this[int x]
        {
        }
        public bool this[short x]
        {
        }

        public bool this[long x]
        {
            get
            {
            }
            set
            {
            }
        }

        public bool this[float x]
        {
            set
            {
            }
            get
            { 
            }
        }

        // Enums
        public enum Enum1
        {
        }
        public enum Enum1
        {
        }
    }
}

#endregion Method, Property, Enum, etc

#region If, While, For, etc.

namespace LineSpacingCurlyNoFollowingBlankLine5
{
    public class Class1
    {
        public void Method1()
        {
            // Block statement
            {
            }
            {
            }

            // try/catch/finally
            try
            {
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }
            try
            {
            }
            catch (System.Exception ex)
            {
            }
            finally
            {
            }

            // if-else
            if (true)
            {
            }
            else if (false)
            {
            }
            else
            {
            }
            if (true)
            {
            }
            else if (false)
            {
            }
            else
            {
            }

            // lock
            lock (this)
            {
            }
            lock (this)
            {
            }

            // switch
            int switcher = 0;
            switch (switcher)
            {
            }
            switch (switcher)
            {
            }

            // unsafe
            unsafe
            {
            }
            unsafe
            {
            }

            // using
            using (Form form1 = new Form())
            {
            }
            using (Form form1 = new Form())
            {
            }

            // while
            while (true)
            {
            }
            while (true)
            {
            }
        }
    }
}

#endregion If, While, For, etc.

#region Events

namespace LineSpacingCurlyNoFollowingBlankLine6
{
    public class Class1
    {
        // Properties
        public event EventHandler Event1
        {
        }
        public event EventHandler Event2
        {
        }

        public event EventHandler Event3
        {
            add
            {
            }
            remove
            {
            }
        }

        public event EventHandler Event4
        {
            remove
            {
            }
            add
            {
            }
        }
    }
}

#endregion Events

namespace A
{
    class B
    {
        var items = from item in this.DataContext.Items
                    join location in this.DataContext.Locations on item.ProductId equals location.ProductId
                    join shelf in this.DataContext.Shelfs on location.ShelfId equals shelf.Id
                    join price in this.DataContext.Prices on item.Id equals price.ItemId
                    where shelf.SubcategoryId == subcategoryId && price.RegionId == region.Id
                    orderby shelf.Position
                    group new ItemViewModel
                    {
                        Item = item,
                        Image = item.Image,
                        Price = price
                    }
                    by shelf;
    }

    class C
    {
        private string Method1()
        {
            return (from data1 in new xDataItem
            {
                Table = SimpleTable,
                Columns = new[] { new FieldColumnModel(SimpleTableFields[0], "col1") },
                Name = "data1"
            }
                    from data2 in new xDataItem
                    {
                        Table = SimpleTable,
                        Columns = new[] { new FieldColumnModel(SimpleTableFields[0], "col2") },
                        Name = "data2"
                    }
                    from data3 in new xDataItem
                    {
                        Table = SimpleTable,
                        Columns = new[] { new FieldColumnModel(SimpleTableFields[0], "col3") },
                        Name = "data3"
                    }
                    select data1).ToxModel(name, id);
        }
    }
}