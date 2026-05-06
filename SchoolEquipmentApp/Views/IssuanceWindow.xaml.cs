using System.Windows;using Microsoft.Data.SqlClient;using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class IssuanceWindow:Window{DatabaseService _db=new();public IssuanceWindow(string u){InitializeComponent();HeaderText.Text=$"Выдача техники | Пользователь: {u}";Load();}
void Load()=>Grid.ItemsSource=_db.GetTable("SELECT i.IssuanceID ID,e.FullName Сотрудник,eq.Name Техника,i.IssueDate [Дата выдачи],i.ReturnDate [Дата возврата],i.IssuanceStatus Статус,i.Comment Комментарий FROM Issuance i JOIN Employees e ON e.EmployeeID=i.EmployeeID JOIN Equipment eq ON eq.EquipmentID=i.EquipmentID WHERE e.FullName LIKE @q OR eq.Name LIKE @q",new SqlParameter("@q",$"%{SearchBox.Text}%")).DefaultView;
private void SearchChanged(object s,RoutedEventArgs e)=>Load();}
