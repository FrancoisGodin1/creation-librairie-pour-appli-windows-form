using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesperLib
{
    public class Employe
    {
        /// <summary>
        /// propriétés
        /// </summary>

        byte cadre;
        int id;
        string nom;
        string prenom;
        decimal salaire;
        char sexe;
        Service sonService;
        List<Diplome> sesDiplomes;
        static int dernierId;


        /// <summary>
        /// constructeur employe
        /// </summary>
        /// <param name="cadre"></param>
        /// <param name="id"></param>
        /// <param name="nom"></param>
        /// <param name="prenom"></param>
        /// <param name="salaire"></param>
        /// <param name="sexe"></param>

        public Employe(int id, string nom, string prenom, char sexe, byte cadre, decimal salaire)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.sexe = sexe;
            this.cadre = cadre;
            this.salaire = salaire;
            this.sonService = null;
            this.sesDiplomes = new List<Diplome>();

        }

        /// <summary>
        /// identifiants en lecture et ecriture
        /// </summary>

        public int Id { get { return id; } set { id = value; } }
        public string Nom { get { return nom; } set { nom = value; } }
        public string Prenom { get { return prenom; } set { prenom = value; } }
        public char Sexe { get { return sexe; } set { sexe = value; } }
        public byte Cadre { get { return cadre; } set { cadre = value; } }
        public List<Diplome> SesDiplomes { get { return sesDiplomes; } set { sesDiplomes = value; } }
        public Service SonService { get { return sonService; } set { sonService = value; } }

        /// <summary>
        /// methodToString 
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            string cadre = "";
            if (this.cadre == 1)
                cadre = "cadre";
            else
                cadre = "non cadre";
            string s = string.Format("employé n°{0}: {1} {2} sexe : {3} statut : {4}, salaire : {5}, service : {6}", this.id, this.nom, this.prenom, this.sexe, cadre, this.salaire, this.sonService.Designation);
            s += string.Format("Diplome obtenu(s) : \n");
            foreach (Diplome d in sesDiplomes)
                s += d.Libelle.ToString()+"\n";
            return s;
        }
    }
}
