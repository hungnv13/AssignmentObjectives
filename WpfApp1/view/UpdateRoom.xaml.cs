using Models;
using ManageHotel.Service;
using System.Windows;

namespace WpfApp1.view
{
    public partial class UpdateRoom : Window
    {
        private readonly RoomInformation _room;
        private readonly RoomService _roomService;
        public RoomInformation subRoom { get; private set; }

        public UpdateRoom(RoomInformation room, RoomService roomService)
        {
            InitializeComponent();
            _room = room;
            _roomService = roomService;
            PopulateRoomDetails();
        }

        private void PopulateRoomDetails()
        {
            RoomNumberTextBox.Text = _room.RoomNumber;
            RoomDescriptionTextBox.Text = _room.RoomDetailDescription;
            RoomMaxCapacityTextBox.Text = _room.RoomMaxCapacity.ToString();
            RoomPricePerDate.Text = _room.RoomPricePerDay.ToString();
            RoomStatus.SelectedIndex = _room.RoomStatus - 1;
            RoomTypeIDTextBox.Text = _room.RoomTypeID.ToString();
        }

        private void UpdateRoomButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.TryParse(RoomMaxCapacityTextBox.Text, out int maxCapacity) &&
                decimal.TryParse(RoomPricePerDate.Text, out decimal pricePerDay) &&
                int.TryParse(RoomTypeIDTextBox.Text, out int roomTypeID))
            {
                _room.RoomNumber = RoomNumberTextBox.Text;
                _room.RoomDetailDescription = RoomDescriptionTextBox.Text;
                _room.RoomMaxCapacity = maxCapacity;
                _room.RoomPricePerDay = pricePerDay;
                _room.RoomStatus = (byte)(RoomStatus.SelectedIndex + 1);
                _room.RoomTypeID = roomTypeID;

                _roomService.UpdateRoom(_room);

                subRoom = _room;
                DialogResult = true;
                Close();
            }
            else
            {
                MessageBox.Show("Please enter valid data for all fields.");
            }
        }
    }
}