using ConsoleApp2;
using System;
using System.Collections.Generic;
using System.Text;

namespace lab3
{
    public class Storages
    {
        public string Name;
        public Processors[] processors;
        public Storages(string a, Processors[] b)
        {
            Name = a;
            processors = b;
        }
    }
}
