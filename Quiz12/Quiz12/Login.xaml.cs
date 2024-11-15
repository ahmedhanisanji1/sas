using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Quiz12
{

    public partial class Login : Page
    {
        oneEntities2 db = new oneEntities2();

        public Login()
        {
            InitializeComponent();
        }

        private void Logbutt(object sender, RoutedEventArgs e)
        {
        
            if (emailtxt.Text == "Admin@gmail.com" && passtxt.Text == "Admin1234")
            {
                Admin ad = new Admin();
                this.NavigationService.Navigate(ad);
                return; 
            }

       
            Student stu = db.Students.FirstOrDefault(s => s.Email == emailtxt.Text);
         
            if (stu != null&& stu.Email == emailtxt.Text && stu.Password == passtxt.Text)
            {
                Pag ap = new Pag(stu.Email); 
                this.NavigationService.Navigate(ap);
            }
            else
            {
                MessageBox.Show("Your email or password is incorrect!!");
            }
        }

        private void signup_button(object sender, RoutedEventArgs e)
        {
            SignUp sign = new SignUp();
            this.NavigationService.Navigate(sign);



        }
    }
}
