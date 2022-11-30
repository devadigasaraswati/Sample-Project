using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Image = System.Drawing.Image;

namespace Sample.Library
{
    public class Functions
    {
        #region WriteToLogFile
        public static void WriteToLogFile(string strMessage, string strFileName)
        {
            try
            {
                String strFilePath = HttpContext.Current.Server.MapPath("~/Log/");
                if (!File.Exists(strFilePath + "\\" + strFileName + ".txt"))
                {
                    FileStream fs = File.Create(strFilePath + "\\" + strFileName + ".txt");
                    fs.Close();
                }
                WriteToFile(strMessage, strFileName);
            }
            catch
            {
                //do nothing
            }
        }

        private static void WriteToFile(string strMessage, string strFileName)
        {
            String strFilePath = HttpContext.Current.Server.MapPath("~/Log/");

            string strContent = File.ReadAllText(strFilePath + "\\" + strFileName + ".txt");
            strContent += Environment.NewLine;
            strContent += "-------------------------------------------------------------------------------------------\r\n";
            strContent += "" + DateTime.Now + "\r\n";
            strContent += "" + strMessage + "\r\n";
            strContent += "--------------------------------------------------------------------------------------------\r\n";
            strContent += Environment.NewLine;
            File.WriteAllText(strFilePath + "\\" + strFileName + ".txt", strContent);
        }
        #endregion


        #region ReadConfigValue
        public static string ReadConfigValue(string KeyName)
        {
            return Convert.ToString(ConfigurationManager.AppSettings[KeyName]);
        }
        #endregion
    }
}
