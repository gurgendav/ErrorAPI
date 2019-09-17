using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void ExcOnUI_Click(object sender, EventArgs e)
        {
            throw new ApplicationException("Ha-ha");
        }

        private void ExcOnBack_Click(object sender, EventArgs e)
        {
            new Thread(() => throw new ApplicationException("bye bye")).Start();
        }
    }
}
