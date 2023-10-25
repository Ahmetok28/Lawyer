using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Business.Abstract
{
    public interface IPracticeAreaService
    {
        void Add(PracticeArea practiceArea);
        void Update(PracticeArea practiceArea);
        void Delete(PracticeArea practiceArea);
        PracticeArea GetById(int id);
        List<PracticeArea> GetAll();
        List<PracticeAreaDTO> GetTitleAndId();
    }
}
