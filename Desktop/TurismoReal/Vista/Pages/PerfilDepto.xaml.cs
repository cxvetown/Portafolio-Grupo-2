using Controlador;
using Microsoft.Win32;
using Modelo;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Vista.Pages
{
    public partial class PerfilDepto : Page
    {
        private Departamento departamento;
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
            if (int.TryParse(txt_cantidad_ag.Text, out int valor))
            {
                if (!txt_objeto_ag.Text.Trim().Equals(""))
                {
                    if (int.TryParse(txt_cantidad_ag.Text, out int cantidad))
                    {
                        Objeto objeto = new()
                        {
                            NombreObjeto = txt_objeto_ag.Text,
                            CantidadObjeto = cantidad,
                            ValorUnitarioObjeto = valor
                        };
                        int estado = CInventario.CrearInventario(objeto, departamento.IdDepto);
                        MessageBox.Show("Objeto agregado al inventario");
                        ListarObjetos();
                        Limpiar();
                    }
                }
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
                MessageBox.Show("Objeto eliminado del inventario");
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
                MessageBox.Show(ofd.FileName);
            }
        }
        private void btn_Agregar_Img_Click(object sender, RoutedEventArgs e)
        {
            string ext = System.IO.Path.GetExtension(txtPathFoto.Text);
            string path = System.IO.Directory.GetCurrentDirectory();
            path = path.Substring(0, path.LastIndexOf("Desktop"));
            path = string.Concat(path, "Turismo_Real_Web\\Fornt_end\\front_end_tr\\src\\imagenes_Dpto\\");

            Fotografia fotografia = new()
            {
                Id_dpto = departamento.IdDepto,
                Path_img = path,
                Alt = txtAltFoto.Text
            };
            string r = CFotografia.InsertarImagen(fotografia, ext);
            if (r.Length > 0)
            {
                r = System.IO.Path.Combine(path, r);
                System.IO.File.Copy(txtPathFoto.Text, r, true);
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
                                       Path_img = rw[2].ToString(),
                                       Alt = rw[3].ToString()
                                   }).ToList();
                    imgMain.Source = new BitmapImage(new Uri(fotografias[0].Path_img));
                    StkOtrasImg.Children.Clear();
                    try
                    {
                        for (int i = 1; i <= fotografias.Count-1 ; i++)
                        {

                            try
                            {
                                StkOtrasImg.UnregisterName("imgDpto" + fotografias[i].Id_foto);

                            }
                            catch (Exception)
                            {

                            }
                            Image image = new()
                            {
                                Source = new BitmapImage(new Uri(fotografias[i].Path_img)),
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

        private void DtgInventarioUpdate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                Objeto objeto = (Objeto)dtgInventario.SelectedItem;
                try
                {
                    int estado = CInventario.ActualizarInventario(objeto);
                    MessageBox.Show("Inventario actualizado");
                    ListarObjetos();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
