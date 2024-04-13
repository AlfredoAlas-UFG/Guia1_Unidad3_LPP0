﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Guia1Unidad3.Model;

namespace Guia1Unidad3
{
    public partial class FrmTabla : Form
    {
        public int? id;
        Persona personas = null;
        public FrmTabla(int? id = null)
        {
            InitializeComponent();
            this.id = id;
            if (id != null )
            {
                CargarDatos();
            }
        }

        private void CargarDatos()
        {
            using(BDD_UFGEntities db = new BDD_UFGEntities())
            {
                personas = db.Persona.Find(id);
                TxtId.Text = personas.id.ToString();
                TxtNombre.Text = personas.nombre;
                TxtCorreo.Text = personas.correo;
                DtpFecha.Value = (DateTime)personas.fecha_nacimiento;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {
            using(BDD_UFGEntities db =  new BDD_UFGEntities())
            {
                if (id == null)
                {
                    personas = new Persona();
                }
                personas.id = int.Parse(TxtId.Text);
                personas.nombre = TxtNombre.Text;
                personas.correo = TxtCorreo.Text;
                personas.fecha_nacimiento = DtpFecha.Value;

                if(id == null)
                {
                    db.Persona.Add(personas);
                }
                else
                {
                    db.Entry(personas).State = System.Data.Entity.EntityState.Modified;
                }
                db.SaveChanges();
                this.Close();
            }
        }
    }
}