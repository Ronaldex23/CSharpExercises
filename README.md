# Exercícios C# - Visão Geral e Guia de Uso

> Este repositório contém alguns dos exercícios em **C# via console** que tenho feito ao longo desse ciclo de aprendizagem, organizados para uso no **Visual Studio 2022**. Espero que goste 😊

---
## 📋 Sumário
- [Estrutura Básica de cada Exercício](#estrutura-básica-de-cada-exercício)
- [O que tenho aprendido?](#o-que-tenho-aprendido)
- [Agora é sua vez, teste e execute](#agora-é-sua-vez-teste-e-execute)
- [Contribuições e licença](#contribuições-e-licença)

## ⚙️Estrutura Básica de cada Exercício {#estrutura-básica-de-cada-exercício}
Ao abrir cada pasta, você encontrará:  
- `Exercise-Name.cs`: arquivo com o código.
- `Exercise-Name.csproj`: projeto .NET console pronto para execução no Visual Studio 2022.
- `README.md`: Explicação detalhada da proposição do exercício, incluindo objetivos e exemplos de saída.

## 📚O que tenho aprendido? {#o-que-tenho-aprendido}

### Paradigmas e Abordagens
1. Programação Modular (procedural)
2. Programação Orientada a Objetos (POO)
   
### Técnicas e boas práticas desenvolvidas
- **Encapsulamento:** separar lógica de negócio em classes com métodos claros.
- **Tratamento de erros:** `try/catch` para proteger operações de I/O e conversão numérica.
- **Validação de entrada:** evitar exceções por entradas inválidas (use `int.TryParse`, `decimal.TryParse` etc.).
- **Versionamento:** conforme necessidade, tenho realizado alguns commits para melhorias dos exercícios.

## 🚀Agora é sua vez, teste e execute {#agora-é-sua-vez-teste-e-execute}
> 🔧 Pré-requisitos: Certifique-se de ter instalado em sua máquina:
> - **Visual Studio 2022** (Community Edition é gratuita): Baixe em [visualstudio.microsoft.com](https://visualstudio.microsoft.com/pt-br/downloads/).
> - **.NET SDK 6.0 ou superior**: Incluído no VS, mas verifique com `dotnet --version` no terminal.

### Como abrir e executar cada exercício no Visual Studio 2022 (passo-a-passo)
1.  **Clone o repositório `CSharpExercises` ou mesmo a pasta do exercício desejado localmente**

3.  **Abrir o projeto/pasta**
   - Opção 1: Abra o `ExercícioNN_Nome` clicando duas vezes no arquivo `.csproj` dentro do Explorer do Windows — o Visual Studio abrirá o projeto diretamente.
   - Opção 2 (recomendado para múltiplos exercícios): Abra a pasta raiz (`Exercicios-CSharp-Console`) em Visual Studio via *File → Open → Folder...* ou crie uma *Solution* e adicione cada `.csproj` como projeto no mesmo Solution (`File → New → Project → Blank Solution`, depois `Add → Existing Project...`).

3. **Executar em modo console**
   - Pressione `F5` para executar com depuração (abre o console e permite breakpoints).
  
## 🤝 Contribuições e licença {#contribuições-e-licença}
- **Contribuições**: Sinta-se à vontade para abrir issues com sugestões ou pull requests com melhorias. Todos os exercícios são open-source!
- **Licença**: Este repositório está sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para detalhes.
- **Contato**: Dúvidas? Abra uma issue ou me envie um e-mail em [ronaldo.reboucas07@gmail.com].

*Palavras-chave: C#, .NET Console, Trilha de Aprendizado, Lógica de Programação, Programação Modular, Programação Orientada a Objetos*
