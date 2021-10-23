using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common.CacheManager;
using Common.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Loader;
using System.Text;
using Utility;
using VOL.Core.CacheManager;

namespace Common.AutofacManager
{
    public static class AutofacContainerModuleExtension
    {
      

        //  private static bool _isMysql = false;
        public static IServiceCollection AddModule(this IServiceCollection services, ContainerBuilder builder, IConfiguration configuration)
        {
            //services.AddSession();
            //services.AddMemoryCache();
            //初始化配置文件
            AppSetting.Init(services, configuration);

            builder.RegisterAssemblyTypes(Assembly.Load("Service"), Assembly.Load("Service"))
                 .Where(t => t.Name.EndsWith("Service"))
                 .AsImplementedInterfaces();
          

            builder.RegisterGeneric(typeof(Repository<>))
       .As(typeof(IRepository<>))
       .InstancePerLifetimeScope();

            var ApplicationContainer =builder.Build();
            new AutofacServiceProvider(ApplicationContainer);

            //builder.RegisterAssemblyTypes(GetAssemblyByName("Service")).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();
            //builder.RegisterAssemblyTypes(GetAssemblyByName("Common")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
            //var assemblys = Assembly.Load("Service");//Service是继承接口的实现方法类库名称

            //var baseType = typeof(IDependency);//IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            //builder.RegisterAssemblyTypes(assemblys)
            // .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
            // .AsImplementedInterfaces().InstancePerLifetimeScope();


            //Type baseType = typeof(IDependency);
            //var compilationLibrary = DependencyContext.Default
            //    .CompileLibraries
            //    .Where(x => !x.Serviceable
            //    && x.Type == "project")
            //    .ToList();
            //var count1 = compilationLibrary.Count;
            //List<Assembly> assemblyList = new List<Assembly>();

            //foreach (var _compilation in compilationLibrary)
            //{
            //    try
            //    {
            //        assemblyList.Add(AssemblyLoadContext.Default.LoadFromAssemblyName(new AssemblyName(_compilation.Name)));
            //    }
            //    catch (Exception ex)
            //    {
            //        Console.WriteLine(_compilation.Name + ex.Message);
            //    }
            //}
            //builder.RegisterAssemblyTypes(assemblyList.ToArray())
            //.Where(type => baseType.IsAssignableFrom(type) && !type.IsAbstract)
            //.AsSelf()
            //.AsImplementedInterfaces()
            //.PropertiesAutowired()
            //.InstancePerLifetimeScope();


            //builder.RegisterType<UserContext>().InstancePerLifetimeScope();
            //builder.RegisterType<ActionObserver>().InstancePerLifetimeScope();
            //model校验结果
            //builder.RegisterType<ObjectModelValidatorState>().InstancePerLifetimeScope();
            //string connectionString = DBServerProvider.GetConnectionString(null);

            //if (DBType.Name == DbCurrentType.MsSql.ToString())
            // {
            //2020.03.31增加dapper对mysql字段Guid映射
            //SqlMapper.AddTypeHandler(new DapperParseGuidTypeHandler());
            //SqlMapper.RemoveTypeMap(typeof(Guid?));
            //services.AddDbContext<VOLContext>();
            //mysql8.x的版本使用Pomelo.EntityFrameworkCore.MySql 3.1会产生异常，需要在字符串连接上添加allowPublicKeyRetrieval=true


            var connection = AppSetting.DbConnectionString;
            services.AddDbContextPool<DataDBContext>(optionsBuilder => { optionsBuilder.UseSqlServer(connection).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking); }, 64);
            //}
            //else if (DBType.Name == DbCurrentType.PgSql.ToString())
            //{
            //    services.AddDbContextPool<VOLContext>(optionsBuilder => { optionsBuilder.UseNpgsql(connectionString); }, 64);
            //}
            //{
            //    services.AddDbContextPool<VOLContext>(optionsBuilder => { optionsBuilder.UseMySql(connectionString); }, 64);
            //}
            //启用缓存
            if (AppSetting.UseRedis)
            {
                builder.RegisterType<RedisCacheService>().As<ICacheService>().SingleInstance();
            }
            else
            {
                builder.RegisterType<MemoryCacheService>().As<ICacheService>().SingleInstance();
            }
            return services;
        }

    }
}
