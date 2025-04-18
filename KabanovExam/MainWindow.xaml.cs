using System.Windows;
using KabanovExam.Models;
using Microsoft.EntityFrameworkCore;

namespace KabanovExam
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadPartners();
        }

        private void LoadPartners()
        {
            using (var context = new KabanovExamContext())
            {
                PartnersListView.ItemsSource =
                    context.Partners
                           .Include(p => p.PartnersType)
                           .ToList();
            }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            var addEditWindow = new AddEditPartner();
            addEditWindow.ShowDialog();
            LoadPartners();
        }

        private void PartnersListView_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            var selectedPartner = (Partner)PartnersListView.SelectedItem;
            var addEditWindow = new AddEditPartner(selectedPartner);
            addEditWindow.ShowDialog();
            LoadPartners();
        }
    }
}
