namespace CSharpAnalyzersTest.TestData.ClassMembers
{
    using static System.Math;

    /// <summary>
    /// Test the this expression for bodied member.
    /// </summary>
    public class ClassMembersPrefixLocalCallsWithThisForBodied
    {
        /// <summary>
        /// The test variable x.
        /// </summary>
        private double x = 3;

        /// <summary>  
        /// The test variable y.
        /// </summary> 
        private double y = 4;

        /// <summary> v
        /// The test variable yy.  
        /// </summary>  
        private double yy = 4;

        /// <summary>
        /// The test variable xx. 
        /// </summary> 
        private double xx = 3;

        /// <summary>
        /// The distance.
        /// </summary>
        public double Distance => Sqrt((yy * xx) + (yy * yy));

        /// <summary>
        /// Gets the distance2 method.
        /// </summary>
        public double Distance2() => Sqrt((yy * xx) + (yy * yy));

        /// <summary>
        /// Gets the distance property regular.
        /// </summary>
        public double DistanceRegular
        {
            get
            {
                return Sqrt((yy * xx) + (yy * yy));
            }
        }
    }
}