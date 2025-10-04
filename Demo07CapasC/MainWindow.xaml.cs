using System;
using System.Collections.Generic;
using System.Windows;
using Entity;
using Business;

namespace Demo07CapasC
{
    public partial class MainWindow : Window
    {
        private BCustomer bCustomer = new BCustomer();
        private int selectedId = 0;

        public MainWindow()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            dataGrid.ItemsSource = null;
            dataGrid.ItemsSource = bCustomer.Read();
        }

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            Customer c = new Customer
            {
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            bCustomer.Create(c);
            LoadData();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId == 0) return;
            Customer c = new Customer
            {
                CustomerId = selectedId,
                Name = txtName.Text,
                Address = txtAddress.Text,
                Phone = txtPhone.Text
            };
            bCustomer.Update(c);
            LoadData();
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (selectedId == 0) return;
            bCustomer.Delete(selectedId);
            LoadData();
        }

        private void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void DataGrid_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (dataGrid.SelectedItem is Customer c)
            {
                selectedId = c.CustomerId;
                txtName.Text = c.Name;
                txtAddress.Text = c.Address;
                txtPhone.Text = c.Phone;
            }
        }
    }
}
