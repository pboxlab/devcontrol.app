# DevControl App

<p align="center">
  <img src="DevControl.App/Resources/logo-banner.jpg" alt="DevControl App" width="400">
</p>

**DevControl App** é uma ferramenta desenvolvida para facilitar o gerenciamento de projetos e programas de desenvolvimento. Este aplicativo foi criado para resolver a necessidade de executar múltiplas linhas de comando, buscar diretórios de projetos e repositórios de código, tudo isso de forma centralizada e eficiente.

## Funcionalidades

- **Cadastro de Projetos**: Permite cadastrar e gerenciar projetos de forma centralizada.
- **Cadastro de Programas**:
  - Suporta diferentes tipos de programas (.Net, Angular, PHP).
  - Botão para iniciar o serviço.
  - Botão para acessar o diretório do código.
  - Botão para acessar o repositório de código.
  - Visualização de logs.
- **Ferramentas Adicionais**:
  - Geração de GUID.
  - Formatação de JSON.

## Tecnologias Utilizadas

- **Linguagem**: C#
- **Framework**: .NET
- **Interface Gráfica**: Windows Forms

## Versão
A versão atual do DevControl App é **1.0.0**.

## Prints
<p align="center">
  <img src="DevControl.App/Resources/Prints/Tela-01-MonitorServicos.jpg" alt="DevControl App" width="600">
  </p>
  <p align="center">
  <img src="DevControl.App/Resources/Prints/Tela-02-Projetos.jpg" alt="DevControl App" width="600">
  </p>
  <p align="center">
  <img src="DevControl.App/Resources/Prints/Tela-03-Ferramentas.jpg" alt="DevControl App" width="600">
  </p>
  <p align="center">
  <img src="DevControl.App/Resources/Prints/Tela-04-Configuracoes.jpg" alt="DevControl App" width="600">
</p>

## Gerar Instalador
Siga os passos abaixo para gerar o instalador do DevControl App:
1. Baixe e instale o **[Inno Setup](https://jrsoftware.org/isdl.php)**.
2. Abra a pasta **Instaladores** localizada na raiz do repositório.
2. Edite o arquivo **ScriptSetup.iss**, conforme necessário, substituindo as informações da **PBOX**.
3. Execute o arquivo **InstallerGenerator.bat**;
4. O instalador será gerado na pasta **Instaladores**.

## Licença
Este projeto é licenciado sob os termos da licença MIT. Veja o arquivo LICENSE para mais detalhes.

## Contato
Se você tiver alguma dúvida ou sugestão, sinta-se à vontade para abrir uma issue ou enviar um e-mail para estevao.silva@pbox.com.br.

## Current Release
[Download versão 1.11.5.0](https://github.com/pboxlab/devcontrol.app/releases/download/1.11.5.0/DevControlApp-1.11.5.0-Setup.exe)

- Correção WindowMonitorDesigner;
- Melhorias no ScriptSetup;
- Correção de BUG para atualização do programa;
- Melhoria atualização disponível.