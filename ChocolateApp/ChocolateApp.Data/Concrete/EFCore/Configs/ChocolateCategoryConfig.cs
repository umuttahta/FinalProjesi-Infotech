using ChocolateApp.Entity.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ChocolateApp.Data.Concrete.EfCore.Configs
{
    internal class ChocolateCategoryConfig : IEntityTypeConfiguration<ChocolateCategory>
    {
        public void Configure(EntityTypeBuilder<ChocolateCategory> builder)
        {
            builder.HasKey(cc => new { cc.ChocolateId, cc.CategoryId });
            builder.ToTable("ChocolateCategories");

            //builder.HasData(
            //    new ChocolateCategory { ChocolateId = 1, CategoryId = 1 },
            //    new ChocolateCategory { ChocolateId = 1, CategoryId = 2 },
            //    new ChocolateCategory { ChocolateId = 1, CategoryId = 3 },

            //    new ChocolateCategory { ChocolateId = 2, CategoryId = 1 },
            //    new ChocolateCategory { ChocolateId = 2, CategoryId = 4 },

            //    new ChocolateCategory { ChocolateId = 3, CategoryId = 2 },
            //    new ChocolateCategory { ChocolateId = 3, CategoryId = 3 },

            //    new ChocolateCategory { ChocolateId = 4, CategoryId = 1 },
            //    new ChocolateCategory { ChocolateId = 4, CategoryId = 4 },

            //    new ChocolateCategory { ChocolateId = 5, CategoryId = 2 },
            //    new ChocolateCategory { ChocolateId = 5, CategoryId = 3 }
            //);
        }
    }
}
