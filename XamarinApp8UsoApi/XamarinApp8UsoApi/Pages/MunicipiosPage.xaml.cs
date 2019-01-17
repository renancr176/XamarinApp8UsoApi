using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp8UsoApi.Models;
using XamarinApp8UsoApi.Services;

namespace XamarinApp8UsoApi.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class MunicipiosPage : ContentPage
    {
        private EstadoModel _estado;
        private IbgeService _ibgeService;

        public List<MunicipioModel> Municipios { get; private set; }

		public MunicipiosPage (EstadoModel estado)
		{
			InitializeComponent ();

            _estado = estado;
            _ibgeService = new IbgeService();

            LabelEstadoNome.Text = _estado.Nome;
            LabelEstadoSilga.Text = _estado.Sigla;

            Municipios = _ibgeService.GetMunicipioFromUf(_estado.Id).OrderBy(m => m.Nome).ToList();
            MunicipiosList.ItemsSource = Municipios;
        }

        private void FiltrarTextChanged(object sender, TextChangedEventArgs args)
        {
            MunicipiosList.ItemsSource = Municipios.Where(m => m.Nome.ToLower().Contains(args.NewTextValue.ToLower())).ToList();
        }
    }
}