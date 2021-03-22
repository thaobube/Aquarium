using System;
using System.Collections.Generic;
using System.Text;

namespace CSharpquarium.Models
{
    abstract class Poisson : EtreVivant
    {
        public Poisson(string nom, Genre sexe, int age = 0)
        {
            Sexe = sexe;
            Nom = nom;
            Age = age;
        }

        public Genre Sexe { get; set; }

        public string Nom { get; set; }
        public bool AFaim
        {
            get { return PV <= 5; }
        }

        public override string ToString()
        {
            return $"Type: {GetType().Name} - Nom: {Nom} - Genre: {Sexe} - Age: {Age} - PV: {PV}";
        }
    }
} 
