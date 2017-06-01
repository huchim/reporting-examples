# [Reporting](https://huchim.com/)

Este repositorio sirve para demostrar en un ejemplo el uso del paquete de "Reporting".

Este sirve para generar en diferentes formatos un reporte basado en una consulta SQL. En [este wiki](https://github.com/huchim/reporting-pdf/wiki) encontrará mayor información acerca de cómo crear reportes y usalos.

**Reporting** consta de 5 paquetes

* [Jaguar.Reporting](https://github.com/huchim/reporting) (Incluye `JsonGenerator`)

  * ```bash
    PM > Install-Package Jaguar.Reporting -Pre
    ```
* [Jaguar.Reporting.Csv](https://github.com/huchim/reporting-csv)

  * ```bash
    PM > Install-Package Jaguar.Reporting.Csv -Pre
    ```
* [Jaguar.Reporting.Excel](https://github.com/huchim/reporting-excel)

  * ```bash
    PM > Install-Package Jaguar.Reporting.Excel -Pre
    ```
* [Jaguar.Reporting.Html](https://github.com/huchim/reporting-html)


  * ```bash
    PM > Install-Package Jaguar.Reporting.Html -Pre
    ```
* [Jaguar.Reporting.Pdf](https://github.com/huchim/reporting-pdf) (**Nota:** No compatible con .NET Core)

  * ```bash
    PM > Install-Package Jaguar.Reporting.Pdf -Pre
    ```

El conjunto usa [un repositorio](https://github.com/huchim/schemas) para permitir crear los archivos JSON de manera sencilla en Visual Studio. Además ha creado un "fork" de [Mustache](https://github.com/huchim/mustache-sharp) para compatibilidad con .NET Core.

Se usa iTextSharp 5 para los PDF y EPPLus.Core para Excel.
