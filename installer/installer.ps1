#
# service installer
#

function installService {

	param([string]$srvName, [string]$srvPath)
	$cred = new-object -typename System.Management.Automation.PSCredential 

	$existingService = Get-WmiObject -Class Win32_Service -Filter "Name='$srvName'"

	# check if the service needs to be uninstalled
	if ($existingService) 
	{
	  "'$srvName' exists already. Stopping."
	  Stop-Service $srvName
	  "Waiting 3 seconds to allow existing service to stop."
	  Start-Sleep -s 3

	  $existingService.Delete()
	  "Waiting 5 seconds to allow service to be uninstalled."
	  Start-Sleep -s 5  
	}

	# install the service
	"Installing the service..."
	New-Service -BinaryPathName $srvPath -Name $srvName -Credential $cred -DisplayName $srvName -StartupType Automatic 
	"...Installed"

	# start the service
	"Starting the service..."
	Start-Service $srvName
	"...started"

	# return true
	true
}

$result = installService -srvName "" -srvPath ""
$result = installService -srvName "" -srvPath ""
