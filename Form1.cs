using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BMI_CALCULATOR
{
    public partial class form1 : Form
    {
        List<User> Users = new List<User>();
        public form1()
        {
            InitializeComponent();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
{
    try
    {
        string nameInput = NameTextBox.Text.Trim();
        if (string.IsNullOrWhiteSpace(nameInput) || !Regex.IsMatch(nameInput, @"^[a-zA-Z\s]+$"))
        {
            MessageBox.Show("Please enter a valid name (letters and spaces only).");
            return;
        }

        if (!int.TryParse(AgeTextBox.Text, out int age) ||
            !double.TryParse(WeightTextBox.Text, out double weight) ||
            !double.TryParse(HeightTextBox.Text, out double height))
        {
            MessageBox.Show("Please enter valid numeric values for age, weight, and height.");
            return;
        }

        User _user = new User
        {
            Name = nameInput,
            Age = age,
            Weight = weight,
            HeightCm = height
        };

        _user.CalculateBmI();
        Users.Add(_user);
        MessageBox.Show($"Hello {_user.Name}\nYour BMI is: {_user.BMI:F2}\n{_user.Category}");
        SaveUserInfo(_user.Name, _user.HeightCm, _user.Weight, _user.BMI);
    }
    catch (Exception ex)
    {
        MessageBox.Show("Error: " + ex.Message);
    }
}

        private void ClearButton_Click(object sender, EventArgs e)
        {
            NameTextBox.Clear();
            AgeTextBox.Clear();
            WeightTextBox.Clear();
            HeightTextBox.Clear();
        }

        private void form1_Load(object sender, EventArgs e)
        {

        }
        // add file handling to save user info
        private void SaveUserInfo(string name, double height, double weight, double bmi)
        {
            try
            {
                // Save the file to your Documents folder
                string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                string path = Path.Combine(folder, "save.txt");

                string data = $"{DateTime.Now}: Name: {name}, Height: {height}, Weight: {weight}, BMI: {bmi:F2}";
                File.AppendAllText(path, data + Environment.NewLine);

                MessageBox.Show("User info saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to save user info: " + ex.Message);
            }
        }
    }
}
