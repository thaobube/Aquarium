using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium.Models
{
    class Algue : EtreVivant
    {
        public Algue(int age = 0) : base(age)
        {

        }
        public override string ToString()
        {
            return $"Je suis une algue - Age : {Age} - PV: {PV}";
        }
    }
}
