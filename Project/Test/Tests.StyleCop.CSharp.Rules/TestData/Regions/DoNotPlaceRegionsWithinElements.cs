#region Region1
namespace DoNotUseRegionsWithinElements
{
    public class Class1
    {
        #region Region2
        public bool Method()
        {
            #region Region3
            #endregion

            #region Region3
            int x = 0;
            #endregion
            #region Region4

            #region XXX generated code
            #region Region within generated code
            #endregion
            #endregion
        }
            #endregion
        #endregion
    }
}
#endregion