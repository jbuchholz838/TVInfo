using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVInfo {

    public partial class ctrlHomeShow : UserControl {

        public ctrlHomeShow() {

            InitializeComponent();

        }

        public ctrlHomeShow(string showName, string strDate) {

            lblName.Text = showName;
            lblDate.Text = strDate;

        }

        public string getName() {

            return lblName.Text;

        }

        public string getDate() {

            return lblDate.Text;

        }

        public void update(string showName, string strDate){

            lblName.Text = showName;
            lblDate.Text = strDate;

        }
    }
}
