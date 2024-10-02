using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

public class TeamsAddinLocator
{
    public static void Main()
    {
        string basePath = @"C:\Program Files (x86)\Microsoft\TeamsMeetingAdd-in\";
        string searchPattern = @"x86\Microsoft.Teams.AddinLoader.dll";

        try
        {
            var directories = Directory.GetDirectories(basePath);
            var versionedDirectory = directories.FirstOrDefault(dir => Directory.Exists(Path.Combine(dir, searchPattern)));

            if (versionedDirectory != null)
            {
                string addinPath = Path.Combine(versionedDirectory, searchPattern);
                MessageBox.Show("Add-in Location: " + addinPath);
                // Add your code here to handle the add-in location
            }
            else
            {
                MessageBox.Show("Add-in not found in the specified path.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("An error occurred: " + ex.Message);
        }
    }
}

using Microsoft.Win32;
using System;

public class TeamsAddinRegistrar
{
    public static void RegisterAddin()
    {
        string addinName = "TeamsFastConnect"; // Replace with your add-in name
        // string addinPath = @"C:\Program Files\Teams Outlook Add-in\YourAddin.dll"; // Replace with the actual path to your add-in DLL

        using (RegistryKey key = Registry.CurrentUser.CreateSubKey(@"Software\Microsoft\Office\Outlook\Addins\" + addinName))
        {
            if (key != null)
            {
                key.SetValue("Description", "Teams Outlook Add-in");
                key.SetValue("FriendlyName", "Teams Outlook Add-in");
                key.SetValue("LoadBehavior", 3, RegistryValueKind.DWord);
                key.SetValue("Manifest", addinPath, RegistryValueKind.String);
                Console.WriteLine("Add-in registered successfully.");
            }
            else
            {
                Console.WriteLine("Failed to create registry key.");
            }
        }
    }
}

