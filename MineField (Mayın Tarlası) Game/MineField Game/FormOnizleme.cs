using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MineField_Game
{
    public partial class FormOnizleme : Form
    {
        public static Panel panelonlz;
        public FormOnizleme()
        {
            InitializeComponent();
            panelonlz = pnlFieldOnz;

        }


        public void FormOnizleme_Load(object sender, EventArgs e)
        {
            panelonlz = pnlFieldOnz;
        }
    }
}
