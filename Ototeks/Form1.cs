using Ototeks.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Ototeks
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();

        }

        private void btnYeniKumas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // Formun bir örneğini oluştur
            FrmKumas frm = new FrmKumas();

            // Formu "Dialog" olarak aç (Arkadaki pencereye tıklanmasını engeller)
            frm.ShowDialog();
        }
    }
}
