cd R:\repositorios\pboxlab\devcontrol.app
dotnet restore
dotnet publish -c Release -o Instaladores\Release
iscc /q R:\repositorios\pboxlab\devcontrol.app\Instaladores\ScriptSetup.iss