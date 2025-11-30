using DevExpress.XtraEditors;
using Ototeks.Business.Concrete;
using Ototeks.DataAccess.Concrete;
using Ototeks.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ototeks.UI
{
    public partial class FrmListFabrics : DevExpress.XtraEditors.XtraForm
    {
        public FrmListFabrics()
        {
            InitializeComponent();
        }

        private void FrmKumasListesi_Load(object sender, EventArgs e)
        {
            // 1. Bağlantıyı Kur (Boru Hattı)
            var repo = new GenericRepository<Fabric>();
            var manager = new FabricManager(repo);

            // 2. Verileri Çek (Select * From Fabrics)
            var kumasListesi = manager.GetAll();

            // 3. Grid'e Bağla (Sihirli Kısım)
            // Sen listeyi verdiğin an GridControl sütunları otomatik oluşturacak.
            bindingSource1.DataSource = kumasListesi;
        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void gridControl1_Click(object sender, EventArgs e)
        {

        }
    }
}