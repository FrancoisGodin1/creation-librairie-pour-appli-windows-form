using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesperLib
{
    public class Service
    {
        /// <summary>
        /// propriétés
        /// </summary>
        /// 
        decimal budget;
        int capacite;
        int dernierId;
        string designation;
        int id;
        string produit;
        char type;
        List<Employe> lesEmployesDuService;

        /// <summary>
        /// Constructeur service productif
        /// </summary>
        /// <param name="id"></param>
        /// <param name="designation"></param>
        /// <param name="produit"></param>
        /// <param name="capacite"></param>
        public Service(int id, string designation, string produit, int capacite)
        {
            this.capacite = capacite;
            this.designation = designation;
            this.id = id;
            this.produit = produit;
            this.type = 'P';
            this.lesEmployesDuService = new List<Employe>();
        }

        /// <summary>
        /// Constructeur service administratif
        /// </summary>
        /// <param name="id"></param>
        /// <param name="designation"></param>
        /// <param name="budget"></param>
        public Service(int id, string designation, decimal budget)
        {
            this.budget = budget;
            this.designation = designation;
            this.id = id;
            this.type = 'A';
            this.lesEmployesDuService = new List<Employe>();
        }

        /// <summary>
        /// identifiants en lecture et ecriture
        /// </summary>

        public decimal Budget { get { return budget; } set { budget = value; } }
        public int Capacite { get { return capacite; } set { capacite = value; } }
        public int DernierId { get { return dernierId; } set { dernierId = value; } }
        public string Designation { get { return designation; } set { designation = value; } }
        public int Id { get { return id; } set { id = value; } }
        public string Produit { get { return produit; } set { produit = value; } }
        public char Type { get { return type; } set { type = value; } }
        public List<Employe> LesEmployesDuService { get { return lesEmployesDuService; } set { lesEmployesDuService = value; } }

        /// <summary>
        /// methodToString 
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            string s;
            if (this.type == 'P')
                s = string.Format("service n°{0}: {1} ({2}), produit: {3}, capacité : {4},dernier id: {5} \n", this.id, this.designation, this.type, this.produit, this.capacite, this.dernierId);
            else
                s = string.Format("service n°{0}: {1} ({2}) ,budget : {3}, dernier id: {4} \n", this.id, this.designation, this.type, this.budget, this.dernierId);
            s += string.Format("employé du service : \n");
            foreach (Employe e in this.lesEmployesDuService)
                s += string.Format("{0} {1} \n", e.Prenom, e.Nom);
                return s;
        }

    }
}
