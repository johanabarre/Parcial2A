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

    public partial class frmControlDosis : Form
    {

        int id = 0;
        private List<Persona> _listado;

        public frmControlDosis()
        {
            InitializeComponent();
            UpdateCombo();
        }
        public frmControlDosis(Persona entity)
        {
            InitializeComponent();
            id = entity.PersonaId;

            textBox1.Text = entity.Nombre;
            textBox2.Text = entity.Edad;
            textBox3.Text = entity.Genero;

            UpdateCombo();
            comboBox1.SelectedValue = entity.Doses;
        }
        private void UpdateCombo()
        {
            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "DosisId";
            comboBox1.DataSource = DosisBL.Instance.SellectAll();


        }
        private void UpdateGrid()
        {
            _listado = PersonaBL.Instance.SellectAll();
            var query = from x in _listado
                        select new
                        {
                            Id = x.PersonaId,
                            Nombre = x.Nombre,
                            Edad = x.Edad,
                            Genero = x.Genero
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[2].Value;
                string nombre = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                int DosisId = _listado.FirstOrDefault(x => x.DosisId.Equals(id)).DosisId;

                Persona entity = new Persona()
                {
                    PersonaId = id,
                    Nombre = nombre,
                    DosisId = DosisId
                };


                UpdateGrid();
            }
        }

        private void frmControlDosis_Load(object sender, EventArgs e)
        {

        }
    }
}
