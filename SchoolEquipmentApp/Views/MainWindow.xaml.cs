using System.Windows;using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class MainWindow : Window
{
    private readonly string _fullName; private readonly DatabaseService _db = new();
    public MainWindow(string fullName){InitializeComponent();_fullName=fullName;UserText.Text=$"Пользователь: {_fullName}";LoadStats();}
    private void LoadStats(){try{TotalEq.Text=$"Всего техники: {_db.Scalar("SELECT COUNT(*) FROM Equipment")}";OkEq.Text=$"Исправна: {_db.Scalar("SELECT COUNT(*) FROM Equipment WHERE Status='Исправна'")}";RepairEq.Text=$"В ремонте: {_db.Scalar("SELECT COUNT(*) FROM Equipment WHERE Status='В ремонте'")}";WriteOffEq.Text=$"Списана: {_db.Scalar("SELECT COUNT(*) FROM Equipment WHERE Status='Списана'")}";TotalComp.Text=$"Всего комплектующих: {_db.Scalar("SELECT COUNT(*) FROM Components")}";}catch{}}
    private void Exit_Click(object s, RoutedEventArgs e){new LoginWindow().Show();Close();}
    private void Equipment_Click(object s,RoutedEventArgs e)=>new EquipmentWindow(_fullName).ShowDialog();
    private void Components_Click(object s,RoutedEventArgs e)=>new ComponentsWindow(_fullName).ShowDialog();
    private void Employees_Click(object s,RoutedEventArgs e)=>new EmployeesWindow(_fullName).ShowDialog();
    private void Issuance_Click(object s,RoutedEventArgs e)=>new IssuanceWindow(_fullName).ShowDialog();
    private void Reports_Click(object s,RoutedEventArgs e)=>new ReportsWindow(_fullName).ShowDialog();
}
