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
    public partial class frmProductos : DevExpress.XtraEditors.XtraForm
    {
        private ProductoBLL productoBLL = ProductoBLL.Instance();
        private CategoriaBLL CategoriaBLL = CategoriaBLL.Instance();
        private MarcaBLL MarcaBLL = MarcaBLL.Instance();
        public frmProductos()
        {
            InitializeComponent();
        }

        private void frmProductos_Load(object sender, EventArgs e)
        {
            productosBindingSource1.DataSource = productoBLL.GetAll();
            gvProductos.BestFitColumns();
            marcasBindingSource.DataSource = MarcaBLL.GetAll();
            categoriasBindingSource.DataSource = CategoriaBLL.GetAll();
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            new frmNProducto().ShowDialog();
            productosBindingSource1.DataSource = productoBLL.GetAll();
            gvProductos.BestFitColumns();
        }
    }
}