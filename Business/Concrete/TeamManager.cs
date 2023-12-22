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
    public class TeamManager : ITeamService     

    {
        private readonly ITeamDal _teamDal;

        public TeamManager(ITeamDal teamDal)
        {
            _teamDal = teamDal;
        }
        [SecuredOperation("Admin")]
        public IResult Add(Team team)
        {
           _teamDal.Add(team);
            return new SuccessResult();
        }
        [SecuredOperation("Admin")]
        public IResult Delete(Team team)
        {
           _teamDal.Delete(team);
            return new SuccessResult();
        }
        
        public IDataResult< List<Team>> GetAll()
        {
           return new SuccessDataResult<List<Team>>( _teamDal.GetAll());
        }

        public IDataResult< Team> GetByTeamId(int teamId)
        {
           return new SuccessDataResult<Team>( _teamDal.Get(x=>x.Id==teamId));
        }
        [SecuredOperation("Admin")]
        public IResult Update(Team team)
        {
           _teamDal.Update(team);
            return new SuccessResult();
        }
    }
}
