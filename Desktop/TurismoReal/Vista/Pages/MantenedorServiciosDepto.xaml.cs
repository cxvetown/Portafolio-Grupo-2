using Controlador;
using Modelo;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Vista.Pages
{
    public partial class MantenedorServiciosDepto : Page
    {
        Departamento departamento;
        int col = 0;
        int colC = 0;

        public MantenedorServiciosDepto(Departamento dpto)
        {
            InitializeComponent();
            departamento = dpto;
            ListarServicios();
            ListarServiciosContratados();
            lblServDpto.Content = lblServDpto.Content.ToString() + dpto.NombreDpto;
        }
        

        public void ListarServicios()
        {
            try
            {
                DataTable dataTable = CServDpto.ListarServiciosDpto(departamento.IdDepto);
                if (dataTable != null)
                {
                    var ServDpto = (from rw in dataTable.AsEnumerable()
                                    select new Servicio()
                                    {
                                        IdServDpto = Convert.ToInt32(rw[0]),
                                        NombreServDpto = rw[1].ToString(),
                                        DescServDpto = rw[2].ToString(),
                                    }).ToList();
                    foreach (var item in ServDpto)
                    {
                        GenerarElementos(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void ListarServiciosContratados()
        {
            try
            {
                DataTable dataTable = CServDpto.ListarServiciosAsignadosDpto(departamento.IdDepto);
                if (dataTable != null)
                {

                    var ServDpto = (from rw in dataTable.AsEnumerable()
                                    select new ServDpto()
                                    {
                                        IdServDpto = Convert.ToInt32(rw[0]),
                                        IdDpto = Convert.ToInt32(rw[1]),
                                        Estado = Convert.ToInt32(rw[2]),
                                        NombreServDpto = rw[3].ToString(),
                                        DescServDpto = rw[4].ToString(),
                                    }).ToList();
                    foreach (var item in ServDpto)
                    {
                        GenerarElementos(item);
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void GenerarElementos(Servicio item)
        {
            Label lblTitulo = new()
            {
                Content = item.NombreServDpto,
                Height = 30,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = "lblT" + item.IdServDpto
            };

            TextBox lblDesc = new()
            {
                Text = item.DescServDpto,
                Height = 60,
                Margin = new Thickness(2, 30, 2, 0),
                VerticalAlignment = VerticalAlignment.Top,
                VerticalContentAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                BorderThickness = new Thickness(0),
                Focusable = false,
                Name = "lblD" + item.IdServDpto
            };

            Button btnAgregar = new()
            {
                Margin = new Thickness(0, 100, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Agregar",
                Height = 30,
                Width = 100,
                Name = "btn" + item.IdServDpto
            };

            Grid contenedor = new()
            {
                Height = 135,
                Name = "grd" + item.IdServDpto.ToString()
            };

            contenedor.Children.Add(lblTitulo);
            contenedor.Children.Add(lblDesc);
            contenedor.Children.Add(btnAgregar);

            Border borde = new()
            {
                Name = "brd" + item.IdServDpto,
                Margin = new Thickness(2),
                CornerRadius = new CornerRadius(3),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = contenedor
            };


            if (col == 0)
            {
                stkServ1.Children.Add(borde);
                stkServ1.RegisterName(lblTitulo.Name, lblTitulo);
                stkServ1.RegisterName(lblDesc.Name, lblDesc);
                btnAgregar.Click += delegate (object sender, RoutedEventArgs e) { BtnAgregarServicioDpto(sender, e, borde, 0, item, lblTitulo.Name, lblDesc.Name); };
                col = 1;
            }
            else
            {
                stkServ2.Children.Add(borde);
                stkServ2.RegisterName(lblTitulo.Name, lblTitulo);
                stkServ2.RegisterName(lblDesc.Name, lblDesc);
                btnAgregar.Click += delegate (object sender, RoutedEventArgs e) { BtnAgregarServicioDpto(sender, e, borde, 1, item, lblTitulo.Name, lblDesc.Name); };
                col = 0;
            }
        }

        private void GenerarElementos(ServDpto item)
        {
            Label lblTitulo = new()
            {
                Content = item.NombreServDpto,
                Height = 30,
                FontSize = 16,
                FontWeight = FontWeights.Bold,
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Center,
                Name = "lblTC" + item.IdServDpto
            };
            Label auxEstado = new() { Content = item.Estado, Visibility = Visibility.Hidden, Name = "aux" + item.IdServDpto};
            TextBox lblDesc = new()
            {
                Text = item.DescServDpto,
                Height = 60,
                Margin = new Thickness(2, 30, 2, 0),
                VerticalAlignment = VerticalAlignment.Top,
                VerticalContentAlignment = VerticalAlignment.Top,
                HorizontalContentAlignment = HorizontalAlignment.Left,
                TextWrapping = TextWrapping.Wrap,
                BorderThickness = new Thickness(0),
                Focusable = false,
                Name = "lblDC" + item.IdServDpto
            };

            Button btnQuitar= new()
            {
                Margin = new Thickness(20, 100, 0, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Left,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Content = "Quitar",
                Height = 30,
                Width = 100,
            };
            Button btnAcEstado = new()
            {
                Margin = new Thickness(0, 100, 20, 0),
                VerticalAlignment = VerticalAlignment.Top,
                HorizontalAlignment = HorizontalAlignment.Right,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                Height = 30,
                Width = 100,
            };

            if (item.Estado == 0)
            {
                btnAcEstado.Content = "Activar";
            }
            else
            {
                btnAcEstado.Content = "Desactivar";

            }

            Grid contenedor = new()
            {
                Height = 135,
                Name = "grdC" + item.IdServDpto.ToString()
            };

            contenedor.Children.Add(lblTitulo);
            contenedor.Children.Add(lblDesc);
            contenedor.Children.Add(btnQuitar);
            contenedor.Children.Add(btnAcEstado);
            contenedor.Children.Add(auxEstado);

            Border borde = new()
            {
                Name = "brdC" + item.IdServDpto,
                Margin = new Thickness(2),
                CornerRadius = new CornerRadius(3),
                BorderBrush = Brushes.Black,
                BorderThickness = new Thickness(1),
                Child = contenedor
            };


            if (colC == 0)
            {
                stkServDpto1.Children.Add(borde);
                stkServDpto1.RegisterName(lblTitulo.Name, lblTitulo);
                stkServDpto1.RegisterName(lblDesc.Name, lblDesc);
                btnAcEstado.Click += delegate (object sender, RoutedEventArgs e) { BtnActServicioDpto(sender, e, item.IdServDpto, auxEstado, btnAcEstado); };
                btnQuitar.Click += delegate (object sender, RoutedEventArgs e) { BtnElimServicioDpto(sender, e, borde, 0, item, lblTitulo.Name, lblDesc.Name); };
                colC = 1;
            }
            else
            {
                stkServDpto2.Children.Add(borde);
                stkServDpto2.RegisterName(lblTitulo.Name, lblTitulo);
                stkServDpto2.RegisterName(lblDesc.Name, lblDesc);
                btnAcEstado.Click += delegate (object sender, RoutedEventArgs e) { BtnActServicioDpto(sender, e, item.IdServDpto, auxEstado, btnAcEstado); };
                btnQuitar.Click += delegate (object sender, RoutedEventArgs e) { BtnElimServicioDpto(sender, e, borde, 1, item, lblTitulo.Name, lblDesc.Name); };
                colC = 0;
            }
        }

        #region
        private void BtnAgregarServicioDpto(object sender, RoutedEventArgs e, Border border, int posStk, Servicio serv, string titulo, string desc)
        {
            int resultado = CServDpto.IngresarServicioDpto(serv.IdServDpto, departamento.IdDepto, 0);
            if (resultado == -21201) return;

            if (posStk == 0)
            {
                stkServ1.Children.Remove(border); 
                stkServ1.UnregisterName(titulo); 
                stkServ1.UnregisterName(desc);
                col = 0;
            }
            else if (posStk == 1)
            {
                stkServ2.Children.Remove(border);
                stkServ2.UnregisterName(titulo); 
                stkServ2.UnregisterName(desc);
                col = 1;
            }

            ServDpto servDpto = new() { IdServDpto = serv.IdServDpto, NombreServDpto = serv.NombreServDpto, DescServDpto = serv.DescServDpto, Estado = 0, IdDpto = departamento.IdDepto };
            GenerarElementos(servDpto);
        }
        private void BtnActServicioDpto(object sender, RoutedEventArgs e, int id, Label estado, Button button)
        {
            int resultado;
            if ((int)estado.Content == 0)
            {
                resultado = CServDpto.ActualizarServicioDpto(id, departamento.IdDepto, 1);
                if (resultado == -21202) return;
                estado.Content = 1;
                button.Content = "Desactivar";
            }
            else
            {
                resultado = CServDpto.ActualizarServicioDpto(id, departamento.IdDepto, 0);
                if (resultado == -21202) return;
                estado.Content = 0;
                button.Content = "Activar";
            }
        }
        private void BtnElimServicioDpto(object sender, RoutedEventArgs e, Border border, int posStk, ServDpto sev, string titulo, string desc)
        {
            int restulado = CServDpto.EliminarServicioDpto(sev.IdServDpto, departamento.IdDepto);

            if (restulado == -21203) return;
            if (posStk == 0)
            {
                stkServDpto1.Children.Remove(border);
                stkServDpto1.UnregisterName(titulo);
                stkServDpto1.UnregisterName(desc);
                colC = 0;
            }
            else if (posStk == 1)
            {
                stkServDpto2.Children.Remove(border);
                stkServDpto2.UnregisterName(titulo);
                stkServDpto2.UnregisterName(desc);
                colC = 1;
            }
            Servicio serv = new() { IdServDpto = sev.IdServDpto, NombreServDpto = sev.NombreServDpto, DescServDpto = sev.DescServDpto };
            GenerarElementos(serv);
        }
        #endregion
    }
}
