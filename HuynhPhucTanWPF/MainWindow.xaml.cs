using System.Text;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Linq;
using System.Windows;
using BusinessObject;
using Service;

namespace HuynhPhucTanWPF
{
    public partial class MainWindow : Window
    {
        private readonly Customer currentCustomer;
        private readonly CustomerService customerService = new CustomerService();
        private readonly BookingService bookingService = new BookingService();

        public MainWindow(Customer customer)
        {
            InitializeComponent();
            currentCustomer = customer; // ✅ Gán customer truyền vào

            LoadProfile();
            LoadBookingHistory();
        }

        private void LoadProfile()
        {
            txtFullName.Text = currentCustomer.CustomerFullName;
            txtEmail.Text = currentCustomer.EmailAddress;
            txtPhone.Text = currentCustomer.Telephone;
        }

        private void LoadBookingHistory()
        {
            var bookings = bookingService.GetAllBookings()
                .Where(b => b.CustomerID == currentCustomer.CustomerID)
                .ToList();

            // Gán thêm Room info nếu cần
            var roomService = new RoomService();
            foreach (var booking in bookings)
            {
                booking.Room = roomService.GetRoomById(booking.RoomID);
            }

            dgBookings.ItemsSource = bookings;
        }

        private void BtnUpdateProfile_Click(object sender, RoutedEventArgs e)
        {
            currentCustomer.CustomerFullName = txtFullName.Text;
            currentCustomer.Telephone = txtPhone.Text;

            customerService.UpdateCustomer(currentCustomer);
            MessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}