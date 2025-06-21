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
    public partial class RoomDialog : Window
    {
        public Room Room { get; private set; }

        public RoomDialog()
        {
            InitializeComponent();
            cboStatus.SelectedIndex = 0;
        }

        public RoomDialog(Room existing) : this()
        {
            Room = existing;
            txtNumber.Text = existing.RoomNumber;
            txtDescription.Text = existing.RoomDescription;
            txtCapacity.Text = existing.RoomMaxCapacity?.ToString();
            txtPrice.Text = existing.RoomPricePerDate?.ToString();
            cboStatus.SelectedIndex = existing.RoomStatus == 1 ? 0 : 1;
            txtRoomTypeId.Text = existing.RoomTypeID?.ToString();
        }

        private void BtnOK_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNumber.Text) ||
                string.IsNullOrWhiteSpace(txtCapacity.Text) ||
                string.IsNullOrWhiteSpace(txtPrice.Text) ||
                string.IsNullOrWhiteSpace(txtRoomTypeId.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin bắt buộc.");
                return;
            }

            int.TryParse(txtCapacity.Text, out int capacity);
            int.TryParse(txtRoomTypeId.Text, out int typeId);
            decimal.TryParse(txtPrice.Text, out decimal price);

            int status = ((ComboBoxItem)cboStatus.SelectedItem).Tag.ToString() == "1" ? 1 : 0;

            if (Room == null)
            {
                // Add
                Room = new Room(0, txtNumber.Text, txtDescription.Text, capacity, status, price, typeId);
            }
            else
            {
                // Update
                Room.RoomNumber = txtNumber.Text;
                Room.RoomDescription = txtDescription.Text;
                Room.RoomMaxCapacity = capacity;
                Room.RoomStatus = status;
                Room.RoomPricePerDate = price;
                Room.RoomTypeID = typeId;
            }

            this.DialogResult = true;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
