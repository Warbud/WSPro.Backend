using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WSPro.Backend.Infrastructure;

namespace Test.WSPro.Backend
{
    public class WSProTestContext
    {
        private const string ConnectionString = "Host=localhost;Database=wspro_test;Username=postgres;Password=admin";
        public WSProContext Context;

        public WSProTestContext()
        {
            Context = new ServiceCollection()
                .AddDbContextPool<WSProContext>(opt =>
                    opt.UseNpgsql(ConnectionString)
                        .EnableSensitiveDataLogging()
                        .LogTo(Console.WriteLine))
                .BuildServiceProvider().GetService<WSProContext>()!;
        }
    }
}