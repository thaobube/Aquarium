using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium.Models
{
    abstract class Carnivore : Poisson
    {
        public Carnivore(string nom, Genre sexe, int age) : base(nom, sexe, age)
        {
        }
        public void Manger(Poisson p)
        {
            p.PV -= 4;
            this.PV += 5;
        }
    }
}
