using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium.Models
{
    abstract class EtreVivant
    {
        public int Age { get; set; }
        public int PV { get; set; }

        public bool EstEnvie { 
            get 
            {
                return PV > 0 && Age <= 20;
            } 
        }

        public EtreVivant(int age =0)
        {
            PV = 10;
            Age = age;
        }

        
    }
}
