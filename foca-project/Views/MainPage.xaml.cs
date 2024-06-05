using foca_project.Views.Templates;
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

namespace foca_project.Views
{
    /// <summary>
    /// Interação lógica para MainPage.xam
    /// </summary>
    public partial class MainPage : Page
    {
        private Templates.Sidebar _sidebar;

        public MainPage()
        {
            _sidebar = new Templates.Sidebar(NavigateToPage);
            InitializeComponent();
            barra_lateral.Navigate(_sidebar);
            principal.Navigate(new HomePage(AddFolderToSidebar));
        }

        private void NavigateToPage(Page page)
        {
            principal.Navigate(page);
        }

        private void AddFolderToSidebar(string folderTitle)
        {
            _sidebar.AddFolderToSidebar(folderTitle);
        }
    }
}
