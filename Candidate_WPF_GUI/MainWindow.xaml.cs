using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;
using CandidateManagement_Service.Service;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private IHRAccountService _service;
        public MainWindow()
        {
            InitializeComponent();
            _service = new HRAccountService();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnSignIn_Click(object sender, RoutedEventArgs e)
        {
            var hraccount = _service.GetHraccountByEmail(txtEmail1.Text);
            if(hraccount != null && hraccount.Password == txtPassword1.Password)
            {
                 var jobPostingWindow = new JobPostingWindow(hraccount.MemberRole);
                 jobPostingWindow.Show();
                this.Close();
                /*var CandidateProfileWindow = new CandidateProfileWindow();
                CandidateProfileWindow.Show();*/
            }
            else MessageBox.Show("Who Are You");
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}