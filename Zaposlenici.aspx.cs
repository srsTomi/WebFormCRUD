using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Zaposlenici : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            FilanjeGV();
            FormHidden();
            lnkZaposlenici.Visible = true;
            lblIme.Text = "Pozdrav Admin, uspješno ste ulogirani!";
        }
    }
    private void FilanjeGV()
    {
        ListItem li = (ListItem)Session["Ime"];
        SqlDataAdapter da = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            
            da.SelectCommand = new SqlCommand("SELECT * FROM Zaposlenik", conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvZaposlenici.DataSource = dt;
            gvZaposlenici.DataBind();
            

        }

    }
    private void FormHidden()
    {
        lblHeader.Visible = false;
        
        lblImeZaposlenika.Visible = false;
        lblPrezime.Visible = false;
        lblKorisnickoIme.Visible = false;
        lblLozinka.Visible = false;
        
        txtIme.Visible = false;
        txtPrezime.Visible = false;
        txtKorisnickoIme.Visible = false;
        txtLozinka.Visible = false;
        btnDodaj.Visible = false;
        btnIzmijeni.Visible = false;
        btnOdustani.Visible = false;
    }
    private void FormVisible()
    {
        lblHeader.Visible = true;
        
        lblImeZaposlenika.Visible = true;
        lblPrezime.Visible = true;
        lblKorisnickoIme.Visible = true;
        lblLozinka.Visible = true;
        
        txtIme.Visible = true;
        txtPrezime.Visible = true;
        txtKorisnickoIme.Visible = true;
        txtLozinka.Visible = true;
        btnDodaj.Visible = true;
        btnIzmijeni.Visible = true;
        btnOdustani.Visible = true;
    }

    private void ClearForm()
    {
        txtIme.Text = "";
        txtPrezime.Text = "";
        txtKorisnickoIme.Text = "";
        txtLozinka.Text = "";
    }


    protected void btnDodajNovog_Click(object sender, EventArgs e)
    {
        FormVisible();
        ClearForm();
        lblHeader.Text = "Dodaj novog zaposlenika:";
        btnIzmijeni.Visible = false;
       
    }

    protected void gvPonudaSeminara_SelectedIndexChanged(object sender, EventArgs e)
    {
        
        FormVisible();
        lblHeader.Text = "Izmijeni postojećeg zaposlenika:";
        btnDodaj.Visible = false;
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            
            SqlCommand cmd = new SqlCommand("SELECT * FROM Zaposlenik WHERE IdZaposlenik = @IdZaposlenik", conn);

            for (int i = 0; i < gvZaposlenici.Rows.Count; i++)
            {
                if (gvZaposlenici.SelectedIndex == i)
                {

                    string value = gvZaposlenici.Rows[i].Cells[0].Text;
                    hfZaposlenici.Value = value;


                }
            }

            cmd.Parameters.AddWithValue("@IDZaposlenik", hfZaposlenici.Value);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtIme.Text = dr["Ime"].ToString();
                        txtPrezime.Text = dr["Prezime"].ToString();
                        txtKorisnickoIme.Text = dr["KorisnickoIme"].ToString();
                        txtLozinka.Text = dr["Lozinka"].ToString();
                        hfZaposlenici.Value = dr["IdZaposlenik"].ToString();
                    }
                }
            }
            dr.Close();
            cmd.Connection.Close();
        }
    }

    protected void btnDodaj_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "INSERT INTO Zaposlenik (Ime, Prezime, KorisnickoIme, Lozinka) VALUES (@Ime, @Prezime, @KorisnickoIme, @Lozinka)";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@Ime", txtIme.Text);
            cmd.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            cmd.Parameters.AddWithValue("@KorisnickoIme", txtKorisnickoIme.Text);
            cmd.Parameters.AddWithValue("@Lozinka", txtLozinka.Text);
            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
            FilanjeGV();
            FormHidden();
            ClearForm();
            lblHeader.Visible = true;
            lblHeader.Text = "Uspješno ste dodali novog zaposlenika!";

        }
    }

    protected void btnOdustani_Click(object sender, EventArgs e)
    {
        FormHidden();
    }

    protected void btnIzmijeni_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "UPDATE  Zaposlenik SET Ime= @Ime, Prezime = @Prezime, KorisnickoIme = @KorisnickoIme, Lozinka = @Lozinka ";
            cmdText += " WHERE IdZaposlenik = @IdZaposlenik ";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@Ime", txtIme.Text);
            cmd.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            cmd.Parameters.AddWithValue("@KorisnickoIme", txtKorisnickoIme.Text);
            cmd.Parameters.AddWithValue("@Lozinka", txtLozinka.Text);
            cmd.Parameters.AddWithValue("@IDZaposlenik", hfZaposlenici.Value);
            cmd.ExecuteNonQuery();

            cmd.Connection.Close();
            FilanjeGV();
            FormHidden();
            ClearForm();
            lblHeader.Visible = true;
            lblHeader.Text = "Uspješno ste izmijenili zaposlenika!";

        }
    }

    protected void gvZaposlenik_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {


            string cmdText = "DELETE FROM Zaposlenik WHERE IdZaposlenik = @IdZaposlenik";
            int id = int.Parse(gvZaposlenici.Rows[e.RowIndex].Cells[0].Text);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            
            cmd.Parameters.AddWithValue("@IdZaposlenik", id);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            
            lblHeader.Visible = true;
            lblHeader.Text = "Uspješno ste obrisali zaposlenika!";
            FilanjeGV();

        }
    }
}