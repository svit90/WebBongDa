using Microsoft.Net.Http.Headers;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Library
{
    public class CommonConstants
    {
        public static int ADD = 1;
        public static int UPD = 2;
        public static int DEL = 3;

        public static string MEMBER_GROUP = "AUTHSTAF";
        public static string ADMIN_GROUP = "AUTHADM";
        public static string MOD_GROUP = "AUTHMOD";

        public static string USER_SESSION = "USER_SESSION";
        public static string SESSION_CREDENTIALS = "SESSION_CREDENTIALS";
        public static string CREDENTIALS = "CREDENTIALS";
        public static string CartSession = "CartSession";

        public const string initVector = "h7g3e4m3t5st5zjw";
        public const int keysize = 256;

        public static string CurrentCulture { set; get; }
    }
   
    public class CookieHelper {

        public static void CreateCookie(string CookieName,
                                        string KeyName ,
                                        string CookieValue,
                                        DateTime? expirationDate)
        {
            System.Web.HttpCookie cookie = HttpContext.Current.Response.Cookies.AllKeys.Contains(CookieName)
                ? HttpContext.Current.Response.Cookies[CookieName]
                : HttpContext.Current.Request.Cookies[CookieName];
            if (cookie == null)
            {
                cookie = new System.Web.HttpCookie(CookieName);
                cookie.Values.Add(KeyName, CookieValue);
                cookie.Expires = expirationDate.Value;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }               
        }

        public static void CreateCookie(string CookieName,
                                        string CookieValue,
                                        DateTime? expirationDate)
        {
            System.Web.HttpCookie cookie = HttpContext.Current.Response.Cookies.AllKeys.Contains(CookieName)
                ? HttpContext.Current.Response.Cookies[CookieName]
                : HttpContext.Current.Request.Cookies[CookieName];
            if (cookie == null)
            {
                cookie = new System.Web.HttpCookie(CookieName);
                cookie.Value = CookieValue;
                cookie.Expires = expirationDate.Value;
                HttpContext.Current.Response.Cookies.Add(cookie);
            }
        }

        public static void CreateCookie(object obj,
                                       DateTime? expirationDate)
        {            
            // cast to an IDictionary<string, object>
            IDictionary<object, object> expDict = (IDictionary<object, object>)obj;
            System.Web.HttpCookie cookie = HttpContext.Current.Response.Cookies.AllKeys.Contains(FormsAuthentication.FormsCookieName)
                ? HttpContext.Current.Response.Cookies[FormsAuthentication.FormsCookieName]
                : HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            if (cookie == null)
            {
                foreach (KeyValuePair<object, object> kvp in expDict)
                {
                    cookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName);
                    cookie.Values.Add(kvp.Key.ToString(), kvp.Value.ToString());
                    cookie.Expires = expirationDate.Value;
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }
        public static string GetCookie(string CookieName, string KeyName)
        {
            System.Web.HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie != null)
            {
                string val = (!String.IsNullOrEmpty(KeyName)) ? cookie[KeyName] : cookie.Value;
                if (!String.IsNullOrEmpty(val)) return Uri.UnescapeDataString(val);
            }
            return null;
        }

        public static string GetCookie(string CookieName)
        {
            System.Web.HttpCookie cookie = HttpContext.Current.Request.Cookies[CookieName];
            if (cookie != null)
            {
                string val = cookie.Value;
                if (!String.IsNullOrEmpty(val)) return Uri.UnescapeDataString(val);
            }
            return null;
        }

        public static void RemoveCookie(string keyName)
        {
            if (HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName] != null)
            {
                System.Web.HttpCookie cookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
                if (String.IsNullOrEmpty(keyName))
                {
                    cookie.Expires = DateTime.UtcNow.AddYears(-1);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                    HttpContext.Current.Request.Cookies.Remove(FormsAuthentication.FormsCookieName);
                }
                else
                {
                    cookie.Values.Remove(keyName);
                    HttpContext.Current.Response.Cookies.Add(cookie);
                }
            }
        }


        public static bool CookieExist(string CookieName)
        {         
            HttpCookieCollection cookies = HttpContext.Current.Request.Cookies;           
            if(cookies[CookieName] != null)
            {
                return true;
            }
            return false;
        }

        public static void ClearCookie()
        {
            string[] myCookies = HttpContext.Current.Request.Cookies.AllKeys;
            foreach (string cookie in myCookies)
            {
                HttpContext.Current.Response.Cookies[cookie].Expires = DateTime.Now.AddDays(-1);
            }
        }
    }
    public static class HashString
    {
        public static string EncryptString(string stringToSecret)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(stringToSecret);
            string EncryptedString = Convert.ToBase64String(passBytes);
            return EncryptedString;
        }
        public static string DecryptString(string EncryptedString)
        {
            byte[] passByteData = Convert.FromBase64String(EncryptedString);
            string originalString = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalString;
        }
    }
    public class Function
    {

        /// Encrypt - Decrypt String Function
        public string Encrypt(string text)
        {
#pragma warning disable CS0618 // Type or member is obsolete
            return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(text.Trim(), "SHA1");
#pragma warning restore CS0618 // Type or member is obsolete
        }
        public string EncryptString(string stringToSecret)
        {
            byte[] passBytes = System.Text.Encoding.Unicode.GetBytes(stringToSecret);
            string EncryptedString = Convert.ToBase64String(passBytes);
            return EncryptedString;
        }
        public string DecryptString(string EncryptedString)
        {
            byte[] passByteData = Convert.FromBase64String(EncryptedString);
            string originalString = System.Text.Encoding.Unicode.GetString(passByteData);
            return originalString;
        }
        public string EncryptUtf8(string clearText)
        {
            string EncryptionKey = "abc123";
            byte[] clearBytes = Encoding.Unicode.GetBytes(clearText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    clearText = Convert.ToBase64String(ms.ToArray());
                }
            }
            return clearText;
        }
        public string DecryptUtf8(string cipherText)
        {
            string EncryptionKey = "abc123";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] { 0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76 });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public string ConvertArray(string text)
        {
            text = text.Replace(",", ";");
            text = text.Replace(" ", "");
            text = text.Replace("/", ";");
            text = text.Replace(";;", ";");
            return text.ToLower();
        }
        public string ToHexString(string str)
        {
            var sb = new StringBuilder();

            var bytes = Encoding.Unicode.GetBytes(str);
            foreach (var t in bytes)
            {
                sb.Append(t.ToString("X2"));
            }

            return sb.ToString();
        }
        public string FromHexString(string hexString)
        {
            var bytes = new byte[hexString.Length / 2];
            for (var i = 0; i < bytes.Length; i++)
            {
                bytes[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 16);
            }

            return Encoding.Unicode.GetString(bytes);
        }
        public string ConvertName(string text)
        {
            string name = "";
            for (int i = 32; i < 48; i++)
            {
                text = text.Replace(((char)i).ToString(), " ");
            }
            Regex regex = new Regex(@"\p{IsCombiningDiacriticalMarks}+");
            string strFormD = text.Normalize(System.Text.NormalizationForm.FormD);
            name = regex.Replace(strFormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D').ToLower();
            return name;
        }
        public DateTime Convertbrd(string indate)
        {
            DateTime fullbrd = DateTime.Parse("01/01/1980");
            try
            {
                indate = indate.Substring(3, 2) + "/" + indate.Substring(0, 2) + "/" + indate.Substring(6, 4);
                DateTime dt = DateTime.Parse(indate);
                return dt;
            }
            catch (Exception)
            {

            }
            return fullbrd;
        }
        public string formatpm(string inObject)
        {
            string outObject = "";
            try
            {
                inObject = inObject.Replace(" ", "");

                string[] words = inObject.Split(';');
                foreach (var line in words)
                {
                    if (line != "")
                    {
                        outObject += line + ";";
                    }
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
            return outObject;
        }
       public string NVL(object obj)
        {
            string revalue = "";
            if (obj != null)
            {
                revalue = obj.ToString();
            }
            else
            {
                revalue = "";
            }
            return revalue;
        }

        public string SplitAndAddSeparator(string inObject)
        {
            string outObject = "";
            try
            {
                inObject = inObject.Replace(" ", "");
                string[] words = inObject.Split(',');
                foreach (var line in words)
                {
                    if (line != "")
                    {
                        outObject += ",'" + line + "'";
                    }
                }
                outObject = outObject.Substring(1);
            }
            catch (Exception ex)
            {
                return "";
            }
            return outObject;
        }
        //General random character code
        public string GetVerifyCode(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "ABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        public string GetUniqueKey(int maxSize)
        {
            char[] chars = new char[62];
            chars =
            "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            byte[] data = new byte[1];
            using (RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider())
            {
                crypto.GetNonZeroBytes(data);
                data = new byte[maxSize];
                crypto.GetNonZeroBytes(data);
            }
            StringBuilder result = new StringBuilder(maxSize);
            foreach (byte b in data)
            {
                result.Append(chars[b % (chars.Length)]);
            }
            return result.ToString();
        }
        //Get list files attach
   
        public void SendMessageMailKit(string MailHeader, string SenderEmail, string SenderPassword, string ToEmail, string CcEmail, string BccEmail, string Subject, string BodyEmail)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(SenderEmail, MailHeader);
            string[] Tomails = ToEmail.Replace(" ", "").Split(';');
            foreach (string email in Tomails)
            {
                if (!String.IsNullOrEmpty(email))
                {
                    message.To.Add(new MailAddress(email));
                }
            }
            string[] CcEmails = CcEmail.Replace(" ", "").Split(';');
            foreach (string email in CcEmails)
            {
                if (!String.IsNullOrEmpty(email))
                {
                    message.CC.Add(new MailAddress(email));
                }
            }
            string[] BccEmails = BccEmail.Replace(" ", "").Split(';');
            foreach (string email in BccEmails)
            {
                if (!String.IsNullOrEmpty(email))
                {
                    message.Bcc.Add(new MailAddress(email));
                }
            }
            message.Subject = Subject;
            message.Body = BodyEmail;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SenderEmail, SenderPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(message);
            client.Dispose();
            //            var client = new RestSharp.RestClient("http://api.crm.imm.group/imm/api");
            //            var request = new RestSharp.RestRequest("sendmail-web", Method.POST);
            //            var sendData = new
            //            {
            //                MailHeader = MailHeader,
            //                SenderEmail = SenderEmail,
            //                SenderPassword = SenderPassword,
            //                ToEmail = ToEmail,
            //                CcEmail = CcEmail,
            //                BccEmail = BccEmail,
            //                Subject = Subject,
            //                BodyEmail = BodyEmail
            //            };
            //            request.AddJsonBody(sendData);
            //#pragma warning disable CS0618 // Type or member is obsolete
            //            var asyncHandle = client.ExecuteAsync(request, response =>
            //            {
            //                Console.WriteLine(response.Content);
            //            });
            //#pragma warning restore CS0618 // Type or member is obsolete
        }
        public void SendMessageStandard(string MailHeader, string SenderEmail, string SenderPassword, string ToEmail, string CcEmail, string BccEmail, string Subject, string BodyEmail, string Attach)
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(SenderEmail, MailHeader);
            string[] Tomails = ToEmail.Replace(" ", "").Split(';');
            foreach (string email in Tomails)
            {
                if (!String.IsNullOrEmpty(email))
                {
                    message.To.Add(new MailAddress(email));
                }
            }
            string[] CcEmails = CcEmail.Replace(" ", "").Split(';');
            foreach (string email in CcEmails)
            {
                if (!String.IsNullOrEmpty(email))
                {
                    message.CC.Add(new MailAddress(email));
                }
            }
            string[] BccEmails = BccEmail.Replace(" ", "").Split(';');
            foreach (string email in BccEmails)
            {
                if (!String.IsNullOrEmpty(email))
                {
                    message.Bcc.Add(new MailAddress(email));
                }
            }
            message.Subject = Subject;
            message.Body = BodyEmail;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            message.IsBodyHtml = true;
            if (!String.IsNullOrEmpty(Attach))
            {
                //Attachment att = new Attachment(attach);
                string[] Attmails = Attach.Split(';');
                foreach (string attid in Attmails)
                {
                    if (!String.IsNullOrEmpty(attid))
                    {
                        message.Attachments.Add(new Attachment(attid));
                    }
                }
            }
            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential(SenderEmail, SenderPassword);
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.Send(message);
            client.Dispose();
        }
       
    public void ActivityLog(string _modeHandle, int _tohandleId, int _fromhandleId, string _act)
        {
            //
            string _sql = "INSERT INTO M_ACTIVITY(STAFF_ID, CUS_ID, ACT_NOTE, INSERT_DATE, ACT_MODE) VALUES("+ _fromhandleId + ","+ _tohandleId + ", N'"+ _act +"', GETDATE(),'"+ _modeHandle + "')";
            DBHelper.ExecuteQuery(_sql);
        }
    
    }

    public class CaseMode
    {
        public const string SHC = "Staff-handle-Cus";
        public const string SHS = "Staff-handle-Staff";
        public const string SYSTS = "System-to-Staffs";
        public const string CTS = "Customer-to-Staff";
    }
    public class Message
    {
        public JsonResult Show(string _MessCode)
        {
            string Query = "SELECT * FROM M_MESSAGE WHERE MES_PRI_KEY = 'VN' AND MES_SEC_KEY = '" + _MessCode + "'";
            JsonResult response = new JsonResult();

            using (SqlConnection connection = new SqlConnection(DBHelper.connectionString))
            {
                connection.Open();
                try
                {
                    using (DBHelper.cmd = new SqlCommand(Query, connection))
                    {
                        DBHelper.cmd.ExecuteNonQuery();
                        SqlDataReader Reader = DBHelper.cmd.ExecuteReader();
                        DataTable dt = new DataTable();
                        dt.Load(Reader);
                        foreach (DataRow row in dt.Rows)
                        {
                            response.Data = new
                            {
                                mess = row[4],
                                type = row[2],
                                header = row[3],
                                pos = row[5]
                            };
                        }
                        Reader.Close();
                    }
                }
                catch
                {
                    connection.Close();
                }
                finally
                {
                    connection.Close();
                }
            }
            return response;
        }

        public JsonResult Success(string message)
        {            
            return Show(message, Library.Message.Type.SUCCESS, "Thông báo", Library.Message.Position.TOP_C);
            
        }
        public JsonResult Info(string message)
        {
            return Show(message, Library.Message.Type.INFO, "Thông báo", Library.Message.Position.TOP_C);

        }
        public JsonResult Error(string message)
        {           
            return Show(message, Library.Message.Type.ERROR, "Something Wrong!", Library.Message.Position.TOP_C);
        }
        public JsonResult Warning(string message)
        {
            return Show(message, Library.Message.Type.WARNING, "Thông báo", Library.Message.Position.TOP_C);
        }

        public JsonResult Success()
        {
            return Show(Library.Message.Content.MES005, Library.Message.Type.SUCCESS, "Thông báo", Library.Message.Position.TOP_C);

        }
        public JsonResult Error()
        {
            return Show(Library.Message.Content.MES006, Library.Message.Type.ERROR, "Something Wrong!", Library.Message.Position.TOP_C);
        }
        public JsonResult Show(string _Mess, string _Type, string _Header, string _Position)
        {
            JsonResult response = new JsonResult();
            response.Data = new
            {
                mess = _Mess,
                type = _Type,
                header = _Header,
                pos = _Position
            };
            return response;
        }
        public class Type
        {
            public const string ERROR = "error";
            public const string SUCCESS = "success";
            public const string WARNING = "warning";
            public const string INFO = "info";
        }
        public class Language
        {
            public const string VN = "VN";
            public const string ENG = "ENG";
        }
        public class Position
        {
            public const string TOP_R = "toast-top-right";
            public const string TOP_L = "toast-top-left";
            public const string BOT_R = "toast-bottom-right";
            public const string BOT_L = "toast-bottom-left";
            public const string TOP_F = "toast-top-full-width";
            public const string BOT_F = "toast-bottom-full-width";
            public const string TOP_C = "toast-top-center";
        }
        public class Content
        {
            public const string MES000 = "Bạn chưa được cấp quyền để sử dụng chức năng này";
            public const string MES001 = "Thông tin nhập vào không được để trống";
            public const string MES002 = "Bạn không có mặt tại văn phòng, không thể đăng nhập vào hệ thống.";
            public const string MES003 = "Thông tin tài khoản không đúng. Vui lòng kiểm tra email và mật khẩu.";
            public const string MES004 = "Nội dung nhập vào không được để trống.";
            public const string MES005 = "Thao tác hoàn tất";
            public const string MES006 = "Thao tác thất bại";
            public const string MES007 = "Đã có lỗi xảy ra trong quá trình xử lý. Đội ngũ chúng tôi đang cố gắng khắc phục vấn đề này.";
            public const string MES008 = "Vui lòng nhập mã xác minh được gửi qua email của bạn để đăng nhập vào hệ thống.";
            public const string MES009 = "Phiên đăng nhập của bạn đã hết hạn. Vui lòng đăng nhập lại";
            public const string MES010 = "Bạn chưa được cấp quyền sử dụng chức năng này.";
            public const string MES011 = "Nội dung nhập vào không đúng định dạng";
            public const string MES012 = "Nội dung nhập vào đã tồn tại";
        }
    }
    public class CateAlert
    {
        public const string C001 = "vừa cập nhật thông tin hồ sơ khách";
        public const string C002 = "vừa cập nhật thông tin người phụ thuộc của khách";
        public const string C003 = "vừa thêm một ghi chú nội bộ";
        public const string C004 = "vừa có trao đổi mới với khách hàng";
        public const string C005 = "vừa có trao đổi mới với luật sư hoặc đối tác";
        public const string C006 = "vừa có phản hồi mới";
        public const string C007 = "Luật sư hoặc đối tác có phản hồi mới";
    }
    public class DBHelper
    {
        public static SqlCommand cmd = new SqlCommand();
        public static SqlDataAdapter sda;
        public static SqlDataReader sdr;
        public static DataSet ds = new DataSet();
        public static SqlConnection con = new SqlConnection("Data Source=103.252.252.254;Initial Catalog=ImmiCRM;Persist Security Info=True;User ID=sa;Password=Mekongdelta@2018");
        public static DataTable dt = new DataTable();
        public static readonly string connectionString = "Data Source=103.252.252.254;Initial Catalog=ImmiCRM;Persist Security Info=True;User ID=sa;Password=Mekongdelta@2018";

        public static bool IsExist(string Query)
        {
            bool check = false;
            using (cmd = new SqlCommand(Query, con))
            {
                con.Open();
                sdr = cmd.ExecuteReader();
                if (sdr.HasRows)
                    check = true;
            }
            sdr.Close();
            con.Close();
            return check;

        }

        public static bool ExecuteQuery(string Query)
        {
            bool flg = false;
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    using (cmd = new SqlCommand(Query, connection))
                    {
                        cmd.ExecuteNonQuery();
                        flg = true;
                    }
                }
                catch
                {
                    return false;
                }
                finally
                {
                    connection.Close();
                }
            }
            return flg;
        }

        public static string GetColumnVal(string Query, string ColumnName)
        {
            string RetVal = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                try
                {
                    using (cmd = new SqlCommand(Query, connection))
                    {
                        sdr = cmd.ExecuteReader();
                        while (sdr.Read())
                        {
                            RetVal = sdr[ColumnName].ToString();
                            break;
                        }
                    }
                }
                catch
                {
                }
                finally
                {
                    connection.Close();
                }
            }
            return RetVal;
        }

        public static string GetColumnVal(string Query, string ColumnName, System.Data.CommandType Type)
        {
            string RetVal = "";
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.CommandType = Type;
            con.Open();

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                RetVal = sdr[ColumnName].ToString();
                break;
            }

            sdr.Close();
            con.Close();
            return RetVal;
        }

        public static string GetColumnVal(string Query, string ColumnName, Dictionary<string, string> Para, System.Data.CommandType Type)
        {
            string RetVal = "";
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.CommandType = Type;
            foreach (KeyValuePair<string, string> kvp in Para)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            con.Open();

            sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                RetVal = sdr[ColumnName].ToString();
                break;
            }
            cmd.Parameters.Clear();
            sdr.Close();
            con.Close();
            return RetVal;
        }


        public static DataTable DB_ToDataTable(string Query)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = Query;
            cmd.Connection = con;
            con.Open();
            dt.Load(sdr = cmd.ExecuteReader());
            sdr.Close();
            con.Close();
            return dt;
        }

        public static DataTable DB_ToDataTable(string Query, System.Data.CommandType Type)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.CommandType = Type;
            con.Open();
            dt.Load(sdr = cmd.ExecuteReader());
            sdr.Close();
            con.Close();
            return dt;
        }

        public static DataTable DB_ToDataTable(string Query, Dictionary<string, string> Para, System.Data.CommandType Type)
        {
            DataTable dt = new DataTable();
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.CommandType = Type;
            foreach (KeyValuePair<string, string> kvp in Para)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }
            con.Open();
            dt.Load(sdr = cmd.ExecuteReader());
            cmd.Parameters.Clear();
            sdr.Close();
            con.Close();
            return dt;
        }

        public static List<dynamic> DB_ToDynamicList(string Query, System.Data.CommandType Type)
        {
            var dynamicDt = new List<dynamic>();
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.CommandType = Type;
            con.Open();

            SqlDataReader sqlReader = cmd.ExecuteReader();
            //DataTable schemaTable = sqlReader.GetSchemaTable();
            DataTable dt = new DataTable();
            dt.Load(sqlReader);
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    //dic[column.ColumnName] = row[column];
                }
            }

            con.Close();
            return dynamicDt;
        }

        public static List<dynamic> DB_ToDynamicList(string Query, Dictionary<string, string> Para, System.Data.CommandType Type)
        {
            var dynamicDt = new List<dynamic>();
            cmd.CommandText = Query;
            cmd.Connection = con;
            cmd.CommandType = Type;

            foreach (KeyValuePair<string, string> kvp in Para)
            {
                cmd.Parameters.AddWithValue(kvp.Key, kvp.Value);
            }

            con.Open();

            SqlDataReader sqlReader = cmd.ExecuteReader();
            //DataTable schemaTable = sqlReader.GetSchemaTable();
            DataTable dt = new DataTable();
            dt.Load(sqlReader);
            foreach (DataRow row in dt.Rows)
            {
                dynamic dyn = new ExpandoObject();
                dynamicDt.Add(dyn);
                foreach (DataColumn column in dt.Columns)
                {
                    var dic = (IDictionary<string, object>)dyn;
                    dic[column.ColumnName] = row[column];
                }
            }
            cmd.Parameters.Clear();
            sdr.Close();
            con.Close();
            return dynamicDt;
        }
    }
    public class Res
    {
        public JsonResult Val(string _Value)
        {
            JsonResult response = new JsonResult();
            response.Data = new { val = _Value };
            return response;
        }
    }
    public class RegexUtilities
    {
        bool invalid = false;

        public bool IsValidEmail(string strIn)
        {
            invalid = false;
            if (String.IsNullOrEmpty(strIn))
                return false;

            // Use IdnMapping class to convert Unicode domain names.
            try
            {
                strIn = Regex.Replace(strIn, @"(@)(.+)$", this.DomainMapper,
                                      RegexOptions.None);
            }
            catch (Exception)
            {
                return false;
            }

            if (invalid)
                return false;

            // Return true if strIn is in valid e-mail format.
            try
            {
                return Regex.IsMatch(strIn,
                        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                        RegexOptions.IgnoreCase);
            }
            catch (Exception)
            {
                return false;
            }
        }

        private string DomainMapper(Match match)
        {
            // IdnMapping class with default property values.
            IdnMapping idn = new IdnMapping();

            string domainName = match.Groups[2].Value;
            try
            {
                domainName = idn.GetAscii(domainName);
            }
            catch (ArgumentException)
            {
                invalid = true;
            }
            return match.Groups[1].Value + domainName;
        }
    }

    public class EmailTemplate
    {
        public string ReplyWhenCusSubmitWebForm(string formname,
         string Cus_Name,
         string Cus_Sex,
         string Content,
         string Head_content
         )
        {
            string body = string.Empty;
            DateTime mmday = DateTime.Now;
            string format = "hh:mm:ss tt dd-MM-yyyy";
            string mday = mmday.ToString(format);
            string path = "~/Extensions/EmailTemplate/WebFormReply" + formname+".htm";

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(path)))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{SEX_L}", Cus_Sex);
            body = body.Replace("{NAME}", Cus_Name);
            body = body.Replace("{CONTENT}", Content);
            body = body.Replace("{HEAD_CONTENT}", Head_content);
            return body;
        }

        public string SentImmCode(string app_pass)
        {
            string body = string.Empty;
            DateTime mmday = DateTime.Now;
            string format = "hh:mm:ss tt dd-MM-yyyy";
            string mday = mmday.ToString(format);
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Extensions/EmailTemplate/VerifyLoginCode.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{IMMCODE}", app_pass);
            return body;
        }

        public string SystemToUser(Dictionary<string, string> _para, string _template)
        {
            string body = string.Empty;
            DateTime mmday = DateTime.Now;
            string format = "hh:mm:ss tt dd-MM-yyyy";
            string mday = mmday.ToString(format);
            if (_template == "")
            {
                _template = "FromSystem.htm";
            }
            string _template_path = "~/Extensions/EmailTemplate/" + _template + ".htm";

            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath(_template_path)))
            {
                body = reader.ReadToEnd();
            }
            foreach (KeyValuePair<string, string> kvp in _para)
            {
                body = body.Replace(kvp.Key, kvp.Value);
            }
            return body;
        }

        public string SentInforToCus(string CusName, string CusEmail, string CusSex, string CusSexUp, string CusPhone, string StaffSign)
        {
            string body = string.Empty;
            DateTime mmday = DateTime.Now;
            string format = "hh:mm:ss tt dd-MM-yyyy";
            string mday = mmday.ToString(format);
            using (StreamReader reader = new StreamReader(System.Web.HttpContext.Current.Server.MapPath("~/Extensions/EmailTemplate/sentinforcus.htm")))
            {
                body = reader.ReadToEnd();
            }
            body = body.Replace("{CusSex}", CusSex);
            body = body.Replace("{CusSexUp}", CusSexUp);
            body = body.Replace("{UserName}", CusName);
            body = body.Replace("{Time}", mday);
            body = body.Replace("{CusEmail}", CusEmail);
            body = body.Replace("{CusPhone}", CusPhone);
            body = body.Replace("{Signature}", StaffSign);
            return body;
        }
    }
}
