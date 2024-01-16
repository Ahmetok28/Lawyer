using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Helpers.FileHelper;
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

            builder.RegisterType<UserOperationClaimManager>().As<IUserOperationClaimService>();
            builder.RegisterType<EfUserOperationClaimDal>().As<IUserOperationClaimDal>();

            builder.RegisterType<OperationClaimManager>().As<IOperationClaimService>();
            builder.RegisterType<EfOperationClaimDal>().As<IOperationClaimDal>();

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

            builder.RegisterType<UserAdditioanalPropertiesManager>().As<IUserAdditioanlPropertiesService>().SingleInstance();
            builder.RegisterType<EfUserAdditionalPropertiesDal>().As<IUserAdditionalPropertiesDal>().SingleInstance();

            builder.RegisterType<SectionManager>().As<ISectionService>().SingleInstance();
            builder.RegisterType<EfSectionDal>().As<ISectionDal>().SingleInstance();

            builder.RegisterType<BlogManager>().As<IBlogService>().SingleInstance();
            builder.RegisterType<EfBlogDal>().As<IBlogDal>().SingleInstance();

            builder.RegisterType<BlogCategoryManager>().As<IBlogCategoryService>().SingleInstance();
            builder.RegisterType<EfBlogCategoryDal>().As<IBlogCategoryDal>().SingleInstance();

            builder.RegisterType<PostManager>().As<IPostService>().SingleInstance();
            builder.RegisterType<EfPostDal>().As<IPostDal>().SingleInstance();
            
            builder.RegisterType<WhatsSaidAboutUsManager>().As<IWhatsSaidAboutUsService>().SingleInstance();
            builder.RegisterType<EfWhatsSaidAboutUsDal>().As<IWhatSaidAboutUsDal>().SingleInstance(); 

            builder.RegisterType<WhyChooseUsManager>().As<IWhyChooseUsService>().SingleInstance();
            builder.RegisterType<EfWhyChooseUsDal>().As<IWhyChooseUsDal>().SingleInstance(); 

            builder.RegisterType<AboutPageManager>().As<IAboutPageService>().SingleInstance();
            builder.RegisterType<EfAboutPageDal>().As<IAboutPageDal>().SingleInstance();
            
            builder.RegisterType<WhyChooseLogoManager>().As<IWhyChooseLogoService>().SingleInstance();
            builder.RegisterType<EfWhyChooseLogoDal>().As<IWhyChooseLogoDal>().SingleInstance(); 
            
            builder.RegisterType<BlogCommentManager>().As<IBlogCommentService>().SingleInstance();
            builder.RegisterType<EfBlogCommentDal>().As<IBlogCommentDal>().SingleInstance();  
            
            builder.RegisterType<FooterSocialAndSayingMaanger>().As<IFooterSocialAndSayingService>().SingleInstance();
            builder.RegisterType<EfFooterSocialAndSayingDal>().As<IFooterSocialAndSayingDal>().SingleInstance();

            builder.RegisterType<ProfilePhotoManager>().As<IProfilePhotoService>().SingleInstance();
            builder.RegisterType<EfProfilePhotoDal>().As<IProfilePhotoDal>().SingleInstance();

            builder.RegisterType<FileHeplerManager>().As<IFileHelper>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}

