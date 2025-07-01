
namespace HNI_TPmoyennes
{
    class Eleve
    {   
        // Propriétés
        public string prenom { get; private set; }
        public string nom { get; private set; }
        public List<Note> notes { get; private set; }

        public Eleve(string pre, string nom) 
        {
            this.prenom = pre;
            this.nom = nom;
            notes = new List<Note>();
        }

        public void ajouterNote(Note note)
        {
            if (notes.Count() < 200) 
            {
                notes.Add(note);
            }
            else
            {
                Console.Write("Il y a déjà 200 notes");
            }
            
        }

        // Moyenne de l'élève dans une matière

        public float moyenneMatiere(int i)
        {
            float tot = 0;
            float sum = 0;

            foreach(Note note in notes)
            {
                if (note.matiere == i)
                {
                    tot += 1;
                    sum += note.note;
                }
            }

            if (tot != 0)
            {
                return (float)Math.Round(sum / tot, 2);
            } 
            else 
            {
                return -1;
            }
        }

        // Moyenne générale de l'élève

        public float moyenneGeneral()
        {
            float tot = 0;
            float sum = 0;
            int nbMatMax = 0;
            int i = 0;

            foreach(Note note in notes)
            {
                if (note.matiere > nbMatMax)
                {
                    nbMatMax = note.matiere;
                }
            }

            while (i <= nbMatMax)
            {
                float moy = moyenneMatiere(i);
                if (moy != -1)
                {
                    sum += moy;
                    tot += 1;
                }
                i++;
            }

            if (tot != 0)
            {
                return (float)Math.Round(sum / tot, 2);
            }
            else 
            {
                return -1;
            }
        }
    }
}