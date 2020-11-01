using DemoCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoCrud
{
    public class UserDataService
    {
        private userDataRepo repo;

        public UserDataService()
        {
            repo = new userDataRepo();
        }


        public List<UserDataModel> GetAllData()
        {
            var repoList = repo.GetAllData();

            var result = new List<UserDataModel>();

            foreach (var item in repoList)
            {
                result.Add(transModel(item));
            }

            return result;
        }

        public List<UserDataModel> GetDataByName(string name)
        {
            var repoList = repo.GetDataByName(name);

            var result = new List<UserDataModel>();

            foreach (var item in repoList)
            {
                result.Add(transModel(item));
            }

            return result;
        }

        public void CreateUserData(UserDataModel data)
        {
            repo.CreateUserData(data);
        }

        public void UpdateUserData(UserDataModel data)
        {
            repo.UpdateUserData(data);
        }

        public void DeleteUserData(UserDataModel data)
        {
            repo.DeleteUserData(data);
        }

        private UserDataModel transModel(userdata data)
        {
            return new UserDataModel()
            {
                pk = data.pk,
                name = data.name,
                age = data.age,
                city = data.city
            };
        }
    }
}