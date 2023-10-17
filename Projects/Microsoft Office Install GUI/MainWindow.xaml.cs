using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Microsoft_Office_Install_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
       
        private List<Product> ProdPackageList = new List<Product>();
        private List<Product> IncludeProducts = new List<Product>();
        private List<Product> ExcludeProducts = new List<Product>();
        public MainWindow()
    {
        InitializeComponents();
    }

    internal class Product
    {
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
        private ComboBox var_Channel = new ComboBox();
        private ComboBox var_Language = new ComboBox();
        private CheckBox var__64 = new CheckBox();
        private CheckBox var__shared = new CheckBox();
        private CheckBox var__UpdatesEnabled = new CheckBox();
        private ListBox var_IncludePackage = new ListBox();
        private ListBox var_ExcludePackage = new ListBox();
        private Button var_NextButton = new Button();
        private Button var_ExitButton = new Button();
    
    private void InitializeComponents()
    {            

       
        // Add Click event handlers
        //NextButton.Click += NextButton_Click;
        //var_ExitButton.Click += ExitButton_Click;

        // ... Add other UI elements and layout logic ...
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        var ProdPackageList = new List<Product>
        {
            new Product { Name = "HomeBusinessRetail", IsSelected = false },
            new Product { Name = "PersonalRetail", IsSelected = false },
            new Product { Name = "ProPlusRetail", IsSelected = false },
            new Product { Name = "O365SmallBusPremRetail", IsSelected = false },
            new Product { Name = "O365BusinessRetail", IsSelected = false },
            new Product { Name = "O365ProPlusRetail", IsSelected = true }
        };

        var IncludeProducts = new List<Product>
        {
        // Define your product lists
            new Product { Name = "AccessRetail", IsSelected = false },
            new Product { Name = "Access2019Retail", IsSelected = false },
            new Product { Name = "Access2019Volume", IsSelected = false },
            new Product { Name = "Access2021Volume", IsSelected = false },
            new Product { Name = "ExcelRetail", IsSelected = false },
            new Product { Name = "Excel2019Retail", IsSelected = false },
            new Product { Name = "Excel2019Volume", IsSelected = false },
            new Product { Name = "Excel2021Volume", IsSelected = false },
            new Product { Name = "HomeBusinessRetail", IsSelected = false },
            new Product { Name = "HomeBusiness2019Retail", IsSelected = false },
            new Product { Name = "HomeStudentRetail", IsSelected = false },
            new Product { Name = "HomeStudent2019Retail", IsSelected = false },
            new Product { Name = "O365HomePremRetail", IsSelected = false },
            new Product { Name = "OneNoteRetail", IsSelected = false },
            new Product { Name = "OneNote2021Volume", IsSelected = false },
            new Product { Name = "OutlookRetail", IsSelected = false },
            new Product { Name = "Outlook2019Retail", IsSelected = false },
            new Product { Name = "Outlook2019Volume", IsSelected = false },
            new Product { Name = "Outlook2021Volume", IsSelected = false },
            new Product { Name = "Personal2019Retail", IsSelected = false },
            new Product { Name = "PowerPointRetail", IsSelected = false },
            new Product { Name = "PowerPoint2019Retail", IsSelected = false },
            new Product { Name = "PowerPoint2019Volume", IsSelected = false },
            new Product { Name = "PowerPoint2021Volume", IsSelected = false },
            new Product { Name = "ProfessionalRetail", IsSelected = false },
            new Product { Name = "Professional2019Retail", IsSelected = false },
            new Product { Name = "ProjectProRetail", IsSelected = false },
            new Product { Name = "ProjectProXVolume", IsSelected = false },
            new Product { Name = "ProjectPro2019Retail", IsSelected = false },
            new Product { Name = "ProjectPro2019Volume", IsSelected = false },
            new Product { Name = "ProjectPro2021Volume", IsSelected = false },
            new Product { Name = "ProjectStdRetail", IsSelected = false },
            new Product { Name = "ProjectStdXVolume", IsSelected = false },
            new Product { Name = "ProjectStd2019Retail", IsSelected = false },
            new Product { Name = "ProjectStd2019Volume", IsSelected = false },
            new Product { Name = "ProjectStd2021Volume", IsSelected = false },
            new Product { Name = "ProPlus2019Volume", IsSelected = false },
            new Product { Name = "ProPlus2021Volume", IsSelected = false },
            new Product { Name = "ProPlusSPLA2021Volume", IsSelected = false },
            new Product { Name = "PublisherRetail", IsSelected = false },
            new Product { Name = "Publisher2019Retail", IsSelected = false },
            new Product { Name = "Publisher2019Volume", IsSelected = false },
            new Product { Name = "Publisher2021Volume", IsSelected = false },
            new Product { Name = "Standard2019Volume", IsSelected = false },
            new Product { Name = "Standard2021Volume", IsSelected = false },
            new Product { Name = "StandardSPLA2021Volume", IsSelected = false },
            new Product { Name = "VisioProRetail", IsSelected = false },
            new Product { Name = "VisioProXVolume", IsSelected = false },
            new Product { Name = "VisioPro2019Retail", IsSelected = false },
            new Product { Name = "VisioPro2019Volume", IsSelected = false },
            new Product { Name = "VisioPro2021Volume", IsSelected = false },
            new Product { Name = "VisioStdRetail", IsSelected = false },
            new Product { Name = "VisioStdXVolume", IsSelected = false },
            new Product { Name = "VisioStd2019Retail", IsSelected = false },
            new Product { Name = "VisioStd2019Volume", IsSelected = false },
            new Product { Name = "VisioStd2021Volume", IsSelected = false },
            new Product { Name = "WordRetail", IsSelected = false },
            new Product { Name = "Word2019Retail", IsSelected = false },
            new Product { Name = "Word2019Volume", IsSelected = false },
            new Product { Name = "Word2021Volume", IsSelected = false },
            new Product { Name = "InfoPathRetail", IsSelected = false },
            new Product { Name = "SPDRetail", IsSelected = false },
            new Product { Name = "LyncEntryRetail", IsSelected = false },
            new Product { Name = "LyncRetail", IsSelected = false },
            new Product { Name = "SkypeforBusiness", IsSelected = false },
            new Product { Name = "EntryRetail", IsSelected = false },
            new Product { Name = "SkypeforBusinessRetail", IsSelected = false }
        };

            // Add items to ComboBox for Language
            var LanguageList = new List<string>
        {
            "MatchOS", "en-us", "ar-sa", "bg-bg", "zh-cn", "zh-tw", "hr-hr", "cs-cz", "da-dk", "nl-nl",
            "et-ee", "fi-fi", "fr-fr", "de-de", "el-gr", "he-il", "hi-in", "hu-hu", "id-id", "it-it",
            "ja-jp", "kk-kz", "ko-kr", "lv-lv", "lt-lt", "ms-my", "nb-no", "pl-pl", "pt-br", "pt-pt",
            "ro-ro", "ru-ru", "sr-latn-cs", "sk-sk", "sl-si", "es-es", "sv-se", "th-th", "tr-tr",
            "uk-ua", "vi-vn"
        };
            Language.ItemsSource = LanguageList;

            // Add items to ComboBox for Channel
            var ChannelList = new List<string> { "Current", "MonthlyEnterprise", "Semi-AnnualEnterprise" };
            Channel.ItemsSource = ChannelList;


            var ExcludeProducts = new List<Product>
        {
            new Product { Name = "Publisher", IsSelected = false },
            new Product { Name = "PowerPoint", IsSelected = false },
            new Product { Name = "OneDrive", IsSelected = false },
            new Product { Name = "Outlook", IsSelected = false },
            new Product { Name = "OneNote", IsSelected = false },
            new Product { Name = "Lync", IsSelected = true },
            new Product { Name = "Groove", IsSelected = true },
            new Product { Name = "Excel", IsSelected = false },
            new Product { Name = "Access", IsSelected = false },
            new Product { Name = "Word", IsSelected = false }
        };

            ProdPackage.ItemsSource = ProdPackageList;

            ProdPackage.Foreground = new SolidColorBrush(Colors.Cyan);

            IncludePackage.ItemsSource = IncludeProducts;

            IncludePackage.Foreground = new SolidColorBrush(Colors.Cyan);

            ExcludePackage.ItemsSource = ExcludeProducts;

            //ExcludePackage.Foreground = new SolidColorBrush(Colors.Cyan);

        }

        private void NextButton_Click(object sender, RoutedEventArgs e)
    {
            List<string> selectedIncludePackages = IncludePackage.Items
                .Cast<Product>()
                .Where(product => product.IsSelected)
                .Select(product => product.Name)
                .ToList();

            string selectedProdPackage = null;

            foreach (Product product in ProdPackage.Items)
            {
                if (product.IsSelected)
                {
                    if (selectedProdPackage != null)
                    {
                        selectedProdPackage += ", "; // Append a comma and space
                    }

                    selectedProdPackage += product.Name;
                }
            }

            string IncludeItems = string.Join(", ", selectedIncludePackages);

            // Combine selectedProdPackageName and IncludeItems
            string combinedString = $"{selectedProdPackage}, {IncludeItems} ";

            // Split the combined string into an array using a comma and space as the delimiter
            string[] combinedArray = combinedString.Split(new[] { ", " }, StringSplitOptions.RemoveEmptyEntries);

            List<string> selectedExcludePackages = ExcludePackage.Items
                .Cast<Product>()
                .Where(product => product.IsSelected)
                .Select(product => product.Name)
                .ToList();

            string selectedLanguage = null;

            string selectedLanguages = Language.SelectedItem as string;

            if (!string.IsNullOrEmpty(selectedLanguages))
            {
                selectedLanguage = $"/Language:{selectedLanguages} "; // You have the selected language in the selectedLanguage variable
            }
            else
            {
                selectedLanguage = $"/Language:MatchOS "; // No language selected, handle the case where no language is chosen
            }

            string source = "--source=https://choco.netgaincloud.com/chocolatey";

            bool archChecked = (bool)_64.IsChecked;
            string arch = archChecked ? "/64 " : "";

            bool sharedChecked = (bool)_shared.IsChecked;
            string shared = sharedChecked ? "/Shared " : "";

            bool updatesChecked = (bool)_UpdatesEnabled.IsChecked;
            string updates = updatesChecked ? "/Updates:Enabled " : "/Updates:Disabled ";

            string excludeString = "";  // Initialize with an empty string
            string excludes = "";

            if (selectedExcludePackages.Count > 1)
            {
                excludes = string.Join(", ", selectedExcludePackages);
                excludeString = $"/Exclude:{excludes} ";
            }
            else if (selectedExcludePackages.Count == 1)
            {
                excludes = selectedExcludePackages[0];
                excludeString = $"/Exclude:{excludes} ";
            }
            string chocoInstallString = $"Choco install Microsoft-Office-Deployment --params=/Product:{combinedString}{excludeString}{selectedLanguage}{arch}{shared}{updates}{source}";

            MessageBox.Show(chocoInstallString);

            InstallWindow installWindow = new InstallWindow(chocoInstallString);
            installWindow.ShowDialog();
            // Rest of your code for creating installation configurations and displaying information
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    }
    
}
