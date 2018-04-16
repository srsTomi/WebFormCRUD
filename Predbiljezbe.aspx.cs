using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Predbiljezbe : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {
            FilanjeGv();
            DropDownLista();
            ObradaHidden();
            btnSvePredbiljezbe.Visible = false;            
        }
    }
    private void FilanjeGv()
    {
        lblPrediljezbe.Text = "";
        ddlStatusPrijave.SelectedIndex = 0;
        ListItem li = (ListItem)Session["Ime"];
        if (li.Text == "Admin Admin")
        {
            lblIme.Text = "Pozdrav Admin, uspješno ste ulogirani!";
            lnkZaposlenici.Visible = true;
        }
        else
        {
            lblIme.Text = "Pozdrav " + li.Text + ", uspješno ste ulogirani!";
        }
        ListItem li2 = (ListItem)Session["Id"];
        int IdZaposlenik = int.Parse(li2.Text);
        SqlDataAdapter da = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {

            if (li.Text == "Admin Admin")
            {
                string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen ";
                cmdText += " FROM Predbiljezba p LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar ORDER BY CONVERT(datetime, Datum, 103) ASC";
                da.SelectCommand = new SqlCommand(cmdText, conn);
                
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvPredbiljezbe.DataSource = dt;

                    gvPredbiljezbe.DataBind();
                }
                else
                {
                    
                    lblPrediljezbe.Text = "                          Nema predbilježbi!";
                    gvPredbiljezbe.DataSource = dt;

                    gvPredbiljezbe.DataBind();
                }
                
               
            }
            else
            {
                string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen ";
                cmdText += " FROM Predbiljezba p LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE p.IdZaposlenik = @IdZaposlenik ORDER BY CONVERT(datetime, Datum, 103) ASC";
                da.SelectCommand = new SqlCommand(cmdText, conn);
                da.SelectCommand.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gvPredbiljezbe.DataSource = dt;
                    
                    gvPredbiljezbe.DataBind();
                    
                }
                else
                {
                    lblPrediljezbe.Text = "                          Nema predbilježbi za vas seminar!";
                    gvPredbiljezbe.DataSource = dt;

                    gvPredbiljezbe.DataBind();
                    
                }
            }

        }
    }

    private void DropDownLista()
    {
        ddlStatusPrijave.Items.Add("Sve prijave");
        ddlStatusPrijave.Items.Add("Otvorene prijave");
        ddlStatusPrijave.Items.Add("Potvđene prijave");
        ddlStatusPrijave.Items.Add("Odbijene prijave");
    }

    private void ObradaHidden()
    {
        lblBr.Visible = false;
        lblImePredbiljezbe.Visible = false;
        lblPrezime.Visible = false;
        lblAdresa.Visible = false;
        txtBr.Visible = false;
        txtIme.Visible = false;
        txtPrezime.Visible = false;
        txtAdresa.Visible = false;
        rblStatus.Visible = false;
        btnPotvrdi.Visible = false;
        btnOdustani.Visible = false;
    }

    private void ObradaVisible()
    {
        txtBr.BackColor = System.Drawing.ColorTranslator.FromHtml("#d3d3d3");
        lblBr.Visible = true;
        lblImePredbiljezbe.Visible = true;
        lblPrezime.Visible = true;
        lblAdresa.Visible = true;
        txtBr.Visible = true;
        txtIme.Visible = true;
        txtPrezime.Visible = true;
        txtAdresa.Visible = true;
        rblStatus.Visible = true;
        btnPotvrdi.Visible = true;
        btnOdustani.Visible = true;
        
    }

    protected void gvPredbiljezbe_SelectedIndexChanged(object sender, EventArgs e)
    {
        ObradaVisible();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "SELECT * FROM Predbiljezba WHERE IdPredbiljezba = @IdPredbiljezba";
            SqlCommand cmd = new SqlCommand(cmdText, conn);

            for (int i = 0; i < gvPredbiljezbe.Rows.Count; i++)
            {
                if (gvPredbiljezbe.SelectedIndex == i)
                {
                    string value = gvPredbiljezbe.Rows[i].Cells[0].Text;
                    hfPredbiljazba.Value = value;
                }
            }
            cmd.Parameters.AddWithValue("@IdPredbiljezba", hfPredbiljazba.Value);
            cmd.Connection.Open();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr != null)
            {
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txtBr.Text = dr["IdPredbiljezba"].ToString();
                        txtIme.Text = dr["Ime"].ToString();
                        txtPrezime.Text = dr["Prezime"].ToString();
                        txtAdresa.Text = dr["Adresa"].ToString();                    
                    }
                }
            }
            dr.Close();
            cmd.Connection.Close();
        }
    }

    protected void btnPotvrdi_Click(object sender, EventArgs e)
    {       
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            int statusPotvrden = -1;
            int statusOdbijen = -1;
            string cmdText = "UPDATE Predbiljezba SET Ime = @Ime, Prezime = @Prezime, Adresa = @Adresa, Status = @Status, Odbijen = @Odbijen ";
            cmdText += " WHERE IdPredbiljezba = @IdPredbiljezba ";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            if (rblStatus.SelectedIndex > 0)
            {
                statusPotvrden = 0;
                statusOdbijen = 1;
            }
            else
            {
                statusPotvrden = 1;
                statusOdbijen = 0;
            }

            cmd.Parameters.AddWithValue("@Ime", txtIme.Text);
            cmd.Parameters.AddWithValue("@Prezime", txtPrezime.Text);
            cmd.Parameters.AddWithValue("@Adresa", txtAdresa.Text);
            cmd.Parameters.AddWithValue("@Status", statusPotvrden);
            cmd.Parameters.AddWithValue("@Odbijen", statusOdbijen);
            cmd.Parameters.AddWithValue("IdPredbiljezba", hfPredbiljazba.Value);
            
            cmd.ExecuteNonQuery();

            FilanjeGv();
            ObradaHidden();

            cmd.Connection.Close();
            rblStatus.ClearSelection();

        }        
    }

    protected void gvPredbiljezbe_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
            string cmdText = "DELETE FROM Predbiljezba WHERE IdPredbiljezba = @IdPredbiljezba";
            SqlCommand cmd = new SqlCommand(cmdText, conn);
            cmd.Connection.Open();
            int id = int.Parse(gvPredbiljezbe.Rows[e.RowIndex].Cells[0].Text);
            cmd.Parameters.AddWithValue("@IdPredbiljezba", id);

            cmd.ExecuteNonQuery();
            cmd.Connection.Close();
            FilanjeGv();
            lblPrediljezbe.Text = "Uspješno ste obrisali Prebilježbu!";

        }
    }

    protected void btnOdustani_Click(object sender, EventArgs e)
    {
        ObradaHidden();
        rblStatus.ClearSelection();
    }

    protected void ddlStatusPrijave_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (ddlStatusPrijave.SelectedItem.Text == "Sve prijave")
        {
            FilanjeGv();
        }
        if (ddlStatusPrijave.SelectedItem.Text == "Otvorene prijave")
        {
            lblPrediljezbe.Text = "";
            ListItem li = (ListItem)Session["Ime"];
          
            ListItem li2 = (ListItem)Session["Id"];
            int IdZaposlenik = int.Parse(li2.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                if (li.Text == "Admin Admin")
                {
                    string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen ";
                    cmdText += " FROM Predbiljezba p LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE Status IS null ORDER BY CONVERT(datetime, Datum, 103) ASC ";
                    da.SelectCommand = new SqlCommand(cmdText, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                    }
                    else
                    {                     
                        lblPrediljezbe.Text = "                          Nema otvorenih predbilježbi!";
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                    }
                }
                else
                {
                    string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen ";
                    cmdText += " FROM Predbiljezba p LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE p.IdZaposlenik = @IdZaposlenik AND (Status IS null) ";
                    cmdText += " ORDER BY CONVERT(datetime, Datum, 103) ASC";
                    da.SelectCommand = new SqlCommand(cmdText, conn);
                    da.SelectCommand.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();                     
                    }
                    else
                    {
                        lblPrediljezbe.Text = "                          Nema otvorenih predbilježbi za vas seminar!";
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                       
                    }
                }

            }
        }
        if  (ddlStatusPrijave.SelectedItem.Text == "Potvđene prijave")
        {
            lblPrediljezbe.Text = "";
            ListItem li = (ListItem)Session["Ime"];
         
            ListItem li2 = (ListItem)Session["Id"];
            int IdZaposlenik = int.Parse(li2.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                if (li.Text == "Admin Admin")
                {
                    string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen FROM Predbiljezba p";
                    cmdText += " LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE Status = 1 ORDER BY CONVERT(datetime, Datum, 103) ASC";
                    da.SelectCommand = new SqlCommand(cmdText, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                    }
                    else
                    {
                        lblPrediljezbe.Text = "                          Nema potvrđenih predbilježbi!";
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                    }
                }
                else
                {
                    string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen ";
                    cmdText += " FROM Predbiljezba p LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE p.IdZaposlenik = @IdZaposlenik AND (Status = 1 ) ";
                    cmdText += " ORDER BY CONVERT(datetime, Datum, 103) ASC";
                    da.SelectCommand = new SqlCommand(cmdText, conn);
                    da.SelectCommand.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                        
                    }
                    else
                    {
                        lblPrediljezbe.Text = "                          Nema potvrđenih predbilježbi za vas seminar!";
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                        
                    }
                }

            }
        }
        if  (ddlStatusPrijave.SelectedItem.Text == "Odbijene prijave")
        {
            lblPrediljezbe.Text = "";
            ListItem li = (ListItem)Session["Ime"];
         
            ListItem li2 = (ListItem)Session["Id"];
            int IdZaposlenik = int.Parse(li2.Text);
            SqlDataAdapter da = new SqlDataAdapter();
            string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
            using (SqlConnection conn = new SqlConnection(connString))
            {

                if (li.Text == "Admin Admin")
                {
                    string cmdText = " SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen FROM Predbiljezba p ";
                    cmdText += " LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE Odbijen = 1 ORDER BY CONVERT(datetime, Datum, 103) ASC";
                    da.SelectCommand = new SqlCommand(cmdText, conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                    }
                    else
                    {
                        lblPrediljezbe.Text = "                          Nema odbijenih predbilježbi!";
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                    }
                }
                else
                {
                    string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen ";
                    cmdText += " FROM Predbiljezba p LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE p.IdZaposlenik = @IdZaposlenik AND (Odbijen = 1 ) ";
                    cmdText += " ORDER BY CONVERT(datetime, Datum, 103) ASC";
                    da.SelectCommand = new SqlCommand(cmdText, conn);
                    da.SelectCommand.Parameters.AddWithValue("@IdZaposlenik", IdZaposlenik);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt.Rows.Count > 0)
                    {
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                        
                    }
                    else
                    {
                        lblPrediljezbe.Text = "                          Nema odbijenih predbilježbi za vas seminar!";
                        gvPredbiljezbe.DataSource = dt;

                        gvPredbiljezbe.DataBind();
                        
                    }
                }

            }
        }
    }

    protected void btnPrikazi_Click(object sender, EventArgs e)
    {
        ObradaHidden();
        SqlDataAdapter da = new SqlDataAdapter();
        string connString = ConfigurationManager.ConnectionStrings["APP"].ConnectionString;
        using (SqlConnection conn = new SqlConnection(connString))
        {
           
            string cmdText = "SELECT p.IdPredbiljezba, p.Ime, p.Prezime, p.Adresa, s.Naziv, CONVERT(nvarchar(10), s.Datum, 103) as Datum, p.Status, p.Odbijen FROM Predbiljezba p";
            cmdText += " LEFT JOIN Seminar s ON p.IdSeminar = s.IdSeminar WHERE (p.Ime LIKE @Pretraga OR p.Prezime LIKE @Pretraga OR p.Adresa LIKE @Pretraga)";
            cmdText += " ORDER BY CONVERT(datetime, Datum, 103) ASC";
            da.SelectCommand = new SqlCommand(cmdText, conn);
            da.SelectCommand.Parameters.AddWithValue("@Pretraga", "%" + txtKljucnaRijec.Text.Trim() + "%");
            DataTable dt = new DataTable();
            da.Fill(dt);
           
                gvPredbiljezbe.DataSource = dt;

                gvPredbiljezbe.DataBind();

                btnSvePredbiljezbe.Visible = true;                    
        }
    }

    protected void btnSvePredbiljezbe_Click(object sender, EventArgs e)
    {
        ObradaHidden();
        txtKljucnaRijec.Text = "";
        FilanjeGv();
        btnSvePredbiljezbe.Visible = false;
    }

    protected void gvPredbiljezbe_PageIndexChanging(Object sender, GridViewPageEventArgs e)
    {
        gvPredbiljezbe.PageIndex = e.NewPageIndex;
        FilanjeGv();
    }
}
