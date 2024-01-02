using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface IWhatsSaidAboutUsService
    {
        IResult Add(WhatsSaidAboutUs whatsSaidAboutUs);
        IResult Update(WhatsSaidAboutUs whatsSaidAboutUs);
        IResult Delete(WhatsSaidAboutUs whatsSaidAboutUs);
        IDataResult<WhatsSaidAboutUs> GetWhatsSaidAboutUsById(int id);
        IDataResult<List<WhatsSaidAboutUs>> GetAll();
    }
}
