using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XamarinApp8UsoApi.Models;
using XamarinApp8UsoApi.Services;

namespace XamarinApp8UsoApi.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Home : ContentPage
    {
        private IbgeService _ibgeService;

        public Home ()
		{
			InitializeComponent ();

            _ibgeService = new IbgeService();

            var estados = _ibgeService.GetEstados().OrderBy(e => e.Nome);
            EstadosList.ItemsSource = estados;
        }

        private void EstadosList_OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var estado = (EstadoModel) args.SelectedItem;
            Navigation.PushAsync(new MunicipiosPage(estado));
        }
    }
}