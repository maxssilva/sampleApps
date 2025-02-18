# Sample Apps for APL2007 Training

This folder contains sample apps that are used in the APL2007 training. Many of the exercise units use these sample apps as the starting point for coding projects.

## APL2007M2Sample1

### Descrição
O `APL2007M2Sample1` é um exemplo de aplicação WPF que demonstra operações assíncronas paralelas para baixar páginas da web e calcular seus tamanhos. Ele utiliza o `HttpClient` para fazer solicitações HTTP e exibe os resultados em uma interface gráfica.

### Requisitos
- .NET 6.0 SDK
- Conexão com a internet

### Restrições
- O projeto deve ser executado em um ambiente Windows, pois utiliza WPF.
- A aplicação deve ter acesso à internet para baixar as páginas da web.

### Arquitetura
O projeto é uma aplicação WPF que utiliza o padrão MVVM (Model-View-ViewModel). A interface gráfica é definida em XAML e o código de lógica está no arquivo `MainWindow.xaml.cs`.

### Projeto de Design
- **Interface do Usuário**: A interface do usuário consiste em um botão "Start" e uma caixa de texto para exibir os resultados.
- **Operações Assíncronas**: As operações de download das páginas da web são realizadas de forma assíncrona utilizando `HttpClient` e `Task`.
- **Atualização da UI**: A interface do usuário é atualizada utilizando o `Dispatcher` para garantir que as atualizações ocorram no thread da UI.

### Teste de Projeto
- **Testes Manuais**: O projeto pode ser testado manualmente executando a aplicação, clicando no botão "Start" e verificando se os tamanhos das páginas da web são exibidos corretamente na caixa de texto.
- **Testes de Unidade**: Testes de unidade podem ser adicionados para verificar a lógica de download e cálculo dos tamanhos das páginas da web.

### Implantação do Projeto
1. **Clone o repositório**:
    ```sh
    git clone https://github.com/seu-usuario/seu-repositorio.git
    cd seu-repositorio/APL2007M2Sample1
    ```

2. **Instale o .NET 6.0 SDK**:
    - Siga as instruções de instalação no site oficial do [.NET](https://dotnet.microsoft.com/download/dotnet/6.0).

3. **Restaure as dependências**:
    ```sh
    dotnet restore
    ```

4. **Construa o projeto**:
    ```sh
    dotnet build
    ```

5. **Execute o projeto**:
    ```sh
    dotnet run
    ```

### Resumo do Projeto
O [APL2007M2Sample1](http://_vscodecontentref_/1) é um exemplo de aplicação WPF que demonstra como realizar operações assíncronas paralelas para baixar páginas da web e calcular seus tamanhos. Ele utiliza o `HttpClient` para fazer as solicitações HTTP e exibe os resultados em uma interface gráfica. O projeto é uma excelente demonstração de como utilizar operações assíncronas em aplicações WPF e como atualizar a interface do usuário de forma segura a partir de threads de background.

### Dependências
- **System.Net.Http**: Utilizado para fazer solicitações HTTP assíncronas.
- **System.Linq**: Utilizado para consultas LINQ.
- **System.Threading.Tasks**: Utilizado para operações assíncronas e paralelas.
- **System.Windows**: Utilizado para a interface gráfica do usuário (WPF).

### Diretrizes para colaboradores
1. **Fork o repositório**.
2. **Crie um branch para sua feature ou correção de bug** (`git checkout -b feature/nova-feature`).
3. **Commit suas mudanças** (`git commit -am 'Adiciona nova feature'`).
4. **Envie para o branch** (`git push origin feature/nova-feature`).
5. **Abra um Pull Request**.

### Licença
Este projeto está licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.