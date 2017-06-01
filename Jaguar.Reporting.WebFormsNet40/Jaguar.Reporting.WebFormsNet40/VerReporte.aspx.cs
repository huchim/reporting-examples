using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jaguar.Reporting.Generators;

namespace Jaguar.Reporting.WebFormsNet40
{
    public partial class VerReporte : System.Web.UI.Page
    {
        private ReportRepository reportRepository;
        private ReportManager reportManager;

        public VerReporte()
        {
            // Se debe ubicar la ruta completa a la carpeta donde están los reportes.
            var reportDirectory = Server.MapPath("~/Reports/");
            
            // ReportRepository ayuda a manejar los reportes.
            // Se recomienda que cada reporte tenga su propia carpeta para organizar los archivos
            // que dependen del reporte.
            this.reportRepository = new ReportRepository(reportDirectory);

            // Obtenemos la cadena de conexión.
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Creamos una conexión al servidor, no importa si aún está cerrada.
            // Se la asignamos al ReportManager.
            this.reportManager = new ReportManager(new SqlConnection(connectionString));

            // BUG: Hay que llamar a esta función para que todo funcione. v1.0.0-rc3 :(
            this.reportManager.AddDefaultVariables();

            // Una vez que el ReportManager tiene la conexión, es necesario registrar los "generadores".
            // En este caso no agregamos JsonGenerator, esto es porque va incluído predeterminadamente.
            this.reportManager.AddGenerator(new HtmlGenerator());
            this.reportManager.AddGenerator(new CsvGenerator());
            this.reportManager.AddGenerator(new ExcelGenerator());
            this.reportManager.AddGenerator(new PdfGenerator());
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            // El nombre ayudará a recuperar el contenido del reporte.
            var reportId = Request.QueryString["reporte"];

            // Este es el encargador de generar el reporte.
            var generatorId = Request.QueryString["generador"];

            // Vamos a recuperar la configuración del reporte.
            var reporte = this.reportRepository.GetReport(reportId);

            if (reporte == null)
            {
                Response.Write("No se pudo encontrar el reporte con el ID: " + reportId);
                Response.End();
            }

            // Vamos a crear un diccionario para agregar las variables
            // en este caso no requeriminos de ninguna.
            var argumentosReporte = new Dictionary<string, object>();

            // Vamos a abrir el reporte, en este momento no lo hemos ejecutado.
            this.reportManager.Open(reporte, argumentosReporte);

            // Ejecutamos el reporte.
            // Cada generador que agregamos a reportManager, tiene un identificador único.
            // es por eso que al generarlo, requerimos ese identificador.
            // En este caso, el reporte devuelve una cadena de texto que se imprimirá en la página.
            var resultado = this.reportManager.GetString(new Guid(generatorId));

            // Se lo asignamos a la variable que imprimiremos en la vista.
            this.SalidaReporte = resultado;
        }

        public string SalidaReporte { get; set; }
    }
}