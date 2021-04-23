# MassTransitUsingRabbitMQ

[MassTransit, RabbitMQ - The Details](https://www.youtube.com/watch?v=2cG2qzNgcsA)

## Run RabbitMQ docker image

```powershell
docker run --name my-rabbit -d -p 5672:5672 -p 15672:15672 rabbitmq:3-management
```

OR

```powershell
docker run -p 15672:15672 -p 5672:5672 masstransit/rabbitmq
```

> Access to RabbitMQ GUI at [http://localhost:15672/](http://localhost:15672/)