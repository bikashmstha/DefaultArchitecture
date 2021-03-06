﻿using DefaultArchitecture.Services;
using DefaultArchitecture.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Repository;
using Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DefaultArchitecture
{
    public static class Injector
    {
        /// <summary>
        /// This extension method inject the things you need into your application
        /// </summary>
        /// <param name="services"></param>
        public static void InjectServices(this IServiceCollection services)
        {
            services.AddTransient<IUserServices, UserServices>();
            services.AddTransient<IUserRepository, UserRepository>();
        }
    }
}
