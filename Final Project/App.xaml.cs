using System;
using System.IO;
using Xamarin.Forms;
using Final_Project.Data;
using Final_Project.Views;
using Xamarin.Forms.Xaml;

namespace Final_Project
{
    public partial class App : Application
    {
        public static string FolderPath {  get; private set; }
        static RecipeDatabase database;

        public static RecipeDatabase Database
        {
            get
            {
                if (database == null)
                {
                    database = new RecipeDatabase(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Recipes.db3"));
                }
                return database;
            }
        }

        public App()
        {
            InitializeComponent();

            FolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData));
            MainPage = new NavigationPage(new LoginPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
