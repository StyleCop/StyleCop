using System;
using System.Collections.Generic;

namespace Operator
{
    public class TernaryOperator
    {
        public long?[] GetSelectedOrgIds()
        {
            return BulkScheduleEvents == null
                ? new long?[0]
                : BulkScheduleEvents.Where(a => a.IsChecked).Select(a
=> a.OrganizationId).ToArray();
        }
    }
}
