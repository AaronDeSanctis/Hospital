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

namespace HospitalWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Hospital.Patient patient = new Hospital.Patient();
            patient.SetFirstName(First_Name.Text);
            patient.SetMiddleName(Middle_Name.Text);
            patient.SetLastName(Last_Name.Text);
            patient.SetAddress1(Address_1.Text);
            patient.SetAddress2(Address_2.Text);
            patient.SetCity(City.Text);
            patient.SetState(State.Text);
            patient.SetZipCode(Zip_Code.Text);
            patient.SetDateOfBirth(Date_Of_Birth.Text);
            patient.SetHeight(Height_.Text);
            patient.SetWeight(Weight.Text);
            patient.SetPhoneNumber(Phone_Number.Text);
            patient.SetSSN(SSN.Text);
            patient.SetEmail(Email.Text);
            patient.CreateInsurance(Insurance_ID.Text, Insurance_Group_ID.Text, Insurance_Provider.Text, Insurance_Type.Text);
            Hospital.Database DB = new Hospital.Database();
            DB.Save(patient);
            //Schedule schedule = new Schedule(patient);
            //schedule.Show();
            //schedule.Activate();
            //Start Next Window(patient)


        }
        private void First_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
        private void Last_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Middle_Name_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Address_1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Address_2_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void City_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void State_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Zip_Code_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Phone_Number_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void SSN_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Insurance_ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Insurance_Provider_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Insurance_Type_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Insurance_Group_ID_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Date_Of_Birth_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Weight_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Height__TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Test_Click(object sender, RoutedEventArgs e)
        {

        }

    }
}
