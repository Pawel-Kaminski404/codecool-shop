﻿using System;
using Codecool.CodecoolShop.Areas.Identity.Data;
using Codecool.CodecoolShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Codecool.CodecoolShop.Areas.Identity.IdentityHostingStartup))]
namespace Codecool.CodecoolShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<CodecoolCodecoolShopContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("CodecoolCodecoolShopContextConnection")));

                services.AddDefaultIdentity<CodecoolShopUser>(options => options.SignIn.RequireConfirmedAccount = false)
                    .AddEntityFrameworkStores<CodecoolCodecoolShopContext>();
            });
        }
    }
}