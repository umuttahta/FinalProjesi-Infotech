using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace ChocolateApp.Data.Concrete.EfCore.Configs
{
    public class ChocolateConfig : IEntityTypeConfiguration<Chocolate>
    {
        public void Configure(EntityTypeBuilder<Chocolate> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.Property(x => x.Price).HasColumnType("decimal(16,2)"); // SQL Server için
            builder.Property(x => x.CreatedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.ModifiedDate).HasDefaultValueSql("getdate()");
            builder.Property(x => x.ImageUrl).IsRequired();
            builder.Property(x => x.Category).IsRequired();

            builder.ToTable("Chocolates");

            builder.HasData(
               new Chocolate
               {
                   Id = 1,
                   Name = "Sütlü Çikolata",
                   Description = "Klasik sütlü çikolata, yumuşak ve kremsi.",
                   Weight = 100,
                   CocoaPercentage = 30,
                   Price = 15.00m,
                   Brand = "ChocoDelight",
                   ExpirationDate = new DateTime(2025, 12, 31),
                   StockQuantity = 50,
                   Ingredients = "Kakao Yağı, Süt Tozu, Şeker",
                   NutritionalInformation = "Kalori: 540, Yağ: 30g, Şeker: 50g",
                   ImageUrl = "images/Chocolates/1.jpg",
                   Category = "Sütlü Çikolata",
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   IsActive = true
               },
               new Chocolate
               {
                   Id = 2,
                   Name = "Bitter Çikolata",
                   Description = "Yüksek kakao oranına sahip bitter çikolata.",
                   Weight = 100,
                   CocoaPercentage = 70,
                   Price = 18.00m,
                   Brand = "DarkEssence",
                   ExpirationDate = new DateTime(2025, 12, 31),
                   StockQuantity = 40,
                   Ingredients = "Kakao Kitlesi, Şeker, Kakao Yağı",
                   NutritionalInformation = "Kalori: 500, Yağ: 35g, Şeker: 20g",
                   ImageUrl = "images/Chocolates/2.jpg",
                   Category = "Bitter Çikolata",
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   IsActive = true
               },
               new Chocolate
               {
                   Id = 3,
                   Name = "Beyaz Çikolata",
                   Description = "Kremamsı ve tatlı beyaz çikolata.",
                   Weight = 100,
                   CocoaPercentage = 20,
                   Price = 16.00m,
                   Brand = "SweetBliss",
                   ExpirationDate = new DateTime(2025, 12, 31),
                   StockQuantity = 60,
                   Ingredients = "Süt Tozu, Kakao Yağı, Şeker",
                   NutritionalInformation = "Kalori: 550, Yağ: 32g, Şeker: 55g",
                   ImageUrl = "images/Chocolates/3.jpg",
                   Category = "Beyaz Çikolata",
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   IsActive = true
               },
               new Chocolate
               {
                   Id = 4,
                   Name = "Organik Çikolata",
                   Description = "Organik kakao ile üretilmiş çikolata.",
                   Weight = 100,
                   CocoaPercentage = 50,
                   Price = 20.00m,
                   Brand = "OrganicTreats",
                   ExpirationDate = new DateTime(2025, 12, 31),
                   StockQuantity = 30,
                   Ingredients = "Organik Kakao Kitlesi, Organik Şeker, Organik Kakao Yağı",
                   NutritionalInformation = "Kalori: 520, Yağ: 28g, Şeker: 22g",
                   ImageUrl = "images/Chocolates/4.jpg",
                   Category = "Organik Çikolata",
                   CreatedDate = DateTime.Now,
                   ModifiedDate = DateTime.Now,
                   IsActive = true
               }
            );
        }
    }
}
