using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfWhatsSaidAboutUsDal : EfEntityRepositoryBase<WhatsSaidAboutUs, Context>, IWhatSaidAboutUsDal
    {
    }
}
