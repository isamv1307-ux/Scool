using ClosedXML.Excel;
using System.Data;
namespace SchoolEquipmentApp.Services;
public class ExcelExportService
{
    public void Export(DataTable table, string reportTitle, string fullName, string path)
    {
        using var wb = new XLWorkbook();
        var ws = wb.Worksheets.Add("Отчет");
        ws.Cell("A1").Value = "МБОУ СОШ № 6 им. Сирина Н.И.";
        ws.Cell("A2").Value = reportTitle;
        ws.Cell("A3").Value = $"Дата: {DateTime.Now:dd.MM.yyyy HH:mm}";
        ws.Cell("A4").Value = $"Пользователь: {fullName}";
        ws.Range("A1:A4").Style.Font.Bold = true;
        ws.Cell(6,1).InsertTable(table);
        ws.Tables.First().Theme = XLTableTheme.TableStyleMedium2;
        ws.Columns().AdjustToContents();
        wb.SaveAs(path);
    }
}
