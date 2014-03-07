using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainAndServices.Interfaces
{
    public interface ISortable
    {
        int SortOrder { get; set; }
    }
}
