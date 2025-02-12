﻿using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHomeTextService
    {
        IResult Add(HomeText homeText);
        IResult Update(IFormFile file, HomeText homeText);
        IResult Delete(HomeText homeText);
        IDataResult<HomeText> GetHomeText();
    }
}
