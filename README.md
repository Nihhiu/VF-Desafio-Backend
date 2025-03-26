## Como Testar o Código

### 1. Navegar até o Diretório do Projeto
```bash
cd .\ListarInstitutos
```

### 2. Executar o Projeto
```bash
dotnet run
```

### 3. Testar a API

#### 3.1 Usando o Arquivo `ListarInstitutos.http`
Utilize os exemplos disponíveis no arquivo `ListarInstitutos.http` para testar.

#### 3.2 Testando Manualmente no Navegador ou Ferramenta de API
Adicione os seguintes parâmetros ao URL base:

- **`university\all`**: Lista todos os institutos.
- **`university\search`**: Lista uma seleção específica.
    - **`?name=`**: Filtra os resultados pelo nome especificado.
    - **`&count=true`**: Retorna a contagem dos resultados.
    - **`&order=asc`** ou **`&order=desc`**: Ordena os resultados em ordem alfabética crescente ou decrescente.

Exemplo de URL:
```
http://localhost:5000/university/all?name=example&count=true&order=asc
```