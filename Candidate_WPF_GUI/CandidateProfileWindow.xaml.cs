using CandidateManagement_BusinessObject.Models;
using CandidateManagement_Service.Interface;
using CandidateManagement_Service.Service;
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

namespace Candidate_WPF_GUI
{
    /// <summary>
    /// Interaction logic for CandidateProfileWindow.xaml
    /// </summary>
    public partial class CandidateProfileWindow : Window
    {
        private int? RoleID;
        private readonly ICandidateProfileService _service;
        private readonly IJobPostingService _postingService;

        public CandidateProfileWindow()
        {
            InitializeComponent();
            _service = new CandidateProfileService();
            _postingService = new JobPostingService();
        }
        public CandidateProfileWindow(int? roleId)
        {
            InitializeComponent();
            _service = new CandidateProfileService();
            _postingService = new JobPostingService();
            RoleID = roleId;
            switch (RoleID)
            {
                case 1:
                    break;
                case 2:
                    this.btnAdd.IsEnabled = false;
                    break;
                default:
                    break;
            }
        }
        
    private void dtgJobPost_Loaded(object sender, RoutedEventArgs e)
        {
            dtgJobPost.ItemsSource = _service.GetCandidateProfiles();
        }

        private void cmbJobPosting_Loaded(object sender, RoutedEventArgs e)
        {
            var JobTitles = _postingService.GetJobPostings().Select(c => c.JobPostingTitle).ToList();
            cmbJobPosting.ItemsSource = JobTitles;
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCandidateID.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(BirthdayDate.Text) ||
                string.IsNullOrWhiteSpace(cmbJobPosting.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }
            DateTime birthday;
            if (!DateTime.TryParse(BirthdayDate.Text, out birthday))
            {
                MessageBox.Show("Please enter a valid date.");
                return;
            }
            var jobPosting = _postingService.GetJobPostings().SingleOrDefault(c => c.JobPostingTitle == cmbJobPosting.Text);
            if (jobPosting == null)
            {
                MessageBox.Show("Job posting not found.");
                return;
            }

            var Candidate = new CandidateProfile
            {
                CandidateId = txtCandidateID.Text,
                Fullname = txtFullName.Text,
                ProfileUrl = txtImageURL.Text,
                Birthday = birthday,
                ProfileShortDescription = txtDescription.Text,
                Posting = jobPosting
            };

            if (_service.AddCandidateProfile(Candidate))
            {
                MessageBox.Show("Added successfully.");
                dtgJobPost.ItemsSource = _service.GetCandidateProfiles();
            }
            else
            {
                MessageBox.Show("Error adding candidate.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            var success = _service.DeleteCandidateProfile(txtCandidateID.Text);
            if (success)
            {
                MessageBox.Show("Deleted successfully.");
                dtgJobPost.ItemsSource = _service.GetCandidateProfiles();
            }
            else
            {
                MessageBox.Show("Error deleting candidate.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCandidateID.Text) ||
                string.IsNullOrWhiteSpace(txtFullName.Text) ||
                string.IsNullOrWhiteSpace(BirthdayDate.Text) ||
                string.IsNullOrWhiteSpace(cmbJobPosting.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }
            DateTime birthday;
            if (!DateTime.TryParse(BirthdayDate.Text, out birthday))
            {
                MessageBox.Show("Please enter a valid date.");
                return;
            }
            var jobPosting = _postingService.GetJobPostings().SingleOrDefault(c => c.JobPostingTitle == cmbJobPosting.Text);
            if (jobPosting == null)
            {
                MessageBox.Show("Job posting not found.");
                return;
            }

            var Candidate = new CandidateProfile
            {
                CandidateId = txtCandidateID.Text,
                Fullname = txtFullName.Text,
                ProfileUrl = txtImageURL.Text,
                Birthday = birthday,
                ProfileShortDescription = txtDescription.Text,
                Posting = jobPosting
            };

            if (_service.UpdateCandidateProfile(Candidate))
            {
                MessageBox.Show("Updated successfully.");
                // Refresh data grid
                dtgJobPost.ItemsSource = _service.GetCandidateProfiles();
            }
            else
            {
                MessageBox.Show("Error updating candidate.");
            }
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void dtgJobPost_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGrid dataGrid = sender as DataGrid;
            DataGridRow row = dataGrid.ItemContainerGenerator.
                ContainerFromIndex(dataGrid.SelectedIndex)
                as DataGridRow;
            if (row != null) {
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id =  ((TextBlock)RowColumn.Content).Text;
                var profile = _service.GetCandidateProfile(id);
                if (profile != null)
                {
                    txtCandidateID.Text = profile.CandidateId;
                    txtDescription.Text = profile.ProfileShortDescription;
                    txtFullName.Text = profile.Fullname;
                    txtImageURL.Text = profile.ProfileUrl;
                    BirthdayDate.Text = profile.Birthday.ToString();
                    cmbJobPosting.SelectedValue = profile.PostingId;

                }
            }
        }

        private void btnJPW_Click(object sender, RoutedEventArgs e)
        {
            var JPW = new JobPostingWindow(RoleID);
            JPW.Show();
            this.Close();
        }
    }
}
