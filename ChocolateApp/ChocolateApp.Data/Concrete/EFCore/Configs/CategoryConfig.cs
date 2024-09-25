using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChocolateApp.Data.Concrete.EfCore.Configs
{
    public class CategoryConfig : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired(false).HasMaxLength(500);
            builder.ToTable("Categories");

            builder.HasData(
                new Category
                {
                    Id = 1,
                    Name = "Sütlü Çikolata",
                    Description = "Sütlü çikolata kategorisi"
                },
                new Category
                {
                    Id = 2,
                    Name = "Bitter Çikolata",
                    Description = "Bitter çikolata kategorisi"
                },
                new Category
                {
                    Id = 3,
                    Name = "Beyaz Çikolata",
                    Description = "Beyaz çikolata kategorisi"
                },
                new Category
                {
                    Id = 4,
                    Name = "Vegan Çikolata",
                    Description = "Organik çikolata kategorisi"
                }

            );
        }
    }
}
