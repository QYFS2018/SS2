using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WComm;

namespace SS2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private bool confirm(string function)
        {
            string message = "Do you want to run " + function + "?";
            string caption = "Confirm";
            MessageBoxButtons buttons = MessageBoxButtons.YesNo;
            DialogResult result;

            result = MessageBox.Show(this, message, caption, buttons);

            return result == DialogResult.Yes;
        }

        private void Process(string action)
        {
            ReturnValue _result = new ReturnValue();

            Process Process = new Process();

            _result = Process.Run(action);
            if (_result.Success == false)
            {
                MessageBox.Show(_result.ErrMessage);
            }
            else
            {
                MessageBox.Show(action + " Completed!");
            }
        }


        private void PullOrder_Click(object sender, EventArgs e)
        {
            if (!confirm("Pull Order")) return;

            Process("PullOrder");
        }

        private void MarkOrderShip_Click(object sender, EventArgs e)
        {
            if (!confirm("Mark Order Ship")) return;

            Process("MarkOrderShip");
        }
    }
}
