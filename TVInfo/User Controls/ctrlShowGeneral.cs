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

    public partial class ctrlShowGeneral : UserControl {

        Show show;

        public ctrlShowGeneral() {

            InitializeComponent();

        }

        public ctrlShowGeneral(Show show) {

            this.show = show;

        }

        private void btnExpand_Click(object sender, EventArgs e) {

            Dictionary<string, string> propDict = show.getPropDict();

            foreach (KeyValuePair<string, string> property in propDict) {



            }

        }

    }
}
