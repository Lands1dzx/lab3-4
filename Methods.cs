using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp2
{
    public static class Methods
    {
        public static Processors[] MaxQuantity(Processors[] mass)
        {
            var maxValue = mass.Max(p => p.quantity);
            List<Processors> result = new List<Processors>();
            for (int i = 0; i < mass.Length; i++)
            {
                if (mass[i].quantity == maxValue)
                {
                    result.Add(mass[i]);
                }
            }
            return result.ToArray();
        }

        public static Processors[] DateSort(Processors[] mass) => mass.OrderByDescending(d => d.dateTime).ToArray();
        public static Processors[] NameSearch(Processors[] mass, string Podstroka) => mass.Where(p => p.name.ToUpper().Contains(Podstroka.ToUpper())).ToArray();
    }
}
