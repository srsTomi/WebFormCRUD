using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;

public partial class Prijava : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btnPrijavi_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "SELECT * FROM Zaposlenik WHERE   KorisnickoIme = @KorisnickoIme AND Lozinka = @Lozinka";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@KorisnickoIme", txtKorisnickoIme.Text);
            cmd.Parameters.AddWithValue("@Lozinka", txtLozinka.Text);
     

            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    ListItem li = new ListItem();
                    ListItem li2 = new ListItem();
                    li.Text = dr["Ime"].ToString() +  " " + dr["Prezime"].ToString();
                    li.Value = dr["IdZaposlenik"].ToString();
                    li2.Text = dr["IdZaposlenik"].ToString();
                    li2.Value = dr["IdZaposlenik"].ToString();
                    Session["Ime"] = li;
                    Session["Id"] = li2;
                    Response.Redirect("Predbiljezbe.aspx");
                }
                
            }
            else
            {
                lblError.Text = "Unijeli ste neispravne podatke, pokušajte ponovno!";
            }
        }        
    }
}