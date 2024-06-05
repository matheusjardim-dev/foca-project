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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace foca_project.Views.Templates
{
    /// <summary>
    /// Interação lógica para Sidebar.xam
    /// </summary>
    public partial class Sidebar : Page
    {
        private readonly Action<Page> _navigateToPage;

        public Sidebar(Action<Page> navigateToPage)
        {
            InitializeComponent();
            _navigateToPage = navigateToPage;
        }

        public void AddFolderToSidebar(string folderTitle)
        {
            TreeViewItem folderItem = new TreeViewItem { Header = folderTitle };
            folderItem.Selected += (sender, args) =>
            {
                _navigateToPage(new TaskPage(folderTitle));
            };

            var homeItem = barra_lateral.Items[0] as TreeViewItem;
            homeItem?.Items.Add(folderItem);
        }

        private void Home_Selected(object sender, RoutedEventArgs e)
        {
            _navigateToPage(new HomePage(AddFolderToSidebar));
        }

        private void NovaPasta_Selected(object sender, RoutedEventArgs e)
        {
            NewFolderPage newFolderPage = new NewFolderPage();
            newFolderPage.NewFolderCreated += (s, folderTitle) =>
            {
                var homePage = new HomePage(AddFolderToSidebar);
                homePage.AddNewFolderToGrid(folderTitle);
                _navigateToPage(homePage);
            };
            _navigateToPage(newFolderPage);
        }
    }
}
