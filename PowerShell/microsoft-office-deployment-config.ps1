$toolsDir = "$(Split-Path -parent $MyInvocation.MyCommand.Definition)"

$binDir = "$($toolsDir)\..\bin"
$logDir = "$($toolsDir)\..\logs"

# Define a class to represent the items in the ListBox
class Product {
    [string] $Name
    [bool] $IsSelected
}

Add-Type -AssemblyName PresentationFramework

# Calculate the image path dynamically
$imagePath = "$($toolsDir)\NetgainBlack.gif"

$xamlFile = "$($toolsDir)\microsoft-office-deployment-gui.xaml"

$inputXAML = Get-Content $xamlFile -Raw

$inputXAML = $inputXAML -Replace 'mc:Ignorable="d"','' -Replace "x:N","N" -Replace '^<Win.*','<Window'

[XML]$XAML = $inputXAML

$reader = New-Object System.Xml.XmlNodeReader $XAML
try {
    $winForm = [Windows.Markup.XamlReader]::Load($reader)
} catch {
    Write-Host $_.Exception
    throw
}

$XAML.SelectNodes("//*[@Name]") | ForEach-Object {
    try {
        Set-Variable "var_$($_.Name)" -Value $winForm.FindName($_.Name) -ErrorAction Stop
    } catch {
        throw
    }
}

$var_NetgainLogo.source = $imagePath

# Define a class to represent the items in the ListView
$ProdPackageList=[array](
    "HomeBusinessRetail", 
    "PersonalRetail", 
    "ProPlusRetail", 
    "O365SmallBusPremRetail", 
    "O365BusinessRetail", 
    "O365ProPlusRetail" 
)

# Define your product list
$PackagedProducts = Foreach($ProdName in $ProdPackageList){  
    If($ProdName -eq "O365ProPlusRetail"){
        [Product]@{ Name = $ProdName; IsSelected = $True }
    } else {
        [Product]@{ Name = $ProdName; IsSelected = $false }
    }
}

# Populate the ListBox with radio buttons
$PackagedProducts | ForEach-Object {
    $dataTemplate = @"
    <DataTemplate xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
        <RadioButton Content="{Binding Name}" IsChecked="{Binding IsSelected, Mode=TwoWay}" GroupName="ProdPackageGroup" />
    </DataTemplate>
"@
    $listBoxItem = [System.Windows.Controls.ListBoxItem]::new()
    $listBoxItem.ContentTemplate = [Windows.Markup.XamlReader]::Parse($dataTemplate)
    $listBoxItem.Content = $_
    $var_ProdPackage.Items.Add($listBoxItem)
}

$IncludePackageList = [array](
    "AccessRetail", 
    "Access2019Retail", 
    "Access2019Volume", 
    "Access2021Volume", 
    "ExcelRetail", 
    "Excel2019Retail", 
    "Excel2019Volume", 
    "Excel2021Volume", 
    "HomeBusinessRetail", 
    "HomeBusiness2019Retail", 
    "HomeStudentRetail", 
    "HomeStudent2019Retail", 
    "O365HomePremRetail", 
    "OneNoteRetail", 
    "OneNote2021Volume", 
    "OutlookRetail", 
    "Outlook2019Retail", 
    "Outlook2019Volume", 
    "Outlook2021Volume", 
    "Personal2019Retail", 
    "PowerPointRetail", 
    "PowerPoint2019Retail", 
    "PowerPoint2019Volume", 
    "PowerPoint2021Volume", 
    "ProfessionalRetail", 
    "Professional2019Retail", 
    "ProjectProRetail", 
    "ProjectProXVolume", 
    "ProjectPro2019Retail", 
    "ProjectPro2019Volume", 
    "ProjectPro2021Volume", 
    "ProjectStdRetail", 
    "ProjectStdXVolume", 
    "ProjectStd2019Retail", 
    "ProjectStd2019Volume", 
    "ProjectStd2021Volume", 
    "ProPlus2019Volume", 
    "ProPlus2021Volume", 
    "ProPlusSPLA2021Volume", 
    "PublisherRetail", 
    "Publisher2019Retail", 
    "Publisher2019Volume", 
    "Publisher2021Volume", 
    "Standard2019Volume", 
    "Standard2021Volume",
    "StandardSPLA2021Volume", 
    "VisioProRetail",
    "VisioProXVolume", 
    "VisioPro2019Retail", 
    "VisioPro2019Volume", 
    "VisioPro2021Volume", 
    "VisioStdRetail", 
    "VisioStdXVolume", 
    "VisioStd2019Retail", 
    "VisioStd2019Volume", 
    "VisioStd2021Volume", 
    "WordRetail", 
    "Word2019Retail", 
    "Word2019Volume", 
    "Word2021Volume", 
    "InfoPathRetail", 
    "SPDRetail",  
    "LyncEntryRetail", 
    "LyncRetail", 
    "SkypeforBusiness", 
    "EntryRetail", 
    "SkypeforBusinessRetail"
)

