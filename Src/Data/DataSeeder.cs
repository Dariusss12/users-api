using Bogus;
using users_api.Src.Models;

namespace users_api.Src.Data
{
    public class DataSeeder
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetRequiredService<DataContext>();

            if (!context.Users.Any())
            {

                int emailIndex = 0;

                var faker = new Faker<User>()
                    .RuleFor(u => u.Name, f => f.Person.FirstName[..Math.Min(15, f.Person.FirstName.Length)]) // Limitar nombre a 15 caracteres
                    .RuleFor(u => u.LastName, f => f.Person.LastName[..Math.Min(100, f.Person.LastName.Length)]) // Limitar apellido
                    .RuleFor(u => u.Email, f => $"{f.Internet.UserName()}{emailIndex++}@email.com") // Garantizar correos únicos
                    .RuleFor(u => u.Password, f => BCrypt.Net.BCrypt.HashPassword("password"))
                    .RuleFor(u => u.IsActive, f => f.Random.Bool());

                var users = faker.Generate(60);

                context.Users.AddRange(users);
            }

            context.SaveChanges();


        }
    }
}