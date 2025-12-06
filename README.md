# Crypto API

Uma API REST para encriptação e desencriptação de conteúdos textuais utilizando diversos algoritmos criptográficos.

## ?? Sobre o Projeto

O **Crypto API** é uma aplicação desenvolvida em .NET que fornece endpoints para realizar operações de criptografia e descriptografia de textos utilizando diferentes algoritmos de segurança. O projeto visa facilitar a implementação de recursos de segurança em aplicações que necessitam proteger informações sensíveis através de criptografia.

## ?? Acesso à API

A API está disponível online no Azure:

**?? URL da API:** [https://api-cryptografy.azurewebsites.net/swagger/index.html](https://api-cryptografy.azurewebsites.net/swagger/index.html)

### Infraestrutura
- **Plataforma**: Azure App Service
- **Plano**: Free Tier (F1)
- **CI/CD**: Pipeline de integração e entrega contínua implementado
- **Deploy automático**: Integração com GitHub para deploys automáticos

## ?? Tecnologias

- **.NET 9.0**
- **ASP.NET Core Web API**
- **Swagger/OpenAPI** - Documentação interativa da API
- **C# 13.0**
- **Azure App Service** - Hospedagem em nuvem

## ??? Arquitetura do Projeto

O projeto segue uma arquitetura em camadas, promovendo separação de responsabilidades e manutenibilidade:

### Estrutura de Pastas

```
crypto/
??? Controllers/  # Camada de apresentação (API endpoints)
?   ??? EncryptController.cs
??? Services/  # Camada de serviços (lógica de negócio)
?   ??? EncryptServices.cs
??? Encryptations/       # Implementações dos algoritmos de criptografia
?   ??? AESService.cs
?   ??? DESService.cs
?   ??? RC2Services.cs
?   ??? AesGcmServices.cs
??? Handler/          # Validações e tratamento de dados
?   ??? EncryptHandler.cs
??? Interface/       # Contratos e abstrações
?   ??? IEncryptService.cs
?   ??? IEncryptMethods.cs
?   ??? IHandlerEncryptService.cs
??? Models/   # Modelos de dados
?   ??? StringEncriptada.cs
??? Program.cs     # Configuração e inicialização da aplicação
```

### Camadas da Aplicação

#### 1. Controllers (Camada de Apresentação)
- **EncryptController**: Gerencia as requisições HTTP e retorna as respostas apropriadas
- Responsável por receber as requisições, chamar os serviços e retornar as respostas HTTP

#### 2. Services (Camada de Negócio)
- **EncryptServices**: Orquestra as operações de criptografia e descriptografia
- Implementa a interface `IEncryptService`
- Aplica validações através do `EncryptHandler`
- Delega a execução para os serviços específicos de cada algoritmo

#### 3. Encryptations (Camada de Implementação)
- Contém as implementações concretas dos algoritmos criptográficos:
  - **AESService**: Advanced Encryption Standard
  - **DESService**: Triple DES (3DES)
  - **RC2Services**: Rivest Cipher 2
  - **AesGcmServices**: AES no modo Galois/Counter Mode (em desenvolvimento)
- Cada serviço implementa a interface `IEncryptMethods`

#### 4. Handler (Camada de Validação)
- **EncryptHandler**: Valida os dados de entrada antes do processamento
- Verifica a presença de texto, chave de criptografia e vetor de inicialização

#### 5. Models (Camada de Dados)
- **StringEncriptada**: Modelo que encapsula os dados de criptografia
  - `textoDesencriptado`: Texto em formato legível
  - `textoEncriptado`: Texto após criptografia
  - `chaveDeCriptografia`: Chave utilizada no processo
  - `vetorDeInicializacao`: Vetor de inicialização (IV)

#### 6. Interfaces (Contratos)
- Definem os contratos que as implementações devem seguir
- Facilitam a manutenção e testabilidade do código

## ?? Endpoints Implementados

A API está organizada sob a rota base `/encriptar` e oferece os seguintes endpoints:

### ?? Encriptação

| Método | Endpoint | Descrição | Algoritmo |
|--------|----------|-----------|-----------|
| POST | `/encriptar/encripta-AES` | Encripta texto usando AES | AES |
| POST | `/encriptar/encripta-RC2` | Encripta texto usando RC2 | RC2 |
| POST | `/encriptar/encripta-TripleDES` | Encripta texto usando Triple DES | 3DES |

#### Request Body (Encriptação)
```json
{
  "textoDesencriptado": "Texto a ser criptografado"
}
```

#### Response (Encriptação)
```json
{
  "textoDesencriptado": "Texto a ser criptografado",
  "textoEncriptado": "Base64EncodedEncryptedText",
  "chaveDeCriptografia": "Base64EncodedKey",
  "vetorDeInicializacao": "Base64EncodedIV"
}
```

### ?? Desencriptação

| Método | Endpoint | Descrição | Algoritmo |
|--------|----------|-----------|-----------|
| POST | `/encriptar/desencripta-AES` | Desencripta texto usando AES | AES |
| POST | `/encriptar/desencripta-RC2` | Desencripta texto usando RC2 | RC2 |
| POST | `/encriptar/desencripta-TripleDES` | Desencripta texto usando Triple DES | 3DES |

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

### ?? Códigos de Status

| Código | Descrição |
|--------|-----------|
| 200 | Operação realizada com sucesso |
| 400 | Dados de entrada inválidos (ArgumentException) |
| 500 | Erro interno no processamento (InvalidOperationException) |

## ?? Instalação e Execução

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

## ?? Algoritmos Suportados

### Implementados
- **AES (Advanced Encryption Standard)**: Algoritmo de criptografia simétrica amplamente utilizado
- **Triple DES (3DES)**: Versão aprimorada do DES com tripla encriptação
- **RC2 (Rivest Cipher 2)**: Algoritmo de criptografia de bloco de tamanho variável

### Em Desenvolvimento
- **AES-GCM (Galois/Counter Mode)**: Modo de operação do AES que fornece autenticação
- **RC4**: Cifra de fluxo
- **RSA**: Criptografia assimétrica

## ?? Funcionalidades Futuras

Baseado na interface `IEncryptService`, os seguintes endpoints estão planejados:

- ? AES - Implementado
- ? Triple DES - Implementado
- ? RC2 - Implementado
- ? AES-GCM - Em desenvolvimento
- ? RC4 - Planejado
- ? RSA - Planejado

## ?? Dependências

- **Swashbuckle.AspNetCore (9.0.6)**: Geração de documentação Swagger/OpenAPI

## ??? Configuração de Injeção de Dependências

O projeto utiliza injeção de dependências nativa do ASP.NET Core:

```csharp
builder.Services.AddScoped<EncryptServices>();
builder.Services.AddScoped<EncryptHandler>();
builder.Services.AddTransient<AESService>();
builder.Services.AddTransient<DESService>();
builder.Services.AddTransient<AesGcmServices>();
builder.Services.AddTransient<RC2Services>();
```

## ?? Deploy e CI/CD

O projeto está configurado com um pipeline de CI/CD que realiza deploy automático no Azure:

- **Plataforma**: Azure App Service (Free Tier - F1)
- **Processo**: Integração contínua com GitHub
- **Deploy**: Automático a cada push na branch principal
- **Monitoramento**: Disponível através do portal Azure

## ?? Licença

Este projeto está em desenvolvimento ativo.

## ?? Autor

**Vinícius Gabriel**

- GitHub: [@viniGab2004](https://github.com/viniGab2004)

---

? Desenvolvido com .NET 9.0 | ?? Hospedado no Azure
