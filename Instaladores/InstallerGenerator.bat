cd ..
dotnet restore
dotnet publish -c Release -o Instaladores\Release
iscc /q .\Instaladores\ScriptSetup.iss