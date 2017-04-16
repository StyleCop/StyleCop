using System;
using System.Collections.Generic;

namespace Operator
{
    public class TernaryOperator
    {
        public long?[] GetSelectedOrgIds()
        {
            string a = true ? "true" : "false";
            string b = true ? "true" : "false";
            string c =
                true ?
                "true" :
                "false";
            string d =
                true ?
                "true" :
                "false";
            string e
                = true
                ? "true"
                : "false";
            string f
                = true
                ? "true"
                : "false";
            return BulkScheduleEvents == null
                ? new long?[0]
                : BulkScheduleEvents.Where(a => a.IsChecked).Select(a
=> a.OrganizationId).ToArray();
        }

        public void TestTernaryOperatorWithThrowExpressions()
        {
            return (parts.Length > 0) ? parts[0] : throw new InvalidOperationException("No name!");
            return (parts.Length < 2) ? throw new InvalidOperationException("No name!") : parts[1];    
        }
    }
}
