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

using Entidades;
using Negocio;

namespace Presentacion
{
    /// <summary>
    /// Lógica de interacción para PostulantesAceptados.xaml
    /// </summary>
    public partial class PostulantesAceptados : Window
    {
        private nPersona onPersona = new nPersona();
        public PostulantesAceptados()
        {
            InitializeComponent();
            dgPostulantesAceptados.ItemsSource = onPersona.ListarPostulantesAceptados();
        }
    }
}
