using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CRUD : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            GridView2.DataBind();



        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            try
            {
                SqlConnection con = new SqlConnection("Data Source=LAPTOP-HFTJM47B\\SQLEXPRESS01;Initial Catalog=TRUE_CURE;Integrated Security=True;Encrypt=False");

                con.Open();
                SqlCommand comm = new SqlCommand("UPDATE [crud_table] SET  full_name = @Param1, dob = @Param2, emaial= @Param4, state = @Param5, city = @Param6, pin_code = @Param7, full_address = @Param8 WHERE contact_no = @Param3", con);
                // Assuming ID is the primary key and Column2, Column3, ..., Column8 are the columns to update

                comm.Parameters.AddWithValue("@Param1", TextBox1.Text); // Assuming TextBox1 contains the ID of the record to update
                comm.Parameters.AddWithValue("@Param2", TextBox2.Text);
                comm.Parameters.AddWithValue("@Param3", TextBox3.Text);
                comm.Parameters.AddWithValue("@Param4", TextBox4.Text);
                comm.Parameters.AddWithValue("@Param5", DropDownList1.SelectedValue);
                comm.Parameters.AddWithValue("@Param6", TextBox6.Text);
                comm.Parameters.AddWithValue("@Param7", TextBox7.Text);
                comm.Parameters.AddWithValue("@Param8", TextBox5.Text);

                int rowsAffected = comm.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Updated');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Update Failed. Record not found.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('An error occurred: " + ex.Message + "');", true);
            }


        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-HFTJM47B\\SQLEXPRESS01;Initial Catalog=TRUE_CURE;Integrated Security=True;Encrypt=False");


            try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("DELETE FROM [crud_table] WHERE contact_no = @Param3", con); // Assuming ID is the primary key
                comm.Parameters.AddWithValue("@Param3", TextBox3.Text); // Assuming TextBox1 contains the ID of the record to delete

                int rowsAffected = comm.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Deleted');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Deletion Failed. Record not found.');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('An error occurred: " + ex.Message + "');", true);
            }

        }

        protected void Button3_Click(object sender, EventArgs e)
        {

            SqlConnection con = new SqlConnection("Data Source=LAPTOP-HFTJM47B\\SQLEXPRESS01;Initial Catalog=TRUE_CURE;Integrated Security=True;Encrypt=False");


            try
            {
                con.Open();
                SqlCommand comm = new SqlCommand("INSERT INTO [crud_table] VALUES (@Param1, @Param2, @Param3, @Param4, @Param5, @Param6, @Param7, @Param8)", con);
                comm.Parameters.AddWithValue("@Param1", TextBox1.Text);
                comm.Parameters.AddWithValue("@Param2", TextBox2.Text);
                comm.Parameters.AddWithValue("@Param3", TextBox3.Text);
                comm.Parameters.AddWithValue("@Param4", TextBox4.Text);
                comm.Parameters.AddWithValue("@Param5", DropDownList1.SelectedValue);
                comm.Parameters.AddWithValue("@Param6", TextBox6.Text);
                comm.Parameters.AddWithValue("@Param7", TextBox7.Text);
                comm.Parameters.AddWithValue("@Param8", TextBox5.Text);
               
                //comm.Parameters.AddWithValue("@Param11", TextBox8.Text);
                int rowsAffected = comm.ExecuteNonQuery();
                con.Close();

                if (rowsAffected > 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Successfully Inserted');", true);
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Insertion Failed');", true);
                }
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('An error occurred: " + ex.Message + "');", true);
            }








        }

        protected void Button4_Click(object sender, EventArgs e)
        {
                        SqlConnection con = new SqlConnection("Data Source=LAPTOP-HFTJM47B\\SQLEXPRESS01;Initial Catalog=TRUE_CURE;Integrated Security=True;Encrypt=False");


            try
            {
                // Clear values in textboxes and dropdownlist
                TextBox1.Text = "";
                TextBox2.Text = "";
                TextBox3.Text = "";
                TextBox4.Text = "";
                DropDownList1.SelectedIndex = 0; // Assuming the default index is 0

                // Additional textboxes to clear if needed
                TextBox6.Text = "";
                TextBox7.Text = "";
                TextBox5.Text = "";

                // Optionally, you can set focus to the first textbox after resetting
                TextBox1.Focus();

                // Optionally, display a message confirming reset
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('Form Reset Successfully');", true);
            }
            catch (Exception ex)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "script", "alert('An error occurred: " + ex.Message + "');", true);
            }




        }
    }
}