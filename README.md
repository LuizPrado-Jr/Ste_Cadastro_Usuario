# Ste_Cadastro_Usuario

Olá foi escolhido ara realizar esse teste a linguagem **C#** com **nunit** e Framework **Coypu**

# Instalando Coypu

dotnet add package COYPU --version 3.1.1

# Executando os Testes

Para uma execução full dos testes deve digitar o ccoamndo no terminal:

**dotnet tests**

Foram criadas Tags para execuções de determinados testes que foram considerados critico, para isso basta digitar:

**dotnet test --filter TestCategory=Critical**

Foi também criado relatorios e screenshots para apresentar os dados que foram testados, para isso foi utilizado formato trx e sua execução é importante informar:

**Dotnet test --filter TestCategory=Critical -l TRX -r ./reports**

Onde o diretorio reports,ficarão "guardados" os dados.

e para executar todos os testes com relatório e screenshot:

**Dotnet test -l TRX -r ./reports**
