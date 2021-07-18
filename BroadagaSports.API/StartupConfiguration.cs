using BroadagaSports.API.CronJob;
using BroadagaSports.API.CronJob.CronJobConfig.Abstract;
using BroadagaSports.API.CronJob.CronJobConfig.Concrate;
using BroadagaSports.API.Services.Abstract;
using BroadagaSports.API.Services.Concrete;
using BroadagaSports.API.UnitOfWork.Abstract;
using BroadagaSports.API.UnitOfWork.Concrete;
using BroadageSports.Data;
using BroadageSports.Data.Repository.Abstract;
using BroadageSports.Data.Repository.Concrete;
using BroadageSports.Entity.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BroadagaSports.API
{
    public static class StartupConfiguration
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BroadageSportsContext>(option => option.UseSqlServer(configuration["ConnectionStrings:LocalDatabase"].ToString(), o => { o.MigrationsAssembly("BroadagaSports.API"); }));
            services.AddDbContext<BroadageSportsContext>(c => c.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
        }
        public static void ConfigureDependecyInjections(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            services.AddSingleton<IApplicationBuilder, ApplicationBuilder>();
            services.AddScoped<IMatchRepository, MatchRepository>();
            services.AddScoped<IMatchService, MatchService>();
            services.AddScoped<IUnitOfWork, _UnitOfWork>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static IServiceCollection AddCronJob<T>(this IServiceCollection services, Action<IScheduleConfig<T>> options) where T : CronJobService
        {
            if (options == null)
                throw new Exception("Please provide Schedule Configurations.");

            var config = new ScheduleConfig<T>();
            options.Invoke(config);
            if (string.IsNullOrWhiteSpace(config.CronExpression))
                throw new Exception("Empty Cron Expression is not allowed.");

            services.AddSingleton<IScheduleConfig<T>>(config);
            services.AddHostedService<T>();
            return services;
        }

    }
}
