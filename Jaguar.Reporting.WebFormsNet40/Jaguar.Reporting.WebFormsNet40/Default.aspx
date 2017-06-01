<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SiteMaster.Master" CodeBehind="Default.aspx.cs" Inherits="Jaguar.Reporting.WebFormsNet40.Default" %>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <h3>Seleccione el reporte</h3>
        <ol class="round">
    <% foreach (var report in this.Reports ) { %>
            <li class="one">
                <h5><%= report.Label %></h5>
                <%= report.Description %>                
                    <ul>
                <% foreach (var generator in Generators ) { %>
                        <li>
                    <!-- Los generadores son los encargados de la presentación del reporte -->
                    <% if (generator.IsEmbed) { %>
                        <!-- Algunos generadores devuelven cadenas de texto que pueden ser mostradas en pantalla. -->
                        <a href="VerReporte.aspx?generador=<%= generator.Id %>&reporte=<%= report.Name %>">Visualizar (<%= generator.Name %>)</a>
                    <% } else { %>
                        <!-- Otros generadores devuelven byte[] por lo que deben guardarse en disco o descargarse. -->
                        <a href="DescargarReporte.aspx?generador=<%= generator.Id %>&reporte=<%= report.Name %>">Descargar (<%= generator.Name %>)</a>
                    <% } %>
                        </li>
                <% } %>
                    </ul>
            </li>
    <% } %>
    </ol>    
</asp:Content>