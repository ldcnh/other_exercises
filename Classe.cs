using System;

namespace HNI_TPmoyennes
{
    class Classe
    {   
        // Propriétés
        public string nomClasse { get; private set; }
        public List<Eleve> eleves { get; private set; }
        public List<string> matieres { get; private set; }

        // Constructeur de Classe
        public Classe(string c)
        {
            this.nomClasse = c;
            eleves = new List<Eleve>();
            matieres = new List<string>();
        }

        // Méthodes
        public void ajouterEleve(string pre, string nom) 
        {
            if (eleves.Count < 30) 
            {
                Eleve eleve = new Eleve(pre, nom);   
                eleves.Add(eleve);
            }
            else
            {
                Console.Write("Il y a déjà 30 élèves");
            }
            
            
        }

        public void ajouterMatiere(string mat)
        {
            if (matieres.Count < 10) 
            {
                matieres.Add(mat);
            }
            else
            {
                Console.Write("Il y a déjà 10 matières");
            }
        }

        // Moyenne de la classe dans une matière

        public float moyenneMatiere(int i)
        {
            float totClasse = 0;
            float sumClasse = 0;

            foreach(Eleve eleve in eleves)
            {
                float moy = eleve.moyenneMatiere(i);
                if (moy != -1)
                {
                    sumClasse += moy;
                    totClasse += 1;
                }
            }

            if (totClasse!= 0)
            {
                return (float)Math.Round(sumClasse / totClasse, 2);
            }
            else 
            {
                return -1;
            }

        }

        // Moyenne de la classe générale

        public float moyenneGeneral()
        {
            float totClasse = 0;
            float sumClasse = 0;
            int nbMatMax = 0;
            int i = 0;

            foreach(Eleve eleve in eleves)
            {
                foreach (Note note in eleve.notes)
                {
                    if (note.matiere > nbMatMax)
                    {
                        nbMatMax = note.matiere;
                    }
                }
            }
                
            while (i <= nbMatMax)
            {
                float moy = moyenneMatiere(i);
                if (moy != -1)
                {
                    sumClasse += moy;
                    totClasse += 1;
                }
                i++;
            }
        
            if (totClasse != 0)
            {
                return (float)Math.Round(sumClasse / totClasse, 2);
            }
            else 
            {
                return -1;
            }
        }
        
 
 
    }
}
