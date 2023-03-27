# ContaBancaria

ConnectionString para o MongoDb: mongodb://localhost:27017

ENDPOINTS aplicação:

Get: localhost:/home/consulta/{cpf}?dataInicio=&dataFim=

Post: localhost:/home/cadastroTransacao
Body do Post: 
{
    "Cpf": "",
    "tipo": "",
    "Valor": 
}

Delete: localhost:/home/deletarTransacao/{id}
