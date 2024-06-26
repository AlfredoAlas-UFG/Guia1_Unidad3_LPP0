﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guia1Unidad3;
using Guia1Unidad3.Model;

namespace Guia1Unidad3
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Refrescar();
        }

        private void Refrescar()
        {
            using (BDD_UFGEntities db = new BDD_UFGEntities())
            {
                //Selecciona los datos disponibles
                var lista = from datos in db.Persona
                            select datos;
                DgvDatos.DataSource = lista.ToList();
            }
        }

        private void BtnNuevo_Click(object sender, EventArgs e)
        {
            FrmTabla frmTabla = new FrmTabla();
            frmTabla.ShowDialog();
            Refrescar();
        }

        private int? ObtenerId()
        {
            try
            {
                return int.Parse(DgvDatos.Rows[DgvDatos.CurrentRow.Index].Cells[0].Value.ToString());
            }
            catch
            {
                return null;
            }
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();
            if (id!= null)
            {
                FrmTabla frmTabla = new FrmTabla(id);
                frmTabla.ShowDialog();
            }
            Refrescar();
        }

        private void BtnEliminar_Click(object sender, EventArgs e)
        {
            int? id = ObtenerId();
            if (id!= null)
            {
                using (BDD_UFGEntities db = new BDD_UFGEntities())
                {
                    Persona personas = db.Persona.Find(id);
                    db.Persona.Remove(personas);
                    db.SaveChanges();
                }
            }
            Refrescar() ;
        }
    }
}
