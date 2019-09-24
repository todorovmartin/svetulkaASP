namespace SvetulkaApp.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    public interface ISeeder
    {
        Task SeedAsync(SvetulkaDbContext dbContext, IServiceProvider serviceProvider);
    }
}
