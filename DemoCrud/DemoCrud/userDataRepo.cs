using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCrud
{
    public class userDataRepo
    {
        private IRepository<userdata> repo;

        public userDataRepo()
            : this(new Repository<userdata>(new demoEntities()))
        {
        }

        public userDataRepo(IRepository<userdata> inRepo)
        {
            repo = inRepo;
        }

        public List<userdata> GetAllData()
        {
            return repo.Reads().ToList();
        }

        public List<userdata> GetDataByName(string name)
        {
            return repo.Reads().Where(x => x.name.IndexOf(name) >= 0).ToList();
        }

        public void CreateUserData(userdata data)
        {
            data.pk = Guid.NewGuid();
            repo.Create(data);
            repo.SaveChanges();
        }

        public void UpdateUserData(userdata data)
        {
            repo.Update(data);
            repo.SaveChanges();
        }

        public void DeleteUserData(userdata data)
        {
            repo.Delete(data);
            repo.SaveChanges();
        }

    }
}