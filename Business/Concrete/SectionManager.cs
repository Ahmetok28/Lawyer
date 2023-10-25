using Business.Abstract;
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

        public void Add(Section section)
        {
            throw new NotImplementedException();
        }

        public void Delete(Section section)
        {
            throw new NotImplementedException();
        }

        public List<Section> GetAll()
        {
            throw new NotImplementedException();
        }

        public List<Section> GetSectionByPracticeAreaId(int id)
        {
           return _sectionDal.GetAll(x=>x.PracticeAreaId==id);
        }

        public void Update(Section section)
        {
            throw new NotImplementedException();
        }
    }
}
