using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Generyczny
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void start_Click(object sender, EventArgs e)
        {
            Populacja populacja = new Populacja();
            populacja.epoki = int.Parse(UpDown.Value.ToString());
            int[] best = populacja.Run();
            textBox.Text = populacja.log;
            MessageBox.Show("Najlepsza trasa: " + Environment.NewLine + Trasa.GetAllCites(best));
        }
    }
}
