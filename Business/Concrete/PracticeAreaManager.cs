using Business.Abstract;
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

        public void Add(PracticeArea practiceArea)
        {
            throw new NotImplementedException();
        }

        public void Delete(PracticeArea practiceArea)
        {
            throw new NotImplementedException();
        }

        public List<PracticeArea> GetAll()
        {
            return _practiceAreaDal.GetAll();
        }
        public List<PracticeAreaDTO> GetTitleAndId()
        {
            var value= _practiceAreaDal.GetAll().Select(x => new PracticeAreaDTO { Id = x.Id, Name = x.Name }).ToList();
            return value;
        }

        public PracticeArea GetById(int id)
        {
           return _practiceAreaDal.Get(x=>x.Id == id);
        }

        public void Update(PracticeArea practiceArea)
        {
            throw new NotImplementedException();
        }
    }
}
