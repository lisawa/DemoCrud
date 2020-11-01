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

        public userdata GetDataByPk(string pk)
        {
            var data = repo.Reads();

            var id = new Guid(pk);

            return repo.Reads().Where(x => x.pk.ToString() == pk).FirstOrDefault();
        }

        public void CreateUserData(UserDataModel data)
        {
            data.pk = Guid.NewGuid();
            var dbData = transModel(data);
            dbData.createDate = DateTime.Now;
            repo.Create(dbData);
            repo.SaveChanges();
        }

        public void UpdateUserData(UserDataModel data)
        {
            var dbData = GetDataByPk(data.pk.ToString());

            dbData.name = data.name;
            dbData.age = data.age;
            dbData.city = data.city;

            repo.Update(dbData);
            repo.SaveChanges();
        }

        public void DeleteUserData(string pk)
        {
            var data = GetDataByPk(pk);

            if (data != null)
            {
                repo.Delete(data);
                repo.SaveChanges();
            }
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