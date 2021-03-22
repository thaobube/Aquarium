using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium.Models
{
    abstract class Herbivore : Poisson
    {
        public Herbivore(string nom, Genre sexe, int age) : base(nom, sexe, age)
        {
        }
        public void Manger(Algue a)
        {
            a.PV -= 2;
            PV += 3;
        }
    }
}
