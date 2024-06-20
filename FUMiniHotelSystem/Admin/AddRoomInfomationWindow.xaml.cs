using BusinessObject;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;
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

namespace FUMiniHotelSystem.Admin
{
    /// <summary>
    /// Interaction logic for AddRoomInfomationWindow.xaml
    /// </summary>
    public partial class AddRoomInfomationWindow : Window
    {
        private readonly RoomInfomationRepository roomInfomationRepository;
        private readonly RoomTypeRepository roomTypeRepository;
        private readonly RoomInformation roomInformation;
        public AddRoomInfomationWindow(RoomInformation existingRoomInformation = null)
        {
            InitializeComponent();
            roomInfomationRepository = new RoomInfomationRepository();
            roomTypeRepository = new RoomTypeRepository();
            roomInformation = existingRoomInformation ?? new RoomInformation();
            LoadRoomType();

            if (existingRoomInformation != null)
            {
                tbRoomId.Text = roomInformation.RoomId.ToString();
                tbRoomNum.Text = roomInformation.RoomNumber;
                tbRoomDes.Text = roomInformation.RoomDetailDescription;
                tbPrice.Text = roomInformation.RoomPricePerDay.ToString();
                tbMaxCapa.Text = roomInformation.RoomMaxCapacity.ToString();
                if (roomInformation.RoomTypeId.HasValue)
                {
                    cbRoomType.SelectedValue = roomInformation.RoomTypeId.Value;
                }
                checkBoxStatus.IsChecked = roomInformation.RoomStatus.HasValue
                 ? (roomInformation.RoomStatus.Value == 1)
                 : (bool?)null;

            }
        }

        private void LoadRoomType()
        {
            var roomTypes = roomTypeRepository.GetRoomTypes();
            cbRoomType.ItemsSource = roomTypes;
            cbRoomType.DisplayMemberPath = "RoomTypeName";
            cbRoomType.SelectedValuePath = "RoomTypeId";
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string roomNum = tbRoomNum.Text;
                string roomDes = tbRoomDes.Text;
                int? roomType = (int?)cbRoomType.SelectedValue;
                bool? status = checkBoxStatus.IsChecked;
                string priceText = tbPrice.Text;
                string maxCapaText = tbMaxCapa.Text;
                string roomIdText = tbRoomId.Text;

                if (string.IsNullOrWhiteSpace(roomNum) || roomType == null || string.IsNullOrWhiteSpace(priceText) || string.IsNullOrWhiteSpace(maxCapaText))
                {
                    MessageBox.Show("Please enter all required fields: Room Number, Room Type, Price, and Max Capacity.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!decimal.TryParse(priceText, out decimal price))
                {
                    MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                if (!int.TryParse(maxCapaText, out int maxCapa))
                {
                    MessageBox.Show("Please enter a valid max capacity.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                bool isNewRecord = string.IsNullOrWhiteSpace(roomIdText) || roomIdText == "0";

                RoomInformation roomInformation = new RoomInformation
                {
                    RoomNumber = roomNum,
                    RoomDetailDescription = roomDes,
                    RoomTypeId = roomType.Value,
                    RoomPricePerDay = price,
                    RoomStatus = status.HasValue ? (byte?)(status.Value ? 1 : 0) : null,
                    RoomMaxCapacity = maxCapa
                };

                if (isNewRecord)
                {
                    roomInfomationRepository.Insert(roomInformation);
                    MessageBox.Show("Room information added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    if (!int.TryParse(roomIdText, out int roomId))
                    {
                        MessageBox.Show("Please enter a valid room ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Error);
                        return;
                    }
                    roomInformation.RoomId = roomId;
                    roomInfomationRepository.Update(roomInformation);
                    MessageBox.Show("Room information updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                }

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving the room information: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }




        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

}