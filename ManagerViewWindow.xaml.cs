﻿using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using PROG_2B_POE_Part_2.Data;
using PROG_2B_POE_Part_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
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

namespace PROG_2B_POE_Part_2
{
    /// <summary>
    /// Interaction logic for ManagerViewWindow.xaml
    /// </summary>
    public partial class ManagerViewWindow : Window
    {
        private readonly AppDbContext _context;
        List<transferrableclaim> clams = new List<transferrableclaim>();
        public ManagerViewWindow(List<transferrableclaim> sent)
        {
            InitializeComponent();
            clams = sent;
            ddLoadList();
            DenyButton.Visibility = Visibility.Collapsed;
            AcceptButton.Visibility = Visibility.Collapsed;
            JustificationTextBox.Visibility = Visibility.Collapsed;
            JustificationLabel.Visibility = Visibility.Collapsed;
        }

        int keynum = 0;
        private void ClaimsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DenyButton.Visibility = Visibility.Collapsed;
            AcceptButton.Visibility = Visibility.Collapsed;
            JustificationTextBox.Visibility = Visibility.Collapsed;
            JustificationLabel.Visibility = Visibility.Collapsed;
            string sel = "";
            string subsel = "";
            int com = 0;
            if (ClaimsListBox.SelectedItem != null)
            {
                sel = ClaimsListBox.SelectedItem.ToString();
                com = sel.IndexOf(",");
                subsel = sel.Substring(0, com);
                keynum = int.Parse(subsel);
            }
            Populate(clams[keynum-1]);
            if (clams[keynum-1].Status == "Pending")
            {
                DenyButton.Visibility = Visibility.Visible;
                AcceptButton.Visibility = Visibility.Visible;
                JustificationTextBox.Visibility = Visibility.Visible;
                JustificationLabel.Visibility = Visibility.Visible;
            }

        }

        public void Populate(transferrableclaim claim)
        {
            ClaimIDTextBox.Text = claim.ClaimId.ToString();
            ClaimantNameTextBox.Text = claim.ClaimantName;
            HourlyRateTextBox.Text = claim.HourlyRate.ToString("F2"); // Format to 2 decimal places
            HoursWorkedTextBox.Text = claim.HoursWorked.ToString();
            DateTextBox.Text = claim.DateLogged.ToString("yyyy-MM-dd"); // Format the date
            CommentTextBox.Text = claim.ClaimantComments;
            StatusTextBox.Text = claim.Status;
            PayemntTextBox.Text = claim.amountOwed().ToString("F2"); // Amount owed, formatted to 2 decimal places
        }
        public void LoadList(string tus)
        {
            ClaimsListBox.Items.Add("");
            ClaimsListBox.Items.Clear();
            foreach (var j in clams)
            {
                if (j.Status == tus)
                {
                    ClaimsListBox.Items.Add(j.DisplayClaim());
                }
            }
        }
        public void ddLoadList()
        {
            ClaimsListBox.Items.Add("");
            ClaimsListBox.Items.Clear();
            foreach (var j in clams)
            {
                if (j.Status == ListCatagoryDropDown.Text)
                {
                    ClaimsListBox.Items.Add(j.DisplayClaim());
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            clams[keynum - 1].Status = "Accepted";
            ddLoadList();
        }

        private void DenyButton_Click(object sender, RoutedEventArgs e)
        {
            if (JustificationTextBox.Text == "")
            {
                MessageBox.Show("Please enter a justification for your denial in the justification box.", "Denial Required!", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                clams[keynum - 1].Status = "Denied";
                ddLoadList();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void ListCatagoryDropDown_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //do nothing
            //MessageBox.Show(ListCatagoryDropDown.Text, "Denial Required!", MessageBoxButton.OK, MessageBoxImage.Information);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            ddLoadList();
        }
    }
}
