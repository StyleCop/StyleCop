public class C
{
    void M()
    {
        var test =
        from itm in new int[] { 1, 2, 3, 4, 5 }
        let i = itm == 1 ? 1 : 0
        select i; 
    }
}