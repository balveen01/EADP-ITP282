using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Doosan.models;
using System.Data;

namespace Doosan.BLL
{
    public class StaffBLL
    {
        StaffModel StaffDAL= new StaffModel();

        // Create
        public int createStaff(string pUsername, string pEmail, string pName, string pDepartment)
        {
            return StaffDAL.createStaff(pUsername, pEmail, pName, pDepartment);
        }

        // Read
        public StaffModel getStaff(string id)
        {
            return StaffDAL.getStaff(id);
        }

        public DataSet getAllStaff()
        {
            return StaffDAL.getAllStaff();
        }

        public DataSet getAllStaff(string Keyword)
        {
            return StaffDAL.getAllStaff(Keyword);
        }

        public DataSet getAllStaffByDepartment(string pDepartment)
        {
            return StaffDAL.getAllStaffByDepartment(pDepartment);
        }

        public DataSet getAllDeactivatedStaff()
        {
            return StaffDAL.getAllDeactivatedStaff();
        }

        public DataSet getAllDeactivatedStaff(string Keyword)
        {
            return StaffDAL.getAllDeactivatedStaff(Keyword);
        }

        public bool checkIsActivated(string Id)
        {
            return StaffDAL.checkIsActivated(Id);
        }

        // Update
        public int updateStaff(string Id, string pName, string pDepartment)
        {
            return StaffDAL.updateStaff(Id, pName, pDepartment);
        }

        public int reactivateStaff(string Id)
        {
            return StaffDAL.reactivateStaff(Id);
        }

        public int deactivateStaff(string Id)
        {
            return StaffDAL.deactivateStaff(Id);
        }
    }
}