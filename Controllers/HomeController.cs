using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Library;


namespace BongDa.Controllers
{
    public class HomeController : Controller
    {
        LinQtoSqlClassDataContext db = new LinQtoSqlClassDataContext();
        DataBongDaDataContext bongda = new DataBongDaDataContext();
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
                    foreach (var u in db._0620_Workbase_Api_GetStaff_ByRowId(code))
                    {
                        CookieHelper.ClearCookie();
                        CookieHelper.CreateCookie("Token", u.ROWID.ToString(), DateTime.Now.AddDays(90));
                        CookieHelper.CreateCookie("Email", u.STAFF_EMAIL, DateTime.Now.AddDays(90));
                        CookieHelper.CreateCookie("UserName", u.STAFF_NAME, DateTime.Now.AddDays(90));
                        return RedirectToAction("Index", "Home");
                    }
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
                    CookieHelper.ClearCookie();
                    CookieHelper.CreateCookie("Token", u.ROWID.ToString(), DateTime.Now.AddDays(90));
                    CookieHelper.CreateCookie("Email", u.STAFF_EMAIL, DateTime.Now.AddDays(90));
                    CookieHelper.CreateCookie("UserName", u.STAFF_NAME, DateTime.Now.AddDays(90));
                    return RedirectToAction("Index", "Home");
                }
            }
            return RedirectToAction("Index", "Home");
        }
        public ActionResult Logout()
        {
            CookieHelper.ClearCookie();
            return RedirectToAction("Wellcome", "Home");
        }
        public ActionResult Index(string id)
        {
            string _token = CookieHelper.GetCookie("Token");           
            int MatchId = 0;
            string Mode = "ID";
            if(id != "" && id != null && id != "Index")
            {
                MatchId = Convert.ToInt32(id);
            }
            else
            {
                string _id = DBHelper.GetColumnVal("SELECT TOP 1 MTCH_ID FROM [wcweb].[dbo].M_MATCH WHERE FLAG_ACTIVE = 1 ORDER BY MTCH_ID ASC" , "MTCH_ID");
                MatchId = Convert.ToInt32(_id);
            }
            foreach(var item in bongda._0620_wc_GetStaff_ByRowId(_token))
            {
                CookieHelper.ClearCookie();
                CookieHelper.CreateCookie("Token", item.ROWID.ToString(), DateTime.Now.AddDays(90));
                CookieHelper.CreateCookie("Email", item.STAFF_EMAIL, DateTime.Now.AddDays(90));
                CookieHelper.CreateCookie("UserName", item.STAFF_NAME, DateTime.Now.AddDays(90));
                ViewBag.UserName = item.STAFF_NAME;
                ViewBag.UserMoney = item.USER_MONEY;
                if(item.STAFF_ID != 84 && item.STAFF_ID != 55 && item.STAFF_ID != 57)
                {
                    ViewBag.NotAdmin = "d-none";
                }
                else
                {
                    ViewBag.NotAdmin = "d-block";
                }
                
            }
            
            ViewBag.Team = bongda._062021_bongda_Get_All_FCTeam().ToList();
            ViewBag.Match = bongda._062021_bongda_Get_Match(Mode, MatchId).ToList();
            ViewBag.MatchDetails = bongda._062021_bongda_Get_Match_Details(Mode, MatchId).ToList();
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
                        fc.SendMessageMailKit("[Football Match]", "crm@immgroup.com", "xnmpyehltkznxedc", _email, "","paul@immgroup.com", " Xác nhận truy cập web bóng đá của IMM GROUP", _body);

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

        [HttpPost]
        public ActionResult AddSubmit(FormCollection data)
        {
            try
            {
                int _chooseA = Convert.ToInt32(data["_chooseA"]);
                int _chooseB = Convert.ToInt32(data["_chooseB"]);
                string _numberA = data["_numberA"];
                string _numberB = data["_numberB"];
                string _ngaythidau = data["_ngaythidau"];
                string _giothidau = data["_giothidau"];
                string _phutthidau = data["_phutthidau"];
                string _ghichu = data["_ghichu"];
                string sql = "";
                sql += "INSERT INTO [wcweb].[dbo].[M_MATCH] ";
                sql += "([MTCH_DATE] ";
                sql += ",[MTCH_HH] ";
                sql += ",[MTCH_MM] ";
                sql += ",[TEAM_1] ";
                sql += ",[TEAM_2] ";
                sql += ",[TYSO_1] ";
                sql += " ,[TYSO_2] ";
                sql += ",[KEO_1] ";
                sql += " ,[KEO_2] ";
                sql += " ,[MTCH_NOTE] ";
                sql += " ,[FLAG_ACTIVE]) ";
                sql += "VALUES ";
                sql += "('" +_ngaythidau + "'";
                sql += ",'" + _giothidau + "'";
                sql += ",'" + _phutthidau + "'";
                sql += " ,"+ _chooseA ;
                sql += " ," + _chooseB;
                sql += " ,0 ";
                sql += " ,0 ";
                sql += " ,'"+ _numberA + "'";
                sql += " ,'" + _numberB + "'";
                sql += " ,N'" + _ghichu + "'";
                sql += " ,1) ";
                DBHelper.ExecuteQuery(sql);



                return mes.Success();
            }
            catch (Exception e)
            {
                return mes.Error(e.Message);
            }
        }

        [HttpPost]
        public ActionResult PickteamSubmit(FormCollection data)
        {
            try
            {
                DateTime dt = DateTime.ParseExact("24/06/2021", "dd/MM/yyyy", CultureInfo.InvariantCulture);
                string _email = CookieHelper.GetCookie("Email");               
                string _idteam = data["_idteam"];
                string _mtchid = data["_mtchid"];
                int hh = Convert.ToInt32(DateTime.Now.Hour.ToString());
                int mm = Convert.ToInt32(DateTime.Now.Minute.ToString());
                bool _flag = true;
                foreach (var m in bongda._062021_bongda_Get_Match("ID",Convert.ToInt32(_mtchid)))
                {
                    string day = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtnow = DateTime.ParseExact(day, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtmatch = DateTime.ParseExact(m.MTCH_DATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (dtnow <= dtmatch) {
                        if (hh >= Convert.ToInt32(m.MTCH_HH) && ((mm - Convert.ToInt32(m.MTCH_MM)) < 30))
                        {
                            _flag = false;
                        }
                    }
                    else { _flag = false; }
                    
                }
                if(_flag == true)
                {
                    string sql = "DELETE [wcweb].[dbo].[M_MATCH_D] WHERE USER_EMAIL ='" + _email + "' AND MTCH_ID = " + _mtchid + " ;";
                    sql += "INSERT INTO [wcweb].[dbo].[M_MATCH_D] ";
                    sql += "([MTCH_ID] ";
                    sql += ",[USER_EMAIL] ";
                    sql += ",[TEAM_ID] ";
                    sql += ",[MTCHD_NOTE] ";
                    sql += ",[FLAG_ACTIVE] ";
                    sql += ",[Voted]) ";
                    sql += "VALUES ";
                    sql += "(" + _mtchid;
                    sql += ",'" + _email + "'";
                    sql += "," + _idteam;
                    sql += ",'' ";
                    sql += ",1";
                    sql += ",'') ";
                    DBHelper.ExecuteQuery(sql);
                    return mes.Success();
                }
                else
                {
                    return mes.Error("Đã hết thời gian chọn.");
                }
                
            }
            catch (Exception e)
            {
                return mes.Error(e.Message);
            }
        }

    }
}