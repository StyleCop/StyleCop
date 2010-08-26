using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    using System.Xml;

    class CloseCurlyBracket
    {
        public void Method1()
        {
            while (true) {} //invalid
        }

        public static Dictionary<Enum, ValidationType> Rules
        {
            get
            {
                return
                    new List<ValidationType>
                            {
                                new ValidationType
                                    {
                                        Key = Keys.validatePinValid,
                                        ServerFunction = failsOnExceptionServerFunc,
                                        ClientFunction = failsOnServerClientScript,
                                        ErrorMessage = DataEntryResources.PinCorrectError
                                    },
                            }.ToDictionary(i => i.Key); // valid spacing after the clsoing curly bracket
            }
        }
    }
}
