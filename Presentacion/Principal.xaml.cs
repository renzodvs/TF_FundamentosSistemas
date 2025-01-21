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
using System.Windows.Shapes;

namespace Presentacion
{
    /// <summary>
    /// Interaction logic for Principal.xaml
    /// </summary>
    public partial class Principal : Window
    {
        public Principal()
        {
            InitializeComponent();
        }

        private void btnTrabajo_Click(object sender, RoutedEventArgs e)
        {
            Trabajo frm = new Trabajo(); frm.Show();
        }
        private void btnPersona_Click(object sender, RoutedEventArgs e)
        {
            Persona frm = new Persona(); frm.Show();
        }

        private void btn_Empresa_Click(object sender, RoutedEventArgs e)
        {
            Empresa frm = new Empresa(); frm.Show();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            PostulantesAceptados frm = new PostulantesAceptados(); frm.Show();
        }
    }
}
