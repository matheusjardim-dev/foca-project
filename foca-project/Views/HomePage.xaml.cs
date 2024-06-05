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

namespace foca_project.Views
{
    /// <summary>
    /// Interação lógica para HomePage.xam
    /// </summary>
    public partial class HomePage : Page
    {
        DirectoryVM _DirectoryVM = new DirectoryVM();
        public HomePage()
        {
            InitializeComponent();
            ListFolders();
        }

        private void ListFolders()
        {
            _DirectoryVM.GetDirectoriesByUser(1).ForEach(directory => AddNewFolderToGrid(directory.Title));
        }

        private void AddNewFolderToGrid(string folderTitle)
        {
            StackPanel newFolder = new StackPanel
            {
                Margin = new Thickness(5)
            };

            Image folderIcon = new Image
            {
                Source = new BitmapImage(new Uri("pack://application:,,,/Resources/Icone pasta.png")),
                Height = 150,
                Width = 150
            };

            Label folderLabel = new Label
            {
                Content = folderTitle,
                HorizontalContentAlignment = HorizontalAlignment.Center,
                FontSize = 20
            };

            newFolder.Children.Add(folderIcon);
            newFolder.Children.Add(folderLabel);

            int numRows = lista_pastas_grid.RowDefinitions.Count;
            int numColumns = lista_pastas_grid.ColumnDefinitions.Count;

            for (int row = 0; row < numRows; row++)
            {
                for (int column = 0; column < numColumns; column++)
                {
                    UIElement element = lista_pastas_grid.Children.Cast<UIElement>()
                        .FirstOrDefault(e => Grid.GetRow(e) == row && Grid.GetColumn(e) == column);

                    if (element == null)
                    {
                        Grid.SetRow(newFolder, row);
                        Grid.SetColumn(newFolder, column);
                        lista_pastas_grid.Children.Add(newFolder);
                        return;
                    }
                }
            }

            lista_pastas_grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(200) });
            Grid.SetRow(newFolder, numRows);
            Grid.SetColumn(newFolder, 0);
            lista_pastas_grid.Children.Add(newFolder);
        }

        private void NewFolderPage_NewFolderCreated(object sender, string folderTitle)
        {
            AddNewFolderToGrid(folderTitle);
            frame_nova_pasta.Content = null;
        }

        private void NewFolderPage_Cancel(object sender, EventArgs e)
        {
            frame_nova_pasta.Content = null;
        }

        private void nova_pasta_Click(object sender, RoutedEventArgs e)
        {
            NewFolderPage newFolderPage = new NewFolderPage();
            newFolderPage.NewFolderCreated += NewFolderPage_NewFolderCreated;
            newFolderPage.Cancel += NewFolderPage_Cancel;
            frame_nova_pasta.Navigate(newFolderPage);
        }
    }
}
