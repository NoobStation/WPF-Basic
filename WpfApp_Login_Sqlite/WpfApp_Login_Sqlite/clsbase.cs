using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Windows;

namespace WpfApp_Login_Sqlite
{
    public class clsbase
    {
        //nombre nuestra base
        public static string nombredb = "Login.sqlite";

        //conexiones
        public static SQLiteConnection conn = new SQLiteConnection(new SQLiteConnection(string.Format("Data SOurce={0};Version=3", nombredb)));

        public static SQLiteCommand comm;

        public static SQLiteDataReader dr;


        public static void OpenConnexion()
        {
            try
            {
                conn.Open();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public static void CloseConnexion()
        {
            try
            {
                conn.Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        public string Login(string usuario, string contraseña)
        {
            string res = "0";

            try
            {
                OpenConnexion();

                comm = conn.CreateCommand();

                comm.CommandText = "Select 1 as resultado  from Credenciales where 1=1 and Usuario='" + usuario + "' and Contraseña='" + contraseña + "'";

                dr = comm.ExecuteReader();

                while (dr.Read())
                {
                    res = dr["resultado"].ToString();
                }
            }
            catch (Exception ex)
            {
                res = "0";

                MessageBox.Show(ex.ToString());
            }
            finally
            {
                CloseConnexion();
            }

            return res;
        }

    }
}
