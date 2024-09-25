
using ChocolateAppClient.Models;
using System.Reflection;

namespace ChocolateAppClient.Repository
{
    public static class DataRepository
    {
        private static readonly List<CategoryViewModel> _categories = [
            new CategoryViewModel() {  Id = 1,
                    Name = "Sütlü Çikolata",
                    Description = "Sütlü çikolata kategorisi" },
            new CategoryViewModel()  {
                    Id = 2,
                    Name = "Bitter Çikolata",
                    Description = "Bitter çikolata kategorisi"
                },
            new CategoryViewModel()  {
                    Id = 3,
                    Name = "Beyaz Çikolata",
                    Description = "Beyaz çikolata kategorisi"
                },
            new CategoryViewModel() {
                    Id = 4,
                    Name = "Vegan Çikolata",
                    Description = "Organik çikolata kategorisi"
                },];



        private static readonly List<ChocolateViewModel> _chocolates = [
            new ChocolateViewModel()
            {
                 Id=1,
                 Name="Sütlü Çikolata",
                 Description="Sütlü çikolata kategorisi",
                 Weight = 100, // gram
                 CocoaPercentage = 30, // %
                 Price = 25.99m, // TL
                 Brand = "Çikolata Markası A",
                 StockQuantity = 150,
                 Ingredients = "Süt, Şeker, Kakao yağı, Kakao kitlesi",
                 NutritionalInformation = "Kalori: 550 kcal, Yağ: 33g, Karbonhidrat: 50g",
                 ImageUrl = "/images/sutlu-cikolata.jpg",
                 Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=1, Name="Sütlü Çikolata" },

                }
            },
            new ChocolateViewModel()
            {
                Id=2,
                Name="Bitter Çikolata",
                Description="Bitter çikolata kategorisi",
                 Weight = 100, // gram
                 CocoaPercentage = 70, // %
                 Price = 29.99m, // TL
                 Brand = "Çikolata Markası B",
                 StockQuantity = 200,
                 Ingredients = "Kakao kitlesi, Şeker, Kakao yağı",
                 NutritionalInformation = "Kalori: 500 kcal, Yağ: 30g, Karbonhidrat: 45g",
                 ImageUrl = "/images/bitter-cikolata.jpg",
                Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=1, Name="Bitter Çikolata" },

                }
            },
            new ChocolateViewModel()
            {
                Id=3,
                Name="Beyaz Çikolata",
                Description="Beyaz çikolata kategorisi",
                Weight = 100, // gram
                 CocoaPercentage = 50, // %
                Price = 24.99m, // TL
                 Brand = "Çikolata Markası C",
                 StockQuantity = 100,
                 Ingredients = "Şeker, Kakao yağı, Süt tozu",
                 NutritionalInformation = "Kalori: 600 kcal, Yağ: 35g, Karbonhidrat: 55g",
                 ImageUrl = "/images/beyaz-cikolata.jpg",
                Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=1, Name="Beyaz Çikolata" },

                }
            },
            new ChocolateViewModel()
            {
                Id=4,
                Name="Vegan Çikolata",
                Description="Organik çikolata kategorisi",
                Weight = 100, // gram
                 CocoaPercentage = 60, // %
                 Price = 34.99m, // TL
                 Brand = "Çikolata Markası D",
                 StockQuantity = 80,
                 Ingredients = "Organik Kakao, Hindistancevizi şekeri, Kakao yağı",
                 NutritionalInformation = "Kalori: 520 kcal, Yağ: 32g, Karbonhidrat: 40g",
                 ImageUrl = "/images/vegan-cikolata.jpg",
                 Categories= new List<CategoryViewModel>
                {
                    new CategoryViewModel() { Id=1, Name="Vegan Çikolata" },

                }
            }
        ];
        public static List<ChocolateViewModel> GetChocolates()
        {
            return _chocolates;
        }
        public static List<CategoryViewModel> GetCategories()
        {
            return _categories;
        }
        public static ChocolateViewModel GetChocolate(int id)
        {
            return _chocolates.Where(x => x.Id == id).FirstOrDefault();
        }
        public static CategoryViewModel GetCategory(int id)
        {
            return _categories.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