# Define your product list
$IncludeProducts = Foreach($ProdName in $IncludePackageList){  
    If($ProdName){
        [Product]@{ Name = $ProdName; IsSelected = $false }
    } else {
        [Product]@{ Name = $ProdName; IsSelected = $false }
    }
}

# Populate the ListBox with products
$IncludeProducts | ForEach-Object {
    $dataTemplate = @"
    <DataTemplate xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
        <CheckBox Content="{Binding Name}" IsChecked="{Binding IsSelected}" />
    </DataTemplate>
"@
    $listBoxItem = [System.Windows.Controls.ListBoxItem]::new()
    $listBoxItem.ContentTemplate = [Windows.Markup.XamlReader]::Parse($dataTemplate)
    $listBoxItem.Content = $_
    $var_IncludePackage.Items.Add($listBoxItem)
}

$ExcludePackageList = [array](
    "Publisher", 
    "PowerPoint", 
    "OneDrive", 
    "Outlook", 
    "OneNote", 
    "Lync", 
    "Groove", 
    "Excel", 
    "Access", 
    "Word"
)

# Define your product list
$ExcludeProducts = Foreach($ProdName in $ExcludePackageList){  
    If(($ProdName -eq "Groove") -or ($ProdName -eq "Lync")){
        [Product]@{ Name = $ProdName; IsSelected = $True }
    } else {
        [Product]@{ Name = $ProdName; IsSelected = $false }
    }
}

# Populate the ListBox with products
$ExcludeProducts | ForEach-Object {
    $dataTemplate = @"
    <DataTemplate xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation">
        <CheckBox Content="{Binding Name}" IsChecked="{Binding IsSelected}" />
    </DataTemplate>
"@
    $listBoxItem = [System.Windows.Controls.ListBoxItem]::new()
    $listBoxItem.ContentTemplate = [Windows.Markup.XamlReader]::Parse($dataTemplate)
    $listBoxItem.Content = $_
    $var_ExcludePackage.Items.Add($listBoxItem)
}

$LanguageList = [array](
    "MatchOS",
    "en-us",
    "ar-sa", 
    "bg-bg", 
    "zh-cn", 
    "zh-tw", 
    "hr-hr", 
    "cs-cz", 
    "da-dk", 
    "nl-nl",  
    "et-ee", 
    "fi-fi", 
    "fr-fr", 
    "de-de", 
    "el-gr", 
    "he-il", 
    "hi-in", 
    "hu-hu", 
    "id-id", 
    "it-it", 
    "ja-jp", 
    "kk-kz", 
    "ko-kr", 
    "lv-lv", 
    "lt-lt", 
    "ms-my", 
    "nb-no", 
    "pl-pl", 
    "pt-br", 
    "pt-pt", 
    "ro-ro", 
    "ru-ru", 
    "sr-latn-cs", 
    "sk-sk", 
    "sl-si", 
    "es-es", 
    "sv-se", 
    "th-th", 
    "tr-tr", 
    "uk-ua", 
    "vi-vn"
)

Foreach($i in $LanguageList){
    $var_Language.Items.Add($I)
}

$ChannelList = [array](
    "Current",
    "MonthlyEnterprise",
    "Semi-AnnualEnterprise"
)

Foreach($i in $ChannelList){
    $var_Channel.Items.Add($I)
}

