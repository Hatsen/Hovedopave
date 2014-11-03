using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Webservice
{
    public class DatabaseHandler
    {
        SQLDatabase DB = new SQLDatabase("SchoolDB.mdf", "LocalDB", "", "");

        public List<Announcement> GetAnnouncements()
        {
            List<Announcement> announcements = new List<Announcement>();

            try
            {
                DB.Open();

                string[][] getAnc = DB.Query("SELECT * FROM announcements");

                for (int i = 0; i < getAnc.Length; i++)
                {
                    Announcement anc = new Announcement();

                    anc.ID = Convert.ToInt32(getAnc[i][0]);
                    anc.Message = getAnc[i][1];
                    //anc.ancGroup = Convert.ToInt32(getAnc[i][2]);

                    Holder.Instance.Announcements.Add(anc);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                DB.Close();
            }
            return announcements;
        }

        public string[][] GetTeacherLogin(string username)
        {
            string[][] loginDetails = null;

            try
            {
                DB.Open();
                loginDetails = DB.Query("SELECT * FROM Teacher WHERE username = '" + username + "'");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
                Holder.Instance.LoginDetails = loginDetails;
            }
            return loginDetails;
        }

        public string[][] GetParentLogin(string username)
        {
            string[][] loginDetails = null;

            try
            {
                DB.Open();
                loginDetails = DB.Query("SELECT * FROM Parent WHERE username = '" + username + "'");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
                Holder.Instance.LoginDetails = loginDetails;
            }
            return loginDetails;
        }

        public string[][] GetStudentLogin(string username)
        {
            string[][] loginDetails = null;

            try
            {
                DB.Open();
                loginDetails = DB.Query("SELECT * FROM Student WHERE username = '" + username + "'");
            }
            catch (Exception ex)
            {
            }
            finally
            {
                DB.Close();
                Holder.Instance.LoginDetails = loginDetails;
            }
            return loginDetails;
        }
    }
}