using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVInfo {

    public partial class frmProgressBar : Form {

        double max = 0;

        public frmProgressBar() {

            InitializeComponent();

        }

        public frmProgressBar(double max) {

            InitializeComponent();

            this.max = max;
            pgbLoading.Maximum = (int)max;
            Console.WriteLine("Progress Bar Created with Max of " + max);

        }

        public void update(int num, string status) {

            double val = (num / max) * 100;

            if (val > 0 && val <= max)
                pgbLoading.Value = (int)val;
            else if (val > max)
                pgbLoading.Value = (int)max;
            else
                pgbLoading.Value = 1;

            lblPercent.Text = pgbLoading.Value.ToString() + "%";
            lblStatusText.Text = status;
            //Console.WriteLine("PGB UPDATE: " + num + " | " + status + " | " + pgbLoading.Value);
        }

        public void update(int num) {

            double val = (num / max) * 100;
            pgbLoading.Value = (int)val;
            lblPercent.Text = pgbLoading.Value.ToString() + "%";

        }

        public void close() {

            this.DialogResult = DialogResult.OK;

        }
    }
}
