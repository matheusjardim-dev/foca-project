﻿using foca_project.Views.Templates;
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
    /// Interação lógica para TaskPage.xam
    /// </summary>
    public partial class TaskPage : Page
    {
        public TaskPage(string nome)
        {
            InitializeComponent();
            page_titulo.Content = nome;

            NavegarParaTask();
        }

        private void NavegarParaTask()
        {
            frame_task.Navigate(new Activity("teste"));
        }
    }
}
