namespace CSharpAnalyzersTest.TestData.CurlyBrackets
{
    public class CurlyBracketsObjectInitializers
    {
        // Invalid Fields
        List<Contact> contacts = new List<Contact> 
        {
            new Contact 
            {
                Name = "Chris Smith",
                PhoneNumbers = { "206-555-0101", "425-882-8080" } },
            new Contact 
            {
                Name = "Bob Harris",
                PhoneNumbers = { "650-555-0199" } } };

        List<Contact> contacts = new List<Contact> {
            new Contact {
                Name = "Chris Smith",
                PhoneNumbers = { "206-555-0101", "425-882-8080" } },
            new Contact {
                Name = "Bob Harris",
                PhoneNumbers = { "650-555-0199" } } };

        List<Contact> contacts = new List<Contact> {
            new Contact {
                Name = "Chris Smith",
                PhoneNumbers = { "206-555-0101", "425-882-8080" }
            },
            new Contact {
                Name = "Bob Harris",
                PhoneNumbers = { "650-555-0199" }
            }
        };

        List<Contact> contacts = new List<Contact> 
        {   new Contact 
            {   Name = "Chris Smith",
                PhoneNumbers = { "206-555-0101", "425-882-8080" }
            },
            new Contact 
            {   Name = "Bob Harris",
                PhoneNumbers = { "650-555-0199" }
            }
        };

        List<Contact> contacts = new List<Contact> 
        {
            new Contact 
            {
                Name = "Chris Smith",
                PhoneNumbers = 
                { "206-555-0101", "425-882-8080" }
            },
            new Contact 
            {
                Name = "Bob Harris",
                PhoneNumbers = 
                { "650-555-0199" }
            }
        };

        var contacts = {
            Name = "Chris Smith",
            PhoneNumber = "206-555-0101"
        };

        var contacts = {
            Name = "Chris Smith",
            PhoneNumber = "206-555-0101" };

        var contacts = 
        {
            Name = "Chris Smith",
            PhoneNumber = "206-555-0101" };

        var contacts = 
        {   Name = "Chris Smith",
            PhoneNumber = "206-555-0101"
        };

        var contacts = 
        { Name = "Chris Smith", PhoneNumber = "206-555-0101" };

        // Valid Fields
        List<Contact> contacts = new List<Contact> 
        {
            new Contact 
            {
                Name = "Chris Smith",
                PhoneNumber = "206-555-0101"
            },
            new Contact 
            {
                Name = "Bob Harris",
                PhoneNumbers = { "650-555-0199" }
            }
        };

        List<Contact> contacts = new List<Contact> 
        {
            new Contact 
            {
                Name = "Chris Smith",
                PhoneNumbers = { "206-555-0101", "425-882-8080" }
            },

            new Contact 
            {
                Name = "Bob Harris",
                PhoneNumbers = { "650-555-0199" }
            }
        };

        List<Contact> contacts = new List<Contact> 
        {
            new Contact { Name = "Chris Smith", PhoneNumbers = { "206-555-0101", "425-882-8080" } },
            new Contact { Name = "Bob Harris", PhoneNumbers = { "650-555-0199" } }
        };

        var contacts = 
        {
            Name = "Chris Smith",
            PhoneNumber = "206-555-0101"
        };

        var contacts = 
        {
            Name = "Chris Smith",

            PhoneNumber = "206-555-0101"
        };

        var contacts = { Name = "Chris Smith", PhoneNumber = "206-555-0101" };

        private void Method()
        {
            // Invalid method variables
            List<Contact> contacts = new List<Contact> 
            {
                new Contact 
                {
                    Name = "Chris Smith",
                    PhoneNumbers = { "206-555-0101", "425-882-8080" } },
                new Contact 
                {
                    Name = "Bob Harris",
                    PhoneNumbers = { "650-555-0199" } } };

            List<Contact> contacts = new List<Contact> {
                new Contact {
                    Name = "Chris Smith",
                    PhoneNumbers = { "206-555-0101", "425-882-8080" } },
                new Contact {
                    Name = "Bob Harris",
                    PhoneNumbers = { "650-555-0199" } } };

            List<Contact> contacts = new List<Contact> {
                new Contact {
                    Name = "Chris Smith",
                    PhoneNumbers = { "206-555-0101", "425-882-8080" }
                },
                new Contact {
                    Name = "Bob Harris",
                    PhoneNumbers = { "650-555-0199" }
                }
            };

            List<Contact> contacts = new List<Contact> 
            {   new Contact 
                {   Name = "Chris Smith",
                    PhoneNumbers = { "206-555-0101", "425-882-8080" }
                },
                new Contact 
                {   Name = "Bob Harris",
                    PhoneNumbers = { "650-555-0199" }
                }
            };

            List<Contact> contacts = new List<Contact> 
            {
                new Contact 
                {
                    Name = "Chris Smith",
                    PhoneNumbers = 
                    { "206-555-0101", "425-882-8080" }
                },
                new Contact 
                {
                    Name = "Bob Harris",
                    PhoneNumbers = 
                    { "650-555-0199" }
                }
            };

            var contacts = {
                Name = "Chris Smith",
                PhoneNumber = "206-555-0101"
            };

            var contacts = {
                Name = "Chris Smith",
                PhoneNumber = "206-555-0101" };

            var contacts = 
            {
                Name = "Chris Smith",
                PhoneNumber = "206-555-0101" };

            var contacts = 
            {   Name = "Chris Smith",
                PhoneNumber = "206-555-0101"
            };

            var contacts = 
            { Name = "Chris Smith", PhoneNumber = "206-555-0101" };

            // Valid method variables.
            List<Contact> contacts = new List<Contact> 
            {
                new Contact 
                {
                    Name = "Chris Smith",
                    PhoneNumber = "206-555-0101"
                },
                new Contact 
                {
                    Name = "Bob Harris",
                    PhoneNumbers = { "650-555-0199" }
                }
            };

            List<Contact> contacts = new List<Contact> 
            {
                new Contact 
                {
                    Name = "Chris Smith",
                    PhoneNumbers = { "206-555-0101", "425-882-8080" }
                },

                new Contact 
                {
                    Name = "Bob Harris",
                    PhoneNumbers = { "650-555-0199" }
                }
            };

            List<Contact> contacts = new List<Contact> 
            {
                new Contact { Name = "Chris Smith", PhoneNumbers = { "206-555-0101", "425-882-8080" } },
                new Contact { Name = "Bob Harris", PhoneNumbers = { "650-555-0199" } }
            };

            var contacts = 
            {
                Name = "Chris Smith",
                PhoneNumber = "206-555-0101"
            };

            var contacts = 
            {
                Name = "Chris Smith",

                PhoneNumber = "206-555-0101"
            };

            var contacts = { Name = "Chris Smith", PhoneNumber = "206-555-0101" };
        }
    }
}
