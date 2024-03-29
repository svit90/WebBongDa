﻿using System;
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
        Message mes = new Message();
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
            string _token = fc.DecryptString(code);
            userid = DBHelper.GetColumnVal("SELECT [NOTE1] FROM [wcweb].[dbo].[M_USER] WHERE NOTE1 = '" + _token + "'", "NOTE1");
            if(userid != "" && userid != null)
            {
                if (CookieHelper.CookieExist("Token") == true) 
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var u in db._0620_Workbase_Api_GetStaff_ByRowId(_token))
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
                foreach (var u in db._0620_Workbase_Api_GetStaff_ByRowId(_token))
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
            if (CookieHelper.CookieExist("Token") != true)
            { 
                return RedirectToAction("Wellcome", "Home");
            }
            else
            {
                string _token = CookieHelper.GetCookie("Token");
                int MatchId = 0;
                string Mode = "ID";

                if (id != "" && id != null && id != "Index")
                {
                    MatchId = Convert.ToInt32(id);
                }
                else
                {
                    string _id = DBHelper.GetColumnVal("SELECT TOP 1 MTCH_ID FROM [wcweb].[dbo].M_MATCH WHERE FLAG_ACTIVE = 1 ORDER BY CONVERT(DATETIME,MTCH_DATE + ' ' + MTCH_HH + ':' + MTCH_MM + ':00',105) ASC", "MTCH_ID");
                    if(_id != null && _id != "")
                    {
                        MatchId = Convert.ToInt32(_id);
                    }                    
                }
                foreach (var item in bongda._0620_wc_GetStaff_ByRowId(_token))
                {
                    ViewBag.UserName = item.STAFF_NAME;
                    ViewBag.UserMoney = item.USER_MONEY;
                    if (item.STAFF_ID != 84 && item.STAFF_ID != 55 && item.STAFF_ID != 57)
                    {
                        ViewBag.NotAdmin = "d-none";
                    }
                    else
                    {
                        ViewBag.NotAdmin = "";
                    }

                }
                ViewBag.BXH = bongda._0620_wc_Get_All_BXH().ToList();
                ViewBag.Team = bongda._062021_bongda_Get_All_FCTeam().ToList();
                ViewBag.Match = bongda._062021_bongda_Get_Match(Mode, MatchId).ToList();
                ViewBag.MatchNext = bongda._062021_bongda_Get_Match("ALL", MatchId).ToList();
                ViewBag.MatchDone = bongda._062021_bongda_Get_Match("DONE", MatchId).ToList();
                ViewBag.MatchDetails = bongda._062021_bongda_Get_Match_Details(Mode, MatchId).ToList();
                ViewBag.MatchDetailsAll = bongda._062021_bongda_Get_Match_Details("ALL", MatchId).ToList();
            }
            
            return View();
        }
        public ActionResult AutoBlockRandom(string id)
        {
            int MatchId = 0;
            if (id != "" && id != null && id != "Index")
            {
                MatchId = Convert.ToInt32(id);
            }
            ViewBag.MatchNext = bongda._062021_bongda_Get_Match("ID", MatchId).ToList();
            ViewBag.MatchTime = ""; string _MatchTime = "";int curentMtach = 0;
            foreach (var item in bongda._062021_bongda_Get_Match("ID", MatchId))
            {
                _MatchTime = item.TIMEMATCH.ToString();
            }
            ViewBag.Current = MatchId;
            ViewBag.MatchTime = _MatchTime;
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
                        string _vercode = fc.EncryptString(row.ROWID.ToString());
                        _url = "https://wc2022.immproject.site/verify/" + _vercode;
                        string _body = "Xin chào " + row.STAFF_NAME + ", </br> Vui lòng xác nhận bằng cách click vào <a href='"+_url+"'>Tôi đã đọc vào xác nhận tham gia</a> chương trình dự đoán worldcup 2022.</br> Bằng việc click xác nhận tham gia bạn đã chấp nhận các điều khoản mà ban tổ chức đã thông báo";
                        fc.SendMessageMailKit("[World cup 2022]", "system@immgroup.com", "lhqoiqxowclesdtt", _email, "","", " Xác nhận tham gia worldcup của IMM GROUP", _body);

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
        //BlockmatchSubmit
        [HttpPost]
        public ActionResult BlockmatchSubmit(FormCollection data)
        {
            try
            {

                string _token = CookieHelper.GetCookie("Token"); 
                string flag = "staff";
                foreach (var item in bongda._0620_wc_GetStaff_ByRowId(_token))
                {
                    if (item.STAFF_ID != 84 && item.STAFF_ID != 55 && item.STAFF_ID != 57)
                    {
                        flag = "admin";
                    }
                }
                if (flag == "staff")
                {
                    int _mtchid = Convert.ToInt32(data["_mtchid"]);
                    int _team1 = Convert.ToInt32(data["_team1"]);
                    int _team2 = Convert.ToInt32(data["_team2"]);
                    int[] names = new int[] { _team1, _team2 };
                    Random rnd = new Random();

                    string sql = "";
                    foreach (var row in bongda._0620_wc_GetStaff_Torandom(_mtchid))
                    {
                        int index = rnd.Next(names.Length);
                        string teamRandom = names[index].ToString();
                        sql += "INSERT INTO [wcweb].[dbo].[M_MATCH_D] ";
                        sql += "([MTCH_ID] ";
                        sql += ",[USER_EMAIL] ";
                        sql += ",[TEAM_ID] ";
                        sql += ",[MTCHD_NOTE] ";
                        sql += ",[FLAG_ACTIVE] ";
                        sql += ",[Voted]) ";
                        sql += "SELECT " + _mtchid + ", '" + row.USER_EMAIL + "', " + teamRandom + " ,'20000',1  ,''; ";
                    }
                    if (sql != "") { DBHelper.ExecuteQuery(sql); }
                }
                return mes.Success();
            }
            catch (Exception e)
            {
                return mes.Error(e.Message);
            }
        }
        [HttpPost]
        public ActionResult AutoBlockmatchSubmit(FormCollection data)
        {
            try
            {
                JsonResult response = new JsonResult();
                int _mtchid = Convert.ToInt32(data["_mtchid"]);
                int _team1 = Convert.ToInt32(data["_team1"]);
                int _team2 = Convert.ToInt32(data["_team2"]);
                int[] names = new int[] { _team1, _team2 };
                Random rnd = new Random();
                
                string sql = "";string _IdMatchNext = "";string _url = "";
                foreach (var row in bongda._0620_wc_GetStaff_Torandom(_mtchid))
                {
                    int index = rnd.Next(names.Length);
                    string teamRandom = names[index].ToString();
                    sql += "INSERT INTO [wcweb].[dbo].[M_MATCH_D] ";
                    sql += "([MTCH_ID] ";
                    sql += ",[USER_EMAIL] ";
                    sql += ",[TEAM_ID] ";
                    sql += ",[MTCHD_NOTE] ";
                    sql += ",[FLAG_ACTIVE] ";
                    sql += ",[Voted]) ";
                    sql += "SELECT " + _mtchid + ", '" + row.USER_EMAIL + "', " + teamRandom + " ,'20000',1  ,''; ";
                }
                if (sql != "") { DBHelper.ExecuteQuery(sql); }

                foreach (var item in bongda._062021_bongda_Get_Match("COUNTNEXT", _mtchid))
                {
                    _IdMatchNext = item.MTCH_ID.ToString() ;
                }
                if (_IdMatchNext != "")
                {
                    _url = "/tools/autorandom/"+ _IdMatchNext;
                }
                response.Data = new
                {
                    type = "success",
                    url = _url
                };
                return response;
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
                if(_numberA == "" || _numberA == null)
                {
                    _numberA = "0";
                }
                if (_numberB == "" || _numberB == null)
                {
                    _numberB = "0";
                }
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
                string _datcuoc = data["_datcuoc"];
                int hh = Convert.ToInt32(DateTime.Now.Hour.ToString());
                int mm = Convert.ToInt32(DateTime.Now.Minute.ToString());
                bool _flag = true;
                foreach (var m in bongda._062021_bongda_Get_Match("ID",Convert.ToInt32(_mtchid)))
                {
                    string day = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtnow = DateTime.ParseExact(day, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    DateTime dtmatch = DateTime.ParseExact(m.MTCH_DATE, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    if (dtnow < dtmatch ) {
                        _flag = true;
                    }
                    else if (dtnow == dtmatch)
                    {
                        if (hh >= Convert.ToInt32(m.MTCH_HH)){
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
                    sql += ",'" + _datcuoc + "'";
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

        [HttpPost]
        public ActionResult EndmatchSubmit(FormCollection data)
        {
            try
            {
                string _token = CookieHelper.GetCookie("Token"); 
                string flag = "staff";
                foreach (var item in bongda._0620_wc_GetStaff_ByRowId(_token))
                {
                    if (item.STAFF_ID != 84 && item.STAFF_ID != 55 && item.STAFF_ID != 57)
                    {
                        flag = "admin";
                    }
                }
                if (flag == "staff")
                {
                    string _tysot1 = data["_tysot1"];
                    string _tysot2 = data["_tysot2"];
                    string _mtchid = data["_mtchid"];
                    string sql = "";
                    sql += " UPDATE [wcweb].[dbo].[M_MATCH] ";
                    sql += " SET ";
                    sql += " [TYSO_1] = " + _tysot1;
                    sql += " ,[TYSO_2] = " + _tysot2;
                    sql += " ,[FLAG_ACTIVE] = 0 ";
                    sql += " WHERE MTCH_ID = " + _mtchid + "; ";
                    DBHelper.ExecuteQuery(sql);
                    sql = "";
                    foreach (var m in bongda._062021_bongda_Get_After_Match(Convert.ToInt32(_mtchid)))
                    {
                        int user = m.USER_ID;
                        int curmoney = Convert.ToInt32(m.USER_MONEY);
                        int wlmoney = Convert.ToInt32(m.WLMONEY);
                        int totalmoney = curmoney + wlmoney;
                        sql += " UPDATE [wcweb].[dbo].[M_USER] SET USER_MONEY = " + totalmoney + " WHERE USER_ID = " + user + " ; ";
                    }
                    DBHelper.ExecuteQuery(sql);
                }
                
                return mes.Success();

            }
            catch (Exception e)
            {
                return mes.Error(e.Message);
            }
        }
    }
}