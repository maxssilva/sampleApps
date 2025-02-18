# Documentation-APL2007M2Sample2

## Visão geral
O projeto `APL2007M2Sample2` é um aplicativo que monitora a temperatura e a umidade usando um sensor BME280 e controla um ventilador com base nas condições monitoradas. O dispositivo se comunica com a nuvem usando o Azure IoT Hub.

## Características
- Monitoramento de temperatura e umidade usando o sensor BME280.
- Controle de um ventilador baseado nas condições monitoradas.
- Comunicação com a nuvem usando o Azure IoT Hub.
- Atualização do dispositivo gêmeo com a temperatura e umidade atuais.
- Manipulação de métodos diretos para controlar o estado do ventilador.
- Envio de telemetria para a nuvem em intervalos regulares.

## Requisitos
- .NET 6.0 SDK
- Sensor BME280
- Controlador GPIO
- Azure IoT Hub
- Conexão com a internet

## Restrições
- O dispositivo deve estar conectado a um sensor BME280.
- O dispositivo deve ter acesso à internet para se comunicar com o Azure IoT Hub.
- A string de conexão do dispositivo deve ser configurada corretamente no código.

## Dependências
- `System.Device.Gpio`
- `System.Device.I2c`
- `Iot.Device.Bmxx80`
- `Microsoft.Azure.Devices.Client`
- `Microsoft.Azure.Devices.Shared`

## Resumo
O projeto `APL2007M2Sample2` é um exemplo de aplicação IoT que monitora a temperatura e a umidade usando um sensor BME280 e controla um ventilador com base nas condições monitoradas. O dispositivo se comunica com a nuvem usando o Azure IoT Hub, enviando telemetria em intervalos regulares e atualizando o dispositivo gêmeo com os dados atuais. O projeto demonstra o uso de GPIO, I2C e comunicação com a nuvem em um cenário de IoT.