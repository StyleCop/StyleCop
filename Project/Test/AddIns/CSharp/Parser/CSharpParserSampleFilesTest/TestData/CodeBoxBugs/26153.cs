class A
{
    public static void Main()
    {
        int x = 1;
        switch (x)
        {
            case unchecked(1): break;
        }
    }
}
