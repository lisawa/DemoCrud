using DemoCrud.Models;
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

        public void CreateUserData(UserDataModel data)
        {
            data.pk = Guid.NewGuid();
            repo.Create(transModel(data));
            repo.SaveChanges();
        }

        public void UpdateUserData(UserDataModel data)
        {
            repo.Update(transModel(data));
            repo.SaveChanges();
        }

        public void DeleteUserData(UserDataModel data)
        {
            repo.Delete(transModel(data));
            repo.SaveChanges();
        }

        private userdata transModel(UserDataModel data)
        {
            return new userdata()
            {
                pk = data.pk,
                name = data.name,
                age = data.age,
                city = data.city
            };
        }

    }
}