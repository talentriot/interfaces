using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Text;
using DomainAndServices.Interfaces;

namespace DomainAndServices.Services
{
    public static class SortService
    {
        public static void SetSortOrder(IEnumerable<ISortable> items)
        {
            var initialSortOrder = 0;
            foreach (var item in items)
            {
                var itemAsSortable = item as ISortable;
                if (itemAsSortable != null)
                {
                    itemAsSortable.SortOrder = initialSortOrder;
                }
                initialSortOrder++;
            }
        }
    }
}
