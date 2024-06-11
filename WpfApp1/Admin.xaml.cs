using Models;
using AssignmentObjectives.Repository;
using Data;
using ManageHotel.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfApp1.view;

namespace WpfApp1
{
    public partial class Admin : Window
    {
        private readonly CustomerService _customerService;
        private ObservableCollection<Customer> _customers;

        public Admin()
        {
            InitializeComponent();

            var customerContext = new DAOContext();
            var customerRepo = new CustomerRepository(customerContext);
            _customerService = new CustomerService(customerRepo);

            RefreshCustomerList();
        }

        private void RefreshCustomerList()
        {
            _customers = new ObservableCollection<Customer>(_customerService.GetAllCustomers());
            CustomerDataGrid.ItemsSource = _customers;
        }

        private void AddCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            AddDialog addDialog = new AddDialog();
            addDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            bool? result = addDialog.ShowDialog();

            if (result == true)
            {
                RefreshCustomerList();
            }
        }

        private void UpdateCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                UpdateDialog updateDialog = new UpdateDialog(selectedCustomer);
                updateDialog.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                bool? result = updateDialog.ShowDialog();

                if (result == true)
                {
                    int index = _customers.IndexOf(selectedCustomer);
                    if (index != -1)
                    {
                        _customers[index] = updateDialog.SubCustomer;
                        CustomerDataGrid.Items.Refresh(); // Refresh the DataGrid to reflect updated data
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to update.");
            }
        }

        private void DeleteCustomerButton_Click(object sender, RoutedEventArgs e)
        {
            if (CustomerDataGrid.SelectedItem is Customer selectedCustomer)
            {
                var result = MessageBox.Show($"Are you sure you want to delete customer {selectedCustomer.CustomerFullName}?",
                                             "Confirmation",
                                             MessageBoxButton.YesNo,
                                             MessageBoxImage.Question);

                if (result == MessageBoxResult.Yes)
                {
                    _customerService.DeleteCustomerByID(selectedCustomer.CustomerID);
                    RefreshCustomerList();
                    MessageBox.Show("Delete Successfully");
                }
            }
            else
            {
                MessageBox.Show("Please select a customer to delete.");
            }
        }
    }
}
