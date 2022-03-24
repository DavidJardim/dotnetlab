using Ficha14.Models;

namespace Ficha14.Data
{
    public static class UsersExtension
    {
        public static void CreateDbIfNotExists(this IHost host)
        {
            {
                using (var scope = host.Services.CreateScope())
                {
                    var services = scope.ServiceProvider;
                    var context = services.GetRequiredService<UserContext>();
                    // Creates the database if not exists
                    if (context.Database.EnsureCreated())
                    {
                        UsersDbInitializer.InsertData(context);
                    }
                }
            }
        }
    }
}
