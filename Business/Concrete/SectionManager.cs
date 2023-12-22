using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SectionManager:ISectionService
    {
        private readonly ISectionDal _sectionDal;

        public SectionManager(ISectionDal sectionDal)
        {
            _sectionDal = sectionDal;
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Add(Section section)
        {
            throw new NotImplementedException();
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Delete(Section section)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Section>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult< List<Section>> GetSectionByPracticeAreaId(int id)
        {
           return new SuccessDataResult<List<Section>>( _sectionDal.GetAll(x=>x.PracticeAreaId==id));
        }
        [SecuredOperation("Admin,Moderator")]
        public IResult Update(Section section)
        {
            throw new NotImplementedException();
        }
    }
}
