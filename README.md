# Crypto API

Uma API REST para encriptação e desencriptação de conteúdos textuais utilizando diversos algoritmos criptográficos.

## Sobre o Projeto

O **Crypto API** é uma aplicação desenvolvida em .NET que fornece endpoints para realizar operações de criptografia e descriptografia de textos utilizando diferentes algoritmos de segurança. O projeto visa facilitar a implementação de recursos de segurança em aplicações que necessitam proteger informações sensíveis através de criptografia.

## Acesso à API

A API está disponível online no Azure:

**URL da API:** [https://api-cryptografy.azurewebsites.net/swagger/index.html](https://api-cryptografy.azurewebsites.net/swagger/index.html)

### Infraestrutura
- **Plataforma**: Azure App Service
- **Plano**: Free Tier (F1)
- **CI/CD**: Pipeline de integração e entrega contínua implementado
- **Deploy automático**: Integração com GitHub Actions para deploys automáticos

## Tecnologias

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Swagger/OpenAPI** - Documentação interativa da API
- **C# 13.0**
- **Azure App Service** - Hospedagem em nuvem

## Arquitetura do Projeto

O projeto segue uma arquitetura em camadas, promovendo separação de responsabilidades e manutenibilidade:

### Estrutura de Pastas

```
crypto/
├── Controllers/    # Camada de apresentação (API endpoints)
│   ├── EncryptController.cs
│   └── DecryptController.cs
├── Services/# Camada de serviços (lógica de negócio)
│   ├── EncryptServices.cs
│   └── DecryptServices.cs
├── Encryptations/  # Implementações dos algoritmos de criptografia
│   ├── AESService.cs
│   ├── DESService.cs
│   ├── RC2Services.cs
│   └── AesGcmServices.cs
├── Handler/        # Validações e tratamento de dados
│   └── EncryptHandler.cs
├── Interface/      # Contratos e abstrações
│   ├── IEncryptService.cs
│   ├── IDecryptService.cs
│   ├── IEncryptMethods.cs
│   └── IAesGcmServices.cs
├── Models/         # Modelos de dados
│   └── StringEncriptada.cs
└── Program.cs  # Configuração e inicialização da aplicação
```

### Camadas da Aplicação

#### 1. Controllers (Camada de Apresentação)
- **EncryptController**: Gerencia as requisições HTTP para operações de encriptação
  - Rota base: `/encriptar`
  - Endpoints: AES, Triple DES, RC2, AES-GCM
- **DecryptController**: Gerencia as requisições HTTP para operações de desencriptação
  - Rota base: `/desencriptar`
  - Endpoints: AES, Triple DES, RC2
- Responsável por receber as requisições, chamar os serviços e retornar as respostas HTTP
- Implementa tratamento de exceções com códigos HTTP apropriados

#### 2. Services (Camada de Negócio)
- **EncryptServices**: Orquestra as operações de criptografia
  - Implementa a interface `IEncryptService`
  - Aplica validações através do `EncryptHandler`
  - Delega a execução para os serviços específicos de cada algoritmo
- **DecryptServices**: Orquestra as operações de descriptografia
  - Implementa a interface `IDecryptService`
  - Aplica validações de texto encriptado, chave e vetor de inicialização
  - Delega a execução para os serviços específicos de cada algoritmo

#### 3. Encryptations (Camada de Implementação)
Contém as implementações concretas dos algoritmos criptográficos:
- **AESService**: Advanced Encryption Standard
  - Implementa `IEncryptMethods`
  - Suporta encriptação e desencriptação
- **DESService**: Triple DES (3DES)
  - Implementa `IEncryptMethods`
  - Suporta encriptação e desencriptação
- **RC2Services**: Rivest Cipher 2
  - Implementa `IEncryptMethods`
  - Suporta encriptação e desencriptação
- **AesGcmServices**: AES no modo Galois/Counter Mode
  - Implementa `IAesGcmServices`
  - Encriptação implementada (não utiliza IV tradicional)
  - Desencriptação em desenvolvimento

#### 4. Handler (Camada de Validação)
- **EncryptHandler**: Implementa `IHandlerEncryptService`
  - `possuiTextoDesencriptado`: Valida a presença de texto para encriptar
  - `possuiTextoEncriptado`: Valida a presença de texto encriptado
  - `possuiChaveDeCriptografia`: Valida a presença da chave de criptografia
  - `possuiVetorDeInicializacao`: Valida a presença do vetor de inicialização

#### 5. Models (Camada de Dados)
- **StringEncriptada**: Modelo que encapsula os dados de criptografia
  - `textoDesencriptado`: Texto em formato legível
  - `textoEncriptado`: Texto após criptografia (Base64)
  - `chaveDeCriptografia`: Chave utilizada no processo (Base64)
  - `vetorDeInicializacao`: Vetor de inicialização - IV (Base64)

#### 6. Interfaces (Contratos)
- **IEncryptService**: Define os métodos de encriptação para todos os algoritmos
- **IDecryptService**: Define os métodos de desencriptação para todos os algoritmos
- **IEncryptMethods**: Contrato para implementação de algoritmos de criptografia simétrica
- **IAesGcmServices**: Contrato específico para o serviço AES-GCM
- Facilitam a manutenção, testabilidade e extensibilidade do código

## Endpoints Implementados

A API está organizada em dois controllers distintos para melhor organização:

### Encriptação

Rota base: `/encriptar`

| Método | Endpoint | Descrição | Algoritmo | Status |
|--------|----------|-----------|-----------|--------|
| POST | `/encriptar/encripta-AES` | Encripta texto usando AES | AES | Implementado |
| POST | `/encriptar/encripta-RC2` | Encripta texto usando RC2 | RC2 | Implementado |
| POST | `/encriptar/encripta-TripleDES` | Encripta texto usando Triple DES | 3DES | Implementado |
| POST | `/encriptar/encripta-AesGcm` | Encripta texto usando AES-GCM | AES-GCM | Implementado |

#### Request Body (Encriptação)
```json
{
  "textoDesencriptado": "Texto a ser criptografado"
}
```

#### Response (Encriptação - AES, RC2, Triple DES)
```json
{
  "textoDesencriptado": "Texto a ser criptografado",
  "textoEncriptado": "Base64EncodedEncryptedText",
  "chaveDeCriptografia": "Base64EncodedKey",
  "vetorDeInicializacao": "Base64EncodedIV"
}
```

#### Response (Encriptação - AES-GCM)
```json
{
  "textoDesencriptado": "",
  "textoEncriptado": "Base64EncodedEncryptedText",
  "chaveDeCriptografia": "Base64EncodedKey",
  "vetorDeInicializacao": ""
}
```
**Nota**: AES-GCM não utiliza vetor de inicialização (IV) tradicional. O nonce e a tag de autenticação são combinados com o texto encriptado.

### Desencriptação

Rota base: `/desencripar`

| Método | Endpoint | Descrição | Algoritmo | Status |
|--------|----------|-----------|-----------|--------|
| POST | `/desencripar/desencripta-AES` | Desencripta texto usando AES | AES | Implementado |
| POST | `/desencripar/desencripta-RC2` | Desencripta texto usando RC2 | RC2 | Implementado |
| POST | `/desencripar/desencripta-TripleDES` | Desencripta texto usando Triple DES | 3DES | Implementado |

#### Request Body (Desencriptação)
```json
{
  "textoEncriptado": "Base64EncodedEncryptedText",
  "chaveDeCriptografia": "Base64EncodedKey",
  "vetorDeInicializacao": "Base64EncodedIV"
}
```

#### Response (Desencriptação)
```json
{
  "textoDesencriptado": "Texto original descriptografado",
  "textoEncriptado": "Base64EncodedEncryptedText",
  "chaveDeCriptografia": "Base64EncodedKey",
  "vetorDeInicializacao": "Base64EncodedIV"
}
```

### Códigos de Status

| Código | Descrição |
|--------|-----------|
| 200 | Operação realizada com sucesso |
| 400 | Dados de entrada inválidos (ArgumentException) |
| 500 | Erro interno no processamento (InvalidOperationException) |

## Instalação e Execução

### Pré-requisitos

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)

