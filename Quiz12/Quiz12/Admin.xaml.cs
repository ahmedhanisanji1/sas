using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Quiz12
{
    public partial class Admin : Page
    {
        oneEntities2 db = new oneEntities2();

        public Admin()
        {
            InitializeComponent();
            LoadStudents();
        }

        public void LoadStudents()
        {
            DGstudents.ItemsSource = db.Students.Select(x => new {x.ID, x.Name, x.Address, DepartmentName = db.Departments.Where(d => d.Department_Id == x.DepId).Select(d => d.Name).FirstOrDefault()}).ToList();
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(StudentIDtxt.Text);
            db.Students.Remove(db.Students.First(x => x.ID == id));
            db.SaveChanges();
            MessageBox.Show("Student deleted successfully.");
            LoadStudents();
        }

        private void Udpate_Butt(object sender, RoutedEventArgs e)
        {

            Student s = new Student();
            Department d = new Department();

            d = db.Departments.First(x => x.Name == Deptxt.Text);

            s = db.Students.First(x => x.DepId == d.Department_Id);

           


        }


        private void Search_Click(object sender, RoutedEventArgs e)
            {

             //Department de= new Department();

             //var  ser = ComboDepTxt.SelectedItem as ComboBoxItem ;

             //DGstudents.ItemsSource = db.Students.Where( de.Name == ser.Content.ToString() ).Select(x => new { x.ID, x.Name, x.Address, DepartmentName = db.Departments.Where(d => d.Department_Id == x.DepId).Select(n => n.Name).FirstOrDefault() }).ToList();

            DGstudents.ItemsSource = db.Students.Where(x => x.Name == searchnametxt.Text).Select(x => new { x.ID, x.Name, x.Address, DepartmentName = db.Departments.Where(d => d.Department_Id == x.DepId).Select(d => d.Name).FirstOrDefault() }).ToList();
        }



    }
    
}
