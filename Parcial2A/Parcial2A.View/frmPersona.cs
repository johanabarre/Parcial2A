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
    public partial class frmPersona : Form
    {
        private List<Persona> _listado;

        public frmPersona()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmAgregarPersona frm = new frmAgregarPersona();
            frm.ShowDialog();
            UpdateGrid();
        }

        private void frmPersona_Load(object sender, EventArgs e)
        {
            UpdateGrid();

        }
        private void UpdateGrid()
        {
            _listado = PersonaBL.Instance.SellectAll();

            var query = from x in _listado
                        select new
                        {
                            Id = x.PersonaId,
                            Nombre = x.Nombre,
                            Edad=x.Edad,
                            Genero=x.Genero,
                            dosis = x.Doses.Nombre
                        };

            dataGridView1.DataSource = query.ToList();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Editar"].Selected)
            {
                int id = (int)dataGridView1.CurrentRow.Cells[1].Value;
                string nombre = dataGridView1.CurrentRow.Cells[2].Value.ToString(); 
                
                int dosisid = _listado.FirstOrDefault(x => x.PersonaId.Equals(id)).DosisId;

                Persona entity = new Persona()
                {
                    PersonaId = id,
                    Nombre = nombre,
                    DosisId = dosisid
                };

                frmAgregarPersona frm = new frmAgregarPersona(entity);
                frm.ShowDialog();
                UpdateGrid();
            }
        }
    }
}
