using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsAppEnergiaital
{
    internal class Energiaital
    {
        int id;
        string name;
        int egysegar;
        int mennyiseg;

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Egysegar { get => egysegar; set => egysegar = value; }
        public int Mennyiseg { get => mennyiseg; set => mennyiseg = value; }

        public Energiaital(int id, string name, int egysegar, int mennyiseg)
        {
            Id = id;
            Name = name;
            Egysegar = egysegar;
            Mennyiseg = mennyiseg;
        }

        public override string ToString()
        {
            return name + " | " + Egysegar + "Ft | " + Mennyiseg + "db";
        }
    }
}
