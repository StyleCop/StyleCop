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

        public async void Method2()
        {
            RemoteInteger result = await (remoteInt1 / remoteInt2);
        }
    }

    public enum SyncAsyncType
    {
        sync,
        async,
        asynclikesync,
        multipleAsync
    }
}

namespace ConsoleApplication1
{
    class Program
    {
        private bool async;
 
        public bool Async { get; set; }
 
        public void SomeMethod(bool async) { this.async = async; this.Async = async;  }
 
        public void SomeOtherMethod(Async async) { }
 
        public void SomeOtherOther(AsyncStuff asyncStuff) { if (asyncStuff == AsyncStuff.async) Console.WriteLine("blah"); }
 
        static void Main(string[] args)
        {
        }
    }
 
    public enum Async
    {
        stuff
    }
 
    public enum AsyncStuff
    {
        sync,
        async
    }

    public enum AsyncStuff
    {
        sync,
        async,
        await
    }
}

namespace ConsoleApplication2
{
    class Program
    {
        private bool async;
        private bool await;

        public bool Async { get; set; }
        public bool Await { get; set; }

        public void SomeMethodAsync(bool async) { this.async = async; this.Async = async;  }
        public void SomeMethodAwait(bool await) { this.await = await; this.Await = await; }

        public void SomeOtherMethodAsync(Async async) { }
        public void SomeOtherMethodAwait(Await await) { }

        public void SomeOtherOtherAsync(AsyncStuff asyncStuff) { if (asyncStuff == AsyncStuff.async) Console.WriteLine("blah"); }
        public void SomeOtherOtherAwait(AsyncStuff asyncStuff) { if (asyncStuff == AsyncStuff.await) Console.WriteLine("blah"); }

        public async void AnAsyncMethod()
        {
            await Task.Factory.StartNew(() => { });
        }

        static void Main(string[] args)
        {
        }
    }

    public enum Async
    {
        stuff
    }

    public enum Await
    {
        stuff
    }

    public enum AsyncStuff
    {
        sync,
        async,
        await
    }
}

 
