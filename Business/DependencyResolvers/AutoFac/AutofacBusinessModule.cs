﻿using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.AutoFac
{
    public class AutofacBusinessModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();

            builder.RegisterType<ClaimManager>().As<IClaimService>();
            builder.RegisterType<EfClaimDal>().As<IClaimDal>();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();



            builder.RegisterType<ContactPageManager>().As<IContactPageService>().SingleInstance();
            builder.RegisterType<EfContactPageDal>().As<IContactPageDal>().SingleInstance();

            builder.RegisterType<MessageManager>().As<IMessageService>().SingleInstance();
            builder.RegisterType<EfMessageDal>().As<IMessageDal>().SingleInstance();

            builder.RegisterType<PracticeAreaManager>().As<IPracticeAreaService>().SingleInstance();
            builder.RegisterType<EfPracticeAreaDal>().As<IPracticeAreaDal>().SingleInstance();

            builder.RegisterType<AboutTextManager>().As<IAboutTextService>().SingleInstance();
            builder.RegisterType<EfAboutTextDal>().As<IAboutTextDal>().SingleInstance();

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<EfContactDal>().As<IContactDal>().SingleInstance();

            builder.RegisterType<HomeTextManager>().As<IHomeTextService>().SingleInstance();
            builder.RegisterType<EfHomeTextDal>().As<IHomeTextDal>().SingleInstance();

            // NOT:
            // bu kısım kaldırılıp veriler practice area dan alınacak
            builder.RegisterType<HomeServicesManager>().As<IHomeServicesService>().SingleInstance();
            builder.RegisterType<EfHomeServicesDal>().As<IHomeServicesDal>().SingleInstance();

            builder.RegisterType<TeamManager>().As<ITeamService>().SingleInstance();
            builder.RegisterType<EfTeamDal>().As<ITeamDal>().SingleInstance();

            builder.RegisterType<SectionManager>().As<ISectionService>().SingleInstance();
            builder.RegisterType<EfSectionDal>().As<ISectionDal>().SingleInstance();

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();

            builder.RegisterType<PostManager>().As<IPostService>().SingleInstance();
            builder.RegisterType<EfPostDal>().As<IPostDal>().SingleInstance();



            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

