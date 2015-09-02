namespace StyleCopBug
{
    class Repro
    {
        void StyleCopThrowsNullReferenceException()
        {
            int n = 0;
            System.Threading.ThreadPool.QueueUserWorkItem((o) => ++n);
        }
    }
}
