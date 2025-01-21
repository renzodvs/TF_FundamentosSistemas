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
    /// Interaction logic for Trabajo.xaml
    /// </summary>
    public partial class Trabajo : Window
    {
        private nTrabajo onTrabajo = new nTrabajo();
        private nEmpresa onEmpresa = new nEmpresa();
        private eTrabajo oeTrabajoSelecionado = null;
        private eTrabajo oeTrabajoModificar = null;
        private eEmpresa empresa = null;
        private int IDTrabajo_;
        public Trabajo()
        {
            InitializeComponent();
            MostrarTrabajo();
            MostrarEmpresa();
        }

        private void MostrarEmpresa()
        {
            cbEmpresa.ItemsSource = onEmpresa.ListarEmpresa();
        }

        private void MostrarTrabajo()
        {
            dgTrabajo.ItemsSource = onTrabajo.ListarTrabajo();
        }
        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtbAñosExperiencia.Text != "" && txtbArea.Text != "" && txtbLugarEmpleo.Text != "" && txtbNumeroVacantes.Text != "" && txtbSueldo.Text != "")
            {
                MessageBox.Show(onTrabajo.Registrar(txtbArea.Text, Convert.ToInt32(txtbAñosExperiencia.Text), Convert.ToDecimal(txtbSueldo.Text), txtbLugarEmpleo.Text, Convert.ToInt32(txtbNumeroVacantes.Text), empresa.idEmpresa));
                MostrarTrabajo();
                LimpiarCajasDeTexto();
            }
            else
                MessageBox.Show("Ingrese datos");
        }


        private void btnRemover_Click(object sender, RoutedEventArgs e)
        {
            if (oeTrabajoSelecionado != null)
            {
                MessageBox.Show(onTrabajo.Remover(IDTrabajo_));
                MostrarTrabajo();
                LimpiarCajasDeTexto();
            }
            else
                MessageBox.Show("Selecione un trabajo de la lista");
        }

        private void dgTrabajo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            oeTrabajoSelecionado = dgTrabajo.SelectedItem as eTrabajo;
            if (oeTrabajoSelecionado != null)
            {
                oeTrabajoModificar = oeTrabajoSelecionado;
                IDTrabajo_ = oeTrabajoModificar.IDtrabajo;
                txtbArea.Text = oeTrabajoModificar.Area;
                txtbAñosExperiencia.Text = oeTrabajoModificar.AñosDeExperiencia.ToString();
                txtbLugarEmpleo.Text = oeTrabajoModificar.LugarDeEmpleo;
                txtbNumeroVacantes.Text = oeTrabajoModificar.NumeroDeVacantes.ToString();
                txtbSueldo.Text = System.Math.Round(oeTrabajoModificar.Sueldo).ToString();
                cbEmpresa.Text = oeTrabajoModificar.Empresa.NombreEmpresa;
            }
            else
                oeTrabajoModificar = null;
        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (oeTrabajoModificar != null)
            {
                eTrabajo oeTrabajoModificar2 = new eTrabajo()
                {
                    
                    Sueldo = Convert.ToDecimal(txtbSueldo.Text),
                    
                };
                MessageBox.Show(onTrabajo.Modificar(txtbArea.Text,
                    int.Parse(txtbAñosExperiencia.Text),
                    oeTrabajoModificar.IDtrabajo,
                    txtbLugarEmpleo.Text,
                    int.Parse(txtbNumeroVacantes.Text), empresa.idEmpresa));
                MostrarTrabajo();
                LimpiarCajasDeTexto();
            }
            else
                MessageBox.Show("Selecione un trabajo que desee modificar y luego cambie los datos");
        }
        private void LimpiarCajasDeTexto()
        {
            txtbAñosExperiencia.Text = "";
            txtbArea.Text = "";
            txtbLugarEmpleo.Text = "";
            txtbNumeroVacantes.Text = "";
            txtbSueldo.Text = "";
            cbEmpresa.Text = "";
        }

        private void cbEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            empresa = cbEmpresa.SelectedItem as eEmpresa;
        }

        private void btn_Postulantes_Click(object sender, RoutedEventArgs e)
        {
            Postulantes frm = new Postulantes(); frm.Show();
        }
    }
}
