using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpAnalyzersTest.TestData.Spacing
{
    public class StringInterpolation
    {
        public void TestSpaceForInterpolation()
        {
            string argumentName = "Test";
            int argIndex = 1;
            string[] arguments = new string[10];

            arguments[0] = "Test";   
            arguments[1] = "Test1"; 

            Console.WriteLine( $"{argumentName}[{argIndex}] =; \"{arguments[argIndex]}\"");
            var test =  $"{argumentName}[{argIndex}] = ; \"{arguments[argIndex]}\"";

            Console.WriteLine($"{argumentName}[{argIndex}] = ; \"{arguments[argIndex]}\"") ;
            Console.WriteLine($"{argumentName}[{argIndex}] = ; \"{arguments[argIndex]}\"" );
            test = $"{argumentName}[{argIndex}] = \"{arguments[argIndex]}\"" ;

            Console.WriteLine( $"{argumentName}[{argIndex}] = ;\"{arguments[argIndex]}\"" ) ;
            test =  $"{argumentName}[{argIndex}] = ; \"{arguments[argIndex]}\"" ;

            Console.WriteLine(          $"{argumentName}[{argIndex}] = ; \"{arguments[argIndex]}\""     )        ;
            test =        $"{argumentName}[{argIndex}]  ; =     \"{arguments[argIndex]}\""     ;  

            Console.WriteLine($"{argumentName}[{argIndex}] = \"{arguments[argIndex]}\"");
            test = $"{argumentName}[{argIndex}] = \"{arguments[argIndex]}\"";
        }
    }
}
