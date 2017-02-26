using Cats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cats.Views
{
    //TODO: Create a ViewModel for DetailsPage
    public partial class DetailsPage : ContentPage
    {
        public Cat SelectedCat { get; private set; }
        public DetailsPage(Cat selectedCat)
        {
            InitializeComponent();

            SelectedCat = selectedCat;
            BindingContext = SelectedCat;

            ButtonWebSite.Clicked += ButtonWebSite_Clicked;
        }

        private void ButtonWebSite_Clicked(object sender, EventArgs e)
        {
            if (SelectedCat.WebSite.StartsWith("http"))
            {
                Device.OpenUri(new Uri(SelectedCat.WebSite));
            }
        }
    }

    
}
