using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using WebApplication1.DataModel;
using WebApplication1.Models;

namespace WebApplication1.Dao
{
    public class HomeDao
    {
        public HomeModel getHomeList(DbAccess dbAccess, SqlCommand cmd, int accountId)
        {
            cmd.CommandText = this.getHomeListSelectQuery(accountId);

            DataTable dt = new DataTable();
            dt = dbAccess.executeQuery(cmd);

            HomeModel homeList = this.getHomeListBindDataTable(dt);

            return homeList;
        }


        public int editLicense(HomeViewModel vm, SqlCommand cmd, DbAccess dbAccess)
        {
            cmd.CommandText = this.getEditQuery(vm);

            return dbAccess.executeNonQuery(cmd);

        }


        private string getHomeListSelectQuery(int accountId)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" SELECT")
              .Append(" STR1,")
              .Append(" MM1,")
              .Append(" STR2,")
              .Append(" MM2,")
              .Append(" STR3,")
              .Append(" MM3,")
              .Append(" STR4,")
              .Append(" MM4")
              .Append(" FROM")
              .Append(" LICENSE")
              .Append(" WHERE")
              .Append($" ACCOUNT_ID = {accountId}");

            return sb.ToString();
        }

        private HomeModel getHomeListBindDataTable(DataTable dt)
        {

            HomeModel homeList = new HomeModel();
            DataRow dr = dt.Rows[0];

            if (!(dr["STR1"] is DBNull))
            {
                homeList.str1 = Convert.ToString(dr["STR1"]);
            }
            if (!(dr["MM1"] is DBNull))
            {
                homeList.MM1 = Convert.ToString(dr["MM1"]);
            }
            if (!(dr["STR2"] is DBNull))
            {
                homeList.str2 = Convert.ToString(dr["STR2"]);
            }
            if (!(dr["MM2"] is DBNull))
            {
                homeList.MM2 = Convert.ToString(dr["MM2"]);
            }
            if (!(dr["STR3"] is DBNull))
            {
                homeList.str3 = Convert.ToString(dr["STR3"]);
            }
            if (!(dr["MM3"] is DBNull))
            {
                homeList.MM3 = Convert.ToString(dr["MM3"]);
            }
            if (!(dr["STR4"] is DBNull))
            {
                homeList.str4 = Convert.ToString(dr["STR4"]);
            }
            if (!(dr["MM4"] is DBNull))
            {
                homeList.MM4 = Convert.ToString(dr["MM4"]);
            }

            return homeList;
        }

        private string getEditQuery(HomeViewModel vm)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append(" UPDATE")
              .Append(" LICENSE")
              .Append(" SET")
              .Append($" STR1 = '{vm.str1}',")
              .Append($" MM1 = '{vm.MM1}',")
              .Append($" STR2 = '{vm.str2}',")
              .Append($" MM2 = '{vm.MM2}',")
              .Append($" STR3 = '{vm.str3}',")
              .Append($" MM3 = '{vm.MM3}',")
              .Append($" STR4 = '{vm.str4}',")
              .Append($" MM4 = '{vm.MM4}'")
              .Append(" WHERE")
              .Append($" ACCOUNT_ID = '{vm.AccountId}'");

            return sb.ToString();
        }
    }
}