using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace GesperLib
{
    public class Donnees
    {
        /// <summary>
        /// propriétés
        /// </summary>
        List<Employe> lesEmployes;
        List<Service> lesServices;
        List<Diplome> lesDiplomes;



        /// <summary>
        /// constructeur donnees
        /// </summary>
        public Donnees()
        {
            this.lesEmployes = new List<Employe>();
            this.lesServices = new List<Service>();
            this.lesDiplomes = new List<Diplome>();
        }

        public MySqlConnection ConnectionBDD()
        {
            return new MySqlConnection("user=root;password=siojjr;server=localhost;database=gesperfg");
        }

        public void ChargerService(MySqlConnection cnx)
        {
            string req = "select ser_id,ser_designation,ser_type,ser_produit,ser_capacite,ser_budget from service ";
            MySqlCommand cmd = new MySqlCommand(req, cnx);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                if (reader.GetString(2) == "P")
                {
                    Service unServiceP = new Service(reader.GetInt32("ser_id"), reader.GetString("ser_designation"), reader.GetString("ser_produit"), reader.GetInt32("ser_capacite"));
                    this.lesServices.Add(unServiceP);
                }
                else
                {
                    Service unServiceA = new Service(reader.GetInt32("ser_id"), reader.GetString("ser_designation"), reader.GetDecimal("ser_budget"));
                    this.lesServices.Add(unServiceA);
                }

            }
            reader.Close();
        }
        public void ChargerEmploye(MySqlConnection cnx)
        {
            string req = "select * from employe ";
            MySqlCommand cmd = new MySqlCommand(req, cnx);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                Employe unEmploye = new Employe(reader.GetInt32(0), reader.GetString(1), reader.GetString(2), reader.GetChar(3), Byte.Parse(reader.GetString(4)), reader.GetDecimal(5));

                this.lesEmployes.Add(unEmploye);

                for (int i = 0; i < lesServices.Count; i++)
                {
                    if (reader.GetInt32(6) == lesServices[i].Id)
                        unEmploye.SonService = lesServices[i];
                }

            }
            reader.Close();
        }
        public void ChargerDiplome(MySqlConnection cnx)
        {
            string req = "select * from diplome ";
            MySqlCommand cmd = new MySqlCommand(req, cnx);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Diplome unDiplome = new Diplome(reader.GetInt32(0), reader.GetString(1));
                this.lesDiplomes.Add(unDiplome);

            }
            reader.Close();
        }
        public void ChargerLesEmployesDesServices(MySqlConnection Cnx)
        {
            foreach (Service s in lesServices)
            {
                string req = "select * from employe where emp_service = " + s.Id + ";";
                Employe unEmploye;
                MySqlCommand cmd = new MySqlCommand(req, Cnx);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < lesEmployes.Count; i++)
                    {
                        if (lesEmployes[i].Id == reader.GetInt32(0))
                        {
                            unEmploye = lesEmployes[i];
                            s.LesEmployesDuService.Add(unEmploye);
                        }
                    }
                }
                reader.Close();
            }
        }

        public void ChargerDiplomeDesEmployes(MySqlConnection cnx)
        {
            string req = "select pos_employe,dip_libelle from posseder p,diplome d where d.dip_id=p.pos_diplome order by pos_employe";
            MySqlCommand cmd = new MySqlCommand(req, cnx);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())

                reader.Close();
        }
        public void ChargerEmployeTitulaireDesDiplomes(MySqlConnection cnx) 
        {
            Employe unEmploye;
            int i;
            foreach (Diplome d in lesDiplomes)
            {
                string req = "select * from posseder where pos_diplome = " + d.Id + ";";

                MySqlCommand cmd = new MySqlCommand(req, cnx);
                MySqlDataReader reader = cmd.ExecuteReader();


                while (reader.Read())
                {
                    for (int i = 0; i < lesEmployes.Count; i++)
                    {
 
                    }
                }

                    
            }
        }
        public void ToutCharger(MySqlConnection cnc) { }

        public void AfficherService()
        {
            foreach (Service s in this.lesServices)
                Console.WriteLine(s.ToString());
        }
        public void AfficherEmploye()
        {

            foreach (Employe e in this.lesEmployes)
                Console.WriteLine(e.ToString());
        }

        public void AfficherDiplome()
        {
            foreach (Diplome dp in this.lesDiplomes)
                Console.WriteLine(dp.ToString());
        }


        public List<Employe> LesEmployes { get { return this.lesEmployes; } }
        public List<Service> LesServices { get { return this.lesServices; } }
        public List<Diplome> LesDiplomes { get { return this.lesDiplomes; } }


    }
}
