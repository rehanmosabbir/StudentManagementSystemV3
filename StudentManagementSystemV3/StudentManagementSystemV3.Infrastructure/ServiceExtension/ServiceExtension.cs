using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentManagementSystemV3.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentManagementSystemV3.Core.Interfaces;
using StudentManagementSystemV3.Infrastructure.Repositories;

namespace StudentManagementSystemV3.Infrastructure.ServiceExtension
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddDIServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("WebApiDatabase"));
            });
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IStudentRepository, StudentRepository>();

            return services;
        }
    }
}
