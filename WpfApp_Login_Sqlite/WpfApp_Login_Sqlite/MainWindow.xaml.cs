using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;

namespace WpfApp_Login_Sqlite
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        clsdatos datos = new clsdatos();

        clsbase reslogin = new clsbase();

        public MainWindow()
        {
            InitializeComponent();

            /*si no tienes la base creada descomenta esta parte
            clsCrearBase.CrearBase();

            clsCrearBase.CrearTablaCredenciales();

            clsCrearBase.AddDatos();*/
        }

        private void btn_iniciar_sesion_Click(object sender, RoutedEventArgs e)
        {
            string res = "0";

            res = reslogin.Login(txt_usuario.Text, txt_contraseña.Password);

            if (res == "1")
            {
                MessageBox.Show("Bienvenido");
            }
            else if (res == "0")
            {
                MessageBox.Show("Credenciales Erroneas Favor de Revisar");
            }

        }
    }
}
