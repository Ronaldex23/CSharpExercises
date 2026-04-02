# 📮 ConsultadorCEP
 
Projeto acadêmico desenvolvido em **C# Windows Forms** com o objetivo de demonstrar o consumo de uma API REST externa utilizando boas práticas de organização de código e princípios básicos de arquitetura de software.
 
---
 
## 📋 Sobre o Projeto
 
O **ConsultadorCEP** é uma aplicação **Windows Forms** que realiza a consulta de endereços a partir de um CEP informado pelo usuário, consumindo a API pública **[ViaCEP](https://viacep.com.br/)**. O projeto foi desenvolvido com fins educacionais, explorando conceitos como consumo de APIs HTTP, desserialização de JSON, programação assíncrona e separação de responsabilidades.
 
> ⚠️ Por se tratar de um projeto de escala reduzida, as validações e regras de negócio foram mantidas diretamente na camada de IHM, sem uma camada específica de validação — decisão consciente dado o escopo acadêmico do projeto.
 
---
 
## 🚀 Funcionalidades
 
- Recebe um CEP via campo mascarado (`MaskedTextBox`) com validação de formato
- Impede o cadastro duplicado de um mesmo CEP na sessão atual
- Realiza uma requisição HTTP GET assíncrona à API ViaCEP
- Desserializa a resposta JSON em um objeto C# (`Endereco`)
- Exibe os endereços consultados em uma `ListView` com as colunas: CEP, Logradouro, Bairro, Cidade e UF
- Trata CEPs inválidos ou inexistentes com mensagens de feedback ao usuário
- Fornece feedback visual durante a requisição (cursor de espera, botão desabilitado)
- Permite acionar a consulta tanto pelo botão quanto pela tecla **Enter**
 
---
 
## 🛠️ Tecnologias e Bibliotecas
 
| Tecnologia | Descrição |
|---|---|
| **C# / .NET** | Linguagem e plataforma principal do projeto |
| **Windows Forms** | Framework para construção da interface gráfica |
| **HttpClient** | Realização das requisições HTTP assíncronas à API ViaCEP |
| **Newtonsoft.Json** | Desserialização do retorno JSON da API em objetos C# |
| **ViaCEP API** | Serviço público e gratuito de consulta de CEPs brasileiros |
 
---
 
## 🏗️ Arquitetura e Organização
 
O projeto foi estruturado em camadas simples, separando as responsabilidades entre modelo de dados, lógica de consumo da API e interface com o usuário:
 
```
Winform_ConsultaCEP/
│
├── Models/
│   └── Endereco.cs               # Modelo que representa o retorno da API
│
├── Services/
│   └── ConsultadorCep.cs         # Responsável pela comunicação com a API ViaCEP
│
└── Forms/
    └── ConsultadorCepIHM.cs      # Interface gráfica e interação com o usuário
```
 
### Models — `Endereco.cs`
Classe modelo que mapeia os campos retornados pela API ViaCEP. Utiliza propriedades anuláveis (`string?`) para refletir que nem todos os campos são sempre retornados, além da propriedade `Erro` que sinaliza quando um CEP não é encontrado pela API.
 
```csharp
class Endereco
{
    public string? Cep { get; set; }
    public string? Logradouro { get; set; }
    public string? Bairro { get; set; }
    public string? Localidade { get; set; }
    public string? Uf { get; set; }
    public bool Erro { get; set; }
}
```
 
### Services — `ConsultadorCep.cs`
Camada responsável por encapsular toda a lógica de comunicação com a API. Utiliza `HttpClient` para a requisição assíncrona e `Newtonsoft.Json` para a desserialização do JSON. Lança exceções tratáveis em caso de CEP inválido ou inexistente.
 
```csharp
public async Task<Endereco> ConsultaCEP(string _cep)
{
    string url = $"https://viacep.com.br/ws/{_cep}/json/";
    HttpResponseMessage response = await client.GetAsync(url);
    response.EnsureSuccessStatusCode();
 
    string json = await response.Content.ReadAsStringAsync();
    Endereco? endereco = JsonConvert.DeserializeObject<Endereco>(json);
 
    if (endereco == null || endereco.Erro)
        throw new Exception("CEP inválido ou inexistente. Tente novamente");
 
    return endereco;
}
```
 
### IHM — `ConsultadorCepIHM.cs`
Camada de interface com o usuário. Gerencia a lista de endereços consultados na sessão, realiza as validações de entrada (formato e duplicidade), fornece feedback visual durante a requisição e popula a `ListView` com os resultados. Por ser um projeto de escopo acadêmico reduzido, as validações e regras de negócio residem nessa camada.
 
---
 
## 🌐 API Utilizada — ViaCEP
 
A [ViaCEP](https://viacep.com.br/) é uma API REST brasileira, gratuita e sem necessidade de autenticação, que retorna dados de endereços a partir de um CEP.
 
**Endpoint utilizado:**
```
GET https://viacep.com.br/ws/{CEP}/json/
```
 
**Exemplo de retorno:**
```json
{
  "cep": "01001-000",
  "logradouro": "Praça da Sé",
  "complemento": "lado ímpar",
  "bairro": "Sé",
  "localidade": "São Paulo",
  "uf": "SP"
}
```
 
**Retorno para CEP inválido:**
```json
{
  "erro": true
}
```
 
> O campo `erro` é mapeado na classe `Endereco` e verificado após a desserialização para lançar a exceção adequada ao usuário.
 
---
 
## ⚙️ Como Executar
 
### Pré-requisitos
 
- [Visual Studio](https://visualstudio.microsoft.com/) com suporte a **Windows Forms (.NET)**
- [Git](https://git-scm.com/install/)
- Pacote NuGet `Newtonsoft.Json`
 
### Passos
 
1. Clone o repositório:
   ```bash
   git clone https://github.com/Ronaldex23/CSharpExercises.git
   ```
 
2. Abra a solution do projeto `ConsultadorCEP` no Visual Studio.
 
3. Restaure os pacotes NuGet (o Visual Studio faz isso automaticamente, ou via CLI):
   ```bash
   dotnet restore
   ```
 
4. Compile e execute o projeto com **F5** ou pelo botão **Iniciar**.
 
5. Informe um CEP válido no campo mascarado e clique em **Consultar** (ou pressione **Enter**).
 
---
 
## 📦 Dependência NuGet
 
```
Newtonsoft.Json
```
 
Para instalar manualmente via CLI:
```bash
dotnet add package Newtonsoft.Json
```
 
---
 
## 📚 Conceitos Aplicados
 
- Consumo de **API REST** com `HttpClient`
- Desserialização de **JSON** com `Newtonsoft.Json` (`JsonConvert.DeserializeObject<T>`)
- Programação **assíncrona** com `async/await`
- Separação de responsabilidades com camadas de **Model** e **Service**
- Validação de entrada e controle de **duplicidade em memória** (`List<Endereco>`)
- Feedback visual ao usuário durante operações assíncronas
- Tratamento de **erros e exceções** com `try/catch/finally`
 
---
 
## 👨‍💻 Autor
 
Desenvolvido por **Ronaldo Brasil Rebouças Filho** como parte de estudos em C# e consumo de APIs.
 
---
 
## 📄 Licença
 
Este projeto é de caráter **acadêmico** e está disponível para fins de aprendizado e referência.
