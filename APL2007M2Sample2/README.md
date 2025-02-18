# README.md

## Descrição
O `APL2007M2Sample2` é um aplicativo IoT que monitora a temperatura e a umidade usando um sensor BME280 e controla um ventilador com base nas condições monitoradas. O dispositivo se comunica com a nuvem usando o Azure IoT Hub, enviando telemetria em intervalos regulares e atualizando o dispositivo gêmeo com os dados atuais. O projeto demonstra o uso de GPIO, I2C e comunicação com a nuvem em um cenário de IoT.

## Instruções de configuração
1. **Clone o repositório**:
    ```sh
    git clone https://github.com/seu-usuario/seu-repositorio.git
    cd seu-repositorio/APL2007M2Sample2
    ```

2. **Instale o .NET 6.0 SDK**:
    - Siga as instruções de instalação no site oficial do [.NET](https://dotnet.microsoft.com/download/dotnet/6.0).

3. **Configure a string de conexão do dispositivo**:
    - Abra o arquivo `Program.cs` e substitua `"YOUR DEVICE CONNECTION STRING HERE"` pela sua string de conexão do Azure IoT Hub.

4. **Restaure as dependências**:
    ```sh
    dotnet restore
    ```

## Uso
1. **Construa o projeto**:
    ```sh
    dotnet build
    ```

2. **Execute o projeto**:
    ```sh
    dotnet run
    ```

3. **Exemplo de código**:
    - O código principal está localizado no arquivo `Program.cs`. Aqui está um exemplo de como o dispositivo monitora as condições e controla o ventilador:

    ```csharp
    private static async void MonitorConditionsAndUpdateTwinAsync()
    {
        // Implementação do método
    }

    private static Task<MethodResponse> SetFanState(MethodRequest methodRequest, object userContext)
    {
        // Implementação do método
    }

    private static async Task UpdateTwin(double currentTemperature, double currentHumidity)
    {
        // Implementação do método
    }
    ```

## Diretrizes para colaboradores
1. **Fork o repositório**.
2. **Crie um branch para sua feature ou correção de bug** (`git checkout -b feature/nova-feature`).
3. **Commit suas mudanças** (`git commit -am 'Adiciona nova feature'`).
4. **Envie para o branch** (`git push origin feature/nova-feature`).
5. **Abra um Pull Request**.

## Licença
Este projeto está licenciado sob a licença MIT. Veja o arquivo LICENSE para mais detalhes.