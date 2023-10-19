using System;
using System.Text;
using System.Windows;
using System.Management.Automation;
using System.Management.Automation.Runspaces;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.IO;

namespace Microsoft_Office_Install_GUI
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class InstallWindow : Window
    {
        private string chocoInstallString; // Stuff from MainWindow
        private string localChocoInstallString; // Declare it here
        private FileSystemWatcher fileWatcher;

        //Calls from MainWindow 

        public InstallWindow(string chocoInstallString)
        {
            InitializeComponent();

            // Set the local variable with the passed value
            localChocoInstallString = chocoInstallString; // Assign the value here

            // Handle the Loaded event
            Loaded += Window_Loaded;
        }
        
        //Behavior for updating localFinalString


        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            UpdateChocoInstallString();
        }

        private void CheckBox_Unchecked(object sender, RoutedEventArgs e)
        {
            UpdateChocoInstallString();
        }

        //Behavior for when the Window get's loaded

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            chocoInstallStringBox.Text = localChocoInstallString; // Now it's accessible within this event handler


            _debug.Checked += CheckBox_Checked;
            _debug.Unchecked += CheckBox_Unchecked;

            _verbose.Checked += CheckBox_Checked;
            _verbose.Unchecked += CheckBox_Unchecked;

            _force.Checked += CheckBox_Checked;
            _force.Unchecked += CheckBox_Unchecked;

            runspace = RunspaceFactory.CreateRunspace();
            runspace.Open();
        }

        //Change final script behavior

        private void UpdateChocoInstallString()
        {
            // Modify your localChocoInstallString based on the checkboxes' states
            string updatedChocoInstallString = localChocoInstallString;
            if (_debug.IsChecked == true)
            {
                updatedChocoInstallString += " --debug";
            }

            if (_verbose.IsChecked == true)
            {
                updatedChocoInstallString += " --verbose";
            }

            if (_force.IsChecked == true)
            {
                updatedChocoInstallString += " --force";
            }

            // Update the chocoInstallString and chocoInstallStringBox

            chocoInstallStringBox.Text = updatedChocoInstallString;
        }

        //Don't know why this is here but hell if I know

        private Runspace runspace;
        private object errorRecord;

        //Function for PowerShell Command

        private async Task ExecutePowerShellCommand(string command)
        {
            using (PowerShell powerShell = PowerShell.Create())
            {
                // Collect the output in a StringBuilder
                StringBuilder resultText = new StringBuilder();

                IProgress<string> progress = new Progress<string>(text =>
                {
                    // This method will be executed on the UI thread, update your UI controls here.
                    resultText.AppendLine(text);
                    PowerShellFrame.Text = resultText.ToString();
                    PowerShellFrame.ScrollToEnd();
                });

                // Source functions.
                powerShell.AddScript(command);


                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> PSOutput = powerShell.Invoke();

                // loop through each output object item
                foreach (PSObject outputItem in PSOutput)
                {
                    if (outputItem != null)
                    {
                        string outputText = outputItem.ToString();
                        progress.Report(outputText); // Report progress to update UI
                    }
                }

                // Check the error stream
                if (powerShell.Streams.Error.Count > 0)
                {
                    foreach (var errorRecord in powerShell.Streams.Error)
                    {
                        // Log or display the error
                        progress.Report("Error: " + errorRecord.ToString()); // Report error
                    }
                }
            }
        }

        //Runs Choco Install String in PowerShell under user login context. May need to run as admin
        private async void InstallButton_Click(object sender, RoutedEventArgs e)
        {

            bool debugChecked = (bool)_debug.IsChecked;
            string debug = debugChecked ? " --debug" : "";

            bool verboseChecked = (bool)_verbose.IsChecked;
            string verbose = verboseChecked ? " --verbose" : "";

            bool forceChecked = (bool)_force.IsChecked;
            string force = forceChecked ? " --force" : "";

            string finalString = $"{localChocoInstallString}" + $"{debug}{verbose}{force} -y";

            // PowerShell command to get a list of processes
            var command = finalString;

            //MessageBox.Show(command);

            // Execute the PowerShell command and get the output
            await ExecutePowerShellCommand(command);

        }

        //BackButton Function
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
