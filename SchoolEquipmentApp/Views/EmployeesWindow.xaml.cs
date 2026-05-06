using System.Windows;using Microsoft.Data.SqlClient;using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class EmployeesWindow:Window{DatabaseService _db=new();public EmployeesWindow(string u){InitializeComponent();HeaderText.Text=$"Сотрудники | Пользователь: {u}";Load();}
void Load()=>Grid.ItemsSource=_db.GetTable("SELECT EmployeeID ID,FullName ФИО,Position Должность,Department [Кабинет/подразделение],Phone Телефон FROM Employees WHERE FullName LIKE @q",new SqlParameter("@q",$"%{SearchBox.Text}%")).DefaultView;
private void SearchChanged(object s,RoutedEventArgs e)=>Load();}
