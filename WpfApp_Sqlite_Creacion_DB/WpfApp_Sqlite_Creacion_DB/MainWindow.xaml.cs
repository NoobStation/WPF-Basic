using System.Windows;

namespace WpfApp_Sqlite_Creacion_DB
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_Crear_DB_Click(object sender, RoutedEventArgs e)
        {
            //todo estara separado con el fin de comprender los codigos
            
            //creamos la base
            clsCrearBase.CrearBase();

            //creamos nuestra tabla de prueba, recuerda validar la creacion de la tabla
            clsCrearBase.CrearTablaPrueba();

            //agregamos datos para algunas pruebas
            clsCrearBase.AddDatos();
        }
    }
}
