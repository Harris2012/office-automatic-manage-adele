using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

using Canos.OfficeAutomatic.Convertor;
using Canos.OfficeAutomatic.Repository;
using MySql.Data.MySqlClient;
using Canos.OfficeAutomatic.Repository.Mysql;
using Canos.OfficeAutomatic.Metadata;
using Canos.OfficeAutomatic.Metadata.Implement;

namespace Canos.OfficeAutomatic
{
    partial class Startup
    {

        private void InternalConfigure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.ApplicationServices.GetRequiredService<IMetaNoticeCategoryProvider>().Load();

        }
    }
}
