using BLL;
using BOL;
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
    public partial class frmMarcas : DevExpress.XtraEditors.XtraForm
    {
        MarcaBLL marcaBLL = MarcaBLL.Instance();
        public frmMarcas()
        {
            InitializeComponent();
        }

        private void frmMarcas_Load(object sender, EventArgs e)
        {
            marcasBindingSource.DataSource = marcaBLL.GetAll();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNMarca().ShowDialog();
            marcasBindingSource.DataSource = marcaBLL.GetAll();
            gvMarcas.BestFitColumns();
        }
    }
}