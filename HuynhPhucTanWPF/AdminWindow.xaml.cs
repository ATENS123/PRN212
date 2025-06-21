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
using BusinessObject;
using Service;

namespace HuynhPhucTanWPF
{
    /// <summary>
    /// Interaction logic for AdminWindow.xaml
    /// </summary>
    public partial class AdminWindow : Window
    {
        private readonly CustomerService customerService = new CustomerService();
        private readonly RoomService roomService = new RoomService();
        private readonly BookingService bookingService = new BookingService();
        public AdminWindow()
        {
            InitializeComponent();
            LoadCustomers();
            LoadRooms();
        }

        private void LoadCustomers()
        {
            dgCustomers.ItemsSource = customerService.GetAllCustomers();
        }

        private void BtnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new CustomerDialog(); // bạn cần tạo dialog này
            if (dialog.ShowDialog() == true)
            {
                customerService.AddCustomer(dialog.Customer);
                LoadCustomers();
            }
        }

        private void BtnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                var dialog = new CustomerDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    customerService.UpdateCustomer(dialog.Customer);
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng để cập nhật.");
            }
        }

        private void BtnDeleteCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (dgCustomers.SelectedItem is Customer selected)
            {
                if (MessageBox.Show($"Xoá khách hàng {selected.CustomerFullName}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    customerService.DeleteCustomer(selected.CustomerID);
                    LoadCustomers();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn khách hàng cần xoá.");
            }
        }

        private void BtnSearchCustomer_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchCustomer.Text.Trim().ToLower();
            var result = customerService.GetAllCustomers()
                          .Where(c => c.CustomerFullName.ToLower().Contains(keyword) || c.EmailAddress.ToLower().Contains(keyword))
                          .ToList();
            dgCustomers.ItemsSource = result;
        }
        private void LoadRooms()
        {
            dgRooms.ItemsSource = roomService.GetAllRooms();
        }

        private void BtnAddRoom_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new RoomDialog(); // bạn cần tạo RoomDialog
            if (dialog.ShowDialog() == true)
            {
                roomService.AddRoom(dialog.Room);
                LoadRooms();
            }
        }

        private void BtnUpdateRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is Room selected)
            {
                var dialog = new RoomDialog(selected);
                if (dialog.ShowDialog() == true)
                {
                    roomService.UpdateRoom(dialog.Room);
                    LoadRooms();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng để cập nhật.");
            }
        }

        private void BtnDeleteRoom_Click(object sender, RoutedEventArgs e)
        {
            if (dgRooms.SelectedItem is Room selected)
            {
                if (MessageBox.Show($"Xoá phòng {selected.RoomNumber}?", "Xác nhận", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    roomService.DeleteRoom(selected.RoomID);
                    LoadRooms();
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng cần xoá.");
            }
        }

        private void BtnSearchRoom_Click(object sender, RoutedEventArgs e)
        {
            string keyword = txtSearchRoom.Text.Trim().ToLower();
            var result = roomService.GetAllRooms()
                          .Where(r => r.RoomNumber.ToLower().Contains(keyword))
                          .ToList();
            dgRooms.ItemsSource = result;
        }

        // -------- BOOKING REPORT --------

        private void BtnGenerateReport_Click(object sender, RoutedEventArgs e)
        {
            DateTime start = dpStart.SelectedDate ?? DateTime.MinValue;
            DateTime end = dpEnd.SelectedDate ?? DateTime.MaxValue;

            var bookings = bookingService.GetAllBookings()
                .Where(b => b.StartDate >= start && b.EndDate <= end)
                .OrderByDescending(b => b.TotalPrice)
                .ToList();

            // mapping thêm thông tin Customer và Room để hiển thị
            foreach (var b in bookings)
            {
                b.Customer = customerService.GetCustomerById(b.CustomerID);
                b.Room = roomService.GetRoomById(b.RoomID);
            }

            dgReport.ItemsSource = bookings;
        }
    }
}
