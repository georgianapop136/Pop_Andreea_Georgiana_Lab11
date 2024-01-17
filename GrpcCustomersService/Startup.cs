using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Pop_Andreea_Georgiana_Lab2.Data;

namespace GrpcCustomersService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; }


        public void ConfigureServices(IServiceCollection services)
        {
            services.AddGrpc();
            services.AddDbContext<LibraryContext>(options =>

            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }
    }
}


