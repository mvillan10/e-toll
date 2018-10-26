using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toll_Automater
{
    public partial class MainForm : Form
    {
        dbConn obj = new dbConn();
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

            groupBox1.Visible = false;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                lblStatus.Text = "Captured";
                obj.DT.Clear();
                obj.ExcecuteQuery("select * from tollTable where id='" + textBox1.Text + "'");
                
                
                if (obj.DT.Rows.Count > 0)
                {
                    groupBox1.Visible = true;
                    StsTimer.Enabled = true;
                    txtPN.Text = obj.DT.Rows[0][1].ToString();
                    obj.ExcecuteNonQuery("update tollTable set Balance=Balance-5 where id='"+textBox1.Text+"'");
                    txtBal.Text = obj.DT.Rows[0][2].ToString();
                    
                    
                }
                else
                {
                    groupBox1.Visible = false;
                    lblStatus.Text = "No data found";
                    StsTimer.Enabled = true;

                }
                textBox1.Text = "";
            }
        }

        private void StsTimer_Tick(object sender, EventArgs e)
        {
            lblStatus.Text = "Scanning...";
            StsTimer.Enabled = false;
           
        }

       
    }
}
