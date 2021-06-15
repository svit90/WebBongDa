using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Library;


namespace BongDa.Controllers
{
    public class HomeController : Controller
    {
        LinQtoSqlClassDataContext db = new LinQtoSqlClassDataContext();
        Library.Message mes = new Library.Message();
        Function fc = new Function();
        Res res = new Res();
        public ActionResult Wellcome()
        {
            if (CookieHelper.CookieExist("Token") == true)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {                
                return View();
            }
        }

        public ActionResult Verify(string code)
        {
            string userid = "";string token = "";
            string sql = "";
            userid = DBHelper.GetColumnVal("SELECT [NOTE1] FROM [wcweb].[dbo].[M_USER] WHERE NOTE1 = '" + code + "'", "NOTE1");
            if(userid != "" && userid != null)
            {
                if (CookieHelper.CookieExist("Token") == true) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    CookieHelper.CreateCookie("Token", userid, DateTime.Now.AddDays(90));
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                foreach (var u in db._0620_Workbase_Api_GetStaff_ByRowId(code))
                {
                    sql += "INSERT INTO [wcweb].[dbo].[M_USER] ";
                    sql += "([USER_NAME] ";
                    sql += ",[USER_EMAIL] ";
                    sql += ",[USER_PASS] ";
                    sql += ",[USER_MONEY] ";
                    sql += ",[FLAG_ACTIVE] ";
                    sql += ",[NOTE1]) ";
                    sql += "VALUES ";
                    sql += "( N'" + u.STAFF_NAME + "'";
                    sql += ",'" + u.STAFF_EMAIL + "'";
                    sql += ",'" + u.STAFF_PASS_CRM + "'";
                    sql += ",0";
                    sql += ",1 ";
                    sql += ",'" + u.ROWID + "')";
                    DBHelper.ExecuteQuery(sql);
                    CookieHelper.CreateCookie("Token", u.ROWID.ToString(), DateTime.Now.AddDays(90));
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        public ActionResult Index()
        {
            return View();
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

        [HttpPost]
        [AllowAnonymous]
        public ActionResult LoginDefine(FormCollection data)
        {
            Function fc = new Function();
            JsonResult response = new JsonResult();
            string _roleUser = "";
            try
            {
                string _email = data["_e"];
              
                string _url = "";
                if (_email != "")
                {
                    foreach (var row in db._0620_Workbase_GetStaff_byEmail(_email))
                    {
                        _url = "https://bongda.immgroup.com/verify/" + row.ROWID;
                        string _body = "Vui lòng <a href='"+_url+"'>Click vào đây</a> để xác nhận đăng nhập. tesst";
                        fc.SendMessageMailKit("[FC]", "crm@immgroup.com", "xnmpyehltkznxedc", _email, "","paul@immgroup.com", " Xác nhận truy cập web bóng đá của IMM GROUP", _body);

                        return mes.Success("Vui lòng kiểm tra email để xác nhận đăng nhập");
                    }
                    if (_url == "")
                    {
                        return mes.Error("Email không tồn tại trên hệ thống.");
                    }
                }
                else
                {
                    return mes.Error(Library.Message.Content.MES001);
                }
                return mes.Error(Library.Message.Content.MES001);
            }
            catch (Exception e)
            {
                return mes.Error(e.Message);
            }
        }
    }
}