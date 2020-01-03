using System;

using Microsoft.Extensions.DependencyInjection;

using Canos.OfficeAutomatic.Convertor;
using Canos.OfficeAutomatic.Convertor.Implement;
using Canos.OfficeAutomatic.Lookup;
using Canos.OfficeAutomatic.Lookup.Implement;
using Canos.OfficeAutomatic.Metadata;
using Canos.OfficeAutomatic.Metadata.Implement;
using Canos.OfficeAutomatic.Repository;
using Canos.OfficeAutomatic.Repository.Mysql;

namespace Canos.OfficeAutomatic.Configure
{
    public static class ServiceExtension
    {
        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {

            services.AddSingleton<INoticeRepository, MysqlNoticeRepository>();
            services.AddSingleton<INoticeCategoryRepository, MysqlNoticeCategoryRepository>();

            services.AddSingleton<IMetaNoticeCategoryRepository, MysqlMetaNoticeCategoryRepository>();


            return services;
        }

        public static IServiceCollection AddConvertorServices(this IServiceCollection services)
        {

            services.AddSingleton<INoticeConvertor, NoticeConvertor>();
            services.AddSingleton<INoticeCategoryConvertor, NoticeCategoryConvertor>();

            services.AddSingleton<IMetaNoticeCategoryConvertor, MetaNoticeCategoryConvertor>();


            return services;
        }

        public static IServiceCollection AddProviderServices(this IServiceCollection services)
        {

            services.AddSingleton<IMetaNoticeCategoryProvider, MetaNoticeCategoryProvider>();

            return services;
        }

        public static IServiceCollection AddLookupProviderServices(this IServiceCollection services)
        {

            services.AddSingleton<INoticeLookupProvider, NoticeLookupProvider>();
            services.AddSingleton<INoticeCategoryLookupProvider, NoticeCategoryLookupProvider>();

            return services;
        }
    }
}
