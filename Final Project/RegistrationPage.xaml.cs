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
    public partial class RegistrationPage : ContentPage
    {
        private DatabaseUser databaseUser;

        public RegistrationPage()
        {
            InitializeComponent();
            databaseUser = new DatabaseUser(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Users.db3"));
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            User newUser = new User
            {
                Username = usernameEntry.Text,
                Password = passwordEntry.Text
            };

            var existingUser = await databaseUser.GetUserByUsernameAsync(newUser.Username);
            if (existingUser == null)
            {
                await databaseUser.SaveUserAsync(newUser);
                await DisplayAlert("Success", "User registered successfully", "OK");
                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Error", "Username already exists", "OK");
            }
        }
    }
}