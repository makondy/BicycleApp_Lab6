using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BicycleApp_Lab6
{
    public partial class fVehicleType : Form
    {
        private void fVehicleType_Load(object sender, EventArgs e)
        {
            
        }

        public string SelectedType { get; private set; }

        public fVehicleType()
        {
            InitializeComponent();
        }

        private void btnElectric_Click(object sender, EventArgs e)
        {
            SelectedType = "Електричний";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnMechanical_Click(object sender, EventArgs e)
        {
            SelectedType = "Механічний";
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
