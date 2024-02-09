# Для сборки требуется:
## - .Net6.0.26 sdk
## - Docker version 25.0.2, build 29cf629

# Сборка:

## windows
./build.bat 

## linux
./build.sh

## Команды(внутри):

docker-compose down --remove-orphans

docker-compose build

docker-compose up -d

# Tест:
GET: http://localhost:28080/usersRoles << []

GET: http://localhost:28080/healthz/live  << строка статуса

GET: http://localhost:28080/healthz/ready  << строка статуса

# Swagger:

### http://localhost:28080/swagger/index.html

# Отладка:
docker run -p 5432:5432 --name duser-permissions -e POSTGRES_PASSWORD=pem1812  -d postgres

# Миграция
-Add-Migration InitialCreate

- Update-Database


