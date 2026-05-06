using System.Windows;
using SchoolEquipmentApp.Services;
namespace SchoolEquipmentApp.Views;
public partial class LoginWindow : Window
{
    private readonly AuthService _auth = new();
    public LoginWindow() => InitializeComponent();
    private void Login_Click(object s, RoutedEventArgs e)
    {
        try
        {
            var user = _auth.Login(LoginBox.Text.Trim(), PasswordBox.Password.Trim());
            if (user == null) { MessageBox.Show("Неверный логин или пароль"); return; }
            new MainWindow(user.FullName).Show(); Close();
        }
        catch { MessageBox.Show("Ошибка подключения к базе данных"); }
    }
}
