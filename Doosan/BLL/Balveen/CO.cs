using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Doosan.models;
using Doosan.BLL;

namespace Doosan.BLL
{
    public class CO
    {
        public DataSet getPODetails(int id)
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.GetPODetails(id);


            return dataSetppList;
        }

        public DataSet SuppApprove(int id)
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.SuppApprove(id);


            return dataSetppList;
        }
        public DataSet SuppDeclined(int id)
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.SuppDeclined(id);


            return dataSetppList;
        }

        public DataSet ProdInfo(int id)
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.ProdInfo(id);


            return dataSetppList;
        }

        public DataSet getPOList()
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.GetPO();


            return dataSetppList;
        }
        public DataSet getAppPOList()
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.GetAppPO();


            return dataSetppList;
        }
        public DataSet getDecPOList()
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.GetDecPO();


            return dataSetppList;
        }
        public DataSet getPendPOList()
        {
            CustomerOrder dal;
            DataSet dataSetppList;

            dal = new CustomerOrder();
            dataSetppList = dal.GetPendPO();


            return dataSetppList;
        }


    }
}