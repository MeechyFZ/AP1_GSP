﻿using AP_1_GSB.Data.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP_1_GSB.Services
{ 
    internal class JustificatifService
    {
        public static Justificatif AjouterJustificatif(byte[] FichierBinaire)
        {
            Data.SqlConnection.ConnexionSql();

            string RequeteCreationJustificatif = "INSERT INTO justificatif (fichier) VALUES (@fichier); SELECT LAST_INSERT_ID()";

            try
            {
            using (MySqlCommand cmd = new MySqlCommand(RequeteCreationJustificatif, Data.SqlConnection.Connection))
            {
                cmd.Parameters.AddWithValue("@fichier", FichierBinaire);

                int idJustificatif = Convert.ToInt32(cmd.ExecuteScalar());

                Justificatif justificatif = new Justificatif()
                {
                    IdJustificatif = idJustificatif,
                    FichierBlob = FichierBinaire
                };
                return justificatif;
            }
            }
            catch (MySqlException e)
            {
                Console.WriteLine(e.Message);
                return null;    
            }
            finally
            {
                Data.SqlConnection.DeconnexionSql();
            }
        }
    }
}