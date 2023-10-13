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

        // Add items to ComboBox for Language
        var LanguageList = new List<string>
        {
            "MatchOS", "en-us", "ar-sa", "bg-bg", "zh-cn", "zh-tw", "hr-hr", "cs-cz", "da-dk", "nl-nl",
            "et-ee", "fi-fi", "fr-fr", "de-de", "el-gr", "he-il", "hi-in", "hu-hu", "id-id", "it-it",
            "ja-jp", "kk-kz", "ko-kr", "lv-lv", "lt-lt", "ms-my", "nb-no", "pl-pl", "pt-br", "pt-pt",
            "ro-ro", "ru-ru", "sr-latn-cs", "sk-sk", "sl-si", "es-es", "sv-se", "th-th", "tr-tr",
            "uk-ua", "vi-vn"
        };
        var_Language.ItemsSource = LanguageList;

        // Add items to ComboBox for Channel
        //var ChannelList = new List<string> { "Current", "MonthlyEnterprise", "Semi-AnnualEnterprise" };
        //Channel.ItemsSource = ChannelList;

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

        var ProdPackage = new ListBox();

        // Populate the ListBox with radio buttons
        foreach (var product in ProdPackageList)
        {
            var listBoxItem = new ListBoxItem();
            listBoxItem.Content = product;
            var radioButton = new RadioButton
            {
                Content = product.Name,
                GroupName = "ProdPackageGroup"
            };
            radioButton.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsSelected") { Mode = BindingMode.TwoWay });
            listBoxItem.Content = radioButton;
            ProdPackage.Items.Add(listBoxItem);
        };

        var IncludePackage = new ListBox();

        // Populate the ListBox with products to include
        foreach (var product in IncludeProducts)
        {
            var listBoxItem = new ListBoxItem();
            listBoxItem.Content = product;
            var checkBox = new CheckBox
            {
                Content = product.Name
            };
            checkBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsSelected") { Mode = BindingMode.TwoWay });
            listBoxItem.Content = checkBox;
            IncludePackage.Items.Add(listBoxItem);
        };

        var ExcludePackage = new ListBox();

        // Populate the ListBox with products to exclude
        foreach (var product in ExcludeProducts)
        {
            var listBoxItem = new ListBoxItem();
            listBoxItem.Content = product;
            var checkBox = new CheckBox
            {
                Content = product.Name
            };
            checkBox.SetBinding(ToggleButton.IsCheckedProperty, new Binding("IsSelected") { Mode = BindingMode.TwoWay });
            listBoxItem.Content = checkBox;
            ExcludePackage.Items.Add(listBoxItem);
        };
    }

    /*private void NextButton_Click(object sender, RoutedEventArgs e)
    {
        List<string> selectedIncludePackages = IncludePackage.Items.Cast<ListBoxItem>()
            .Where(item => ((Product)item.Content).IsSelected)
            .Select(item => ((Product)item.Content).Name)
            .ToList();

        List<string> selectedExcludePackages = ExcludePackage.Items.Cast<ListBoxItem>()
            .Where(item => ((Product)item.Content).IsSelected)
            .Select(item => ((Product)item.Content).Name)
            .ToList();

        bool arch = var__64.IsChecked ?? false;
        bool shared = var__shared.IsChecked ?? false;
        bool updates = var__UpdatesEnabled.IsChecked ?? false;

        string Product = ProdPackageList.First(prod => prod.IsSelected).Name;
        List<string> Products = new List<string> { Product };
        Products.AddRange(selectedIncludePackages);
        string Channel = var_Channel.SelectedItem?.ToString() ?? "";
        string Language = var_Language.SelectedItem?.ToString() ?? "";
        string IncludeItems = string.Join(", ", selectedIncludePackages);
        string Excludes = string.Join(", ", selectedExcludePackages);

        // Rest of your code for creating installation configurations and displaying information
    }*/

    }
           /* private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }*/

}
