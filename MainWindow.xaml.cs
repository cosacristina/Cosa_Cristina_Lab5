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
using System.Data;
using System.ComponentModel;

namespace Cosa_Cristina_Lab5
{
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        ///
       enum ActionState
        {
            New,
            Edit,
            Delete,
            Nothing
        }


        public partial class MainWindow : Window
        {

            ActionState action = ActionState.Nothing;
            PhoneNumbersDataSet phoneNumbersDataSet = new PhoneNumbersDataSet();
            PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter tblPhoneNumbersAdapter = new PhoneNumbersDataSetTableAdapters.PhoneNumbersTableAdapter();
            Binding txtPhoneNumberBinding = new Binding();
            Binding txtSubscriberBinding = new Binding();
        // cele doua obiecte de tip Binding - initializare
            Binding txtContractValueBinding = new Binding();
            Binding txtContractDateBinding = new Binding();
        


        public MainWindow()
            {
                InitializeComponent();

                grdMain.DataContext = phoneNumbersDataSet.PhoneNumbers;
                txtPhoneNumberBinding.Path = new PropertyPath("Phonenum");
                txtSubscriberBinding.Path = new PropertyPath("Subscriber");
            // setare proprieteti path
                txtContractValueBinding.Path = new PropertyPath("Contract_value");
                txtContractDateBinding.Path = new PropertyPath("Contract_date");

                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            // setBinding
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
        }

            private void lstPhonesLoad()
            {
                tblPhoneNumbersAdapter.Fill(phoneNumbersDataSet.PhoneNumbers);
            }

            private void grdMain_Loaded(object sender, RoutedEventArgs e)
            {
                lstPhonesLoad();
            }

            private void btnExit_Click(object sender, RoutedEventArgs e)
            {
                if (MessageBox.Show("Close Application?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                {
                    this.Close();
                }
            }

            private void frmMain_Loaded(object sender, RoutedEventArgs e)
            {
                PhoneNumbersDataSet phoneNumbersDataSet =((PhoneNumbersDataSet)(this.FindResource("phoneNumbersDataSet")));
                System.Windows.Data.CollectionViewSource phoneNumbersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("phoneNumbersViewSource")));
                phoneNumbersViewSource.View.MoveCurrentToFirst();
            }

            private void btnNew_Click(object sender, RoutedEventArgs e)
            {
                action = ActionState.New;
                btnNew.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;

                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                lstPhones.IsEnabled = false;
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = false;
                txtPhoneNumber.IsEnabled = true;
                txtSubscriber.IsEnabled = true;
                BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
                BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
                txtPhoneNumber.Text = "";
                txtSubscriber.Text = "";
            // modificare proprietati buton new pentru cele doua coloane adaugate
            txtContractValue.IsEnabled = true;
            txtContractDate.IsEnabled = true;
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            txtContractValue.Text = "";
            txtContractDate.Text = "";

            Keyboard.Focus(txtPhoneNumber);
            }

            private void btnEdit_Click(object sender, RoutedEventArgs e)
            {
                action = ActionState.Edit;
                string tempPhonenum = txtPhoneNumber.Text.ToString();
                string tempSubscriber = txtSubscriber.Text.ToString();
            // creare temp txtContractValue si txtContractDate
            string tempContract_value = txtContractValue.Text.ToString();
            string tempContract_date = txtContractValue.Text.ToString();

                btnNew.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                lstPhones.IsEnabled = false;
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = false;
                txtPhoneNumber.IsEnabled = true;
                txtSubscriber.IsEnabled = true;
                BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
                BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
                txtPhoneNumber.Text = tempPhonenum;
                txtSubscriber.Text = tempSubscriber;
            //modificare propreitati buton edit
            txtContractValue.IsEnabled = true;
            txtContractDate.IsEnabled = true;
            BindingOperations.ClearBinding(txtContractValue, TextBox.TextProperty);
            BindingOperations.ClearBinding(txtContractDate, TextBox.TextProperty);
            txtContractValue.Text = tempContract_value;
            txtContractDate.Text = tempContract_date;
            
            Keyboard.Focus(txtPhoneNumber);
            }

