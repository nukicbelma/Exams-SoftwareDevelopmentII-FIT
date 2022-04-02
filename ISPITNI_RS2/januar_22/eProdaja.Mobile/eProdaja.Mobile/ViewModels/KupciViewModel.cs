using eProdaja.Mobile.Services;
using eProdaja.Mobile.ViewModels;
using eProdaja.Model;
using eProdaja.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eProdaja.Mobile.ViewModels
{
    public class KupciViewModel : BaseViewModel
    {
        private readonly APIService _pregled = new APIService("PregledNarudzbi");
        private readonly APIService _kupci = new APIService("Kupci");


        public KupciViewModel()
        {
            InitCommand = new Command(async () => await Init());
        }

        public ObservableCollection<PregledNarudzbi> PrelgedList { get; set; } = new ObservableCollection<PregledNarudzbi>();
        public ObservableCollection<Kupci> KupciList { get; set; } = new ObservableCollection<Kupci>();
        Kupci _selectedKupac = null;

        public Kupci SelectedKupac
        {
            get { return _selectedKupac; }
            set
            {
                SetProperty(ref _selectedKupac, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }

            }
        }

        public ICommand InitCommand { get; set; }

        public async Task Init()
        {
            if (KupciList.Count == 0)
            {
                var vrsteProizvodaList = await _kupci.Get<List<Kupci>>(null);

                foreach (var vrsteProizvoda in vrsteProizvodaList)
                {
                    KupciList.Add(vrsteProizvoda);
                }
            }

            if (SelectedKupac != null)
            {
                PregledNarudzbiSearchRequest searchRequest = new PregledNarudzbiSearchRequest();
                searchRequest.KupciId = SelectedKupac.KupacId;

                var list = await _pregled.Get<IList<PregledNarudzbi>>(searchRequest);
                PrelgedList.Clear(); 
                foreach (var item in list)
                {
                    PrelgedList.Add(item);
                }
            }
        }

    }
}
