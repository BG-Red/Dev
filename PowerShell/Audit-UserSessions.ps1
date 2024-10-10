Import-Module activedirectory
$ErrorActionPreference = "SilentlyContinue"

<#
# Get Domain    , select User
$trust = get-adtrust -Filter *  `
| ogv -PassThru

$dc    = Get-ADDomainController `
    -DomainName $trust.name     `
    -Discover                   `
    -NextClosestSite

$servers = get-adcomputer       `
    -filter *                   `
    -Server $dc.HostName[0]     `
| ? enabled                     `
| ogv -passthru
#>

$servers = get-adcomputer       `
    -filter *                   `
| ? enabled                     `
| ogv -passthru

$output         = @()
$filteredOutput = @()

[int]$days = read-host "How many days of events to gather?"

foreach ($Server in $servers) {
    write-host $server.dnshostname

    $LogFilter    = @{
        LogName   = 'Microsoft-Windows-TerminalServices-LocalSessionManager/Operational'
        ID        = 21, 23, 24, 25
        StartTime = (get-date).adddays(-$days)
    }

    $AllEntries = Get-WinEvent      `
        -FilterHashtable $LogFilter `
        -ComputerName    $Server.DNSHostName

    if ( $allentries.count -gt 0 ) {
        $AllEntries | Foreach {
            $thisEvent = $_
            try {
                $entry = [xml]$thisEvent.ToXml()
                [array]$Output += New-Object PSObject -Property @{
                    TimeCreated = $thisEvent.TimeCreated
                    User        = $entry.Event.UserData.EventXML.User
                    IPAddress   = $entry.Event.UserData.EventXML.Address
                    EventID     = $entry.Event.System.EventID
                    ServerName  = $Server.DNSHostName
                }
            } catch {
                # write-host $thisEvent
                [array]$Output += New-Object PSObject -Property @{
                    TimeCreated = $thisEvent.TimeCreated
                    User        = (($thisEvent.Message -split "`n" | select-string "User: ") -split "\s+")[-2]
                    IPAddress   = (($thisEvent.Message -split "`n" | select-string "Source Network Address: ") -split "\s+")[-1]
                    EventID     = $thisEvent.Id
                    ServerName  = $Server.DNSHostName
                }
            }
        }
    }
}

if ( $output.count -gt 0 ) {
    $FilteredOutput += $Output `
    | Select TimeCreated, User, ServerName, IPAddress, @{
        Name='Action';Expression={
            if ( $_.EventID -eq '21' ) { "logon"        }
            if ( $_.EventID -eq '22' ) { "Shell start"  }
            if ( $_.EventID -eq '23' ) { "logoff"       }
            if ( $_.EventID -eq '24' ) { "disconnected" }
            if ( $_.EventID -eq '25' ) { "reconnection" }
        }
    }
}

$selectedOutput = $filteredOutput | sort timecreated | ogv -PassThru | ft * -AutoSize

$selectedOutput

<#
$Date     = (Get-Date -Format "yyyyMMddHHmmss") -replace ":", "."
$FilePath = "C:\temp\$Date`_RDP_Report.csv"

$FilteredOutput          `
| Sort       TimeCreated `
| Export-Csv $FilePath -NoTypeInformation

$FilteredOutput | ft ipaddress, user,action, servername
#>