### Passos para Execução Local

1. Clone o repositório:
```bash
git clone https://github.com/viniGab2004/crypto_backend.git
cd crypto_backend
```

2. Restaure as dependências:
```bash
dotnet restore
```

3. Execute a aplicação:
```bash
dotnet run
```

4. Acesse a documentação Swagger localmente:
```
https://localhost:{porta}/swagger
```

## Algoritmos Suportados

### Implementados
- **AES (Advanced Encryption Standard)**: Algoritmo de criptografia simétrica amplamente utilizado
  - Encriptação: Implementado
  - Desencriptação: Implementado
- **Triple DES (3DES)**: Versão aprimorada do DES com tripla encriptação
  - Encriptação: Implementado
  - Desencriptação: Implementado
- **RC2 (Rivest Cipher 2)**: Algoritmo de criptografia de bloco de tamanho variável
  - Encriptação: Implementado
  - Desencriptação: Implementado
- **AES-GCM (Galois/Counter Mode)**: Modo de operação do AES que fornece autenticação
  - Encriptação: Implementado
  - Desencriptação: Em desenvolvimento

### Planejados
- **RC4**: Cifra de fluxo
- **RSA**: Criptografia assimétrica

## Funcionalidades por Algoritmo

| Algoritmo | Encriptação | Desencriptação |
|-----------|-------------|----------------|
| AES | Implementado | Implementado |
| Triple DES | Implementado | Implementado |
| RC2 | Implementado | Implementado |
| AES-GCM | Implementado | Em desenvolvimento |
| RC4 | Planejado | Planejado |
| RSA | Planejado | Planejado |

## Dependências

- **Swashbuckle.AspNetCore (9.0.6)**: Geração de documentação Swagger/OpenAPI

## Configuração de Injeção de Dependências

O projeto utiliza injeção de dependências nativa do ASP.NET Core:

```csharp
// Services
builder.Services.AddScoped<EncryptServices>();
builder.Services.AddScoped<DecryptServices>();

// Handler
builder.Services.AddScoped<EncryptHandler>();

// Encryptation Implementations
builder.Services.AddTransient<AESService>();
builder.Services.AddTransient<DESService>();
builder.Services.AddTransient<AesGcmServices>();
builder.Services.AddTransient<RC2Services>();
```

### Ciclos de Vida
- **Scoped**: Services e Handler (uma instância por requisição HTTP)
- **Transient**: Serviços de encriptação (nova instância a cada injeção)

## Deploy e CI/CD

O projeto está configurado com um pipeline de CI/CD que realiza deploy automático no Azure:

- **Plataforma**: Azure App Service (Free Tier - F1)
- **Processo**: Integração contínua com GitHub
- **Deploy**: Automático a cada push na branch principal
- **Monitoramento**: Disponível através do portal Azure

## Licença

Este projeto está em desenvolvimento ativo.

## Autor

**Vinícius Gabriel**

- GitHub: [@viniGab2004](https://github.com/viniGab2004)

---

Desenvolvido com .NET 9.0 | Hospedado no Azure
