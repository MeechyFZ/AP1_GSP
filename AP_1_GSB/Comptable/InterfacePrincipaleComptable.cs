﻿using AP_1_GSB.Data.Models;
using iText.Layout.Splitting;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AP_1_GSB.Comptable
{
    public partial class InterfacePrincipaleComptable : Form
    {
        List<Utilisateur> visiteurs; 
        public InterfacePrincipaleComptable()
        {
            InitializeComponent();
            ChargerListView();
        }

        private void ChargerListView()
        {
            visiteurs = new List<Utilisateur>();
            visiteurs = Services.UtilisateurService.RecupererVisiteurs();

            foreach (Utilisateur visisteur in visiteurs)
            {
                ListViewItem item = new ListViewItem(visisteur.Nom);
                item.SubItems.Add(visisteur.Prenom);
                item.SubItems.Add(visisteur.Email);
                item.Tag = visisteur.IdUtilisateur;
                listViewAffichageUtilisateurs.Items.Add(item);
            }
        }

        public Utilisateur SelectionnerVisiteur()
        {
            Utilisateur employe;
            if (listViewAffichageUtilisateurs.SelectedItems.Count > 0)
            {
                int IdEmploye = (int)listViewAffichageUtilisateurs.SelectedItems[0].Tag;
                employe = visiteurs.FirstOrDefault( v => v.IdUtilisateur == IdEmploye ); 
                return employe;
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un employé");
                return null;
            }
        }
    }
}
