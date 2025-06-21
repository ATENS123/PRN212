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
using System;
using System.Windows;
using BusinessObject;

namespace HuynhPhucTanWPF
{
    public partial class CustomerDialog : Window
    {
        public Customer Customer { get; private set; }

        public CustomerDialog()
        {
            InitializeComponent();
            dpBirthday.SelectedDate = DateTime.Today;
        }

        public CustomerDialog(Customer existing) : this()
        {
            Customer = existing;

            txtName.Text = existing.CustomerFullName;
            txtEmail.Text = existing.EmailAddress;
            txtPhone.Text = existing.Telephone;
            txtPassword.Password = existing.Password;
            dpBirthday.SelectedDate = existing.CustomerBirthday;
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtEmail.Text) ||
                string.IsNullOrWhiteSpace(txtPassword.Password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                return;
            }

            if (Customer == null)
            {
                // Nếu thêm mới
                Customer = new Customer(0, txtName.Text, txtEmail.Text, txtPhone.Text,
                                        dpBirthday.SelectedDate ?? DateTime.Today, 1, txtPassword.Password);
            }
            else
            {
                // Nếu sửa
                Customer.CustomerFullName = txtName.Text;
                Customer.EmailAddress = txtEmail.Text;
                Customer.Telephone = txtPhone.Text;
                Customer.Password = txtPassword.Password;
                Customer.CustomerBirthday = dpBirthday.SelectedDate ?? DateTime.Today;
            }

            DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;
        }
    }
}