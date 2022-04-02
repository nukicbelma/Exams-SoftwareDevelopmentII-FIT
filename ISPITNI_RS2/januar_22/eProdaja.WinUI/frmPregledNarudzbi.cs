using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eProdaja.WinUI
{
    public partial class frmPregledNarudzbi : Form
    {
        APIService _proizvodi = new APIService("Proizvodi");
        APIService _narudzbe = new APIService("Narudzbe");
        APIService _pregled = new APIService("PregledNarudzbi");
        public frmPregledNarudzbi()
        {
            InitializeComponent();
            dgvPregled.AutoGenerateColumns = false;
        }

        private async void frmPregledNarudzbi_Load(object sender, EventArgs e)
        {
            await UcitajProizvode();
            txtMinIznos.Text = "0";
        }
        private async Task UcitajProizvode()
        {
            var result = await _proizvodi.GetAll<List<Model.Proizvodi>>(null);
            cmbProizvodi.DataSource = result;
            cmbProizvodi.ValueMember = "ProizvodId";
            cmbProizvodi.DisplayMember = "Naziv";
        }
        
        private async void btnTrazi_Click(object sender, EventArgs e)
        {
            try
            {
                var search = new Model.Requests.NarudzbeSearchRequest
                {
                    DatumOd = dtpDatumOd.Value,
                    DatumDo = dtpDatumDo.Value,
                    ProizvodiId = int.Parse(cmbProizvodi.SelectedValue.ToString()),
                    MinIznos = int.Parse(txtMinIznos.Text.ToString())
                };
                var result = await _narudzbe.GetAll<List<Model.Narudzbe>>(search);
                dgvPregled.DataSource = result;
                var lista = dgvPregled.DataSource as List<Model.Narudzbe>;
                txtSuma.Text = lista.Sum(x => x.UkupanIznos).ToString();
            }
            catch
            {
                MessageBox.Show("Unesite validne podatke");
            }
        }

        private async void btnSpasi_Click(object sender, EventArgs e)
        {
            try
            {
                var lista = dgvPregled.DataSource as List<Model.Narudzbe>;
                int broj = 0;
                foreach (var item in lista)
                {
                    var nova = new Model.Requests.PregledNarudzbiInsertRequest
                    {
                        BrojNarudzbe = item.BrojNarudzbe,
                        DatumOd = dtpDatumOd.Value,
                        DatumDo = dtpDatumDo.Value,
                        IznosNarudzbe = item.UkupanIznos,
                        KupciId = item.KupacId,
                        ProizvodiId = int.Parse(cmbProizvodi.SelectedValue.ToString()),
                        MinIznos = int.Parse(txtMinIznos.Text.ToString())
                    };
                    broj++;
                    await _pregled.Insert<Model.PregledNarudzbi>(nova);
                }
                MessageBox.Show($"Dodane {broj} nove stavke.");
            }
            catch
            {
                MessageBox.Show("Podaci nisu validni.");
            }
        }
    }
}
