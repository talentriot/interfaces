﻿using System;

namespace DomainAndServices.Interfaces
{
    public interface IDBDisplayable : IComparable
    {
        int Id { get; set; }
        string Name { get; }
        int SortOrder { get; set; }
    }
}