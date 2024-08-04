using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutTextService
    {
        IResult Add(AboutText aboutText);
        IResult Update(IFormFile file, AboutText aboutText);
        IResult Delete(AboutText aboutText);
        IDataResult<AboutText> GetAboutText();
    }
}
