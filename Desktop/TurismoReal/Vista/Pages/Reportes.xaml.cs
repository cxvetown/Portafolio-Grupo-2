using Controlador;
using Modelo;
using QuestPDF.Drawing;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using static Vista.Pages.StatsReport;

namespace Vista.Pages
{
    public partial class Reportes : Page
    {
        public Reportes()
        {
            InitializeComponent();
            ListarRegiones();
            ListarComunas();
            ListarDpto();
        }
        private void ItemError(object sender, ValidationErrorEventArgs e)
        {
            if (e.Action == ValidationErrorEventAction.Added)
            {
                MessageBox.Show(e.Error.ErrorContent.ToString());
            }
        }
        public void ListarComunas()
        {
            try
            {
                List<Comuna> comunas = CComuna.ListarComuna();
                if (comunas != null)
                {
                    comunas.Insert(0, new Comuna() { NombreComuna = "Seleccione una comuna" });
                    cbo_Comunas.ItemsSource = comunas;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ListarRegiones()
        {
            try
            {
                List<Region> regiones = CRegion.ListarRegion();
                if (regiones != null)
                {
                    regiones.Insert(0, new Region() { NombreRegion = "Seleccione una región" });

                    cbo_Regiones.ItemsSource = regiones;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void ListarDpto()
        {
            try
            {
                DataTable dataTable = CDepartamento.ListarDpto();
                if (dataTable != null)
                {
                    var Dptos = (from rw in dataTable.AsEnumerable()
                                 select new Departamento()
                                 {
                                     IdDepto = Convert.ToInt32(rw[0]),
                                     NombreDpto = rw[1].ToString(),
                                     TarifaDiara = Convert.ToInt32(rw[2]),
                                     Direccion = rw[3].ToString(),
                                     NroDpto = Convert.ToInt32(rw[4]),
                                     Capacidad = Convert.ToInt32(rw[5]),
                                     Comuna = new Comuna
                                     {
                                         IdComuna = Convert.ToInt32(rw[6]),
                                         NombreComuna = rw[9].ToString()
                                     },
                                     Disponibilidad = Convert.ToBoolean(rw[7])
                                 }).ToList();
                    Dptos.Insert(0,new Departamento() { NombreDpto = "Seleccione un departamento" });
                    cbo_Dptos.ItemsSource = Dptos;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGenReporteStats_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int nivel = 0;

            if (dp_Fecinicio.SelectedDate != null || dp_FecTermino.SelectedDate != null)
            {
                DateTime fecha_inicio = (DateTime)dp_Fecinicio.SelectedDate;
                DateTime fecha_termino = (DateTime)dp_FecTermino.SelectedDate;

                if (cbo_Dptos.SelectedIndex > 0)
                {
                    Departamento departamento = (Departamento)cbo_Dptos.SelectedItem;
                    id = departamento.IdDepto;
                    nivel = 3;
                }
                else if (cbo_Comunas.SelectedIndex > 0)
                {
                    Comuna comuna = (Comuna)cbo_Comunas.SelectedItem;
                    id = comuna.IdComuna;
                    nivel = 2;
                }
                else if (cbo_Regiones.SelectedIndex > 0)
                {
                    Region region = (Region)cbo_Regiones.SelectedItem;
                    id = region.IdRegion;
                    nivel = 1;
                }
                var model = ReporteStatsDataSource.GetInvoiceDetails(id, nivel, fecha_inicio, fecha_termino);
                var documentStats = new ReporteDocumentoStats(model);

                GenerateStatsDocumentAndShow(documentStats);
            }
            else
            {
                MessageBox.Show("Se debe selecionar fechas");
            }
        }
        private void btnGenReporteReservas_Click(object sender, RoutedEventArgs e)
        {
            int id = 0;
            int nivel = 0;

            if (dp_Fecinicio.SelectedDate != null && dp_FecTermino.SelectedDate != null)
            {
                DateTime fecha_inicio = (DateTime)dp_Fecinicio.SelectedDate;
                DateTime fecha_termino = (DateTime)dp_FecTermino.SelectedDate;
                if (cbo_Dptos.SelectedIndex > 0)
                {
                    Departamento departamento = (Departamento)cbo_Dptos.SelectedItem;
                    id = departamento.IdDepto;
                    nivel = 3;
                }
                else if (cbo_Comunas.SelectedIndex > 0)
                {
                    Comuna comuna = (Comuna)cbo_Comunas.SelectedItem;
                    id = comuna.IdComuna;
                    nivel = 2;
                }
                else if (cbo_Regiones.SelectedIndex > 0)
                {
                    Region region = (Region)cbo_Regiones.SelectedItem;
                    id = region.IdRegion;
                    nivel = 1;
                }
                var model = InvoiceDocumentDataSource.GetInvoiceDetails(id, nivel, fecha_inicio, fecha_termino);
                var document = new ReporteDocumento(model);

                GenerateDocumentAndShow(document);
            }
            else
            {
                MessageBox.Show("Se debe selecionar fechas");
            }
        }
        private void GenerateStatsDocumentAndShow(ReporteDocumentoStats documentStats)
        {
            const string filePath = "invoiceStats.pdf";

            documentStats.GeneratePdf(filePath);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                }
            };

            process.Start();
        }
        private void GenerateDocumentAndShow(ReporteDocumento document)
        {
            const string filePath = "invoice.pdf";

            document.GeneratePdf(filePath);

            var process = new Process
            {
                StartInfo = new ProcessStartInfo(filePath)
                {
                    UseShellExecute = true
                }
            };

            process.Start();
        }
    }

    #region "REPORTE RESERVA"
    
    public class ReporteDocumento : IDocument
    {
        public List<ReporteReserva> Modelo { get; }

        public ReporteDocumento(List<ReporteReserva> modelo)
        {
            Modelo = modelo;
        }        

        public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

        public void Compose(IDocumentContainer container)
        {
            container
                .Page(page =>
                {
                    page.Margin(50);

                    page.Header().Element(ComposeHeader);
                    page.Content().Element(ComposeContent);

                    page.Footer().AlignCenter().Text(text =>
                    {
                        text.CurrentPageNumber();
                        text.Span(" / ");
                        text.TotalPages();
                    });
                });
        }

        void ComposeHeader(IContainer container)
        {
            container.Row(row =>
            {
                row.RelativeItem().Column(Column =>
                {
                    Column
                        .Item().Text($"Reporte Reservas #1")
                        .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                    Column.Item().Text(text =>
                    {
                        text.Span("Fecha del reporte: ").SemiBold();
                        text.Span($"{DateTime.Now:d}");
                    });
                });

                row.ConstantItem(100).Height(50).Placeholder();
            });
        }

        void ComposeContent(IContainer container)
        {
            container.PaddingVertical(40).Column(column =>
            {
                column.Spacing(20);

                column.Item().Element(ComposeTable);

                column.Item().Table(table =>
                {
                    var headerStyle = TextStyle.Default.SemiBold();
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(250);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });
                    table.Header(header =>
                    {
                        var headerStyle = TextStyle.Default.SemiBold();

                        header.Cell().Text("").Style(headerStyle);
                        header.Cell().MaxWidth(55).AlignRight().Text("Total Gral. Arriendos").Style(headerStyle).FontSize(10);
                        header.Cell().MaxWidth(55).AlignRight().Text("Prom. Total. Gral. Reservas").Style(headerStyle).FontSize(10);
                        header.Cell().MaxWidth(55).AlignRight().Text("Total Gral. Multas").Style(headerStyle).FontSize(10);

                        header.Cell().ColumnSpan(4).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                    });
                    var CantMultas = 0m;
                    var CantArriendos = 0m;
                    var PromReservas = 0m;
                    var count = 0;
                    foreach (var item in Modelo)
                    {
                        CantMultas += item.CantMultas;
                        CantArriendos += item.CantArriendos;
                        PromReservas += item.PromDiasReserva;
                        count++;                      
                    }
                    table.Cell().Element(CellStyle).AlignRight().Text("");
                    table.Cell().Element(CellStyle).AlignCenter().Text(CantArriendos);
                    if (count!=0)
                    {
                        table.Cell().MaxWidth(55).Element(CellStyle).AlignRight().Text(Math.Truncate(PromReservas / count));
                    }
                    else
                    {
                        table.Cell().MaxWidth(55).Element(CellStyle).AlignRight().Text(0);
                    }
                    
                    table.Cell().MaxWidth(55).Element(CellStyle).AlignRight().Text(CantMultas);
                    

                    static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                });
            });
        }
        
        void ComposeTable(IContainer container)
        {
            var headerStyle = TextStyle.Default.SemiBold();

            container.Table(table =>
            {
                table.ColumnsDefinition(columns =>
                {
                    columns.ConstantColumn(250);
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                    columns.RelativeColumn();
                });

                table.Header(header =>
                {
                    header.Cell().AlignMiddle().Text("Nombre Departamento").Style(headerStyle).FontSize(10);
                    header.Cell().MaxWidth(55).AlignRight().Text("Cant. Arriendos").Style(headerStyle).FontSize(10);
                    header.Cell().MaxWidth(55).AlignRight().Text("Duración prom. de reservas").Style(headerStyle).FontSize(10);
                    header.Cell().MaxWidth(55).AlignRight().Text("Cant. Multas").Style(headerStyle).FontSize(10);

                    header.Cell().ColumnSpan(4).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                }); 
                                
                foreach (var item in Modelo)
                {
                    //table.Cell().Element(CellStyle).Text(Modelo.Items.IndexOf(item) + 1);
                    table.Cell().Element(CellStyle).Text(item.NombreDpto);
                    table.Cell().MaxWidth(55).Element(CellStyle).AlignRight().Text(item.CantArriendos);
                    table.Cell().MaxWidth(55).Element(CellStyle).AlignRight().Text(item.PromDiasReserva);
                    table.Cell().MaxWidth(55).Element(CellStyle).AlignRight().Text(item.CantMultas);

                    static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                }
            });
        }
    }   
    public static class InvoiceDocumentDataSource
    {
        public static List<ReporteReserva> GetInvoiceDetails(int id, int nivel, DateTime fecha_inicio, DateTime fecha_termino)
        {

            DataTable dt = CReporte.GenReporteReserva(id, nivel, fecha_inicio, fecha_termino);            
            var Dptos = (from rw in dt.AsEnumerable()
                         select new ReporteReserva()
                         {
                             NombreDpto = (string)rw[0],
                             CantArriendos = (decimal)rw[1],
                             PromDiasReserva = (decimal)rw[2],
                             CantMultas = (decimal)rw[3]
                         }).ToList();
            return Dptos;
        }
    }
    #endregion

    #region "Reporte Estadísticas"
    public class StatsReport
    {
        public class ReporteDocumentoStats : IDocument
        {
            public List<ReporteStats> Modelo { get; }

            public ReporteDocumentoStats(List<ReporteStats> modelo)
            {
                Modelo = modelo;
            }

            public DocumentMetadata GetMetadata() => DocumentMetadata.Default;

            public void Compose(IDocumentContainer container)
            {
                container
                    .Page(page =>
                    {
                        page.Margin(50);

                        page.Header().Element(ComposeHeader);
                        page.Content().Element(ComposeContent);

                        page.Footer().AlignCenter().Text(text =>
                        {
                            text.CurrentPageNumber();
                            text.Span(" / ");
                            text.TotalPages();
                        });
                    });
            }
            void ComposeHeader(IContainer container)
            {
                container.Row(row =>
                {
                    row.RelativeItem().Column(Column =>
                    {
                        Column
                            .Item().Text($"Reporte Estadísticas #1")
                            .FontSize(20).SemiBold().FontColor(Colors.Blue.Medium);

                        Column.Item().Text(text =>
                        {
                            text.Span("Fecha del reporte: ").SemiBold();
                            text.Span($"{DateTime.Now:d}");
                        });
                    });

                    row.ConstantItem(100).Height(50).Placeholder();
                });
            }
            void ComposeContent(IContainer container)
            {
                container.PaddingVertical(40).Column(column =>
                {
                    column.Spacing(20);

                    column.Item().Element(ComposeTable);

                    column.Item().Table(table =>
                    {
                        var headerStyle = TextStyle.Default.SemiBold();
                        table.ColumnsDefinition(columns =>
                        {
                            columns.ConstantColumn(200);
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                            columns.RelativeColumn();
                        });
                        table.Header(header =>
                        {
                            var headerStyle = TextStyle.Default.SemiBold();

                            header.Cell().Text("").Style(headerStyle);
                            header.Cell().MaxWidth(55).AlignRight().Text("Total Gral. días Arriendos").Style(headerStyle).FontSize(10);
                            header.Cell().MaxWidth(55).AlignRight().Text("Total Gral. Mantención").Style(headerStyle).FontSize(10);
                            header.Cell().MaxWidth(55).AlignRight().Text("Total Gral. Multas").Style(headerStyle).FontSize(10);
                            header.Cell().MaxWidth(60).AlignRight().Text("Total Gral. Recaudación").Style(headerStyle).FontSize(10);

                            header.Cell().ColumnSpan(5).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                        });

                        var TotalGralCantArriendos = 0m;
                        var TotalGralCostoMantencion = 0m;
                        var TotalGralCostoMultas = 0m;
                        var TotalGralRecaudacion = 0m;
                        foreach (var item in Modelo)
                        {
                            TotalGralCantArriendos += item.TotalDiasMantencion;
                            TotalGralCostoMantencion += item.TotalMantencion;
                            TotalGralCostoMultas += item.TotalMultas;
                            TotalGralRecaudacion += item.TotalRecaudacion;
                        }
                        table.Cell().Element(CellStyle).AlignRight().Text("");
                        table.Cell().Element(CellStyle).AlignRight().Text(TotalGralCantArriendos);
                        table.Cell().Element(CellStyle).AlignRight().Text(TotalGralCostoMantencion);
                        table.Cell().Element(CellStyle).AlignRight().Text(TotalGralCostoMultas);
                        table.Cell().Element(CellStyle).AlignRight().Text(TotalGralRecaudacion);


                        static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    });
                });
            }
            void ComposeTable(IContainer container)
            {
                var headerStyle = TextStyle.Default.SemiBold();

                container.Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.ConstantColumn(200);
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Text("Nombre Departamento").Style(headerStyle).FontSize(10);
                        header.Cell().MaxWidth(55).AlignRight().Text("Cant. días Arriendos").Style(headerStyle).FontSize(10);
                        header.Cell().MaxWidth(55).AlignRight().Text("Total Costo Mantención").Style(headerStyle).FontSize(10);
                        header.Cell().MaxWidth(55).AlignRight().Text("Total Costo Multas").Style(headerStyle).FontSize(10);
                        header.Cell().MaxWidth(60).AlignRight().Text("Total Recaudación").Style(headerStyle).FontSize(10);

                        header.Cell().ColumnSpan(5).PaddingTop(5).BorderBottom(1).BorderColor(Colors.Black);
                    });


                    foreach (var item in Modelo)
                    {
                        table.Cell().Element(CellStyle).Text(item.NombreDpto);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.TotalDiasMantencion);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.TotalMantencion);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.TotalMultas);
                        table.Cell().Element(CellStyle).AlignRight().Text(item.TotalRecaudacion);
                        static IContainer CellStyle(IContainer container) => container.BorderBottom(1).BorderColor(Colors.Grey.Lighten2).PaddingVertical(5);
                    }
                });
            }
        }
        public static class ReporteStatsDataSource
        {
            public static List<ReporteStats> GetInvoiceDetails(int id, int nivel, DateTime fecha_inicio, DateTime fecha_termino)
            {

                DataTable dt = CReporte.GenReporteStats(id, nivel, fecha_inicio, fecha_termino);
                var Dptos = (from rw in dt.AsEnumerable()
                             select new ReporteStats()
                             {
                                 NombreDpto = (string)rw[0],
                                 TotalRecaudacion = (decimal)rw[1],
                                 TotalMantencion = (decimal)rw[2],
                                 TotalDiasMantencion = (decimal)rw[3],
                                 TotalMultas = (decimal)rw[4],
                             }).ToList();
                return Dptos;
            }
        }
    }
    #endregion
}
