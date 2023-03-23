using BLL;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JP2023
{
    public partial class frmNProducto : DevExpress.XtraEditors.XtraForm
    {
        CategoriaBLL categoriaBLL = CategoriaBLL.Instance();
        MarcaBLL marcaBLL = MarcaBLL.Instance();
        public frmNProducto()
        {
            InitializeComponent();
        }

        private void frmNProducto_Load(object sender, EventArgs e)
        {
            marcasBindingSource.DataSource = marcaBLL.GetAll();
            categoriasBindingSource.DataSource = categoriaBLL.GetAll();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("El id de la categoria es: " + rlookCategoria.EditValue);
        }
    }
}