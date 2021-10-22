//using Autofac;
//using Common.Repository;
//using System;
//using System.Collections.Generic;
//using System.Reflection;
//using System.Runtime.Loader;
//using System.Text;

//namespace Common.AutofacManager
//{
//    public class DefaultModuleRegister : Autofac.Module
//    {
//        public DefaultModuleRegister(ContainerBuilder builder)
//        {


//        }
//        protected override void Load(ContainerBuilder builder)
//        {
//            builder.RegisterGeneric(typeof(Repository<>))
//             .As(typeof(IRepository<>))
//             .InstancePerLifetimeScope();
//            ////注册当前程序集中以“Service”及“Repository”结尾的类,暴漏类实现的所有接口，生命周期为PerLifetimeScope

//            //以“Service”及“Repository”结尾的类是利用发型实现的数据仓库的管理及业务处理的类和接口
//          //  var assemblys = Assembly.Load("Service");//Service是继承接口的实现方法类库名称
//          //  var assemblys2 = Assembly.Load("Common");//Service是继承接口的实现方法类库名称
//          //  var baseType = typeof(IDependency);//IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
//          //  builder.RegisterAssemblyTypes(assemblys)
//          //   .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
//          //   .AsImplementedInterfaces().InstancePerLifetimeScope();
//          //  builder.RegisterAssemblyTypes(assemblys2)
//          //.Where(m => baseType.IsAssignableFrom(m) && m != baseType)
//          //.AsImplementedInterfaces().InstancePerLifetimeScope();
//            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();
//            //builder.RegisterAssemblyTypes(System.Reflection.Assembly.GetExecutingAssembly()).Where(t => t.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();

//        }

//        public static Assembly GetAssembly(string assemblyName)
//        {
//            var assembly = AssemblyLoadContext.Default.LoadFromAssemblyPath(AppContext.BaseDirectory + $"{assemblyName}.dll");
//            return assembly;
//        }

//    }
//}
