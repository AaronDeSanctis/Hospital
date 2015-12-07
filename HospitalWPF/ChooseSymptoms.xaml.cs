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
using System.Windows.Shapes;

namespace HospitalWPF
{
    /// <summary>
    /// Interaction logic for ChooseSymptoms.xaml
    /// </summary>
    public partial class ChooseSymptoms : Window
    {
        Hospital.Patient patient;
        public ChooseSymptoms(Hospital.Patient patient)
        {
            InitializeComponent();
            this.patient = patient;
        }

        private void Coughing_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Coughing "))
            {

            }
            else
            {
                patient.AddSymptom("Coughing");
                SymptomList.Text += "Coughing ";
            }
        }

        private void Diarrhea_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Diarrhea "))
            {

            }
            else
            {
                patient.AddSymptom("Diarrhea");
                SymptomList.Text += "Diarrhea ";
            }
        }

        private void Vomiting_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Vomiting "))
            {

            }
            else
            {
                patient.AddSymptom("Vomiting");
                SymptomList.Text += "Vomiting ";
            }
        }

        private void Hemorrhoids_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Hemorrhoids "))
            {

            }
            else
            {
                patient.AddSymptom("Hemorrhoids");
                SymptomList.Text += "Hemorrhoids ";
            }
        }

        private void Bloody_Stool_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Bloody Stool "))
            {

            }
            else
            {
                patient.AddSymptom("Bloody Stool");
                SymptomList.Text += "Bloody Stool ";
            }
        }

        private void Headaches_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Headaches "))
            {

            }
            else
            {
                patient.AddSymptom("Headaches");
                SymptomList.Text += "Headaches ";
            }
        }

        private void Migraines_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Migraines "))
            {

            }
            else
            {
                patient.AddSymptom("Migraines");
                SymptomList.Text += "Migraines ";
            }
        }

        private void Muscle_Soreness_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Muscle Soreness "))
            {

            }
            else
            {
                patient.AddSymptom("Muscle Soreness");
                SymptomList.Text += "Muscle Soreness ";
            }
        }

        private void Difficulty_Breathing_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Difficulty Breathing "))
            {

            }
            else
            {
                patient.AddSymptom("Difficulty Breathing");
                SymptomList.Text += "Difficulty Breathing ";
            }
        }

        private void Constipation_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Constipation "))
            {

            }
            else
            {
                patient.AddSymptom("Constipation");
                SymptomList.Text += "Constipation ";
            }
        }

        private void Rash_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Rash "))
            {

            }
            else
            {
                patient.AddSymptom("Rash");
                SymptomList.Text += "Rash ";
            }
        }

        private void Lasceration_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Lasceration "))
            {

            }
            else
            {
                patient.AddSymptom("Lasceration");
                SymptomList.Text += "Lasceration ";
            }
        }

        private void Broken_Bone_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Broken Bone "))
            {

            }
            else
            {
                patient.AddSymptom("Broken Bone");
                SymptomList.Text += "Broken Bone ";
            }
        }

        private void Runny_Nose_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Runny Nose "))
            {

            }
            else
            {
                patient.AddSymptom("Runny Nose");
                SymptomList.Text += "Runny Nose ";
            }
        }

        private void Bleeding_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Bleeding "))
            {

            }
            else
            {
                patient.AddSymptom("Bleeding");
                SymptomList.Text += "Bleeding ";
            }
        }

        private void Dizzyness_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Dizzyness "))
            {

            }
            else
            {
                patient.AddSymptom("Dizzyness");
                SymptomList.Text += "Dizzyness ";
            }
        }

        private void Sweating_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Diarrhea "))
            {

            }
            else
            {
                patient.AddSymptom("Sweating");
                SymptomList.Text += "Sweating ";
            }
        }

        private void Night_Terrors_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Night Terrors "))
            {

            }
            else
            {
                patient.AddSymptom("Night Terrors");
                SymptomList.Text += "Night Terrors ";
            }
        }

        private void Depression_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Sleep Walking "))
            {

            }
            else
            {
                patient.AddSymptom("Sleep Walking");
                SymptomList.Text += "Sleep Walking ";
            }
        }

        private void Concussion_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Diarrhea "))
            {

            }
            else
            {
                patient.AddSymptom("Concussion");
                SymptomList.Text += "Concussion ";
            }
        }

        private void Blurred_Vision_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Blurred Vision "))
            {

            }
            else
            {
                patient.AddSymptom("Blurred Vision");
                SymptomList.Text += "Blurred Vision ";
            }
        }

        private void Hair_Loss_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Hair Loss "))
            {

            }
            else
            {
                patient.AddSymptom("Hair Loss");
                SymptomList.Text += "Hair Loss ";
            }
        }

        private void Bruising_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Bruising "))
            {

            }
            else
            {
                patient.AddSymptom("Bruising");
                SymptomList.Text += "Bruising ";
            }
        }

        private void General_Pain_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("General Pain "))
            {

            }
            else
            {
                patient.AddSymptom("General Pain");
                SymptomList.Text += "General Pain ";
            }
        }

        private void Light_Sensitivity_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Light Sensitivity "))
            {

            }
            else
            {
                patient.AddSymptom("Light Sensitivity");
                SymptomList.Text += "Light Sensitivity ";
            }
        }

        private void Sexual_Impotency_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Sexual Impotency "))
            {

            }
            else
            {
                patient.AddSymptom("Sexual Impotency");
                SymptomList.Text += "Sexual Impotency ";
            }
        }

        private void Fainting_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Fainting "))
            {

            }
            else
            {
                patient.AddSymptom("Fainting");
                SymptomList.Text += "Fainting ";
            }
        }

        private void Chills_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Chills "))
            {

            }
            else
            {
                patient.AddSymptom("Chills");
                SymptomList.Text += "Chills ";
            }
        }

        private void Fever_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Fever "))
            {

            }
            else
            {
                patient.AddSymptom("Fever");
                SymptomList.Text += "Fever ";
            }
            
        }

        private void Sneezing_Click(object sender, RoutedEventArgs e)
        {
            if (SymptomList.Text.Contains("Sneezing "))
            {

            }
            else
            {
                patient.AddSymptom("Sneezing");
                SymptomList.Text += "Sneezing ";
            }
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            patient.ClearSymptoms();
            SymptomList.Text = "";
        }

        private void Done_Click(object sender, RoutedEventArgs e)
        {
            Hospital.Database dataBase = new Hospital.Database();
            dataBase.Save(patient);
            this.Hide();
            Schedule schedule = new Schedule(patient);
            schedule.ShowDialog();
        }

        private void SymptomList_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
