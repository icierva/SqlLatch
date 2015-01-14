using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using LatchSDK;

namespace LatchTest
{
    public partial class Form1 : Form
    {
        public const string APP_ID = "ArD4WAsBCDTGdC9NmQJG";
        public const string SECRET = "nb7XWyL43dGxFrXTYr2bAezLbbCpJsBPChqLmX8D";
        public const string ACCOUNT_ID = "jyRh63DneDmHe9Dy7ajDU3HTRkrCsxwMTg2C7chie929X38xsdPZh4f64TzVmpm2";
        public const string LOGIN_ID = "MpvyRr7NcUgzh6DR72MP";
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Latch latch = new Latch(APP_ID, SECRET);
            LatchResponse pairResponse = latch.Pair(txtToken.Text);
            
            if (pairResponse.Data != null && pairResponse.Data.ContainsKey("accountId"))
            {
                string accountId = pairResponse.Data["accountId"].ToString();
                txtAccountID.Text  = accountId;

            }
        }


        private void btnEstado_Click(object sender, EventArgs e)
        {
            Latch latch = new Latch(APP_ID, SECRET);
            LatchResponse statusResponse = latch.OperationStatus( ACCOUNT_ID, LOGIN_ID);
             if (statusResponse.Data != null && statusResponse.Data.ContainsKey("operations"))
                    {
                        var operations = (Dictionary<string, object>)statusResponse.Data["operations"];
                        if (operations.ContainsKey(LOGIN_ID ))
                        {
                            var app = (Dictionary<string, object>)operations[LOGIN_ID];
                            if (app.ContainsKey("status"))
                            {
                                string status = app["status"].ToString().ToLower();
                                 txtEstado.Text = status;

                            }

                        }

                 }

            }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Latch latch = new Latch(APP_ID, SECRET);

            latch.Unpair(ACCOUNT_ID);

        }
    }
}
