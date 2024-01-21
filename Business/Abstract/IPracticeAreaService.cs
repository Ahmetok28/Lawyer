using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Business.Abstract
{
    public interface IPracticeAreaService
    {
        IResult Add(IFormFile image, IFormFile background, PracticeArea practiceArea);
        IResult Update(IFormFile image, IFormFile background, PracticeArea practiceArea);
        IResult Delete(PracticeArea practiceArea);
        IDataResult<PracticeArea> GetById(int id);
        IDataResult<List<PracticeArea>> GetAll();
        IDataResult<List<PracticeAreaDTO>> GetTitleAndId();
    }
}
