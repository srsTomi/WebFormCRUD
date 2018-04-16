using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Seminari : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        ListItem li = (ListItem)Session["Ime"];
        if (!Page.IsPostBack)
        {
            
            FilanjeGv();
            SeminarHidden();
            btnDodaj.Visible = false;
            btnIzmijeni.Visible = false;           
        }
        
    }
    private void FilanjeGv()
    {
        ListItem li = (ListItem)Session["Ime"];
        if (li.Text == "Admin Admin")
        {
            lblIme.Text = "Pozdrav Admin, uspješno ste ulogirani!";
            lblPredavac.Text = "Id Zaposlenika*";
            txtPredavac.ReadOnly = false;
            txtPredavac.BackColor = System.Drawing.Color.White;
            lnkZaposlenici.Visible = true;
        }
        else
        {
            lblIme.Text = "Pozdrav " + li.Text + ", uspješno ste ulogirani!";
        }
        ListItem li2 = (ListItem)Session["Id"];
        int IdZaposlenik = int.Parse(li2.Text);
        SqlDataAdapter da = new SqlDataAdapter();
        SqlDataAdapter daZaposlenici = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {

            if (li.Text == "Admin Admin")
            {
                string cmdText = "SELECT s.IdSeminar, s.Naziv, s.Opis, CONVERT(nvarchar(10), s.Datum, 103) as Datum, ";
                cmdText += " z.Ime + ' ' + z.Prezime as Predavac, s.Zatvoren, sum(isnull(case when p.Status > 0 then p.Status else 0 end, 0)) AS BrPredbiljezbi ";
                cmdText += " FROM Seminar s LEFT Join Predbiljezba p ON s.IdSeminar = p.IdSeminar LEFT JOIN Zaposlenik z ON s.IdZaposlenik = z.IdZaposlenik ";
                cmdText += " GROUP BY s.IdSeminar, s.Naziv, s.Opis, s.Datum, z.Ime, z.Prezime, s.Zatvoren ORDER BY CONVERT(datetime, Datum, 103) ASC";
                string cmdTextZaposlenici = "SELECT * FROM Zaposlenik";
                da.SelectCommand = new SqlCommand(cmdText, conn);
                daZaposlenici.SelectCommand = new SqlCommand(cmdTextZaposlenici, conn);
                
                DataTable dt = new DataTable();
                DataTable dtZaposlenici = new DataTable();
                da.Fill(dt);
                daZaposlenici.Fill(dtZaposlenici);

                gvSeminari.DataSource = dt;
                gvSeminari.Columns[0].Visible = true;
                
                gvSeminari.DataBind();
                gvSeminari.Columns[0].Visible = false;
                
                gvZaposlenici.DataSource = dtZaposlenici;
                gvZaposlenici.DataBind();
                gvZaposlenici.Visible = false;
                
            }
            else
            {
                string cmdText = " SELECT s.IdSeminar, s.Naziv, s.Opis, CONVERT(nvarchar(10), s.Datum, 103) as Datum, z.Ime + ' ' + z.Prezime as Predavac, ";
                cmdText += " s.Zatvoren, sum(isnull(case when p.Status > 0 then p.Status else 0 end, 0)) AS BrPredbiljezbi ";
                cmdText += " FROM Seminar s LEFT Join Predbiljezba p ON s.IdSeminar = p.IdSeminar LEFT JOIN Zaposlenik z ON s.IdZaposlenik = z.IdZaposlenik ";
                cmdText += " WHERE s.IdZaposlenik = @IdZaposlenik GROUP BY s.IdSeminar, s.Naziv, s.Opis, s.Datum, z.Ime, z.Prezime, s.Zatvoren ORDER BY CONVERT(datetime, Datum, 103) ASC";
                da.SelectCommand = new SqlCommand(cmdText, conn);
               
                da.SelectCommand.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                DataTable dt = new DataTable();
                da.Fill(dt);
               
                    gvSeminari.DataSource = dt;
                    
                    gvSeminari.Columns[0].Visible = true;
                    gvSeminari.DataBind();
                    gvSeminari.Columns[0].Visible = false;
               
            }

        }
    }

    private void SeminarVisible()
    {        
        lblNaziv.Visible = true;
        lblOpis.Visible = true;
        lblPredavac.Visible = true;
        lblDatum.Visible = true;
        txtNaziv.Visible = true;
        txtOpis.Visible = true;
        txtDatum.Visible = true;
        txtPredavac.Visible = true;
        lblZatvoriSeminar.Visible = true;
        chkZatvoriSeminar.Visible = true;
        btnOdustani.Visible = true;
    }

    private void SeminarHidden()
    {
        
        lblNaziv.Visible = false;
        lblOpis.Visible = false;
        lblPredavac.Visible = false;
        lblDatum.Visible = false;
        txtNaziv.Visible = false;
        txtOpis.Visible = false;
        txtDatum.Visible = false;
        txtPredavac.Visible = false;
        lblZatvoriSeminar.Visible = false;
        chkZatvoriSeminar.Visible = false;
        btnOdustani.Visible = false;
    }

    private void PrazniListuSeminara()
    {
        txtNaziv.Text = "";
        txtOpis.Text = "";
        txtDatum.Text = "";
        txtPredavac.Text = "";
        chkZatvoriSeminar.Checked = false;
    }

    protected void gvSeminari_SelectedIndexChanged(object sender, EventArgs e)
    {
        SeminarVisible();
        btnDodaj.Visible = false;
        btnIzmijeni.Visible = true;
        
        lblHeaderSeminar.Text = "Izmijeni seminar:";
        
       
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            ListItem li = (ListItem)Session["Ime"];
            string cmdText = "SELECT IdSeminar, Naziv, Opis, CONVERT(nvarchar(10), Datum, 103) as Datum, IdZaposlenik, Zatvoren FROM Seminar WHERE IdSeminar = @IdSeminar";
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            for (int i = 0; i < gvSeminari.Rows.Count; i++)
            {
                if (gvSeminari.SelectedIndex == i)
                {

                    string value = gvSeminari.Rows[i].Cells[0].Text;
                    
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
                        txtNaziv.Text = dr["Naziv"].ToString();
                        txtOpis.Text = dr["Opis"].ToString();
                        txtDatum.Text = dr["Datum"].ToString();
                        
                        if (li.Text == "Admin Admin")
                        {
                            txtPredavac.Text = dr["IdZaposlenik"].ToString();
                            gvZaposlenici.Visible = true;
                            
                        }
                        else
                        {
                            txtPredavac.Text = li.Text;
                        }

                    }
                }
            }
            dr.Close();
            cmd.Connection.Close();
            
        }
    }
 

    protected void gvSeminari_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {

        PrazniListuSeminara();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            
            
            string cmdText = "DELETE FROM Seminar WHERE IdSeminar = @IdSeminar";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            int id = int.Parse(gvSeminari.Rows[e.RowIndex].Cells[0].Text);
            cmd.Parameters.AddWithValue("@IdSeminar", id);
           
            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            FilanjeGv();
            lblHeaderSeminar.Text = "Uspješno ste obrisali seminar!";
    
        }
    }
    
    protected void lnkDodajNoviSeminar_Click(object sender, EventArgs e)
    {
        
        btnIzmijeni.Visible = false;
        SeminarVisible();
        btnDodaj.Visible = true;
        lblHeaderSeminar.Text = "Dodaj novi seminar:";
        PrazniListuSeminara();
        ListItem li = (ListItem)Session["Ime"];
        
        if (li.Text == "Admin Admin")
        {
            txtPredavac.ReadOnly = false;
            txtPredavac.Text = "";
            lblZatvoriSeminar.Visible = false;
            chkZatvoriSeminar.Visible = false;
            gvZaposlenici.Visible = true;
            
        }
        else
        {
            txtPredavac.Text = li.Text;
        }
    }

    protected void btnOdustani_Click(object sender, EventArgs e)
    {
        SeminarHidden();
        PrazniListuSeminara();
        btnDodaj.Visible = false;
        btnIzmijeni.Visible = false;
        lblHeaderSeminar.Text = "";
        gvZaposlenici.Visible = false;       
    }

    protected void btnIzmijeni_Click(object sender, EventArgs e)
    {
        ListItem li = (ListItem)Session["Ime"];
        ListItem li2 = (ListItem)Session["Id"];
        int IdZaposlenik = int.Parse(li2.Text);
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {

            if (chkZatvoriSeminar.Checked == true)
            {
                
                string cmdText =  "UPDATE Seminar SET Naziv = @Naziv, Opis = @Opis, Datum = @Datum, Zatvoren = 1, IdZaposlenik = @IdZaposlenik WHERE IdSeminar = @IdSeminar";
                DateTime datum = Convert.ToDateTime(txtDatum.Text);
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();


                cmd.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
                cmd.Parameters.AddWithValue("@Opis", txtOpis.Text);
                cmd.Parameters.AddWithValue("@Datum", datum);
                cmd.Parameters.AddWithValue("@IdSeminar", hfIdSeminar.Value);

                if (li.Text == "Admin Admin")
                {
                    cmd.Parameters.AddWithValue("@IdZaposlenik", txtPredavac.Text);
                    gvZaposlenici.Visible = false;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                }
                lblHeaderSeminar.Text = "Uspješno ste izmijenili seminar!";
                cmd.ExecuteNonQuery();

                FilanjeGv();
                SeminarHidden();
                btnIzmijeni.Visible = false;

                PrazniListuSeminara();
                cmd.Connection.Close();
            }
            else
            {
                
                string cmdText = "UPDATE Seminar SET Naziv = @Naziv, Opis = @Opis,  Datum = @Datum , Zatvoren = 0, IdZaposlenik = @IdZaposlenik WHERE IdSeminar = @IdSeminar";
                DateTime datum = Convert.ToDateTime(txtDatum.Text);
                SqlCommand cmd = new SqlCommand(cmdText, conn);
                cmd.Connection.Open();


                cmd.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
                cmd.Parameters.AddWithValue("@Opis", txtOpis.Text);
                cmd.Parameters.AddWithValue("@Datum", datum);
                cmd.Parameters.AddWithValue("@IdSeminar", hfIdSeminar.Value);

                if (li.Text == "Admin Admin")
                {
                    cmd.Parameters.AddWithValue("@IdZaposlenik", txtPredavac.Text);
                    gvZaposlenici.Visible = false;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                }
                try
                {
                    cmd.ExecuteNonQuery();
                    lblHeaderSeminar.Text = "Uspješno ste izmijenili seminar!";
                    FilanjeGv();
                    SeminarHidden();
                    btnIzmijeni.Visible = false;

                    PrazniListuSeminara();
                    cmd.Connection.Close();
                }
                catch (Exception)
                {

                    lblHeaderSeminar.Text = "Došlo je do pogreške, provjerite upisane podatke!";
                    gvZaposlenici.Visible = true;
                }
            }
            
        }
    }

    protected void btnDodaj_Click(object sender, EventArgs e)
    {
        ListItem li = (ListItem)Session["Ime"];
        ListItem li2 = (ListItem)Session["Id"];
        int IdZaposlenik = int.Parse(li2.Text);
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {

            
            string cmdText = "INSERT INTO Seminar (Naziv, Opis,  Datum, IdZaposlenik) VALUES (@Naziv, @Opis,  @Datum, @IdZaposlenik)  ";
            DateTime datum = Convert.ToDateTime(txtDatum.Text);
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            cmd.Parameters.AddWithValue("@Naziv", txtNaziv.Text);
            cmd.Parameters.AddWithValue("@Opis", txtOpis.Text);
            cmd.Parameters.AddWithValue("@Datum", datum);
           
            if (li.Text == "Admin Admin")
            {
                cmd.Parameters.AddWithValue("@IdZaposlenik", txtPredavac.Text);
                gvZaposlenici.Visible = false;
            }
            else
            {
                cmd.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
            }
            try
            {
                cmd.ExecuteNonQuery();

                cmd.Connection.Close();

                SeminarHidden();
                PrazniListuSeminara();
                lblHeaderSeminar.Text = "Uspješno ste dodali seminar!";
                FilanjeGv();
                btnDodaj.Visible = false;
            }
            catch (Exception)
            {

                lblHeaderSeminar.Text = "Došlo je do pogreške, provjerite upisane podatke!";
                gvZaposlenici.Visible = true;
            }            
        }
    }

    protected void btnPrikazi_Click(object sender, EventArgs e)
    {
        SeminarHidden();
        btnDodaj.Visible = false;
        lblHeaderSeminar.Visible = false;
        gvZaposlenici.Visible = false;
        btnIzmijeni.Visible = false;
        SqlDataAdapter da = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = " SELECT s.IdSeminar, s.Naziv, s.Opis, CONVERT(nvarchar(10), s.Datum, 103) as Datum, z.Ime + ' ' + z.Prezime as Predavac, ";
            cmdText += " s.Zatvoren, sum(isnull(case when p.Status > 0 then p.Status else 0 end, 0)) AS BrPredbiljezbi ";
            cmdText += " FROM Seminar s LEFT Join Predbiljezba p ON s.IdSeminar = p.IdSeminar LEFT JOIN Zaposlenik z ON s.IdZaposlenik = z.IdZaposlenik ";
            cmdText += " WHERE (s.Naziv LIKE @Pretraga OR s.Opis LIKE @Pretraga OR z.Ime LIKE @Pretraga OR z.Prezime LIKE @Pretraga)  ";
            cmdText += " GROUP BY s.IdSeminar, s.Naziv, s.Opis, s.Datum, z.Ime, z.Prezime, s.Zatvoren ";
            da.SelectCommand = new SqlCommand(cmdText, conn);
            da.SelectCommand.Parameters.AddWithValue("@Pretraga", "%" + txtKljucnaRijec.Text.Trim() + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
            gvSeminari.Columns[0].Visible = true;
            gvSeminari.DataSource = dt;

            gvSeminari.DataBind();
            gvSeminari.Columns[0].Visible = false;
            btnSviSeminari.Visible = true;
        }
    }

    protected void btnSviSeminari_Click(object sender, EventArgs e)
    {
        SeminarHidden();
        lblHeaderSeminar.Visible = false;
        btnIzmijeni.Visible = false;
        btnDodaj.Visible = false;
        txtKljucnaRijec.Text = "";
        btnSviSeminari.Visible = false;
        FilanjeGv();
    }
    protected void gvSeminari_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvSeminari.PageIndex = e.NewPageIndex;
        FilanjeGv();
    }
 }