class Class1
{
    public void Method()
    {
        var data = from pr in value
                   from pref in pr.rolepreferences
                   select new { programname = pr.incentiveprogram.name, rolename = pref.role.name, rolestatus = pref.rolestatus.name };
    }
}
