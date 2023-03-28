using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Xml.Linq;


namespace WindowsFormsApp8
{
    public partial class Form2 : Form
    {
        SqlConnection con;
        SqlDataAdapter da;
        SqlCommandBuilder scb;
        DataSet ds;

        public Form2()
        {
            InitializeComponent();
            con = new SqlConnection(ConfigurationManager.ConnectionStrings["DbConnection"].ConnectionString);

        }
        private DataSet GetAllEmployees()
        {
            da = new SqlDataAdapter("select * from employee1", con);
            da.MissingSchemaAction = MissingSchemaAction.AddWithKey;
            scb = new SqlCommandBuilder(da);
            ds = new DataSet();
            da.Fill(ds, "employee1");
            return ds;
        }


        private void btnsave_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllEmployees();
                DataRow row = ds.Tables["employee1"].NewRow();
                row["id"] = txtid.Text;
                row["name"] = txtname.Text;
                row["sal"] = txtsal.Text;
                // add new row in the dataset table
                ds.Tables["employee1"].Rows.Add(row);
                int res = da.Update(ds.Tables["employee1"]);
                if (res >= 1)
                {
                    MessageBox.Show("Record inserted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllEmployees();
                DataRow row = ds.Tables["employee1"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row["name"] = txtname.Text;
                    row["sal"] = txtsal.Text;
                    int res = da.Update(ds.Tables["employee1"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record updated");
                    }

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btnsearch_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllEmployees();
                DataRow row = ds.Tables["employee1"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    txtname.Text = row["name"].ToString();
                    txtid.Text = row["id"].ToString();
                    txtsal.Text = row["sal"].ToString();
                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = GetAllEmployees();
                DataRow row = ds.Tables["employee1"].Rows.Find(txtid.Text);
                if (row != null)
                {
                    row.Delete();
                    int res = da.Update(ds.Tables["employee1"]);
                    if (res >= 1)
                    {
                        MessageBox.Show("Record deleted");
                    }

                }
                else
                {
                    MessageBox.Show("Record not found");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void txtsal_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtname_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
