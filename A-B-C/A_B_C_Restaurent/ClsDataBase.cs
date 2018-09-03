using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;

namespace A_B_C_Restaurent
{
    class ClsDataBase
    {

        SqlConnection cn = new SqlConnection("Data Source=.;Initial Catalog=db_A-B-C;Integrated Security=True");
        SqlDataAdapter da;
        DataSet ds;
        SqlCommand cmd = new SqlCommand();
             
        ReportDocument RD = new ReportDocument();
       

        public static string Role;
        public static int U_Id;
        public static int O_Id;


        public bool SearchUser(string query)
        {
           // qry = "select * from " + TableName + " where " + Value_1 + " = " + Value_2 + " and " + Value_3 + " = " + Value_4 + " ";
            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();

            da.Fill(ds, "tab");
            if (ds.Tables["tab"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public bool SearchRecord(string query)
        {
            // qry = "select * from " + TableName + " where " + Value_1 + " = " + Value_2 + " and " + Value_3 + " = " + Value_4 + " ";
            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();

            da.Fill(ds, "tab");
            if (ds.Tables["tab"].Rows.Count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public string FindField(string query, string rqField)
        {

            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");

            return ds.Tables["tab"].Rows[0][rqField].ToString();


        }
        public string Manipulate(string query,string msg)
        {
            //try
            //{
                cmd = new SqlCommand();

                cmd.CommandText = query;
                cmd.Connection = cn;
                cn.Open();
                cmd.ExecuteNonQuery();
                cn.Close();
                return msg;
            //}
            //catch (Exception ex)
            //{
            //    cn.Close();
            //    msg = "Some Error Occured !!";
            //    return msg;
            //}

        }
        public string NewId(string FieldName, string TableName)
        {
            string qry = "select isnull(max(" + FieldName + "),0) + 1 as ID from " + TableName;
            da = new SqlDataAdapter(qry,cn);
            ds = new DataSet();
            da.Fill(ds, "tab");
            return ds.Tables["tab"].Rows[0]["ID"].ToString();

        }

        public void BindToComboBox(string query, ComboBox C_Box, string D_mem)
        {
            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");
            C_Box.DataSource = ds.Tables["tab"];

            C_Box.DisplayMember = D_mem;

        }

        public void BindToComboBox(string query , ComboBox C_Box , string D_mem, string V_mem)
        {
            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");
            C_Box.DataSource = ds.Tables["tab"];

            C_Box.DisplayMember = D_mem;
            C_Box.ValueMember = V_mem;

        }
        public void BindToListBox(string query, ListBox List_Box, string D_mem, string V_mem)
        {
            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");
            List_Box.DataSource = ds.Tables["tab"];
            List_Box.DisplayMember = D_mem;
            List_Box.ValueMember = V_mem;
        }

        public void BindToDataGridView(string query, DataGridView Data_Grid_View)
        {
            da = new SqlDataAdapter(query, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");
            Data_Grid_View.DataSource = ds.Tables["tab"];

        }
        public ReportDocument BindToReport(string qry, string ReportName)
        {
            da = new SqlDataAdapter(qry, cn);
            ds = new DataSet();
            da.Fill(ds, "tab");

            RD.Load(Application.StartupPath + "//" + ReportName);
            RD.SetDataSource(ds.Tables["tab"]);
            return RD;
        }

    }
}
