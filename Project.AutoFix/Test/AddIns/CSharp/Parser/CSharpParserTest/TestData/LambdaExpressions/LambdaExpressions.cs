namespace CSharpParserTest.TestData
{
    public class LambdaExpressions
    {
        public void Method()
        {
            x => x + 1;                          // Implicitly typed, expression body
            x => { return x + 1; };              // Implicitly typed, statement body
            (int x) => x + 1;                    // Explicitly typed, expression body
            (int x) => { return x + 1; };        // Explicitly typed, statement body
            (int x, int y) => x - y;             // Multiple explicitly typed parameters, expression body
            (int x, int y) => { return x - y; }; // Multiple explicitly typed parameters, statement body
            (x, y) => x * y;                     // Multiple parameters, expression body
            (x, y) => { return x * y; };         // Multiple parameters, statement body
            () => Console.WriteLine();           // No parameters, expression body
            () => { Console.WriteLine(); };      // No parameters, statement body

            x=>x+1;                              // Implicitly typed, expression body
            x=>{return x+1;};                    // Implicitly typed, statement body
            (int x)=>x+1;                        // Explicitly typed, expression body
            (int x)=>{return x+1;};              // Explicitly typed, statement body
            (int x,int y)=>x-y;                  // Multiple explicitly typed parameters, expression body
            (int x,int y)=>{return x-y;};        // Multiple explicitly typed parameters, statement body
            (x,y)=>x*y;                          // Multiple parameters, expression body
            (x,y)=>{return x*y;};                // Multiple parameters, statement body
            ()=>Console.WriteLine();             // No parameters, expression body
            ()=>{Console.WriteLine();};          // No parameters, statement body
        }

        public void AdvancedLambdas()
        {
            duplicateProjects.Iterate(duplicateProject =>
            {
                foreach (EnvDTE.ProjectItem item in duplicateProject.ProjectItems)
                {
                    item.SubProject.Save(item.SubProject.FileName);
                }
            });

            codeModelEvents.ElementChanged += element =>
                {
                    elementChangedHandler(element);
                };

            codeModelEvents.ElementChanged += (element, change) =>
                {
                    elementChangedHandler(element, change);
                };
        }
    }
}
