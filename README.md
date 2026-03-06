================================================================
                ESP32 + Wokwi + ASP.NET Web API
                 Integração IoT com Backend
================================================================


VISÃO GERAL
----------------------------------------------------------------
Este projeto demonstra a comunicação entre um dispositivo IoT
(ESP32) simulado no Wokwi e uma API REST desenvolvida em
ASP.NET Core.

O objetivo é mostrar como um microcontrolador pode enviar dados
de sensores para um backend utilizando requisições HTTP com
dados em formato JSON.

Mesmo sendo uma simulação, o fluxo reproduz um cenário real de
arquiteturas IoT utilizadas em:

- monitoramento de sensores
- automação
- coleta de dados
- sistemas conectados a servidores


TECNOLOGIAS UTILIZADAS
----------------------------------------------------------------

BACKEND
- C#
- ASP.NET Core Web API (.NET 8)
- Swagger / Swashbuckle
- Visual Studio

IOT / FIRMWARE
- ESP32
- Arduino Framework
- Bibliotecas utilizadas no firmware:
  WiFi.h
  HTTPClient.h
  ArduinoJson

SIMULAÇÃO
- Wokwi

BUILD / COMPILAÇÃO
- PlatformIO


EXTENSÕES NECESSÁRIAS (VS CODE)
----------------------------------------------------------------

Para executar corretamente o projeto do ESP32 no VS Code,
algumas extensões são necessárias.

1) PlatformIO IDE

Extensão responsável por gerenciar projetos de
microcontroladores.

Ela instala automaticamente:

- compilador
- framework Arduino
- bibliotecas
- ferramentas de build

Também é responsável por gerar os arquivos de firmware usados
pelo Wokwi.


2) Wokwi Simulator

Permite executar a simulação do ESP32 diretamente dentro do
VS Code utilizando o firmware compilado pelo PlatformIO.


3) C/C++ (Microsoft)

Responsável por:

- syntax highlighting
- autocomplete
- IntelliSense

Sem essa extensão o código pode aparecer sem cores ou sem
sugestões no editor.


ARQUITETURA DO SISTEMA
----------------------------------------------------------------

Fluxo de comunicação:

        ESP32 (Wokwi)
              |
              | HTTP POST (JSON)
              v
        ASP.NET Web API
              |
              v
        Console da aplicação


O ESP32 envia dados simulando um sensor (por exemplo um DHT11).

A API recebe esses dados através do endpoint:

/api/Sensor


CONFIGURAÇÃO DA API
----------------------------------------------------------------

Para que o ESP32 consiga acessar a API, o servidor precisa
aceitar conexões externas.

Isso pode ser configurado permitindo que a aplicação escute
em um endereço geral da rede.

Exemplo:

0.0.0.0:5050

Isso permite que dispositivos da rede consigam acessar a API.


ARQUIVO DE CONFIGURAÇÃO DO WOKWI
----------------------------------------------------------------

O projeto utiliza um arquivo de configuração chamado:

wokwi.toml

Esse arquivo conecta o simulador Wokwi com o firmware gerado
pelo PlatformIO.

Ele aponta para os arquivos gerados durante a compilação:

- firmware.bin
- firmware.elf


PASSOS PARA EXECUTAR
----------------------------------------------------------------

1. Criar a API ASP.NET Core Web API no Visual Studio

2. Criar o endpoint responsável por receber os dados do sensor

3. Executar a API e verificar se o Swagger abre corretamente

4. Descobrir o IP da máquina que está rodando a API

5. Configurar o endereço da API no firmware do ESP32

6. Compilar o firmware utilizando PlatformIO

7. Executar a simulação do ESP32 no Wokwi

8. Verificar os logs do ESP32 e da API


RESULTADO ESPERADO
----------------------------------------------------------------

Quando tudo está funcionando corretamente:

- o ESP32 envia requisições HTTP
- a API responde com status 200
- os dados enviados aparecem no console da aplicação


PROBLEMAS COMUNS
----------------------------------------------------------------

CONNECTION RESET BY PEER

Esse erro significa que o ESP32 conseguiu encontrar o servidor,
mas a conexão foi encerrada.

Possíveis causas:

- API não está rodando
- IP incorreto
- porta incorreta
- endpoint errado


SWAGGER NÃO MOSTRA DADOS

Isso é esperado.

O endpoint apenas recebe dados e escreve no console da API.
Ele não salva nem retorna os dados no Swagger.


CONCLUSÃO
----------------------------------------------------------------

Este projeto demonstra uma arquitetura básica de comunicação
entre um dispositivo IoT (ESP32) e um backend.

Mesmo utilizando simulação no Wokwi, o fluxo reproduz o
funcionamento de sistemas reais onde sensores enviam dados
para servidores usando HTTP e JSON.

Essa base pode ser expandida para:

- armazenamento em banco de dados
- dashboards de monitoramento
- sistemas de automação
- integração com serviços em nuvem

================================================================
