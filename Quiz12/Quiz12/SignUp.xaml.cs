using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Text.RegularExpressions;


namespace Quiz12
{
    /// <summary>
    /// Interaction logic for SignUp.xaml
    /// </summary>
    public partial class SignUp : Page
    {
        oneEntities2 db = new oneEntities2();
        public SignUp()
        {
            InitializeComponent();
        }

        private void Sign_Butt(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();

            if (Passwordtxt.Text != ConfPasswordtxt.Text)
            {               
                MessageBox.Show("Your password is not match the confirm");
                return;
            }
            

            if (db.Students.Any(x => x.Email == Emailtxt.Text))
            {
                MessageBox.Show("your email is already taken !");
                return;
            }
        
            if(Passwordtxt.Text.Length < 8)
            {
                MessageBox.Show("Your password should be more than 8 letter ");
                return;
            }
            //public static bool IsStrongPassword(string password)
            //{
            //    // Check if password is at least 8 characters
            //    if (password.Length < 8)
            //        return false;

            //    // Regular expression to check for uppercase, lowercase, digit, and special character
            //    Regex regex = new Regex(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$");

            //    return regex.IsMatch(password);
            //}

            stu.Name = Nametxt.Text;
            stu.Email = Emailtxt.Text;
            stu.Password = Passwordtxt.Text;
            

            db.Students.Add(stu);
            db.SaveChanges();

            MessageBox.Show("Registration successful!");

            Login log = new Login();
            this.NavigationService.Navigate(log);





        }
    }
}
