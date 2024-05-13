using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Final_Project.Models;
using Newtonsoft.Json;

namespace Final_Project
{
    public class RecipeLoader
    {
        public List<Recipe> LoadRecipes()
        {
            List<Recipe> recipes = new List<Recipe>();

            // Get embedded resource stream
            var assembly = IntrospectionExtensions.GetTypeInfo(typeof(RecipeLoader)).Assembly;
            Stream stream = assembly.GetManifestResourceStream("Final_Project.recipes.json");

            if (stream != null)
            {
                using (var reader = new StreamReader(stream))
                {
                    // Read JSON from stream
                    string json = reader.ReadToEnd();

                    // Deserialize JSON into list of Recipe objects
                    recipes = JsonConvert.DeserializeObject<List<Recipe>>(json);
                }
            }

            return recipes;
        }
    }
}