using Models;
using Data;
using ManageHotel.Repository;
using ManageHotel.Service;
using System.Windows;

namespace WpfApp1
{
    public partial class HistoryWindow : Window
    {
        private readonly BookingReservationService _bookingReservationService;
        public Customer CurrentCustomer { get; set; }

        public HistoryWindow(Customer currentCus)
        {
            InitializeComponent();

            var bookingReservationContext = new DAOContext();
            var bookingReservationRepo = new BookingReservationRepository(bookingReservationContext);
            _bookingReservationService = new BookingReservationService(bookingReservationRepo);

            BookingListView.ItemsSource = _bookingReservationService.GetBookingReservationByCustomerID(currentCus.CustomerID);
            CurrentCustomer = currentCus;
        }

        private void Logout_Click(object sender, RoutedEventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Close();
        }
    }
}
