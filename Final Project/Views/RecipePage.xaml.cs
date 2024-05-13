using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Final_Project.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RecipePage : ContentPage
    {
        public RecipePage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            recipe.Date = DateTime.UtcNow;
            await App.Database.SaveRecipeAsync(recipe);
            await Navigation.PopAsync();
        }

        //async void OnSave(object sender, EventArgs e)
        //{
        //    var recipe = (Recipe) BindingContext;
        //    recipe.Date = DateTime.UtcNow;
        //    if (!string.IsNullOrWhiteSpace(recipe.Title) || !string.IsNullOrWhiteSpace(recipe.Ingredients) || !string.IsNullOrWhiteSpace(recipe.Steps))
        //    {
        //        await App.Database.SaveRecipeAsync(recipe);
        //    }

        //    await Shell.Current.GoToAsync("..");
        //}

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var recipe = (Recipe)BindingContext;
            await App.Database.DeleteRecipeAsync(recipe);
            await Navigation.PopAsync();
        }
    }
}