using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using Final_Project.Models;
using Final_Project.Views;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace Final_Project.Data
{
    public class RecipeDatabase
    {
        readonly SQLiteAsyncConnection _database;

        public RecipeDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Recipe>().Wait();
        }

        public Task<List<Recipe>> GetRecipesAsync()
        {
            return _database.Table<Recipe>().ToListAsync();
        }

        public Task<Recipe> GetRecipeAsync(int id)
        {
            return _database.Table<Recipe>()
                .Where(i => i.ID == id)
                .FirstOrDefaultAsync();
        }

        public Task<int> SaveRecipeAsync(Recipe recipe)
        {
            if (recipe.ID != 0)
            {
                return _database.UpdateAsync(recipe);
            }
            else
            {
                return _database.InsertAsync(recipe);
            }
        }

        public Task<int> DeleteRecipeAsync(Recipe recipe)
        {
            return _database.DeleteAsync(recipe);
        }

        public async Task<bool> LoadRecipesFromJsonAsync(string jsonFilePath)
        {
            string databasePath = "\"D:\\Multiplatform App Projects\\Final Project\\Final Project\\recipes.json\""; // Replace this with the actual file path
            RecipeDatabase database = new RecipeDatabase(databasePath);
            try
            {
                if (!File.Exists(jsonFilePath))
                {
                    // Handle case when the file doesn't exist
                    Console.WriteLine("JSON file does not exist.");
                    return false;
                }

                string json = File.ReadAllText(jsonFilePath);
                var recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);

                if (recipes != null && recipes.Count > 0)
                {
                    await _database.InsertAllAsync(recipes);
                    Console.WriteLine("Recipes loaded successfully.");
                    bool success = await database.LoadRecipesFromJsonAsync(jsonFilePath);
                    return true;
                }
                else
                {
                    // Handle case when no recipes are found in JSON
                    Console.WriteLine("No recipes found in JSON.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions
                Console.WriteLine($"Error loading recipes from JSON: {ex.Message}");
                return false;
            }
        }
    }
}
