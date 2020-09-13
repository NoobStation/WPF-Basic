using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp_Login_Sqlite
{
    public class clsCrearBase
    {
        //nombre nuestra base
        public static string nombredb = "Login.sqlite";
        //ruta
        public static string ruta = string.Empty;

        public static void CrearBase()
        {
            if (!File.Exists(Path.GetFullPath(nombredb)))
            {
                SQLiteConnection.CreateFile(nombredb);
                MessageBox.Show("Base creada con exito en:" + Path.GetFullPath(nombredb).ToString());
            }
            else
            {
                MessageBox.Show("la base ya existe en:"+Path.GetFullPath(nombredb).ToString());
            }
        }

        public static SQLiteConnection conn = new SQLiteConnection(new SQLiteConnection(string.Format("Data Source={0};Version=3;", nombredb)));
        public static SQLiteCommand comm;

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

        public static void CrearTablaCredenciales()
        {
            try
            {
                OpenConnexion();

                comm = conn.CreateCommand();

                comm.CommandText = "CREATE TABLE Credenciales (ID INTEGER,Usuario varchar(100),Contraseña varchar(100),PRIMARY KEY(ID AUTOINCREMENT));";

                comm.ExecuteNonQuery();

                CloseConnexion();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static void AddDatos()
        {
            try
            {
                OpenConnexion();

                comm = conn.CreateCommand();

                comm.CommandText = "INSERT INTO Credenciales(Usuario,Contraseña) VALUES ('Admin','1234')";

                comm.ExecuteNonQuery();

                CloseConnexion();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }
    }
}
