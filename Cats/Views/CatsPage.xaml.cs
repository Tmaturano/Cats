using Cats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Cats.Views
{
    public partial class CatsPage : ContentPage
    {
        public CatsPage()
        {
            InitializeComponent();
            ListViewCats.ItemSelected += ListViewCats_ItemSelected;
        }

        private async void ListViewCats_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedCat = e.SelectedItem as Cat;

            if (selectedCat != null)
            {
                await Navigation.PushAsync(new DetailsPage(selectedCat));
                ListViewCats.SelectedItem = null;
            }
        }
    }
}
