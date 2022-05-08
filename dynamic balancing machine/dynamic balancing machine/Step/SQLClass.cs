using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace dynamic_balancing_machine.Step
{
    class SQLClass
    {
        //string strcon = @"Data Source=LAPTOP-OUODJF98\SQLEXPRESS;Initial Catalog=DynamicBalanceMachine;Integrated Security=True";
        //SqlConnection sqlcon = new SqlConnection(@"Data Source=LAPTOP-OUODJF98\SQLEXPRESS;Initial Catalog=DynamicBalanceMachine;Integrated Security=True");
        public void Open_Connect(SqlConnection sqlcon)
        {
            try
            {                           
                if (sqlcon.State == ConnectionState.Closed)
                {
                    sqlcon.Open();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        public void Close_Connect(SqlConnection sqlcon)
        {
            try
            {
                if (sqlcon.State == ConnectionState.Open)
                {
                    sqlcon.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void excedata(string cmd, SqlConnection sqlcon)
        {
            Open_Connect(sqlcon);           
            try
            {
                SqlCommand cmds = new SqlCommand(cmd,sqlcon);
                cmds.ExecuteNonQuery();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close_Connect(sqlcon);            
        }
        public DataSet LoadData(string cmd, SqlConnection sqlcon)
        {
            DataSet ds = new DataSet();
            Open_Connect(sqlcon);
            try
            {
                SqlCommand cmds = new SqlCommand(cmd,sqlcon);
                SqlDataAdapter da = new SqlDataAdapter(cmd, sqlcon);
                da.Fill(ds);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            Close_Connect(sqlcon);
            return ds;
        }
    }
}
