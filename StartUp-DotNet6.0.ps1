# tests powershell
echo "Setup .net Core skeleton for each day!"

$dayNum = Read-Host -Prompt 'Which day? Use numeric e.g. 02'
$appName= Read-Host -Prompt 'What is app name? e.g. Two. It will create DayTwo'
#Write-Host "You input server '$Servers' and '$User' on '$Date'" 
#Todo: Check if path exists don't add

mkdir Day$dayNum
cd Day$dayNum

#dotnet new console -n $appName
dotnet new console -n $appName

$testProjectName = "${appName}.Tests"
dotnet new xunit -n $testProjectName


Dotnet add "${testProjectName}/${testProjectName}.csproj" reference "${appName}/${appName}.csproj"

Dotnet new sln -n $appName
Dotnet sln $appName.sln add "${appName}/${appName}.csproj"
Dotnet sln $appName.sln add "${testProjectName}/${testProjectName}.csproj"

Dotnet run --project "${appName}/${appName}.csproj"
dotnet run --project "${testProjectName}/${testProjectName}.csproj"

