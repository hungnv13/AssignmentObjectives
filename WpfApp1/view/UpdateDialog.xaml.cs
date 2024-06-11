using Models;
using AssignmentObjectives.Repository;
using Data;
using ManageHotel.Service;
using System;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp1.view
{
    public partial class UpdateDialog : Window
    {
        private readonly CustomerService _customerService;
        public Customer SubCustomer;
        private int CustomerID = 0;
        private Customer selectedCustomer;

        public UpdateDialog(Customer selectedCustomer)
        {
            InitializeComponent();
            var customerContext = new DAOContext();
            var customerRepo = new CustomerRepository(customerContext);
            _customerService = new CustomerService(customerRepo);

            this.selectedCustomer = selectedCustomer;

            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            FullNameTextBox.Text = selectedCustomer.CustomerFullName;
            TelephoneTextBox.Text = selectedCustomer.Telephone;
            EmailTextBox.Text = selectedCustomer.EmailAddress;
            BirthdayDatePicker.SelectedDate = selectedCustomer.CustomerBirthday;
            PasswordBox.Password = selectedCustomer.Password;
            StatusComboBox.SelectedIndex = selectedCustomer.CustomerStatus - 1;

            CustomerID = selectedCustomer.CustomerID;
        }

        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            string fullName = FullNameTextBox.Text;
            string telephone = TelephoneTextBox.Text;
            string email = EmailTextBox.Text;
            string password = PasswordBox.Password;

            if (BirthdayDatePicker.SelectedDate == null || BirthdayDatePicker.SelectedDate.Value.Year > DateTime.Now.Year - 10)
            {
                MessageBox.Show("Please select a valid Birthday.");
                return;
            }
            DateTime birthday = BirthdayDatePicker.SelectedDate.Value;

            if (StatusComboBox.SelectedItem == null)
            {
                MessageBox.Show("Please select a Status.");
                return;
            }
            string statusText = (StatusComboBox.SelectedItem as ComboBoxItem)?.Content.ToString();
            byte status = statusText == "Active" ? (byte)1 : (byte)0;

            var customer = new Customer
            {
                CustomerID = CustomerID,
                CustomerFullName = fullName,
                Telephone = telephone,
                EmailAddress = email,
                CustomerBirthday = birthday,
                CustomerStatus = status,
                Password = password
            };

            _customerService.UpdateCustomer(customer);
            SubCustomer = customer;

            MessageBox.Show("Update successfully");

            this.DialogResult = true;
            this.Close();
        }
    }
}
