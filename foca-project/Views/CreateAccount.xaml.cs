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
using foca_project.Models;
using foca_project.ViewModels;

namespace foca_project.Views
{
    /// <summary>
    /// Lógica interna para CreateAccount.xaml
    /// </summary>
    public partial class CreateAccount : Window
    {
        private readonly UserVM _UserVM = new UserVM();
        public CreateAccount()
        {
            InitializeComponent();
            botaoConfirmar.Click += ClickButton;
        }

        private void ClickButton(object sender, RoutedEventArgs e)
        {
            createUser();
        }

        private void CampoNome_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void GotFocus(object sender, RoutedEventArgs e)
        {
            if (campoNome.Text == "Nome")
            {
                campoNome.Text = "";
            }
        }

        private void LostFocus(object sender, RoutedEventArgs e)
        {
            if (campoNome.Text ==  null)
            {
                campoNome.Text = "Nome";
            }
        }

        private bool createUser()
        {
            if(
                string.IsNullOrWhiteSpace(campoNome.Text) ||
                string.IsNullOrWhiteSpace(campoEmail.Text) || 
                string.IsNullOrWhiteSpace(campoSenha.Text)
                )
            {
                MessageBox.Show("Preencha todos os campos");
                return false;
            }

            User _user = new()
            {
                Name = campoNome.Text,
                Email = campoEmail.Text,
                Password = campoSenha.Text
            };
            _UserVM.CreateUser(_user);
            return true;
        }
    }
}
