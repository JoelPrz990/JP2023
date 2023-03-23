using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace JP2023
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        MarcaBLL marcaBLL = MarcaBLL.Instance();
        private void Form1_Load(object sender, EventArgs e)
        {
            gcMarcas.DataSource = marcaBLL.GetAll();
        }
    }
}
