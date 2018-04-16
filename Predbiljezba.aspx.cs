using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Predbiljezba : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            FilanjeGv();
            btnSviSeminari.Visible = false;
        }
        
    }

    private void FilanjeGv()
    {
        SqlDataAdapter da = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "SELECT s.IdSeminar, s.Naziv, s.Opis, CONVERT(nvarchar(10), s.Datum, 103) as Datum, z.Ime + ' ' + z.Prezime AS Predavac, s.Zatvoren";
            cmdText += " FROM Seminar s LEFT JOIN Zaposlenik z on s.IdZaposlenik = z.IdZaposlenik WHERE (s.Zatvoren = 0 OR s.Zatvoren IS null) AND Datum >  GETDATE()";
            cmdText += " ORDER BY CONVERT(datetime, Datum, 103) ASC";
            da.SelectCommand = new SqlCommand(cmdText, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvPonudaSeminara.DataSource = dt;
            gvPonudaSeminara.Columns[0].Visible = true;
            gvPonudaSeminara.DataBind();
            gvPonudaSeminara.Columns[0].Visible = false;

        }
    }

    private void PraznjenjePrijave()
    {
        txtIme.Text = "";
        txtPrezime.Text = "";
        txtAdresa.Text = "";
        txtDatumSeminara.Text = "";
        txtNazivSeminara.Text = "";
        txtPredavac.Text = "";
        hfIdSeminar.Value = null;
    }
    private void PrijavaVisible()
    {
        lblPotvrda.Visible = false;
        lblPrijavaSeminara.Visible = true;
        lblIme.Visible = true;
        lblPrezime.Visible = true;
        lblNazivSeminara.Visible = true;
        lblAdresa.Visible = true;
        lblDatumSeminara.Visible = true;
        lblPredavac.Visible = true;
        txtIme.Visible = true;
        txtPrezime.Visible = true;
        txtAdresa.Visible = true;
        txtNazivSeminara.Visible = true;
        txtDatumSeminara.Visible = true;
        txtPredavac.Visible = true;
        btnPrijavi.Visible = true;
        btnOdustani.Visible = true;
        txtDatumSeminara.ReadOnly = true;
        txtNazivSeminara.ReadOnly = true;
        txtPredavac.ReadOnly = true;
        
    }
    private void PrijavaHidden()
    {
        lblPotvrda.Visible = false;
        lblPrijavaSeminara.Visible = false;
        lblIme.Visible = false;
        lblPrezime.Visible = false;
        lblNazivSeminara.Visible = false;
        lblAdresa.Visible = false;
        lblDatumSeminara.Visible = false;
        lblPredavac.Visible = false;
        txtIme.Visible = false;
        txtPrezime.Visible = false;
        txtAdresa.Visible = false;
        txtNazivSeminara.Visible = false;
        txtDatumSeminara.Visible = false;
        txtPredavac.Visible = false;
        btnPrijavi.Visible = false;
        btnOdustani.Visible = false;
        txtDatumSeminara.ReadOnly = false;
        txtNazivSeminara.ReadOnly = false;
        txtPredavac.ReadOnly = false;
    }
 

    protected void gvPonudaSeminara_SelectedIndexChanged1(object sender, EventArgs e)
    {
        gvPonudaSeminara.EditIndex = -1;
        PrijavaVisible();
        txtNazivSeminara.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
        txtDatumSeminara.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
        txtPredavac.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "SELECT s.IdSeminar, s.Naziv, s.Opis, CONVERT(nvarchar(10), s.Datum, 103) as Datum, s.IdZaposlenik, z.Ime + ' ' + z.Prezime AS Predavac ";
            cmdText += " FROM Seminar s LEFT JOIN Zaposlenik z ON s.IdZaposlenik = z.IdZaposlenik WHERE s.IdSeminar = @IdSeminar ";
            SqlCommand cmd = new SqlCommand(cmdText, conn);

           for (int i = 0; i < gvPonudaSeminara.Rows.Count; i++)
            {
                if (gvPonudaSeminara.SelectedIndex == i)
                {

                    string value = gvPonudaSeminara.Rows[i].Cells[0].Text;
                    hfIdSeminar.Value = value;
                    

                }
            }
           
            cmd.Parameters.AddWithValue("@IdSeminar", hfIdSeminar.Value);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtNazivSeminara.Text = dr["Naziv"].ToString();
                        txtDatumSeminara.Text = dr["Datum"].ToString();
                        txtPredavac.Text = dr["Predavac"].ToString();
                        hfIdSeminar.Value = dr["IdSeminar"].ToString();
                        hfIdZaposlenik.Value = dr["IdZaposlenik"].ToString();
                    }
                }
            }
            dr.Close();
            cmd.Connection.Close();
        }
    }

    protected void btnPrijavi_Click(object sender, EventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "INSERT INTO Predbiljezba (Ime, Prezime, Adresa, IdSeminar, IdZaposlenik) ";
            cmdText += " VALUES (@Ime, @Prezime, @Adresa, @IdSeminar, @IdZaposlenik) ";
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            cmd.Parameters.AddWithValue("@Ime", txtIme.Text);
            cmd.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            cmd.Parameters.AddWithValue("@Adresa", txtAdresa.Text);
            cmd.Parameters.AddWithValue("@IdSeminar", hfIdSeminar.Value);
            
            cmd.Parameters.AddWithValue("@IdZaposlenik", hfIdZaposlenik.Value);
            cmd.Connection.Open();

            cmd.ExecuteNonQuery();
           
            cmd.Connection.Close();

            PrijavaHidden();
            lblPotvrda.Visible = true;

            PraznjenjePrijave();
        }
    }

    protected void btnOdustani_Click(object sender, EventArgs e)
    {
        PraznjenjePrijave();
        PrijavaHidden();
    }

    protected void btnPretraga_Click(object sender, EventArgs e)
    {
        PrijavaHidden();
        SqlDataAdapter da = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "SELECT s.IdSeminar, s.Naziv, s.Opis, CONVERT(nvarchar(10), s.Datum, 103) as Datum, z.Ime + ' ' + z.Prezime AS Predavac, s.Zatvoren ";
            cmdText += " FROM Seminar s left join Zaposlenik z ON s.IdZaposlenik = z.IdZaposlenik WHERE (s.Zatvoren = 0 OR s.Zatvoren IS null) AND Datum >  GETDATE() ";
            cmdText += " AND (s.Naziv LIKE @Pretraga OR s.Opis LIKE @Pretraga OR z.Ime LIKE @Pretraga OR z.Prezime LIKE @Pretraga) ORDER BY CONVERT(datetime, Datum, 103) ASC ";
            da.SelectCommand = new SqlCommand(cmdText, conn);
            da.SelectCommand.Parameters.AddWithValue("@Pretraga", "%" + txtPretraga.Text.Trim() + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvPonudaSeminara.DataSource = dt;
            gvPonudaSeminara.Columns[0].Visible = true;
            gvPonudaSeminara.DataBind();
            gvPonudaSeminara.Columns[0].Visible = false;
            btnSviSeminari.Visible = true;

        }
    }

    protected void btnSviSeminari_Click(object sender, EventArgs e)
    {
        PrijavaHidden();
        FilanjeGv();
        btnSviSeminari.Visible = false;
        txtPretraga.Text = "";
    }
}