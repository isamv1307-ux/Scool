using System.Data;using System.Windows;using Microsoft.Win32;using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class ReportsWindow:Window{DatabaseService _db=new();ExcelExportService _excel=new();DataTable _current=new();string _title="Отчет";readonly string _user;
public ReportsWindow(string u){InitializeComponent();_user=u;HeaderText.Text=$"Отчеты | Пользователь: {u}";EquipmentReport_Click(null!,null!);} 
void Bind(string sql,string title){_title=title;_current=_db.GetTable(sql);Grid.ItemsSource=_current.DefaultView;}
private void EquipmentReport_Click(object s,RoutedEventArgs e)=>Bind("SELECT * FROM Equipment","Отчет по технике");
private void StatusReport_Click(object s,RoutedEventArgs e)=>Bind("SELECT Status,COUNT(*) Count FROM Equipment GROUP BY Status","Отчет по состоянию оборудования");
private void IssuanceReport_Click(object s,RoutedEventArgs e)=>Bind("SELECT * FROM Issuance","Отчет по выдаче техники");
private void ComponentsReport_Click(object s,RoutedEventArgs e)=>Bind("SELECT * FROM Components","Отчет по комплектующим");
private void Export_Click(object s,RoutedEventArgs e){var dlg=new SaveFileDialog{Filter="Excel|*.xlsx",FileName="Report.xlsx"};if(dlg.ShowDialog()==true){_excel.Export(_current,_title,_user,dlg.FileName);MessageBox.Show("Файл успешно экспортирован");}}
private void FilterChanged(object s,RoutedEventArgs e){if(_current==null)return;_current.DefaultView.RowFilter=string.Join(" OR ",_current.Columns.Cast<DataColumn>().Select(c=>$"CONVERT([{c.ColumnName}], 'System.String') LIKE '%{SearchBox.Text.Replace("'","''")}%'") );}
}
