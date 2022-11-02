using System;
using System.Collections.Generic;
using System.Data;
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
using Controlador;

namespace Vista
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Ingresar_button_Click(object sender, RoutedEventArgs e)
        {
            string email = "desktop@gmail.com"; //email_txt.Text;
            string psw = "123"; //pass_txt.Password.ToString();
            DataTable dt = CUsuario.Autentificar(email, psw);
            if (dt.Rows.Count != 0)
            {
                if (dt.Rows[0][1].Equals("Administrador"))
                {
                    MenuAdmin menuAdmin = new(dt);
                    menuAdmin.Show();
                    this.Close();
                }
                else if(dt.Rows[0][1].Equals("Funcionario"))
                {
                    MessageBox.Show("Bienvenid@ Funcionari@ "+ dt.Rows[0][0].ToString());
                }
            }
            else
            {
                MessageBox.Show("Email o contraseña no válidos");
            }
        }
    }
}
