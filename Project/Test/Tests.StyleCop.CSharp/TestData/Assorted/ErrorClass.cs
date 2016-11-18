namespace StyleCopRepro
{
    public class ErrorClass
    {
        public string[] MyMethod()
        {
            string[] myStrings = new string[]
                {
                    "VerifiedByMedicalRecordOnly", 
                    "Aborted"
                };

            return myStrings;
        }
    }
}
