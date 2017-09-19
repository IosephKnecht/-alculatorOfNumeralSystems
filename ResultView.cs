using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CalculatorSS
{
    public partial class ResultView : Form
    {
        private string digit;
        private string conv_out;
        public ResultView(string digit)
        {
            InitializeComponent();
            this.digit = digit;
        }

        public string Conv_out { get { return conv_out; } }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1)
                if (!ReConverter.ConvertTrans(Convert.ToInt32(comboBox1.SelectedItem), digit, out conv_out)) conv_out = "0";
            this.Hide();
        }
    }
}
