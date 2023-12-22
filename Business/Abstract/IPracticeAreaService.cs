using Core.Utilities.Results;
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
        IResult Add(PracticeArea practiceArea);
        IResult Update(PracticeArea practiceArea);
        IResult Delete(PracticeArea practiceArea);
        IDataResult<PracticeArea> GetById(int id);
        IDataResult<List<PracticeArea>> GetAll();
        IDataResult<List<PracticeAreaDTO>> GetTitleAndId();
    }
}
