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
    /// Lógica de interacción para Postulantes.xaml
    /// </summary>
    public partial class Postulantes : Window
    {
        private nPersona onPersona = new nPersona();
        private ePersona oePersonaSeleccionada = null;

        public Postulantes()
        {
            InitializeComponent();
            MostrarPostulantes();
        }

        private void MostrarPostulantes()
        {
            dgPostulantes.ItemsSource = onPersona.ListarPersona();
        }
        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)//ACEPTAR POSTULANTE
        {
            if (oePersonaSeleccionada != null)
            {
                MessageBox.Show(onPersona.AceptarPostulante(oePersonaSeleccionada.IDPersona));
                MostrarPostulantes();
            }
            else
                MessageBox.Show("Selecione una persona de la lista");
        }

        private void btn_Rechazar_Click(object sender, RoutedEventArgs e)//RECHAZAR POSTULANTE
        {
            if (oePersonaSeleccionada != null)
            {
                MessageBox.Show(onPersona.RechazarPostulante(oePersonaSeleccionada.IDPersona));
                MostrarPostulantes();
            }
            else
                MessageBox.Show("Selecione una persona de la lista");
        }

        private void dgPostulantes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            oePersonaSeleccionada = dgPostulantes.SelectedItem as ePersona;
        }
    }
}
