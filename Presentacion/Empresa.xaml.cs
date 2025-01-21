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
    /// Lógica de interacción para Empresa.xaml
    /// </summary>
    public partial class Empresa : Window
    {
        nEmpresa gp = new nEmpresa();
        eEmpresa EmpresaSeleccionada = null;
        int CodigoEmpresa;
        public Empresa()
        {
            InitializeComponent();
            MostrarEmpresas();
        }

        private void MostrarEmpresas()
        {
            dgEmpresa.ItemsSource = gp.ListarEmpresa();
        }

        private void btn_Agregar_Click(object sender, RoutedEventArgs e)
        {
            if (txtNombre.Text != "")
            {
                MessageBox.Show(gp.RegistrarEmpresa(txtNombre.Text));
                MostrarEmpresas();
            }
            else
            {
                MessageBox.Show("Debe ingresar un nombre de empresa");
            }

        }

        private void btn_Modificar_Click(object sender, RoutedEventArgs e)
        {
            if (EmpresaSeleccionada != null)
            {
                MessageBox.Show(gp.ModificarEmpresa(CodigoEmpresa, txtNombre.Text));
                MostrarEmpresas();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una empresa de la lista");
            }
        }

        private void btn_Eliminar_Click(object sender, RoutedEventArgs e)
        {
            if (EmpresaSeleccionada != null)
            {
                MessageBox.Show(gp.EliminarEmpres(CodigoEmpresa));
                MostrarEmpresas();
            }
            else
            {
                MessageBox.Show("Debe seleccionar una empresa");
            }
        }

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            EmpresaSeleccionada = dgEmpresa.SelectedItem as eEmpresa;
            if (EmpresaSeleccionada != null)
            {
                CodigoEmpresa = EmpresaSeleccionada.idEmpresa;
                txtNombre.Text = EmpresaSeleccionada.NombreEmpresa;
            }
        }
    }
}
