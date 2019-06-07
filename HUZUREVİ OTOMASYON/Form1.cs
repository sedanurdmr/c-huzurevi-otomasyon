using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace HUZUREVİ_OTOMASYON
{
    public partial class Form1 : Form
    { 
        //bool[] yataklar = new bool[2];
        //bool[] odalar = new bool[30];

        Boolean yenikayitmi;
        int kacincikayit, kacincikayit1, kacincikayit2, kacincikayit3;
        OleDbConnection baglan = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\huzurevii.mdb");

        DataSet ds = new DataSet();
        BindingSource bs = new BindingSource();

        DataSet ds2 = new DataSet();
        BindingSource bs2 = new BindingSource();

        DataSet ds3 = new DataSet();
        BindingSource bs3 = new BindingSource();

        DataSet ds4 = new DataSet();
        BindingSource bs4 = new BindingSource();


        public Form1()
        {
            InitializeComponent();
        }

        ////*****OLUŞTURULAN BUTONLARIN YAPACAKLARI*****//

        //private void yatak_islem(object sender, EventArgs e)
        //{
        //    Button btn = (Button)sender;
        //    if (yataklar[int.Parse(btn.Name)])
        //    {
                
        //        btn.Enabled = true;
        //        btn.BackColor = Color.LightGray;
        //        yataklar[int.Parse(btn.Name)] = false;
        //    }
        //    else
        //    {
        //        btn.Enabled = false;
        //        btn.BackColor = Color.Firebrick;
        //        yataklar[int.Parse(btn.Name)] = true;
        //    }
        //    tbyatak.Text = btn.Text;
        //}

        //private void oda_islem(object sender, EventArgs e)
        //{
        //    Button btn2 = (Button)sender;
        //    if (odalar[int.Parse(btn2.Name)])
        //    {
        //        btn2.Enabled = true;
        //        btn2.BackColor = Color.LightGray;
        //        odalar[int.Parse(btn2.Name)] = false;
        //    }
        //    else
        //    {
        //        btn2.Enabled = false;
        //        btn2.BackColor = Color.Firebrick;
        //        odalar[int.Parse(btn2.Name)] = true;


        //    }
        //    tboda.Text = btn2.Text;
        //}

        //void yatak(object sender ,EventArgs e)
        //{
        //    panel1.AutoSize = true;

        //    int kactane = 0; int ust = -25;
        //    for (int i = 0; i < yataklar.Length; i++)
        //    {
        //        Button b = new Button();
        //        b.Name = (i + 1).ToString(); ;
        //        b.Text = "Y-" + (i + 1).ToString();
        //        b.Width = 40;
        //        if (i % 6 == 0)
        //        { ust += 25; kactane = 0; }
        //        b.Top = ust;
        //        b.Left = kactane * 60;
        //        kactane++;
        //        b.Click += new EventHandler(yatak_islem);
        //        b.BackColor = Color.LightGray;
        //        panel1.Controls.Add(b);
        //    }

        //}
        void verileri_cek()
        {
            string seckomutu = "select * from yenikayit";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            ds.Clear();
            da.Fill(ds, "yenikayit");

            string seckomutu2 = "select velibilgi.*,yenikayit.adisoyadi from velibilgi,yenikayit where velibilgi.kid=yenikayit.kid";
            OleDbDataAdapter da2 = new OleDbDataAdapter(seckomutu2, baglan);
            ds2.Clear();
            da2.Fill(ds2, "velibilgi");

            string seckomutu3 = "select ziyaretci.*,yenikayit.adisoyadi from ziyaretci,yenikayit where ziyaretci.kid=yenikayit.kid";
            OleDbDataAdapter da3 = new OleDbDataAdapter(seckomutu3, baglan);
            ds3.Clear();
            da3.Fill(ds3, "ziyaretci");

            string seckomutu4 = "select ilachatirlat.*,yenikayit.adisoyadi from ilachatirlat,yenikayit where ilachatirlat.kid=yenikayit.kid";
            OleDbDataAdapter da4 = new OleDbDataAdapter(seckomutu4, baglan);
            ds4.Clear();
            da4.Fill(ds4, "ilachatirlat");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //OleDbConnection baglan2 = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\huzurevii.mdb");
            //baglan2.Open();
            //OleDbCommand komut = new OleDbCommand("select * from yenikayit where", baglan2);
            //OleDbDataReader oku = komut.ExecuteReader();
            //if(oku.Read())
            //{
            //    for(int i=0;i<)
            //}
            if (baglan.State == ConnectionState.Closed)baglan.Open();
            verileri_cek();
            bs.DataSource = ds.Tables["yenikayit"];
            dataGridView1.DataSource = bs;
            tbtc.DataBindings.Add("Text", bs, "tcno");
            tbadisoyadi.DataBindings.Add("Text", bs, "adisoyadi");
            tbtel.DataBindings.Add("Text", bs, "telno");
            tbdyeri.DataBindings.Add("Text", bs, "dyeri");
            tbdtarihi.DataBindings.Add("Text", bs, "dtarihi");
            cbcinsiyet.DataBindings.Add("Text", bs, "cinsiyet");
            tbmeslek.DataBindings.Add("Text", bs, "meslek");
            cbkan.DataBindings.Add("Text", bs, "kangrubu");
            cbsaglik.DataBindings.Add("Text", bs, "saglikgüvence");
            tbyatak.DataBindings.Add("Text", bs, "yatakno");
            tboda.DataBindings.Add("Text", bs, "odano");
            tbadres.DataBindings.Add("Text", bs, "adres");
            tbhastalik.DataBindings.Add("Text", bs, "hastalik");
            tbkid.DataBindings.Add("Text", bs, "kid");

            bs2.DataSource = ds2.Tables["velibilgi"];
            dataGridView2.DataSource = bs2;
            tbvtc.DataBindings.Add("Text", bs2, "vtcno");
            tbvad.DataBindings.Add("Text", bs2, "vadi");
            tbvsoyad.DataBindings.Add("Text", bs2, "vsoyadi");
            tbvyakinlik.DataBindings.Add("Text", bs2, "yakinlik");
            tbvtelno.DataBindings.Add("Text", bs2, "vtelno");
            kkişi.DataBindings.Add("SelectedValue",bs2 ,"kid");
            tbvid.DataBindings.Add("Text", bs2, "vid");

            bs3.DataSource = ds3.Tables["ziyaretci"];
            dataGridView3.DataSource = bs3;
            tbztcno.DataBindings.Add("Text", bs3, "ztcno");
            tbzadi.DataBindings.Add("Text", bs3, "zadi");
            tbzsoyadi.DataBindings.Add("Text", bs3, "zsoyadi");
            tbztelno.DataBindings.Add("Text", bs3, "ztelno");
            cbzedilen.DataBindings.Add("SelectedValue", bs3, "kid");
            tbzid.DataBindings.Add("Text", bs3, "zid");

            bs4.DataSource = ds4.Tables["ilachatirlat"];
            dataGridView4.DataSource = bs4;
            tbilacadi.DataBindings.Add("Text", bs4, "ilacadi");
            tbkacadet.DataBindings.Add("Text", bs4, "kacadet");
            cbactok.DataBindings.Add("Text", bs4, "actok");
            cbkiminilaci.DataBindings.Add("SelectedValue", bs4, "kid");
            tbilachatirlat.DataBindings.Add("Text", bs4, "ilachatirlatid");

            baglan.Close();

            //*****ODA VE YATAK İÇİN OLUŞTURULAN BUTONLAR*****//

            //panel1.AutoSize = true;

            //int kactane = 0; int ust = -25;
            //for (int i = 0; i < yataklar.Length; i++)
            //{
            //    Button b = new Button();
            //    b.Name = (i + 1).ToString(); ;
            //    b.Text = "Y-" + (i + 1).ToString();
            //    b.Width = 40;
            //    if (i % 6 == 0)
            //    { ust += 25; kactane = 0; }
            //    b.Top = ust;
            //    b.Left = kactane * 60;
            //    kactane++;
            //    b.Click += new EventHandler(yatak_islem);
            //    b.BackColor = Color.LightGray;
            //    panel1.Controls.Add(b);
            //}

            //panel2.AutoSize = true;

            //int kactanee = 0; int ustt = -25;
            //for (int i = 0; i < odalar.Length; i++)
            //{
            //    Button b2 = new Button();
            //    b2.Name = (i + 1).ToString(); ;
            //    b2.Text = "ODA-" + (i + 1).ToString();
            //    b2.Width = 60;
            //    if (i % 4 == 0)
            //    { ustt += 25; kactanee = 0; }
            //    b2.Top = ustt;
            //    b2.Left = kactanee * 60;
            //    kactanee++;
            //    panel1.Refresh();
            //    b2.Click += new EventHandler(oda_islem);
            //    b2.Click += new EventHandler(yatak);
            //    b2.BackColor = Color.LightGray;
            //    panel2.Controls.Add(b2);
            //}

            //*****COMBOBOXLARI DOLDURMA*****//

            string seckomutu2 = "select * from yenikayit";
            OleDbDataAdapter da2 = new OleDbDataAdapter(seckomutu2,baglan);
            da2.Fill(ds2, "yenikayit");
            kkişi.DataSource = ds.Tables["yenikayit"];
            kkişi.ValueMember = "kid";
            kkişi.DisplayMember = "adisoyadi";    

            string seckomutu3 = "select * from yenikayit";
            OleDbDataAdapter da3 = new OleDbDataAdapter(seckomutu3, baglan);
            da3.Fill(ds3, "yenikayit");
            cbzedilen.DataSource = ds.Tables["yenikayit"];
            cbzedilen.ValueMember = "kid";
            cbzedilen.DisplayMember = "adisoyadi";

            string seckomutu4 = "select * from yenikayit";
            OleDbDataAdapter da4 = new OleDbDataAdapter(seckomutu4, baglan);
            da4.Fill(ds3, "yenikayit");
            cbkiminilaci.DataSource = ds.Tables["yenikayit"];
            cbkiminilaci.ValueMember = "kid";
            cbkiminilaci.DisplayMember = "adisoyadi";

        }

        //*****YENİ KAYIT*****//

        private void btnyenikayit_Click(object sender, EventArgs e)
        {
            if (btnyenikayit.Text == "Yeni Kayıt")
            {
                yenikayitmi = true;
                tbtc.Clear();
                tbadisoyadi.Clear();
                tbtel.Clear();
                tbdyeri.Clear();
                tbdtarihi.DataBindings.Clear();
                cbcinsiyet.SelectedItem = null;
                tbmeslek.Clear();
                cbkan.SelectedItem = null;
                cbsaglik.SelectedItem = null;
                tbyatak.Clear();
                tboda.Clear();
                tbadres.Clear();
                tbhastalik.Clear();
                tbtc.Focus();
                btnyenikayit.Text = "Kaydet";
                kacincikayit = ds.Tables["yenikayit"].Rows.Count;
            }
            else if (btnyenikayit.Text == "Kaydet")
            {
                if (tbtc.Text.Length != 11)
                {
                    MessageBox.Show("TC 11 haneli giriniz");
                }
                else
                {
                    if (tbadisoyadi.Text == "" || tbtel.Text == "" || tbdyeri.Text == "" || tbdtarihi.Text == "" || cbcinsiyet.Text == "" || tbmeslek.Text == "" || cbkan.Text == "" || cbsaglik.Text == "" || tbyatak.Text == "" || tboda.Text == "" || tbadres.Text == "" || tbhastalik.Text == "")
                    {
                        MessageBox.Show("Lütfen Eksik Bilgi Girmeyiniz");
                    }
                    else
                    {
                        baglan.Open();
                        OleDbCommand TCKimlikVarmiYokmu = new OleDbCommand("select * from yenikayit where tcno=" + "'" + tbtc.Text + "'", baglan);
                        OleDbDataReader dm = TCKimlikVarmiYokmu.ExecuteReader();
                        if (dm.Read())
                        {
                            MessageBox.Show("Daha önce kaydedilmiş TC kimlik numarası girdiniz");
                            tbtc.Text = "";
                        }
                        
                        else
                        {
                            OleDbCommand cmd = new OleDbCommand();
                            cmd.Connection = baglan;
                            cmd.CommandText = "insert into yenikayit (tcno,adisoyadi,telno,dyeri,dtarihi,cinsiyet,meslek,kangrubu,saglikgüvence,yatakno,odano,adres,hastalik) Values (@tbtc,@tbadi,@tbtel,@tbdyeri,@tbdtarihi,@cbcinsiyet,@tbmeslek,@cbkan,@cbsaglik,@tbyatak,@tboda,@tbadres,@tbhastalik)";
                            cmd.Parameters.AddWithValue("@tbtc", tbtc.Text);
                            cmd.Parameters.AddWithValue("@tbadi", tbadisoyadi.Text);
                            cmd.Parameters.AddWithValue("@tbtel", tbtel.Text);
                            cmd.Parameters.AddWithValue("@tbdyeri", tbdyeri.Text);
                            cmd.Parameters.AddWithValue("@tbdtarihi", tbdtarihi.Text);
                            cmd.Parameters.AddWithValue("@cbcinsiyet", cbcinsiyet.Text);
                            cmd.Parameters.AddWithValue("@tbmeslek", tbmeslek.Text);
                            cmd.Parameters.AddWithValue("@cbkan", cbkan.Text);
                            cmd.Parameters.AddWithValue("@cbsaglik", cbsaglik.Text);
                            cmd.Parameters.AddWithValue("@tbyatak", tbyatak.Text);
                            cmd.Parameters.AddWithValue("@tboda", tboda.Text);
                            cmd.Parameters.AddWithValue("@tbadres", tbadres.Text);
                            cmd.Parameters.AddWithValue("@tbhastalik", tbhastalik.Text);
                            cmd.ExecuteNonQuery();
                            bs.Position = kacincikayit;
                            MessageBox.Show("KAYDINIZ YAPILMIŞTIR.");
                            verileri_cek();
                            btnyenikayit.Text = "Yeni Kayıt";
                        }
                        baglan.Close();
                    }
                }
            }
        }

        private void btndüzelt_Click(object sender, EventArgs e)
        {
            if(btndüzelt.Text=="Düzelt")
            {
                tbtc.Focus();
                btndüzelt.Text = "Kaydet";
            }
            else if (btndüzelt.Text == "Kaydet")
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                baglan.Open();
                cmd.CommandText = "update yenikayit set tcno=@tbtc,adisoyadi=@tbadi,telno=@tbtel,dyeri=@tbdyeri,dtarihi=@tbdtarihi,cinsiyet=@cbcinsiyet,meslek=@tbmeslek,kangrubu=@cbkan,saglikgüvence=@cbsaglik,yatakno=@tbyatak,odano=@tboda,adres=@tbadres,hastalik=@tbhastalik where kid=@tbkid";
                cmd.Parameters.AddWithValue("@tbtc", tbtc.Text);
                cmd.Parameters.AddWithValue("@tbadi", tbadisoyadi.Text);
                cmd.Parameters.AddWithValue("@tbtel", tbtel.Text);
                cmd.Parameters.AddWithValue("@tbdyeri", tbdyeri.Text);
                cmd.Parameters.AddWithValue("@tbdtarihi", tbdtarihi.Text);
                cmd.Parameters.AddWithValue("@cbcinsiyet", cbcinsiyet.Text);
                cmd.Parameters.AddWithValue("@tbmeslek", tbmeslek.Text);
                cmd.Parameters.AddWithValue("@cbkan", cbkan.Text);
                cmd.Parameters.AddWithValue("@cbsaglik", cbsaglik.Text);
                cmd.Parameters.AddWithValue("@tbyatak", tbyatak.Text);
                cmd.Parameters.AddWithValue("@tboda", tboda.Text);
                cmd.Parameters.AddWithValue("@tbadres", tbadres.Text);
                cmd.Parameters.AddWithValue("@tbhastalik", tbhastalik.Text);
                cmd.Parameters.AddWithValue("@tbkid", tbkid.Text);
                cmd.ExecuteNonQuery();
                baglan.Close();
                bs.Position = kacincikayit;
                MessageBox.Show("KAYDINIZ DÜZELTİLMİŞTİR.");
                verileri_cek();
                btndüzelt.Text = "Düzelt";
            }
        }
        private void btnsil_Click(object sender, EventArgs e)
        {
            kacincikayit = bs.Position;
            baglan.Open();
            DialogResult cevap = MessageBox.Show("SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd = new OleDbCommand();
                cmd.Connection = baglan;
                cmd.CommandText = "delete from yenikayit where kid=@tbkid";
                cmd.Parameters.AddWithValue("@tbkid", int.Parse(tbkid.Text));
                cmd.ExecuteNonQuery();
                bs.Position = kacincikayit;
                MessageBox.Show("KAYIT SİLİNDİ");
                verileri_cek();

                
            }
            baglan.Close();
        }

        private void tbaranan_TextChanged(object sender, EventArgs e)
        {
            string seckomutu = "select * from yenikayit where adisoyadi like '" + tbaranan.Text + "%'";
            OleDbDataAdapter da = new OleDbDataAdapter(seckomutu, baglan);
            if(ds.Tables["yenikayit"]!=null) ds.Tables["yenikayit"].Clear();
            da.Fill(ds, "yenikayit");
        }
        private void btngeri_Click(object sender, EventArgs e)
        {
            if (--bs.Position <= 0)
            {
                btngeri.Enabled = false;
            }
            btnileri.Enabled = true;
        }

        private void btnileri_Click(object sender, EventArgs e)
        {

            if (++bs.Position >= ds.Tables["yenikayit"].Rows.Count - 1)
            {
                btnileri.Enabled = false;
            }
            btngeri.Enabled = true;
        }

        private void btniptal_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //*****VELİ BİLGİLENDİRME*****//

        private void btnyenikayitt_Click(object sender, EventArgs e)
        {
            if (btnyenikayitt.Text == "Yeni Kayıt")
            {
                tbvtc.Clear();
                tbvad.Clear();
                tbvsoyad.Clear();
                tbvyakinlik.Clear();
                tbvtelno.Clear();
                kkişi.SelectedItem = null;
                tbvtc.Focus();
                btnyenikayitt.Text = "Kaydet";
                kacincikayit1 = ds2.Tables["velibilgi"].Rows.Count;
            }
            else if (btnyenikayitt.Text == "Kaydet")
            {
                if (tbvtc.Text.Length != 11)
                {
                    MessageBox.Show("TC 11 haneli giriniz");
                }
                else
                {
                    if (tbvad.Text == "" || tbvsoyad.Text == "" || tbvyakinlik.Text == "" || tbvtelno.Text == "" || kkişi.Text == "")
                    {
                        MessageBox.Show("Lütfen Eksik Bilgi Girmeyiniz");
                    }
                    else
                    {
                        baglan.Open();
                        OleDbCommand TCKimlikVarmiYokmu = new OleDbCommand("select * from velibilgi where vtcno=" + "'" + tbvtc.Text + "'", baglan);
                        OleDbDataReader dm = TCKimlikVarmiYokmu.ExecuteReader();
                        if (dm.Read())
                        {
                            MessageBox.Show("Daha önce kaydedilmiş TC kimlik numarası girdiniz");
                            tbvtc.Text = "";
                        }
                        else
                        {
                            OleDbCommand cmd2 = new OleDbCommand();
                            cmd2.Connection = baglan;
                            cmd2.CommandText = "insert into velibilgi (vtcno,vadi,vsoyadi,yakinlik,vtelno,kid) Values (@tbvtc,@tbvad,@tbvsoyad,@tbvyakinlik,@tbvtelno,@kkişi)";
                            cmd2.Parameters.AddWithValue("@tbvtc", tbvtc.Text);
                            cmd2.Parameters.AddWithValue("@tbvad", tbvad.Text);
                            cmd2.Parameters.AddWithValue("@tbvsoyad", tbvsoyad.Text);
                            cmd2.Parameters.AddWithValue("@tbvyakinlik", tbvyakinlik.Text);
                            cmd2.Parameters.AddWithValue("@tbvtelno", tbvtelno.Text);
                            cmd2.Parameters.AddWithValue("@kkişi", Convert.ToInt64(kkişi.SelectedValue));
                            cmd2.ExecuteNonQuery();
                            bs2.Position = kacincikayit1;
                            MessageBox.Show("VELİ KAYDINIZ YAPILMIŞTIR.");
                            verileri_cek();
                            btnyenikayitt.Text = "Yeni Kayıt";
                        }
                        baglan.Close();
                    }
                }
            }
        }

        private void btndüzeltt_Click(object sender, EventArgs e)
        {
            if (btndüzeltt.Text == "Düzelt")
            {
                tbvtc.Focus();
                btndüzeltt.Text = "Kaydet";
            }
            else if (btndüzeltt.Text == "Kaydet")
            {
                OleDbCommand cmd2 = new OleDbCommand();
                cmd2.Connection = baglan;
                baglan.Open();
                cmd2.CommandText = "update velibilgi set vtcno=@tbvtc,vadi=@tbvad,vsoyadi=@tbvsoyad,yakinlik=@tbvyakinlik,vtelno=@tbvtelno,kid=@kkişi where vid=@tbvid";
                cmd2.Parameters.AddWithValue("@tbvtc", tbvtc.Text);
                cmd2.Parameters.AddWithValue("@tbvad", tbvad.Text);
                cmd2.Parameters.AddWithValue("@tbvsoyad", tbvsoyad.Text);
                cmd2.Parameters.AddWithValue("@tbvyakinlik", tbvyakinlik.Text);
                cmd2.Parameters.AddWithValue("@tbvtelno", tbvtelno.Text);
                cmd2.Parameters.AddWithValue("@kkişi", Convert.ToInt64(kkişi.SelectedValue));
                cmd2.Parameters.AddWithValue("@tbvid", tbvid.Text);
                cmd2.ExecuteNonQuery();
                baglan.Close();
                MessageBox.Show("VELİ KAYDINIZ DÜZELTİLMİŞTİR.");
                verileri_cek();
                bs2.Position=kacincikayit1;
                btndüzeltt.Text = "Düzelt";
            }
        }

        private void btnsill_Click(object sender, EventArgs e)
          {
            kacincikayit1 = bs2.Position;
            baglan.Open();
            DialogResult cevap = MessageBox.Show("VELİ BİLGİLERİNİ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd2 = new OleDbCommand();
                cmd2.Connection = baglan;
                cmd2.CommandText = "delete from velibilgi where vid ="+ Convert.ToInt64(tbvid.Text);
                cmd2.ExecuteNonQuery();
                MessageBox.Show("VELİ KAYDI SİLİNDİ");
                verileri_cek();
                bs2.Position = kacincikayit1;
                baglan.Close();
            }
        }

        private void aranann_TextChanged(object sender, EventArgs e)
        {
            string seckomutu2= "select velibilgi.*,yenikayit.adisoyadi from velibilgi,yenikayit where velibilgi.kid=yenikayit.kid and adisoyadi like '" + aranann.Text + "%'";
           //string seckomutu2 = "select * from velibilgi where vadi like '" + aranann.Text + "%'";
            OleDbDataAdapter da2 = new OleDbDataAdapter(seckomutu2, baglan);
            if (ds2.Tables["velibilgi"] != null) ds2.Tables["velibilgi"].Clear();
            da2.Fill(ds2, "velibilgi");
        }

        private void btngerii_Click(object sender, EventArgs e)
        {
            if (--bs2.Position <= 0)
            {
                btngerii.Enabled = false;
            }
            btnilerii.Enabled = true;
        }

        private void btnilerii_Click(object sender, EventArgs e)
        {
            if (++bs2.Position >= ds2.Tables["velibilgi"].Rows.Count - 1)
            {
                btnilerii.Enabled = false;
            }
            btngerii.Enabled = true;
        }

        private void btniptall_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //******ZİYARETÇİ BİLGİLERİ*****//

        private void btnyenikayittt_Click(object sender, EventArgs e)
        {
            if (btnyenikayittt.Text == "Yeni Kayıt")
            {
                tbztcno.Clear();
                tbzadi.Clear();
                tbzsoyadi.Clear();
                tbztelno.Clear();
                cbzedilen.SelectedItem = null;
                tbztcno.Focus();
                btnyenikayittt.Text = "Kaydet";
                kacincikayit = ds3.Tables["ziyaretci"].Rows.Count;
            }
            else if (btnyenikayittt.Text == "Kaydet")
            {
                if (tbztcno.Text.Length != 11)
                {
                    MessageBox.Show("TC 11 haneli giriniz");
                }
                else
                {
                    if (tbzadi.Text == "" || tbzsoyadi.Text == "" || tbztelno.Text == "" || cbzedilen.Text == "" || tbztarih.Text == "")
                    {
                        MessageBox.Show("Lütfen Eksik Bilgi Girmeyiniz");
                    }
                    else
                    {
                        if (baglan.State == ConnectionState.Closed) baglan.Open();
                        OleDbCommand TCKimlikVarmiYokmu = new OleDbCommand("select * from ziyaretci where ztcno=" + "'" + tbztcno.Text + "'", baglan);
                        OleDbDataReader dm = TCKimlikVarmiYokmu.ExecuteReader();
                        if (dm.Read())
                        {
                            MessageBox.Show("Daha önce kaydedilmiş TC kimlik numarası girdiniz");

                            tbztcno.Text = "";
                        }
                        else
                        {
                            OleDbCommand cmd3 = new OleDbCommand();
                            cmd3.Connection = baglan;
                            cmd3.CommandText = "insert into ziyaretci (ztcno,zadi,zsoyadi,ztelno,kid,ztarih) Values (@tbztcno,@tbzadi,@tbzsoyadi,@tbztelno,@cbzedilen,@tbztarih)";
                            cmd3.Parameters.AddWithValue("@tbztcno", tbztcno.Text);
                            cmd3.Parameters.AddWithValue("@tbzadi", tbzadi.Text);
                            cmd3.Parameters.AddWithValue("@tbzsoyadi", tbzsoyadi.Text);
                            cmd3.Parameters.AddWithValue("@tbztelno", tbztelno.Text);
                            cmd3.Parameters.AddWithValue("@cbzedilen", Convert.ToInt64(cbzedilen.SelectedValue));
                            cmd3.Parameters.AddWithValue("@tbztarih", tbztarih.Text);
                            cmd3.ExecuteNonQuery();
                            baglan.Close();
                            MessageBox.Show("ZİYARETÇİ KAYDINIZ YAPILMIŞTIR.");
                            verileri_cek();
                            btnyenikayittt.Text = "Yeni Kayıt";
                            bs3.Position = kacincikayit2;
                        }
                    }
                }
            }
        }

        private void btndüzelttt_Click(object sender, EventArgs e)
        {
            if (btndüzelttt.Text == "Düzelt")
            {
                tbztcno.Focus();
                btndüzelttt.Text = "Kaydet";
            }
            else if(btndüzelttt.Text == "Kaydet")
            {
                OleDbCommand cmd3 = new OleDbCommand();
                cmd3.Connection = baglan;
                baglan.Open();
                cmd3.CommandText = "update ziyaretci set ztcno=@tbztcno,zadi=@tbzadi,zsoyadi=@tbzsoyadi,ztelno=@tbztelno,kid=@cbzedilen,ztarih=@tbztarih where zid=@tbzid";
                cmd3.Parameters.AddWithValue("@tbztcno", tbztcno.Text);
                cmd3.Parameters.AddWithValue("@tbzadi", tbzadi.Text);
                cmd3.Parameters.AddWithValue("@tbzsoyadi", tbzsoyadi.Text);
                cmd3.Parameters.AddWithValue("@tbztelno", tbztelno.Text);
                cmd3.Parameters.AddWithValue("@cbzedilen", Convert.ToInt64(cbzedilen.SelectedValue));
                cmd3.Parameters.AddWithValue("@tbztarih", tbztarih.Text);
                cmd3.Parameters.AddWithValue("@tbzid", tbzid.Text);
                cmd3.ExecuteNonQuery();
                verileri_cek();
                baglan.Close();
                MessageBox.Show("ZİYARETÇİ KAYDINIZ DÜZELTİLMİŞTİR.");
                btndüzelttt.Text = "Düzelt";
                bs3.Position = kacincikayit2;
            }
        }

        private void btnsilll_Click(object sender, EventArgs e)
        {
            kacincikayit2 = bs3.Position;
            DialogResult cevap = MessageBox.Show("ZİYARETÇİ BİLGİLERİNİ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                baglan.Open();
                OleDbCommand cmd3 = new OleDbCommand();
                cmd3.Connection = baglan;
                cmd3.CommandText = "delete from ziyaretci where zid=@zid";
                cmd3.Parameters.AddWithValue("@zid",int.Parse(tbzid.Text));
                cmd3.ExecuteNonQuery();
                MessageBox.Show("ZİYARETÇİ KAYDI SİLİNDİ");
                verileri_cek();
                bs3.Position = kacincikayit2;
                baglan.Close();
            }
           
        }

        private void aranannn_TextChanged(object sender, EventArgs e)
        {
            string seckomutu3 = "select ziyaretci.*,yenikayit.adisoyadi from ziyaretci,yenikayit where ziyaretci.kid=yenikayit.kid and adisoyadi like '" + aranannn.Text + "%'";
            //string seckomutu3 = "select * from ziyaretci where zadi like '" + aranannn.Text + "%'";
            OleDbDataAdapter da3 = new OleDbDataAdapter(seckomutu3, baglan);
            if (ds3.Tables["ziyaretci"] != null) ds3.Tables["ziyaretci"].Clear();
            da3.Fill(ds3, "ziyaretci");
        }
        
        private void btngeriii_Click(object sender, EventArgs e)
        {
            if (--bs3.Position <= 0)
            {
                btngeriii.Enabled = false;
            }
            btnileriii.Enabled = true;
        }

        private void btnileriii_Click(object sender, EventArgs e)
        {
            if (++bs3.Position >= ds3.Tables["ziyaretci"].Rows.Count - 1)
            {
                btnileriii.Enabled = false;
            }
            btngeriii.Enabled = true;
        }
        
        private void btniptalll_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //*****İLAÇ HATIRLATMA*****//

        private void btnyenikayitttt_Click(object sender, EventArgs e)
        {
            if (btnyenikayitttt.Text == "Yeni Kayıt")
            {
                yenikayitmi = true;
                tbilacadi.Clear();
                tbkacadet.Clear();
                cbactok.SelectedItem = null;
                cbkiminilaci.SelectedItem = null;
                tbilacadi.Focus();
                btnyenikayitttt.Text = "Kaydet";
                kacincikayit = ds4.Tables["ilachatirlat"].Rows.Count;
            }
            else if (btnyenikayitttt.Text == "Kaydet")
            {
                if (cbkiminilaci.Text == "" || tbilacadi.Text == "" || tbkacadet.Text == "" || cbactok.Text == "")
                {
                    MessageBox.Show("Lütfen Eksik Bilgi Girmeyiniz");
                }
                else
                {
                    OleDbCommand cmd4 = new OleDbCommand();
                    cmd4.Connection = baglan;
                    baglan.Open();
                    cmd4.CommandText = "insert into ilachatirlat (ilacadi,kacadet,actok,kid) Values (@tbilacadi,@tbkacadet,@cbactok,@cbkiminilaci)";
                    cmd4.Parameters.AddWithValue("@tbilacadi", tbilacadi.Text);
                    cmd4.Parameters.AddWithValue("@tbkacadet", tbkacadet.Text);
                    cmd4.Parameters.AddWithValue("@cbactok", cbactok.Text);
                    cmd4.Parameters.AddWithValue("@cbkiminilaci", Convert.ToInt64(cbkiminilaci.SelectedValue));
                    cmd4.ExecuteNonQuery();
                    baglan.Close();
                    MessageBox.Show("İLAC HATIRLATMA KAYDINIZ YAPILMIŞTIR.");
                    verileri_cek();
                    bs4.Position = kacincikayit;
                }
            }
        }

        private void btndüzeltttt_Click(object sender, EventArgs e)
        {
            if (btndüzeltttt.Text == "Düzelt")
            {
                tbztcno.Focus();
                btndüzeltttt.Text = "Kaydet";
            }
            else if (btndüzeltttt.Text == "Kaydet")
            {
                OleDbCommand cmd4 = new OleDbCommand();
                cmd4.Connection = baglan;
                baglan.Open();
                cmd4.CommandText = "update ilachatirlat set ilacadi=@tbilacadi,kacadet=@tbkacadet,actok=@cbactok,kid=@cbkiminilaci where ilachatirlatid=@tbilachatirlat";
                cmd4.Parameters.AddWithValue("@tbilacadi", tbilacadi.Text);
                cmd4.Parameters.AddWithValue("@tbkacadet", tbkacadet.Text);
                cmd4.Parameters.AddWithValue("@cbactok", cbactok.Text);
                cmd4.Parameters.AddWithValue("@cbkiminilaci", Convert.ToInt64(cbkiminilaci.SelectedValue));
                cmd4.Parameters.AddWithValue("@tbilachatirlat", tbilachatirlat.Text);
                cmd4.ExecuteNonQuery();
                verileri_cek();
                baglan.Close();
                MessageBox.Show("İLAÇ HATIRLATMA KAYDINIZ DÜZELTİLMİŞTİR.");
                btndüzeltttt.Text = "Düzelt";
                bs4.Position = kacincikayit3;
            }
            
        }

        private void btnsillll_Click(object sender, EventArgs e)
        {
            kacincikayit3 = bs4.Position;
            baglan.Open();
            DialogResult cevap = MessageBox.Show("İLAÇ BİLGİLERİNİ SİLMEK İSTEDİĞİNİZE EMİN MİSİNİZ?", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (cevap == DialogResult.Yes)
            {
                OleDbCommand cmd4 = new OleDbCommand();
                cmd4.Connection = baglan;
                cmd4.CommandText = "delete from ilachatirlat where ilachatirlatid=@tbilachatirlat";
                cmd4.Parameters.AddWithValue("ilachatirlatid", int.Parse(tbilachatirlat.Text));
                cmd4.ExecuteNonQuery();
                MessageBox.Show("İLAÇ HATIRLATMA KAYDI SİLİNDİ");
                verileri_cek();
                bs4.Position = kacincikayit3;
                baglan.Close();
            }
        }

        private void aranannnn_TextChanged(object sender, EventArgs e)
        {
            //if (cbkiminilaci.FindString(aranannnn.Text) >= 0)
            //{
            //    cbkiminilaci.SelectedIndex = cbkiminilaci.FindString(aranannnn.Text);
            //}
            string seckomutu4 = "select ilachatirlat.*,yenikayit.adisoyadi from ilachatirlat,yenikayit where ilachatirlat.kid=yenikayit.kid and adisoyadi like '" + aranannnn.Text + "%'";
            //string seckomutu4 = "select * from ilachatirlat where ilacadi like '" + aranannnn.Text + "%'";
            OleDbDataAdapter da4 = new OleDbDataAdapter(seckomutu4, baglan);
            if (ds4.Tables["ilachatirlat"] !=null) ds4.Tables["ilachatirlat"].Clear();
            da4.Fill(ds4, "ilachatirlat");
        }

        private void btngeriiii_Click(object sender, EventArgs e)
        {
            if (--bs4.Position <= 0)
            {
                btngeriiii.Enabled = false;
            }
            btnileriiii.Enabled = true;
        }

        private void btnileriiii_Click(object sender, EventArgs e)
        {
            if (++bs4.Position >= ds4.Tables["ilachatirlat"].Rows.Count - 1)
            {
                btnileriiii.Enabled = false;
            }
            btngeriiii.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button21.Visible = true;
            //button22.Visible = true;
            tboda.Text = button1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button23.Visible = true;
            //button24.Visible = true;
            tboda.Text = button2.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //button25.Visible = true;
            //button26.Visible = true;
            tboda.Text = button3.Text;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //button27.Visible = true;
            //button28.Visible = true;
            tboda.Text = button4.Text;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            //button29.Visible = true;
            //button30.Visible = true;
            tboda.Text = button5.Text;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //button31.Visible = true;
            //button32.Visible = true;
            tboda.Text = button6.Text;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            //button33.Visible = true;
            //button34.Visible = true;
            tboda.Text = button7.Text;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            //button35.Visible = true;
            //button36.Visible = true;
            tboda.Text = button8.Text;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            //button37.Visible = true;
            //button38.Visible = true;
            tboda.Text = button9.Text;
        }

        private void button10_Click(object sender, EventArgs e)
        {
        //    button39.Visible = true;
        //    button40.Visible = true;
            tboda.Text = button10.Text;
        }

        private void button11_Click(object sender, EventArgs e)
        {
            //button41.Visible = true;
            //button42.Visible = true;
            tboda.Text = button11.Text;
        }

        private void button12_Click(object sender, EventArgs e)
        {
            //button43.Visible = true;
            //button44.Visible = true;
            tboda.Text = button12.Text;
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //button45.Visible = true;
            //button46.Visible = true;
            tboda.Text = button13.Text;
        }

        private void button14_Click(object sender, EventArgs e)
        {
            //button47.Visible = true;
            //button48.Visible = true;
            tboda.Text = button14.Text;
        }

        private void button15_Click(object sender, EventArgs e)
        {
            //button49.Visible = true;
            //button50.Visible = true;
            tboda.Text = button15.Text;
        }

        private void button16_Click(object sender, EventArgs e)
        {
            //button51.Visible = true;
            //button52.Visible = true;
            tboda.Text = button16.Text;
        }

        private void button17_Click(object sender, EventArgs e)
        {
            //button53.Visible = true;
            //button54.Visible = true;
            tboda.Text = button17.Text;
        }

        private void button18_Click(object sender, EventArgs e)
        {
            //button55.Visible = true;
            //button56.Visible = true;
            tboda.Text = button18.Text;
        }

        private void button19_Click(object sender, EventArgs e)
        {
            //button57.Visible = true;
            //button58.Visible = true;
            tboda.Text = button19.Text;
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //button59.Visible = true;
            //button60.Visible = true;
            tboda.Text = button20.Text;
        }

        private void button21_Click(object sender, EventArgs e)
        {
            button21.Enabled = false;
            button21.BackColor = Color.Red;
            tbyatak.Text = button21.Text;
        }

        private void button22_Click(object sender, EventArgs e)
        {
            button22.Enabled = false;
            button22.BackColor = Color.Red;
            tbyatak.Text = button22.Text;
        }

        private void button23_Click(object sender, EventArgs e)
        {
            button23.Enabled = false;
            button23.BackColor = Color.Red;
            tbyatak.Text = button23.Text;
        }

        private void button24_Click(object sender, EventArgs e)
        {
            button24.Enabled = false;
            button24.BackColor = Color.Red;
            tbyatak.Text = button24.Text;
        }

        private void button25_Click(object sender, EventArgs e)
        {
            button25.Enabled = false;
            button25.BackColor = Color.Red;
            tbyatak.Text = button25.Text;
        }

        private void button26_Click(object sender, EventArgs e)
        {
            button26.Enabled = false;
            button26.BackColor = Color.Red;
            tbyatak.Text = button26.Text;
        }

        private void button27_Click(object sender, EventArgs e)
        {
            button27.Enabled = false;
            button27.BackColor = Color.Red;
            tbyatak.Text = button27.Text;
        }

        private void button28_Click(object sender, EventArgs e)
        {
            button28.Enabled = false;
            button28.BackColor = Color.Red;
            tbyatak.Text = button28.Text;
        }

        private void button29_Click(object sender, EventArgs e)
        {
            button29.Enabled = false;
            button29.BackColor = Color.Red;
            tbyatak.Text = button29.Text;
        }

        private void button30_Click(object sender, EventArgs e)
        {
            button30.Enabled = false;
            button30.BackColor = Color.Red;
            tbyatak.Text = button30.Text;
        }

        private void button31_Click(object sender, EventArgs e)
        {
            button31.Enabled = false;
            button31.BackColor = Color.Red;
            tbyatak.Text = button31.Text;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            button32.Enabled = false;
            button32.BackColor = Color.Red;
            tbyatak.Text = button32.Text;
        }

        private void button33_Click(object sender, EventArgs e)
        {
            button33.Enabled = false;
            button33.BackColor = Color.Red;
            tbyatak.Text = button33.Text;
        }

        private void button34_Click(object sender, EventArgs e)
        {
            button34.Enabled = false;
            button34.BackColor = Color.Red;
            tbyatak.Text = button34.Text;
        }

        private void button35_Click(object sender, EventArgs e)
        {
            button35.Enabled = false;
            button35.BackColor = Color.Red;
            tbyatak.Text = button35.Text;
        }

        private void button36_Click(object sender, EventArgs e)
        {
            button36.Enabled = false;
            button36.BackColor = Color.Red;
            tbyatak.Text = button36.Text;
        }

        private void button37_Click(object sender, EventArgs e)
        {
            button37.Enabled = false;
            button37.BackColor = Color.Red;
            tbyatak.Text = button37.Text;
        }

        private void button38_Click(object sender, EventArgs e)
        {
            button38.Enabled = false;
            button38.BackColor = Color.Red;
            tbyatak.Text = button38.Text;
        }

        private void button39_Click(object sender, EventArgs e)
        {
            button39.Enabled = false;
            button39.BackColor = Color.Red;
            tbyatak.Text = button39.Text;
        }

        private void button40_Click(object sender, EventArgs e)
        {
            button40.Enabled = false;
            button40.BackColor = Color.Red;
            tbyatak.Text = button40.Text;
        }

        private void button41_Click(object sender, EventArgs e)
        {
            button41.Enabled = false;
            button41.BackColor = Color.Red;
            tbyatak.Text = button41.Text;
        }

        private void button42_Click(object sender, EventArgs e)
        {
            button42.Enabled = false;
            button42.BackColor = Color.Red;
            tbyatak.Text = button42.Text;
        }

        private void button43_Click(object sender, EventArgs e)
        {
            button43.Enabled = false;
            button43.BackColor = Color.Red;
            tbyatak.Text = button43.Text;
        }

        private void button44_Click(object sender, EventArgs e)
        {
            button44.Enabled = false;
            button44.BackColor = Color.Red;
            tbyatak.Text = button44.Text;
        }

        private void button45_Click(object sender, EventArgs e)
        {
            button45.Enabled = false;
            button45.BackColor = Color.Red;
            tbyatak.Text = button45.Text;
        }

        private void button46_Click(object sender, EventArgs e)
        {
            button46.Enabled = false;
            button46.BackColor = Color.Red;
            tbyatak.Text = button46.Text;
        }

        private void button47_Click(object sender, EventArgs e)
        {
            button47.Enabled = false;
            button47.BackColor = Color.Red;
            tbyatak.Text = button47.Text;
        }

        private void button48_Click(object sender, EventArgs e)
        {
            button48.Enabled = false;
            button48.BackColor = Color.Red;
            tbyatak.Text = button48.Text;
        }

        private void button49_Click(object sender, EventArgs e)
        {
            button49.Enabled = false;
            button49.BackColor = Color.Red;
            tbyatak.Text = button49.Text;
        }

        private void button50_Click(object sender, EventArgs e)
        {
            button50.Enabled = false;
            button50.BackColor = Color.Red;
            tbyatak.Text = button50.Text;
        }

        private void button51_Click(object sender, EventArgs e)
        {
            button51.Enabled = false;
            button51.BackColor = Color.Red;
            tbyatak.Text = button51.Text;
        }

        private void button52_Click(object sender, EventArgs e)
        {
            button52.Enabled = false;
            button52.BackColor = Color.Red;
            tbyatak.Text = button52.Text;
        }

        private void button53_Click(object sender, EventArgs e)
        {
            button53.Enabled = false;
            button53.BackColor = Color.Red;
            tbyatak.Text = button53.Text;
        }

        private void button54_Click(object sender, EventArgs e)
        {
            button54.Enabled = false;
            button54.BackColor = Color.Red;
            tbyatak.Text = button54.Text;
        }

        private void button55_Click(object sender, EventArgs e)
        {
            button55.Enabled = false;
            button55.BackColor = Color.Red;
            tbyatak.Text = button55.Text;
        }

        private void button56_Click(object sender, EventArgs e)
        {
            button56.Enabled = false;
            button56.BackColor = Color.Red;
            tbyatak.Text = button56.Text;
        }

        private void button57_Click(object sender, EventArgs e)
        {
            button57.Enabled = false;
            button57.BackColor = Color.Red;
            tbyatak.Text = button57.Text;
        }

        private void button58_Click(object sender, EventArgs e)
        {
            button58.Enabled = false;
            button58.BackColor = Color.Red;
            tbyatak.Text = button58.Text;
        }

        private void button59_Click(object sender, EventArgs e)
        {
            button59.Enabled = false;
            button59.BackColor = Color.Red;
            tbyatak.Text = button59.Text;
        }

        private void button60_Click(object sender, EventArgs e)
        {
            button60.Enabled = false;
            button60.BackColor = Color.Red;
            tbyatak.Text = button60.Text;
        }

        private void tbadisoyadi_TextChanged(object sender, EventArgs e)
        {
            if (tbadisoyadi.Text.Length == 1)
            {
                string ilk = tbadisoyadi.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbadisoyadi.Text = ilk;
                tbadisoyadi.Select(tbadisoyadi.Text.Length, 1);
            }
        }

        private void tbdyeri_TextChanged(object sender, EventArgs e)
        {
            if (tbdyeri.Text.Length == 1)
            {
                string ilk = tbdyeri.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbdyeri.Text = ilk;
                tbdyeri.Select(tbdyeri.Text.Length, 1);
            }
        }

        private void tbmeslek_TextChanged(object sender, EventArgs e)
        {
            if (tbmeslek.Text.Length == 1)
            {
                string ilk = tbmeslek.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbmeslek.Text = ilk;
                tbmeslek.Select(tbmeslek.Text.Length, 1);
            }
        }

        private void tbadres_TextChanged(object sender, EventArgs e)
        {
            if (tbadres.Text.Length == 1)
            {
                string ilk = tbadres.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbadres.Text = ilk;
                tbadres.Select(tbadres.Text.Length, 1);
            }
        }

        private void tbhastalik_TextChanged(object sender, EventArgs e)
        {
            if (tbhastalik.Text.Length == 1)
            {
                string ilk = tbhastalik.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbhastalik.Text = ilk;
                tbhastalik.Select(tbhastalik.Text.Length, 1);
            }
        }

        private void tbvad_TextChanged(object sender, EventArgs e)
        {
            if (tbvad.Text.Length == 1)
            {
                string ilk = tbvad.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbvad.Text = ilk;
                tbvad.Select(tbvad.Text.Length, 1);
            }
        }

        private void tbvsoyad_TextChanged(object sender, EventArgs e)
        {
            if (tbvsoyad.Text.Length == 1)
            {
                string ilk = tbvsoyad.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbvsoyad.Text = ilk;
                tbvsoyad.Select(tbvsoyad.Text.Length, 1);
            }
        }

        private void tbvyakinlik_TextChanged(object sender, EventArgs e)
        {
            if (tbvyakinlik.Text.Length == 1)
            {
                string ilk = tbvyakinlik.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbvyakinlik.Text = ilk;
                tbvyakinlik.Select(tbvyakinlik.Text.Length, 1);
            }
        }

        private void tbzadi_TextChanged(object sender, EventArgs e)
        {

            if (tbzadi.Text.Length == 1)
            {
                string ilk = tbzadi.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbzadi.Text = ilk;
                tbzadi.Select(tbzadi.Text.Length, 1);
            }
        }

        private void tbzsoyadi_TextChanged(object sender, EventArgs e)
        {
            if (tbzsoyadi.Text.Length == 1)
            {
                string ilk = tbzsoyadi.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbzsoyadi.Text = ilk;
                tbzsoyadi.Select(tbzsoyadi.Text.Length, 1);
            }
        }

        private void tbilacadi_TextChanged(object sender, EventArgs e)
        {
            if (tbilacadi.Text.Length == 1)
            {
                string ilk = tbilacadi.Text.Substring(0, 1);
                ilk = ilk.ToUpper();
                tbilacadi.Text = ilk;
                tbilacadi.Select(tbilacadi.Text.Length, 1);
            }
        }

        private void dataGridView4_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tbtc_TextChanged(object sender, EventArgs e)
        {

        }

        private void cbcinsiyet_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btniptallll_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void tbztarih_ValueChanged(object sender, EventArgs e)
        {
            tbztarih.Value = DateTime.Today;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        
       
    }
}
