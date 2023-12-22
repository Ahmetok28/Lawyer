using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ITeamService
    {
        IResult Add(Team team);
        IResult Update(Team team);
        IResult Delete(Team team);
        IDataResult<Team> GetByTeamId(int teamId);
        IDataResult<List<Team>> GetAll();



    }
}
