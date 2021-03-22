using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSharpquarium.Models
{
    class Aquarium
    {

        private List<EtreVivant> population
            = new List<EtreVivant>();
        private Random random = new Random();
        public void JourDeplus()
        {
            List<EtreVivant> toDelete = new List<EtreVivant>();
            List<EtreVivant> nouveauxNes = new List<EtreVivant>();
            foreach (EtreVivant ev in population)
            {
                ev.Age++;
                if (ev is Algue)
                {
                    ev.PV++;
                    if (ev.PV >= 10)
                    {
                        Algue a = new Algue();
                        a.PV = ev.PV / 2;
                        ev.PV -= a.PV;
                        nouveauxNes.Add(a);
                        

                    }
                }
                if (ev is Carnivore c)
                {
                    ev.PV--;
                    if (c.AFaim)
                    {
                        // trouver une cible au hazard
                        int indexCible = random.Next(0, population.Count);
                        if (population[indexCible] is Poisson p && population[indexCible].GetType() != ev.GetType())
                        {
                            c.Manger(p);
                        }
                    }
                    else
                    {
                        List<Poisson> poissons = population.OfType<Poisson>().ToList();
                        int indexPart = random.Next(0, poissons.Count);
                        if (poissons[indexPart].GetType() == ev.GetType() && poissons[indexPart].Sexe != c.Sexe)
                        {
                            AjouterPoisson(
                                c.Nom.Substring(0, 2) + poissons[indexPart].Nom.Substring(0, 2),
                                random.Next(0, 2) == 0 ? Genre.Male : Genre.Femelle,
                                ev.GetType().Name,
                                0,
                                nouveauxNes
                                );
                        }
                    }
                }
                else if (ev is Herbivore h)
                {
                    ev.PV--;
                    if (h.AFaim)
                    {
                        int indexCible = random.Next(0, population.Count);
                        if (population[indexCible] is Algue a)
                        {
                            h.Manger(a);
                        }
                    }
                    else
                    {
                        List<Poisson> poissons = population.OfType<Poisson>().ToList();
                        int indexPart = random.Next(0, poissons.Count);
                        if (poissons[indexPart].GetType() == ev.GetType() && poissons[indexPart].Sexe != h.Sexe)
                        {
                            AjouterPoisson(
                                h.Nom.Substring(0, 2) + poissons[indexPart].Nom.Substring(0, 2),
                                random.Next(0, 2) == 0 ? Genre.Male : Genre.Femelle,
                                ev.GetType().Name,
                                0,
                                nouveauxNes
                                );
                        }
                    }
                }
            }
            // Tester a la fin l'etat des poissons
            foreach (EtreVivant ev in population)
            {
                if (!ev.EstEnvie)
                {
                    toDelete.Add(ev);
                }
            }

            // nettoyage de l'aquarium
            foreach (EtreVivant ev in toDelete)
            {
                population.Remove(ev);
            }
            // ajout des nouveaux nes
            foreach (EtreVivant ev in nouveauxNes)
            {
                population.Add(ev);
            }
            
        }

        public void AjouterPoisson(string nom, Genre sexe, string type, int age = 0, List<EtreVivant> autreListe = null)
        {
            // creer une instance de poisson
            Poisson nouveau = null;
            switch (type)
            {
                case "Carpe":
                    nouveau = new Carpe(nom, sexe, age);
                    break;
                case "Sole":
                    nouveau = new Sole(nom, sexe, age);
                    break;
                case "Bar":
                    nouveau = new Bar(nom, sexe, age);
                    break;
                case "Thon":
                    nouveau = new Thon(nom, sexe, age);
                    break;
                case "Merou":
                    nouveau = new Merou(nom, sexe, age);
                    break;
                case "PoissonClown":
                    nouveau = new PoissonClown(nom, sexe, age);
                    break;
            }
            if (autreListe == null)
            {
                population.Add(nouveau);
            }
            else
            {
                autreListe.Add(nouveau);
            }
        }

        public void AjouterAlgue(int age = 0)
        {
            // creer une instance de algue
            Algue nouvelle = new Algue(age);
            //ajouter l'instance qque part
            population.Add(nouvelle);
        }
        public void Afficher()
        {   
            foreach(EtreVivant ev in population)
            {
                Console.WriteLine(ev);
            }
        }
    }
}
