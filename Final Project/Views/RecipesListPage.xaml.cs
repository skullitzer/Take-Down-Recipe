using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Data;
using Final_Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipesListPage : ContentPage
    {
        public RecipesListPage()
        {
            InitializeComponent();
            //Shell.SetNavBarHasShadow(this, false);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            listView.ItemsSource = await App.Database.GetRecipesAsync();
        }

        async void OnRecipeAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipePage 
            {
                BindingContext = new Recipe()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                await Navigation.PushAsync(new RecipePage
                {
                    BindingContext = e.SelectedItem as Recipe
                });
            }
        }
    }
}