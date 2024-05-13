using Final_Project.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Final_Project
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void LogoutButton_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Success", "Logged out successfully", "OK");
            await Navigation.PushAsync(new LoginPage());
        }

        private async void RecipeBookButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RecipesListPage());
        }
    }
}
