using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Data;
using AuthViewModel;

namespace PlexShareApp
{
    /// <summary>
    /// Interaction logic for AuthenticationView.xaml
    /// </summary>
    public partial class AuthenticationView : Window
    {
        public AuthenticationView()
        {
            InitializeComponent();

            AuthenticationViewModel viewModel = new AuthenticationViewModel();
            this.DataContext = viewModel;
        }

        /* Manual Authentication */
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            AuthenticationViewModel viewModel = this.DataContext as AuthenticationViewModel;
            if (string.IsNullOrEmpty(this.Name.Text) || string.IsNullOrEmpty(this.Smail.Text))
            {

                this.Name.Text = String.Empty;
                this.Smail.Text = String.Empty;

                if (string.IsNullOrEmpty(this.Name.Text))
                    this.NameBlock.Text = "Please fill this information";

                if (string.IsNullOrEmpty(this.Smail.Text))
                    this.SmailBlock.Text = "Please fill this information";
            } else
            {
                string smail = this.Smail.Text;
                var returnVal = viewModel.AuthenticateUser(smail);

                if (returnVal == true)
                {
                    var homePage = new HomePageView();

                    homePage.Show();
                    Close();
                } else
                {
                    this.Name.Text = String.Empty;
                    this.Smail.Text = String.Empty;

                    this.NameBlock.Text = "Please fill this information";
                    this.SmailBlock.Text = "Please enter your smail email ID";

                }
            }           
        }

        private void SmailTextChanged(object sender, RoutedEventArgs e)
        {
            this.SmailBlock.Text = ""; 
        }

        private void NameTextChanged(object sender, RoutedEventArgs e)
        {
            this.NameBlock.Text = "";
        }

    }
}
