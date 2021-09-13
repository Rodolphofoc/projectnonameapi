using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using project.noname.core;
using project.noname.data;
using project.noname.data.Interface;
using project.noname.service;
using project.noname.service.Interface;
using static project.noname.core.ConfigurationManager;

namespace project.noname.ioc
{
    public class Ioc
    {
        public static void AddIoc(IServiceCollection services)
        {
            AddServices(services);
            AddRepository(services);
            AddCore(services);
            AddAuthenticated(services);
            
        }

        public static void AddCore(IServiceCollection services)
        {
            services.AddSingleton<ConfigurationManager>();
            services.AddSingleton<KeyApp>();

        }

        public static void AddServices(IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IMusicService, MusicService>();
            services.AddScoped<ITypeMusicService, TypeMusicService>();

        }

        public static void AddRepository(IServiceCollection services)
        {

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IAuthorRepository, AuthorRepository>();
            services.AddTransient<IMusicRepository, MusicRepository>();
            services.AddTransient<ITypeMusicRepository, TypeMusicRepository>();

        }

        public static void AddAuthenticated(IServiceCollection services)
        {
            //addauthenticated 
        }
    }
}
