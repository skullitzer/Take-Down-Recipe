using Final_Project.Views;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final_Project
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        private DatabaseUser databaseUser;

        public LoginPage()
        {
            InitializeComponent();
            databaseUser = new DatabaseUser(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
        }

        private async void LoginButton_Clicked(object sender, EventArgs e)
        {
            var user = await databaseUser.GetUserByUsernameAsync(usernameEntry.Text);
            if (user != null && user.Password == passwordEntry.Text)
            {
                await DisplayAlert("Success", "Login successful", "OK");
                await Navigation.PushAsync(new MainPage());
            }
            else
            {
                await DisplayAlert("Error", "Invalid username or password", "OK");
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrationPage());
        }
    }
}