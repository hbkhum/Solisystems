
using Microsoft.EntityFrameworkCore;
using Solisystems.Domain.Entities;

namespace Solisystems.Data;

public static class SeedExtension
{
    public static void Seed(this ModelBuilder modelBuilder)
    {
        bool isInDocker = Environment.GetEnvironmentVariable("IN_DOCKER_CONTAINER") == "True";
        string path;

        if (isInDocker)
        {
            path = @"/app/Data/TestExampleFile.csv";
        }
        else
        {
            path = @"Data\TestExampleFile.csv";
        }

        var lines = File.ReadAllLines(path).Skip(1);

        var categories = new HashSet<string>();
        var products = new HashSet<string>();
        foreach (var line in lines)
        {
            var columns = line.Split(',');
            var categoryCode = columns[3];
            var categoryName = columns[4];

            if (!categories.Contains(categoryName))
            {
                modelBuilder.Entity<Category>().HasData(
                    new Category
                    {
                        CategoryCode = categoryCode,
                        CategoryName = categoryName,
                    });
                categories.Add(categoryName);
            }
        }

        foreach (var line in lines)
        {
            var columns = line.Split(',');
            var productCode = columns[0];
            var productName = columns[1];
            var categoryCode = columns[2];

            if (!categories.Contains(productName))
            {
                modelBuilder.Entity<ProductEntity>().HasData(
                    new ProductEntity
                    {
                        ProductCode = productCode,
                        ProductName = productName,
                        CategoryCode = categoryCode
                    });
                categories.Add(productName);
            }
        }
    }
}
