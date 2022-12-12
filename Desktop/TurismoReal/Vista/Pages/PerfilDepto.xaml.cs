using Controlador;
using Microsoft.Win32;
using Modelo;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Vista.Pages
{
    public partial class PerfilDepto : Page
    {

        private Departamento? departamento;
        public PerfilDepto(Departamento depto)
        {
            InitializeComponent();
            departamento = depto;
            ListarObjetos();
            ListarImg();
            lblNombreDpto.Content = "Departamento " + departamento.Direccion;
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        private void MensajeError(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Inventario", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        private void MensajeOk(string Mensaje)
        {
            MessageBox.Show(Mensaje, "Inventario", MessageBoxButton.OK, MessageBoxImage.Information);
        }
        private void ListarObjetos()
        {
            try
            {
                DataTable dataTable = CInventario.ListarInventario(departamento.IdDepto);
                if (dataTable != null)
                {
                    var Objetos = (from rw in dataTable.AsEnumerable()
                                 select new Objeto()
                                 {
                                     IdObjeto = Convert.ToInt32(rw[0]),
                                     NombreObjeto = rw[2].ToString(),
                                     CantidadObjeto = Convert.ToInt32(rw[3]),
                                     ValorUnitarioObjeto = Convert.ToInt32(rw[4])
                                 }).ToList();
                    dtgInventario.ItemsSource = Objetos;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnAbrirAgregarObj_Click(object sender, RoutedEventArgs e)
        {
            dhObjetoAg.IsOpen = true;
        }
        private void btn_Cancelar_Ag_Click(object sender, RoutedEventArgs e)
        {
            dhObjetoAg.IsOpen = false;
        }
        private void btn_Agregar_Objeto_Click(object sender, RoutedEventArgs e)
        {
            if (!txt_objeto_ag.Text.Trim().Equals(""))                
            {                
                if (!txt_cantidad_ag.Text.Trim().Equals(""))
                {
                    int.TryParse(txt_cantidad_ag.Text, out int cantidad);
                    if (!txt_precio_unitario.Text.Trim().Equals(""))
                    {
                        int.TryParse(txt_precio_unitario.Text, out int valor);
                        Objeto objeto = new()
                        {
                            NombreObjeto = txt_objeto_ag.Text,
                            CantidadObjeto = cantidad,
                            ValorUnitarioObjeto = valor
                        };
                        int estado = CInventario.CrearInventario(objeto, departamento.IdDepto);
                        MensajeOk("Objeto agregado al inventario");
                        ListarObjetos();
                        Limpiar();
                    }
                    else
                    {
                        MensajeError("El precio unitario es requerido");
                    }
                }
                else
                {
                    MensajeError("La cantidad es requerida");
                }
            }
            else
            {
                MensajeError("El nombre es requerido");
            }
            
        }
        private void Limpiar()
        {
            txt_objeto_ag.Clear();
            txt_cantidad_ag.Clear();
            txt_precio_unitario.Clear();
        }
        private void BtnEliminarObj_Click(object sender, RoutedEventArgs e)
        {
            Objeto objeto = (Objeto)dtgInventario.SelectedItem;
            try
            {
                int estado = CInventario.EliminarObjeto(objeto.IdObjeto);
                MensajeOk("Objeto eliminado del inventario");
                ListarObjetos();
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void btnAgregarImagen_Click(object sender, RoutedEventArgs e)
        {
            dhFotos.IsOpen = true;
        }
        private void btnSubirFoto_Click(object sender, RoutedEventArgs e)
        {   
            OpenFileDialog ofd = new();
            ofd.Filter = "Image names|*.jpg;*.png";
            ofd.Multiselect = false;
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == true)
            {
                txtPathFoto.Text = ofd.FileName;
                imgFoto.Source = new BitmapImage(new Uri(ofd.FileName));
            }
        }
        private void btn_Agregar_Img_Click(object sender, RoutedEventArgs e)
        {
            if (txtPathFoto.Text == string.Empty)
            {
                MensajeError("Debe ingresar una foto"); 
                return;
            }
            if (txtAltFoto.Text == string.Empty)
            {
                MensajeError("Debe ingresar una descripción");
                return;
            }
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("Desktop"));
            path = string.Concat(path, "Turismo_Real_Web\\Fornt_end\\front_end_tr\\src\\imagenes_Dpto\\");

            Fotografia fotografia = new()
            {
                Id_dpto = departamento.IdDepto,
                Alt = txtAltFoto.Text
            };
            Stream st = File.OpenRead(txtPathFoto.Text);
            int r = CFotografia.InsertarImagen(fotografia, st);
            if (r > 0)
            {
                string copiarImg = System.IO.Path.Combine(path, r.ToString() + ".jpg");
                System.IO.File.Copy(txtPathFoto.Text, copiarImg, true);
                dhFotos.IsOpen = false;
                ListarImg();
            }
        }
        private void btn_Cancelar_AgImg_Click(object sender, RoutedEventArgs e)
        {
            dhFotos.IsOpen = false;
        }
        private void ListarImg()
        {
            string path = Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("Desktop"));
            path = string.Concat(path, "Turismo_Real_Web\\Fornt_end\\front_end_tr\\src\\imagenes_Dpto\\");
            try
            {
                DataTable dataTable = CFotografia.ListarImagenes(departamento.IdDepto);
                if (dataTable.Rows.Count > 0)
                {
                    var fotografias = (from rw in dataTable.AsEnumerable()
                                   select new Fotografia()
                                   {
                                       Id_foto = Convert.ToInt32(rw[0]),
                                       Id_dpto = Convert.ToInt32(rw[1]),
                                       Alt = rw[2].ToString()
                                   }).ToList();
                    imgMain.Source = new BitmapImage(new Uri(string.Concat(path, fotografias[0].Id_foto,".jpg")));
                    StkOtrasImg.Children.Clear();
                    try
                    {
                        for (int i = 1; i <= fotografias.Count-1 ; i++)
                        {
                            string pathF = string.Concat(path, fotografias[i].Id_foto, ".jpg");
                            try
                            {
                                StkOtrasImg.UnregisterName("imgDpto" + fotografias[i].Id_foto);

                            }
                            catch (Exception)
                            {
                            }
                            Image image = new()
                            {
                                Source = new BitmapImage(new Uri(pathF)),
                                Name = "imgDpto" + fotografias[i].Id_foto,
                                Height = 100,
                                Width = 100
                            };
                            StkOtrasImg.RegisterName(image.Name, image);
                            StkOtrasImg.Children.Add(image);
                            image.MouseLeftButtonUp += delegate (object sender, MouseButtonEventArgs e) { CambiarImagen(sender, e); };
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        private void CambiarImagen(object sender, MouseButtonEventArgs e)
        {
            Image img = (Image)sender;
            ImageSource mainPath = imgMain.Source;
            imgMain.Source = img.Source;
            int s1 = mainPath.ToString().LastIndexOf("/") + 1;
            int s2 = mainPath.ToString().LastIndexOf(".");
            string idFoto = mainPath.ToString()[s1..s2];
            img.Name = "imgDpto" + idFoto;
            img.Source = mainPath;
        }

        private void txt_objeto_ag_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^a-zA-Zá-úÁ-Ú0-9\"]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void txt_numero_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
        
        Objeto? objetoActualizar;

        private void dtgInventario_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            objetoActualizar = (Objeto)dtgInventario.SelectedItem;
            if (objetoActualizar == null) return;
            dhObjetoAc.IsOpen = true;
            txt_objeto_ac.Text = objetoActualizar.NombreObjeto.ToString();
            txt_cantidad_ac.Text = objetoActualizar.CantidadObjeto.ToString();
            txt_precio_unitario_ac.Text = objetoActualizar.ValorUnitarioObjeto.ToString();
        }

        private void BtnActualizarObjeto_Click(object sender, RoutedEventArgs e)
        {
            objetoActualizar.NombreObjeto = txt_objeto_ac.Text;
            objetoActualizar.CantidadObjeto = int.Parse(txt_cantidad_ac.Text);
            objetoActualizar.ValorUnitarioObjeto = int.Parse(txt_precio_unitario_ac.Text);
            int estado = CInventario.ActualizarInventario(objetoActualizar);
            if (estado > 0)
            {
                MensajeOk("Inventario actualizado");
                LimpiarAc();
                ListarObjetos();
            }
        }

        private void LimpiarAc()
        {
            txt_objeto_ac.Clear();
            txt_cantidad_ac.Clear();
            txt_precio_unitario_ac.Clear();
        }

        private void BtnCancelarAc_Click(object sender, RoutedEventArgs e)
        {
            dhObjetoAc.IsOpen = false;
            txt_objeto_ac.Text = string.Empty;
            txt_cantidad_ac.Text = string.Empty;
            txt_precio_unitario_ac.Text = string.Empty;
            objetoActualizar = null;
        }
    }
}
