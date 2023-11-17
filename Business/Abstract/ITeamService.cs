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
        void Add(Team team);
        void Update(Team team);
        void Delete(Team team);
        Team GetByTeamId(int teamId);
        List<Team> GetAll();



    }
}
