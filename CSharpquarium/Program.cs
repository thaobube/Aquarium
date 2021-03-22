using CSharpquarium.Models;
using System;
using System.Collections.Generic;

namespace CSharpquarium
{
    class Program
    {
        static Aquarium aquarium = new Aquarium();

        static void Main(string[] args)
        {
            aquarium.AjouterPoisson("Pol", Genre.Male, "Carpe", 5);
            aquarium.AjouterPoisson("Martine", Genre.Femelle, "Sole", 10);
            aquarium.AjouterAlgue();
            aquarium.AjouterAlgue();

            while(true)
            {
                Console.Clear();
                aquarium.Afficher();
                Console.WriteLine("Que voulez-vous faire?");
                Console.WriteLine("1. Ajouter un poisson");
                Console.WriteLine("2. Ajouter une algue");
                Console.WriteLine("3. Passer au jour suivant");
                Console.WriteLine("4. Quitter");

                string choix = Console.ReadLine();
                switch (choix)
                {
                    case "1":
                        Choix1();
                        break;
                    case "2":
                        Choix2();
                        break;
                    case "3":
                        aquarium.JourDeplus();
                        break;
                    case "4":
                        break;
                }
            } 

        }

        private static void Choix1()
        {
            string type = Question("Entre le type de votre poisson");
            string nom = Question("Entrer le nom de votre poisson");
            string s = Question("Entrer le sexe de votre poisson");
            string a = Question("Entrer l'age de votre poisson");

            Genre genre;
            while (!Enum.TryParse(s, out genre))
            {
                s = Question("Entrer le sexe de votre poisson");
            } 
            int age;
            while (!int.TryParse(a, out age))
            {
                s = Question("Entrer l'age de votre poisson");
            }
            aquarium.AjouterPoisson(nom, genre, type, age);
        }

        private static void Choix2()
        {
            aquarium.AjouterAlgue();
        }


        private static string Question(string message)
        {
            Console.WriteLine(message);
            return Console.ReadLine();
        }
    }
}
