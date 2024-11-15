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
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.Entity.Migrations;

namespace Quiz12
{
    /// <summary>
    /// Interaction logic for Pag.xaml
    /// </summary>
    public partial class Pag : Page
    {
        oneEntities2 db = new oneEntities2();
        string mail;
        public Pag(string email)
        {
            InitializeComponent();
             mail = email;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Student stu = new Student();
            stu = db.Students.FirstOrDefault(x => x.Email == mail);

            stu.Name = nametxt.Text;
            stu.Address = addresstxt.Text;
            stu.Age = int.Parse(agetxt.Text);
            

            Department dep = new Department();
            dep = db.Departments.First(x => x.Name == deparmenttxt.Text);

            stu.DepId = dep.Department_Id;

            db.Students.AddOrUpdate(stu);
            db.SaveChanges();

            MessageBox.Show("Data added succefully");

        }
    }
}