            private void btnDelete_Click(object sender, RoutedEventArgs e)
            {
                action = ActionState.Delete;
                string tempPhonenum = txtPhoneNumber.Text.ToString();
                string tempSubscriber = txtSubscriber.Text.ToString();
                btnNew.IsEnabled = false;
                btnEdit.IsEnabled = false;
                btnDelete.IsEnabled = false;
                btnSave.IsEnabled = true;
                btnCancel.IsEnabled = true;
                lstPhones.IsEnabled = false;
                btnPrevious.IsEnabled = false;
                btnNext.IsEnabled = false;
                BindingOperations.ClearBinding(txtPhoneNumber, TextBox.TextProperty);
                BindingOperations.ClearBinding(txtSubscriber, TextBox.TextProperty);
                txtPhoneNumber.Text = tempPhonenum;
                txtSubscriber.Text = tempSubscriber;
            }
            private void btnCancel_Click(object sender, RoutedEventArgs e)
            {

                action = ActionState.Nothing;
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
            //modificare proprietati cancel
            txtContractValue.IsEnabled = false;
            txtContractDate.IsEnabled = false;
            txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
            txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {        
            if (action == ActionState.New)    {      
                try       
                {         
                    DataRow newRow = phoneNumbersDataSet.PhoneNumbers.NewRow();          
                    newRow.BeginEdit();         
                    newRow["Phonenum"] = txtPhoneNumber.Text.Trim();          
                    newRow["Subscriber"] = txtSubscriber.Text.Trim();
                    // modificare functionalitati save
                    newRow["Contract_value"] = txtContractValue.Text.Trim();
                    newRow["Contract_date"] = txtContractDate.Text.Trim();

                    newRow.EndEdit();          
                    phoneNumbersDataSet.PhoneNumbers.Rows.Add(newRow);          
                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);         
                    phoneNumbersDataSet.AcceptChanges();       
                }       
                catch (DataException ex)       
                {           phoneNumbersDataSet.RejectChanges();           
                    MessageBox.Show(ex.Message);       
                }       
                btnNew.IsEnabled = true;      
                btnEdit.IsEnabled = true;       
                btnSave.IsEnabled = false;       
                btnCancel.IsEnabled = false;       
                lstPhones.IsEnabled = true;       
                btnPrevious.IsEnabled = true;       
                btnNext.IsEnabled = true;       
                txtPhoneNumber.IsEnabled = false;       
                txtSubscriber.IsEnabled = false;
                // prindere erori 
                txtContractValue.IsEnabled = false;
                txtContractDate.IsEnabled = false;
            }     
            else        if (action == ActionState.Edit)
            {
                try
                {
                    DataRow editRow = phoneNumbersDataSet.PhoneNumbers.Rows[lstPhones.SelectedIndex];
                    editRow.BeginEdit();
                    editRow["Phonenum"] = txtPhoneNumber.Text.Trim();
                    editRow["Subscriber"] = txtSubscriber.Text.Trim();
                    // editare rand
                    editRow["Contract_value"] = txtContractValue.Text.Trim();
                    editRow["Contract_date"] = txtContractDate.Text.Trim();
                    editRow.EndEdit();
                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }
                catch (DataException ex)
                {
                    phoneNumbersDataSet.RejectChanges();
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                // modificare
                txtContractValue.IsEnabled = false;
                txtContractDate.IsEnabled = false;
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            }
            else
                if (action == ActionState.Delete)
            {
                try
                {
                    DataRow deleterow = phoneNumbersDataSet.PhoneNumbers.Rows[lstPhones.SelectedIndex];
                    deleterow.Delete();

                    tblPhoneNumbersAdapter.Update(phoneNumbersDataSet.PhoneNumbers);
                    phoneNumbersDataSet.AcceptChanges();
                }
                catch (DataException ex)
                {
                    phoneNumbersDataSet.RejectChanges(); MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.Message);
                }
                btnNew.IsEnabled = true;
                btnEdit.IsEnabled = true;
                btnDelete.IsEnabled = true;
                btnSave.IsEnabled = false;
                btnCancel.IsEnabled = false;
                lstPhones.IsEnabled = true;
                btnPrevious.IsEnabled = true;
                btnNext.IsEnabled = true;
                txtPhoneNumber.IsEnabled = false;
                txtSubscriber.IsEnabled = false;
                txtPhoneNumber.SetBinding(TextBox.TextProperty, txtPhoneNumberBinding);
                txtSubscriber.SetBinding(TextBox.TextProperty, txtSubscriberBinding);
                // prindere erori
                txtContractValue.IsEnabled = false;
                txtContractDate.IsEnabled = false;
                txtContractValue.SetBinding(TextBox.TextProperty, txtContractValueBinding);
                txtContractDate.SetBinding(TextBox.TextProperty, txtContractDateBinding);
            }
        }

        private void btnPrevious_Click(object sender, RoutedEventArgs e)
        {
            //using System.ComponentModel
            ICollectionView navigationView = CollectionViewSource.GetDefaultView(phoneNumbersDataSet.PhoneNumbers);
            navigationView.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView navigationView =
           CollectionViewSource.GetDefaultView(phoneNumbersDataSet.PhoneNumbers);
            navigationView.MoveCurrentToNext();
        }
    }
    }


