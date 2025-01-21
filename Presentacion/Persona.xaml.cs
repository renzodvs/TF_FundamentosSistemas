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
    /// Interaction logic for Persona.xaml
    /// </summary>
    public partial class Persona : Window
    {
        private nPersona onPersona = new nPersona();
        private nTrabajo onTrabajo = new nTrabajo();
        private nCV onCV = new nCV();
        private ePersona PersonaSelecionada;
        private ePersona PersonaModificar;
        private eCV CvSelecionada;
        private eCV CvModificar;
        public Persona()
        {
            InitializeComponent();
            listbTrabajos.ItemsSource = onTrabajo.ListarTrabajo();
            MostrarPersonaCV();
        }

        private void btnRegistrar_Click(object sender, RoutedEventArgs e)
        {
            if (txtAñosDeExperiencia.Text != "" && txtbDireccion.Text != "" && txtbEdad.Text != "" && txtbNombre.Text != "" && txtbNumeroTrabajosAnteriores.Text != "" && txtbOficio.Text != "" && txtbTrabajo.Text != "")
            {
                int AñosDeExperiencia = Convert.ToInt32(txtAñosDeExperiencia.Text);
                string Direccion = txtbDireccion.Text;
                int Edad = Convert.ToInt32(txtbEdad.Text);
                string Nombre = txtbNombre.Text;
                int NumeroTrabajosAteriores = Convert.ToInt32(txtbNumeroTrabajosAnteriores.Text);
                string Oficio = txtbOficio.Text;
                int IDTrabajo = Convert.ToInt32(txtbTrabajo.Text);
                MessageBox.Show(onCV.Registrar(Oficio, AñosDeExperiencia, NumeroTrabajosAteriores, Nombre) + ", Curriculum Viate\n" + onPersona.Registrar(Nombre, Edad, Direccion, IDTrabajo) + ", Persona");
                MostrarPersonaCV();
                LimpiarCajasDeTexto();
            }
            else
                MessageBox.Show("Ingrese datos");

        }
        private void MostrarPersonaCV()
        {
            dgPersona.ItemsSource = onPersona.ListarPersona();
            dgCV.ItemsSource = onCV.ListarCV();
        }
        private void txtbTrabajo_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            if (PersonaSelecionada != null)
            {
                MessageBox.Show(onPersona.Eliminar(PersonaSelecionada.IDPersona) + onCV.Eliminar(PersonaSelecionada.Nombre));
                MostrarPersonaCV();
                LimpiarCajasDeTexto();
            }
            else
                MessageBox.Show("Selecione una persona !");
        }

        private void dgPersona_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            PersonaSelecionada = dgPersona.SelectedItem as ePersona;
            if (PersonaSelecionada != null)
            {
                PersonaModificar = PersonaSelecionada;
                txtbNombre.Text = PersonaModificar.Nombre;
                txtbEdad.Text = PersonaModificar.Edad.ToString();
                txtbDireccion.Text = PersonaModificar.Direccion;
                txtbTrabajo.Text = PersonaModificar.IDtrabajo.ToString();
            }
            else
                PersonaModificar = null;
        }

        private void dgCV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CvSelecionada = dgCV.SelectedItem as eCV;
            if (CvSelecionada != null)
            {
                CvModificar = CvSelecionada;
                txtbOficio.Text = CvModificar.Oficio;
                txtAñosDeExperiencia.Text = CvModificar.AñosDeExperiencia.ToString();
                txtbNumeroTrabajosAnteriores.Text = CvModificar.NumeroTrabajosAnteriores.ToString();
                txtbNombre.Text = CvModificar.Nombre;
            }
            else
                CvModificar = null;
        }

        private void btnModifica_Click(object sender, RoutedEventArgs e)
        {
            if (PersonaModificar != null)
            {
                ePersona PersonaModificar2 = new ePersona()
                {
                    Nombre = txtbNombre.Text,Edad = Convert.ToInt32(txtbEdad.Text),Direccion = txtbDireccion.Text,IDtrabajo = Convert.ToInt32(txtbTrabajo.Text), IDPersona = PersonaModificar.IDPersona
                };
                MessageBox.Show(onCV.ModificarNombre(PersonaModificar2) + onPersona.Modificar(PersonaModificar2));
                MostrarPersonaCV();
                LimpiarCajasDeTexto();
            }
            else
                MessageBox.Show("Selecione una persona !");
        }
        private void LimpiarCajasDeTexto()
        {
            txtAñosDeExperiencia.Text = "";
            txtbDireccion.Text = "";
            txtbEdad.Text = "";
            txtbNombre.Text = "";
            txtbNumeroTrabajosAnteriores.Text = "";
            txtbOficio.Text = "";
            txtbTrabajo.Text = "";
        }

        private void btnModificarCv_Click(object sender, RoutedEventArgs e)
        {
            if (CvModificar != null)
            {
                if (txtbNombre.Text == CvModificar.Nombre)
                {
                    eCV CvModificar2 = new eCV()
                    {
                        Oficio = txtbOficio.Text,
                        AñosDeExperiencia = Convert.ToInt32(txtAñosDeExperiencia.Text),
                        NumeroTrabajosAnteriores = Convert.ToInt32(txtbNumeroTrabajosAnteriores.Text),
                        Nombre = CvModificar.Nombre
                    };
                    MessageBox.Show(onCV.Modificar(CvModificar2));
                    MostrarPersonaCV();
                    LimpiarCajasDeTexto();
                }
                else
                    MessageBox.Show("El Nombre no existe. Solo se podrá modificar el nombre en la opción Personas/Modificar");
            }
            else
                MessageBox.Show("Selecione un Cv. El nombre solo se podrá modificar en Personas/Modificar");
        }
    }
}
