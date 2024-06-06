using foca_project.Models;
using foca_project.ViewModels;
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
        ActivityVM _ActivityVM = new ActivityVM();
        
        public Sidebar(Action<Page> navigateToPage)
        {
            InitializeComponent();
            _navigateToPage = navigateToPage;
        }

        public void AddFolderToSidebar(string folderTitle)
        {
            var homeItem = barra_lateral.Items[0] as TreeViewItem;

            if (homeItem != null)
            {
                foreach (TreeViewItem item in homeItem.Items)
                {
                    if (item.Header.ToString() == folderTitle)
                    {
                        return;
                    }
                }

                TreeViewItem folderItem = new TreeViewItem { Header = folderTitle };
                folderItem.Selected += (sender, args) =>
                {
                    _navigateToPage(new TaskPage(folderTitle));
                };


                homeItem?.Items.Add(folderItem);
            }
        }

        private void Home_Selected(object sender, RoutedEventArgs e)
        {
            var selectedItem = barra_lateral.SelectedItem as TreeViewItem;
            if (selectedItem != null && selectedItem.Header.ToString() == "Home")
            {
                _navigateToPage(new HomePage(AddFolderToSidebar));
            }
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

        private void configuracoes_Click(object sender, RoutedEventArgs e)
        {
            ConfigWindow cw = new ConfigWindow();
            cw.Show();
        }
    }
}
