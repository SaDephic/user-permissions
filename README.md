#Для сборки требуется:
##- .Net6.0.26 sdk
##- Docker version 25.0.2, build 29cf629

#Сборка:

###windows
./build.bat 

###linux
./build.sh

или выполнить команды:

docker-compose down --remove-orphans

docker-compose build

docker-compose up -d

#Тест:
GET: http://localhost:28080/usersRoles 

вернется пустой массив.

GET: http://localhost:28080/healthz/live 

GET: http://localhost:28080/healthz/ready

по запросам вернется строка.

Страница swagger:

http://localhost:28080/swagger/index.html

