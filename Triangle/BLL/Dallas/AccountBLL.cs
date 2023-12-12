using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using Triangle.models;

namespace Triangle.BLL
{
    public class AccountBLL
    {
        AccountModel AccountDAL = new AccountModel();

        public int CreateAccount(string pUsername, string pPassword, string pEmail, string pName, string pRole)
        {
            return AccountDAL.CreateAccount(pUsername, pPassword, pEmail, pName, pRole);
        }

        public int UpdateAccount(string Id, string pEmail, string pName, string pRole)
        {
            return AccountDAL.updateAccount(Id, pEmail, pName, pRole);
        }

        public DataSet GetAllUsers()
        {
            return AccountDAL.GetAllUsers();
        }

        public AccountModel GetUser(string id)
        {
            return AccountDAL.GetUser(id);
        }

        public DataSet GetUsersBySearch(string keyword, bool GetArchived)
        {
            return AccountDAL.GetAllUsersBySearch(keyword, GetArchived);
        }

        public int ArchiveAccount(string Id)
        {
            return AccountDAL.ArchiveAccount(Id);
        }

        public int UnarchiveAccount(string Id)
        {
            return AccountDAL.UnarchiveAccount(Id);
        }
    }
}