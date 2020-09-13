using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Dao;
using WebApplication1.DataModel;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {


            int accountId = 1;
            HomeModel homeList = getHomeList(accountId);
            HomeViewModel vm = new HomeViewModel();

            vm.AccountId = accountId;
            
            vm.str1 = homeList.str1;
            vm.MM1 = homeList.MM1;
            vm.str2 = homeList.str2;
            vm.MM2 = homeList.MM2;
            vm.str3 = homeList.str3;
            vm.MM3 = homeList.MM3;
            vm.str4 = homeList.str4;
            vm.MM4 = homeList.MM4;

            int count = 2;
            if(!(vm.MM2 == null || vm.MM2 == ""))
            {
                count = 3;
            }
            if (!(vm.MM3 == null || vm.MM3 == ""))
            {
                count = 4;
            }
            if (!(vm.MM4 == null || vm.MM4 == ""))
            {
                count = 5;
            }
            vm.Count = count;

            ViewBag.SelectOptions = Util.DropDownList.getSelectListItem();

            return View(vm);

        }

        public ActionResult Edit(HomeViewModel vm)
        {

            try
            {
                int accountId = 1;
                vm.AccountId = accountId;
                editLicense(vm);
                TempData["message"] = "プロフィールが変更されました";
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                this.ModelState.AddModelError(string.Empty, "プロフィールを変更することが出来ませんでした。");
            }
            return RedirectToAction("Index");
        }

        private HomeModel getHomeList(int accountId)
        {
            DbAccess dbAccess = new DbAccess();
            SqlCommand cmd = dbAccess.sqlCon.CreateCommand();
            try
            {
                HomeDao dao = new HomeDao();
                HomeModel homeList = dao.getHomeList(dbAccess, cmd, accountId);

                dbAccess.close();
                return homeList;
            }
            catch (DbException)
            {
                dbAccess.close();
                throw;
            }
        }


        private static void editLicense(HomeViewModel vm)
        {
            //SQLServerの接続開始
            DbAccess dbAccess = new DbAccess();
            SqlCommand cmd = dbAccess.sqlCon.CreateCommand();

            dbAccess.beginTransaciton();
            try
            {
                HomeDao dao = new HomeDao();
                if (dao.editLicense(vm, cmd, dbAccess) > 0)
                {
                    dbAccess.sqlTran.Commit();
                }
                else
                {
                    dbAccess.sqlTran.Rollback();
                }

                dbAccess.close();
            }
            catch (Exception)
            {
                dbAccess.close();
                throw;
            }

        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

    }
}