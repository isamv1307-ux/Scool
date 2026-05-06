using System.Data;using System.Windows;using System.Windows.Controls;using Microsoft.Data.SqlClient;using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class EquipmentWindow : Window { DatabaseService _db=new(); int _id; public EquipmentWindow(string u){InitializeComponent();HeaderText.Text=$"Учет организационной техники | Пользователь: {u}";Refresh(null,null);} 
private void Refresh(object? s, RoutedEventArgs? e){Grid.ItemsSource=_db.GetTable("SELECT e.EquipmentID ID,e.Name Наименование,e.Type Тип,e.InventoryNumber [Инвентарный номер],e.PurchaseDate [Дата поступления],e.Status Состояние,e.Location Местоположение,ISNULL(em.FullName,'') [Ответственный сотрудник] FROM Equipment e LEFT JOIN Employees em ON em.EmployeeID=e.EmployeeID WHERE e.Name LIKE @q OR e.InventoryNumber LIKE @q",new SqlParameter("@q",$"%{SearchBox.Text}%")).DefaultView;}
private void Grid_SelectionChanged(object s,SelectionChangedEventArgs e){if(Grid.SelectedItem is DataRowView r)_id=(int)r["ID"];}
private void Reset_Click(object s,RoutedEventArgs e){SearchBox.Text="";Refresh(null,null);} }