$var_NextButton.Add_Click({
    # Get selected items from the CheckBoxList
    $selectedIncludePackages = $var_IncludePackage.Items | Where-Object { $_.Content.IsSelected } | ForEach-Object { $_.Content.Name }
    
    $selectedExcludePackages = $var_ExcludePackage.Items | Where-Object { $_.Content.IsSelected } | ForEach-Object { $_.Content.Name }

    If($var__64.IsChecked -eq $true){
        $64 = $true
    } else {
        $64 = $false
    }

    If($var__shared.IsChecked -eq $true){
        $shared = $true
    } else {
        $shared = $false
    }

    If($var__UpdatesEnabled.IsChecked -eq $true){
        $updates = $true
    } else {
        $updates = $false
    }

    # Get selected item from the ComboBox
    $Product = $PackagedProducts | Where-Object { $_.IsSelected } | Select-Object -ExpandProperty Name
    $Products = @(
        $Product
    )
    $Channel = $var_Channel.SelectedItem
    $Language = $var_Language.SelectedItem
    $IncludeItems = $selectedIncludePackages -join ', '
    $Products = $Products + $selectedIncludePackages -join ', '
    $Excludes = $selectedExcludePackages -join ', '

    If($64 -eq $true){
        $arch = 64
        $choco64 = "/64bit "
    } else {
        $arch = 32
        $choco64 = $null
    }

    If($Shared -eq $true){
        $sharedMachine = 1
        $chocoShare = "/Shared "
    } else {
        $sharedMachine = 0
        $chocoShare = $null
    }

    If(!$Language){
        $languages = "MatchOS"
    } else {
        $languages = $Language
    }

    If(!$Products){
        If($IncludeItems){
            $products = "O365ProPlusRetail" + $selectedIncludePackages -join ', '
        } else {
            $products = "O365ProPlusRetail"
        }
    }

    If(!$updates){
        $updates = "FALSE"
        $chocoUpdates = "/DisableUpdate:True "
    } else {
        $updates = "TRUE"
        $chocoUpdates = $null
    }

    If(!$Excluded){
        $chocoExclude = "/Exclude:$Excludes"
    } else {
        $chocoExclude = $null
    }

    # Display selected items in the terminal
    Write-Host "Selected Product: $Product"
    Write-Host "Included Products: $IncludeItems"
    Write-Host "Excluded Products: $Excludes"
    Write-Host "64-bit installation: $64"
    Write-Host "Shared Computing installation: $shared"
    Write-Host "Updates enabled: $updates"
    Write-Host "Update Channel: $Channel"
    Write-Host "Language: $Language"
    Write-Host "All Products: $Products"

    Write-Host "Chocolatey Install String: choco install microsoft-office-deployment --params=$choco64/Product:$Products $chocoShare$chocoExclude /Channel:$Channel $chocoUpdates--source=https://choco.netgaincloud.com/chocolatey"

####################################################################################################
# Building Config Files

    if (!($installConfigData)) {
        $installConfigData = @"
<Configuration>
    $(
        if($channel -ne $null){ 
    "<Add OfficeClientEdition=""$($arch)"" Channel=""$($channel)"">"
        } else {
    "<Add OfficeClientEdition=""$($arch)"">"
        }
    )
    $(
        foreach($product in $products) {
            if($pidkey -ne $null){
"`r`n       <Product ID=""$($product)"" PIDKEY=""$($pidkey)"">"
            }
            else {
"`r`n       <Product ID=""$($product)"">" }
        foreach($language in $languages) {
"`r`n           <Language ID=""$($language)"" />"

        }
        foreach($exclude in $excludes) {
"`r`n           <ExcludeApp ID=""$($exclude)"" />"

        }
"`r`n       </Product>"
        }
        if ($ProofingToolLanguages.Count -gt 0)
        {
"`r`n       <Product ID=""ProofingTools"">"
            foreach($prooflanguage in $ProofingToolLanguages) {
"`r`n           <Language ID=""$($prooflanguage)"" />"

            }
"`r`n       </Product>"
        }
    )
    </Add>  
    $(
        if($channel -ne $null){ 
    "<Updates Enabled=""$($updates)"" Channel=""$($channel)"" />"
        } else  {
    "<Updates Enabled=""$($updates)"" />"
        }
    )

    <Display Level="None" AcceptEULA="TRUE" />  
    <Logging Level="Standard" Path="$logDir" /> 
    <Property Name="SharedComputerLicensing" Value="$sharedMachine" />  
</Configuration>
"@
}
 
$uninstallConfigData = @"
<Configuration>
    <Remove>
    $(
        foreach($product in $products) {
"`r`n       <Product ID=""$($product)"">"
"`r`n       </Product>"
        }
        if ($ProofingToolLanguages.Count -gt 0)
        {
"`r`n       <Product ID=""ProofingTools"">"
"`r`n       </Product>"
        }
    )
    </Remove>
    <Display Level="None" AcceptEULA="TRUE" />  
    <Logging Level="Standard" Path="$logDir" /> 
    <Property Name="FORCEAPPSHUTDOWN" Value="True" />
</Configuration>
"@

$installConfigData | Out-File "$($binDir)\Install.xml"
$uninstallConfigData | Out-File "$($binDir)\Uninstall.xml"

    # Close the window
    $winForm.Close()
})

# Adding Exit Button Click Function
$var_ExitButton.Add_Click({
    # Close the window
    $winForm.Close()
})

# Show the GUI
$winForm.ShowDialog()