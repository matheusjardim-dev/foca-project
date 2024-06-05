﻿using foca_project.Models;
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
using System.Windows.Shapes;

namespace foca_project.Views
{
    /// <summary>
    /// Lógica interna para EditActivityWindow.xaml
    /// </summary>
    public partial class EditActivityWindow : Window
    {
        public EditActivityWindow()
        {
            InitializeComponent();
        }


        private void data_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void concluir_Click(object sender, RoutedEventArgs e)
        {
            estado_concluido.Visibility = Visibility.Visible;
            concluir.Visibility = Visibility.Hidden;
            voltar.Visibility = Visibility.Visible;
        }

        private void voltar_Click(object sender, RoutedEventArgs e)
        {
            estado_concluido.Visibility = Visibility.Hidden;
            concluir.Visibility = Visibility.Visible;
            voltar.Visibility = Visibility.Hidden;
        }

        private void excluir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cancelar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void confirmar_Click(object sender, RoutedEventArgs e)
        {

            //aqui o código para salvar as alterações no banco
            this.Close();
        }
    }
}