using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using AlbumMeta.Models;

namespace AlbumMeta
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ArtistContext>(opt => opt.UseInMemoryDatabase("ArtistList"));
            services.AddDbContext<AlbumContext>(opt => opt.UseInMemoryDatabase("AlbumList"));
            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseMvc();
        }
    }
}