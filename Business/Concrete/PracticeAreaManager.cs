using Business.Abstract;
using Business.Constants;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PracticeAreaManager:IPracticeAreaService
    {
        private readonly IPracticeAreaDal _practiceAreaDal;

        public PracticeAreaManager(IPracticeAreaDal practiceAreaDal)
        {
            _practiceAreaDal = practiceAreaDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(PracticeArea practiceArea)
        {
            _practiceAreaDal.Add(practiceArea);
            return new SuccessResult(Messages.SuccesfullyAdded);
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(PracticeArea practiceArea)
        {
            _practiceAreaDal.Delete(practiceArea);
            return new SuccessResult(Messages.SuccesfullyDeleted);
        }

       
        public IDataResult< List<PracticeArea>> GetAll()
        {
            return new SuccessDataResult<List<PracticeArea>>( _practiceAreaDal.GetAll());
        }
        public IDataResult<List<PracticeAreaDTO>> GetTitleAndId()
        {
            var value= _practiceAreaDal.GetAll().Select(x => new PracticeAreaDTO { Id = x.Id, Name = x.Name }).ToList();
            return new SuccessDataResult<List<PracticeAreaDTO>>( value);
        }

        public IDataResult<PracticeArea>  GetById(int id)
        {
           return new SuccessDataResult<PracticeArea>( _practiceAreaDal.Get(x=>x.Id == id));
        }

        [SecuredOperation("Admin,Moderator")]
        public IResult Update(PracticeArea practiceArea)
        {
            _practiceAreaDal.Update(practiceArea);
            return new SuccessResult(Messages.SuccesfullyUpdated);
        }
    }
}
