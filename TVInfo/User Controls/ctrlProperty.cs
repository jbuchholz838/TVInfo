using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TVInfo{

    public partial class ctrlProperty : UserControl {

        public ctrlProperty() {

            InitializeComponent();

        }

        public ctrlProperty(string name, string text) {

            lblName.Text = name + ":";

            lblText.Text = text;
        }

        public string propName {

            get {

                return lblName.Text;

            }set {

                lblName.Text = value;
                this.Invalidate();

            }
        }

        public string propText {

            get {

                return lblText.Text;

            }
            set {

                lblText.Text = value;
                this.Invalidate();

            }
        }

        public void update(string propName, string propText) {

            lblName.Text = propName;
            lblText.Text = propText;

        }

    }
}
