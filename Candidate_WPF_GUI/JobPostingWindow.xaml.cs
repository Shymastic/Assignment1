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
    public partial class JobPostingWindow : Window
    {
        private int? RoleID;
        private readonly IJobPostingService _jobPostingService;

        public JobPostingWindow()
        {
            InitializeComponent();
            _jobPostingService = new JobPostingService();
        }
        public JobPostingWindow(int? roleId)
        {
            InitializeComponent();
            _jobPostingService = new JobPostingService();
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
            dtgJobPost.ItemsSource = _jobPostingService.GetJobPostings();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
           
            if (string.IsNullOrWhiteSpace(txtPostID.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                txtPostDate.Text == null)
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            var job = new JobPosting
            {
                PostingId = txtPostID.Text,
                JobPostingTitle = txtTitle.Text,
                Description = txtDescription.Text,
                PostedDate = DateTime.Parse(txtPostDate.Text), 
            };

            bool success = _jobPostingService.AddJobPosting(job);

            if (success)
            {
                MessageBox.Show("Job posting added successfully.");
                dtgJobPost.ItemsSource = _jobPostingService.GetJobPostings();
            }
            else
            {
                MessageBox.Show("Error adding job posting.");
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostID.Text))
            {
                MessageBox.Show("Please enter a Post ID.");
                return;
            }

            var success = _jobPostingService.DeleteJobPosting(txtPostID.Text);

            if (success)
            {
                MessageBox.Show("Job posting deleted successfully.");
                dtgJobPost.ItemsSource = _jobPostingService.GetJobPostings();
            }
            else
            {
                MessageBox.Show("Error deleting job posting.");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPostID.Text) ||
                string.IsNullOrWhiteSpace(txtTitle.Text) ||
                txtPostDate.Text == null)
            {
                MessageBox.Show("Please fill in all the required fields.");
                return;
            }

            var job = new JobPosting
            {
                PostingId = txtPostID.Text,
                JobPostingTitle = txtTitle.Text,
                Description = txtDescription.Text,
                PostedDate = DateTime.Parse(txtPostDate.Text),
            };

            var success = _jobPostingService.UpdateJobPosting(job);

            if (success)
            {
                MessageBox.Show("Job posting updated successfully.");
                dtgJobPost.ItemsSource = _jobPostingService.GetJobPostings();
            }
            else
            {
                MessageBox.Show("Error updating job posting.");
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
            if (row != null)
            {
                DataGridCell RowColumn = dataGrid.Columns[0].GetCellContent(row).Parent as DataGridCell;
                string id = ((TextBlock)RowColumn.Content).Text;
                var profile = _jobPostingService.GetJobPosting(id);
                if (profile != null)
                {
                    txtPostID.Text = profile.PostingId;
                    txtTitle.Text = profile.JobPostingTitle;
                    txtDescription.Text = profile.Description;
                    txtPostDate.Text = profile.PostedDate.ToString();
                }
            }
        }


        private void btnCP_Click(object sender, RoutedEventArgs e)
        {
            var CPW = new CandidateProfileWindow(RoleID);
            CPW.Show();
            this.Close();
        }
    }
}
