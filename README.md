# CarrefourFluxoCaixa
Projeto desenvolvido com .NET 7.0
Instruções de como utilizar web api estão disponíveis em Swagger. Se executar a partir de Visual Studio faça em modo administrador para carregar comentários em Swagger.

**Desing Patterns
SOLID Principles: baseado em interfaces para serviços e entidades

Microserviço: independente para time, permite escalar horizontalmente e verticalmente

##CQRS (Não inteiramente já que não existe uma outra base de dados para read na solução, nem foi implementado Commands em dominio ou Query Results, business layer está em application service com validação lá também, comunicação com repositório, mas existe view model e models): Consultas e persistência em database realizada em repositórios (Persistência), contratos repositórios e entidades em Domínio, Serviços contém regras de negócio e invocação de contratos, controller invocam serviços e fazem validação

##Saga: FluxoCaixaConsolidado service RabbitMQ

##Repository: EF

##Strategy: EF depende de abstrações

##Retry: tentativa de reconexão à base de dados

##AutoMapper: mapeamento entre viewModel, entidades, modelRequest

##Annotations: entidades e view models com características de campo e validação

##EntityFramework: EF Core 7, CodeFirst

##AMQP Rabbit MQ: Mensageria pode ser ativada ou desativada em arquivo de appsettings, mas se ativada deve ser instalada versão (3.12.2), em projeto RabbitMQ.Client 6.5.0

##Unit Tests: Utilizado Moq e VisualStudioUnitTests. Realizado unit testes com padrão AAA (arrange act assert) de um serviço ApplicationServiceBalanceUnitTest. Cobre métodos, exceções 

##Monitoramento Application insights, entretanto não está ativado

##SQL Server 2016 gerado a partir de migrations
##IIS padrão de uso

##Docker: deve ser realizado publish, gerar imagem e criar container, incluir atributo para permitir consulta a serviços externos --network host, connection string deve ser atualizada em appsettings.json para container linux (exemplo:
"ConnectionStrings": {
    "DefaultConnection": "Data Source=host.docker.internal,1433;Initial Catalog=FluxoCaixa;Integrated Security=False;User ID=user;Password=password;Encrypt=False;"
  })
alterar AMQP hostname para host.docker.internal

Para publicar versão da aplicação faça na pasta da solução:
Dotnet publish -c Debug

Gerar imagem em docker:
docker build -f "D:\RestfulApi\CarrefourFluxoCaixa\CarrefourFluxoCaixa\Dockerfile" --force-rm -t carrefour "D:\RestfulApi\CarrefourFluxoCaixa"

Criar container a partir de imagem:
docker run -dt -e "ASPNETCORE_ENVIRONMENT=Development" -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true"  -p49155:80 --name carrefour_development carrefour:latest --network host
