using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Jaguar.Reporting.Generators;

namespace Jaguar.Reporting.WebFormsNet40
{
    public partial class Default : System.Web.UI.Page
    {
        private ReportRepository reportRepository;
        private List<IGeneratorEngine> generatorList;

        public Default()
        {
            // Se debe ubicar la ruta completa a la carpeta donde están los reportes.
            var reportDirectory = Server.MapPath("~/Reports/");
            
            // ReportRepository ayuda a manejar los reportes.
            // Se recomienda que cada reporte tenga su propia carpeta para organizar los archivos
            // que dependen del reporte.
            this.reportRepository = new ReportRepository(reportDirectory);

            // Crear una lista de los "generadores" disponibles.
            // Esto puede servir para crear una lista y dejar que el usuario elija el formato.
            this.generatorList = new List<IGeneratorEngine>
            {
                new HtmlGenerator(),
                new JsonGenerator(),
                new CsvGenerator(),                
                new ExcelGenerator(),
                new PdfGenerator()
            };
        }

        /// <summary>
        /// Obtiene la lista de generadores disponibles.
        /// </summary>
        public IGeneratorEngine[] Generators
        {
            get
            {
                return this.generatorList.ToArray();
            }
        }

        /// <summary>
        /// Obtiene la lista de reportes disponibles en el repositorio.
        /// </summary>
        public ReportHandler[] Reports
        {
            get
            {
                return this.reportRepository.Reports;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {            
        }
    }
}