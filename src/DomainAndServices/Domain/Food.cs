﻿using System;
using DomainAndServices.Interfaces;

namespace DomainAndServices.Domain
{
    public class Food : IDBDisplayable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Calories { get; set; }
        public int Index { get; set; }


        public int CompareTo(object obj)
        {
            if (obj == null)
            {
                return -1;
            }
            var objAsFood = obj as Food;
            if (objAsFood == null)
            {
                return -1;
            }
            return this.Index.CompareTo(objAsFood.Index);
        }

    }
}
