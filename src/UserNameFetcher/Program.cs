using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace UserNameFetcher
{
    internal class Program
    {
        private static readonly int[] UserIds = {1, 2, 3, -1};

        private static void Main()
        {
            var host = CreateHostBuilder().Build();
            var userNameService = host.Services.GetService<IUserNameService>();

            if (userNameService == null)
            {
                throw new Exception("UserName service is required!");
            }

            var userIdPairs = UserIds.ToDictionary(id => id, id => userNameService.GetUserName(id));

            foreach (var userIdPair in userIdPairs)
            {
                Console.WriteLine(userIdPair.Value == null
                    ? $"No username found for UserId: {userIdPair.Key}"
                    : $"Username found for UserId: {userIdPair.Key} with Value: {userIdPair.Value}");
            }
        }

        private static IHostBuilder CreateHostBuilder()
        {
            var hostBuilder = Host.CreateDefaultBuilder()
                .ConfigureAppConfiguration((context, builder) =>
                {
                    builder.SetBasePath(Directory.GetCurrentDirectory());
                })
                .ConfigureServices((context, services) =>
                {
                    services.AddScoped<IUserNameService, UserNameService>();
                });

            return hostBuilder;
        }
    }
}