using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GesperLib
{
    public class Diplome
    {
        /// <summary>
        /// propriétés
        /// </summary>
        /// 
        int id;
        string libelle;
        List<Employe> LesEmployés;


        /// <summary>
        /// constructeur Diplome
        /// </summary>
        /// <param name="id"></param>
        /// <param name="libelle"></param>

        public Diplome(int id, string libelle)
        {
            this.id = id;
            this.libelle = libelle;
            this.LesEmployés = new List<Employe>();
        }
        /// <summary>
        /// identifiants en lecture et ecriture
        /// </summary>

        public int Id { get { return id; } set { id = value; } }
        public string Libelle { get { return libelle; } set { libelle = value; } }

        /// <summary>
        /// methodToString 
        /// </summary>
        /// <returns></returns>
        public new string ToString()
        {
            return string.Format("diplome n°{0}: {1} ", this.id, this.libelle);
        }
    }
}
