using BusinessObject;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FUMiniHotelSystem.Admin
{
    /// <summary>
    /// Interaction logic for RoomInfoManager.xaml
    /// </summary>
    public partial class RoomInfoManager : Page
    {
        private readonly RoomInfomationRepository roomInfomationRepository;
        public RoomInfoManager()
        {
            InitializeComponent();
            roomInfomationRepository = new RoomInfomationRepository();
            LoadRoomInfo();
        }
        private void LoadRoomInfo()
        {
            var bi = roomInfomationRepository.GetRoomInformations();
            lvRi.ItemsSource = bi;
        }
        private void Button_Click_Insert(object sender, RoutedEventArgs e)
        {
            var addRoomInfo = new AddRoomInfomationWindow();
            addRoomInfo.ShowDialog();
            LoadRoomInfo();

        }

        private void Button_Click_Update(object sender, RoutedEventArgs e)
        {
            if (lvRi.SelectedItem != null)
            {
                var selectedRoomInformation = (RoomInformation)lvRi.SelectedItem;
                var addRoomInformationWindow = new AddRoomInfomationWindow(selectedRoomInformation);
                addRoomInformationWindow.ShowDialog();
                LoadRoomInfo();
            }
        }

        private void Button_Click_Delete(object sender, RoutedEventArgs e)
        {
            if (lvRi.SelectedItem != null)
            {
                var selectedRoomInformation = (RoomInformation)lvRi.SelectedItem;
                var result = MessageBox.Show("Are you sure you want to delete this room infomation?", "Delete Infomation", MessageBoxButton.YesNo, MessageBoxImage.Question);
                if (result == MessageBoxResult.Yes)
                {
                    var isDeleted = roomInfomationRepository.Delete(selectedRoomInformation.RoomId);
                    if (isDeleted)
                    {
                        MessageBox.Show("RoomInformation deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                    else
                    {
                        MessageBox.Show("RoomInformation cannot be deleted.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    LoadRoomInfo();
                }
            }
        }

        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            tbSearch.Text = tbSearch.Text.Trim();
            string searchTerm = tbSearch.Text;

            if (!string.IsNullOrEmpty(searchTerm))
            {
                var searchResults = roomInfomationRepository.SearchRoomInformationsByRoomNum(searchTerm);
                lvRi.ItemsSource = searchResults;
            }
            else
            {
                LoadRoomInfo();
            }
        }
        private void TbSearch_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !IsTextAllowed(e.Text);
        }

        private static bool IsTextAllowed(string text)
        {
            Regex regex = new Regex("[^0-9]+");
            return !regex.IsMatch(text);
        }
    }
}
