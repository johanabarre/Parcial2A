using Parcial2A.BusinessLogic;
using Parcial2A.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Parcial2A.View
{
    public partial class frmAgregarPersona : Form
    {
        int id = 0;

        public frmAgregarPersona()
        {

            InitializeComponent();
            UpdateCombo();

        }
        public frmAgregarPersona(Persona entity)
        {
            InitializeComponent();
            id = entity.PersonaId;

            textBox1.Text = entity.Nombre;
            textBox2.Text = entity.Edad;
            textBox3.Text = entity.Genero;

            UpdateCombo();
            comboBox1.SelectedValue = entity.DosisId;
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "DosisId";
            comboBox1.DataSource = DosisBL.Instance.SellectAll();


        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Persona entity = new Persona()
            {
                PersonaId = id,
                Nombre = textBox1.Text.Trim(),
                Edad = textBox2.Text.Trim(),
                Genero = textBox3.Text.Trim(),
                DosisId = (int)comboBox1.SelectedValue
            };
            if (id == 0)
            {
                if (PersonaBL.Instance.Insert(entity))
                {
                     MessageBox.Show(this, "Registro se agrego con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (PersonaBL.Instance.Update(entity))
                {
                    MessageBox.Show(this, "Registro se edito con exito!", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            this.Close();
        }
    }
}
