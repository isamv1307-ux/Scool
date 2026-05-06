using System.Windows;using Microsoft.Data.SqlClient;using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class ComponentsWindow:Window{DatabaseService _db=new();public ComponentsWindow(string u){InitializeComponent();HeaderText.Text=$"Комплектующие | Пользователь: {u}";Load();}
void Load()=>Grid.ItemsSource=_db.GetTable("SELECT ComponentID ID,Name Наименование,Type Тип,Quantity Количество,Unit [Ед. изм.],Price Стоимость,Note Примечание FROM Components WHERE Name LIKE @q",new SqlParameter("@q",$"%{SearchBox.Text}%")).DefaultView;
private void SearchChanged(object s,RoutedEventArgs e)=>Load();}
