using Business.Abstract;
using Bussines.BusinessAspects.Autofac;
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
        public void Add(Team team)
        {
           _teamDal.Add(team);
        }
        [SecuredOperation("Admin")]
        public void Delete(Team team)
        {
           _teamDal.Delete(team);
        }
        
        public List<Team> GetAll()
        {
           return _teamDal.GetAll();
        }

        public Team GetByTeamId(int teamId)
        {
           return _teamDal.Get(x=>x.Id==teamId);
        }
        [SecuredOperation("Admin")]
        public void Update(Team team)
        {
           _teamDal.Update(team);
        }
    }
}
