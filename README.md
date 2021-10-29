# ServerRoomMonitoringApp

# Docker

## Development

### Build image
In ServerRoomMonitoring.Web folder run to build an image:

`docker build . -t local/serverroom-web`

### Compose
In base repo folder run:

`docker compose -f .\docker-compose.developer.yml -p serverroom up -d`

It will use the image created with the previous command and expose the app frontend under http://localhost:8080.

### Run only rabbitmq
In base repo folder run:

`docker compose -f .\docker-compose.developer.yml -p serverroom  up -d rabbitmq`

It will create and run docker container with default rabbitmq config. This means that messages are using 5672 port, and management UI is available under 15672 port with guest/guest credentials.

## Production
TODO: use faculty docker registry server instead of the docker hub

### Build image
### Build image
In ServerRoomMonitoring.Web folder run to build an image:

`docker build . -t tpiechocki/si_175690`

Later publish the image to registry, so it can be used by docker compose file:

`docker push tpiechocki/si_175690`

### Compose
In base repo folder run :

`docker compose -f .\docker-compose.yml -p SI_175690 up -d`

It will expose the app on 17569 port.