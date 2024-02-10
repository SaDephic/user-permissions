# Для сборки требуется:
## - .Net6.0.26 sdk
## - Docker version 25.0.2, build 29cf629

# Сборка:

## windows
./user-permissions/build.bat 

## linux
./user-permissions/build.sh

## Команды(внутри):

docker-compose down --remove-orphans

docker-compose build

docker-compose up -d

# Tест:
GET: http://localhost:21812/usersroles << 
[{"data":[{"id":"id","userLogin":"userLogin","_UserRole":"userRole"},{"id":"id","userLogin":"userLogin","_UserRole":"userRole"}]},{"data":[{"id":"id","userLogin":"userLogin","_UserRole":"userRole"},{"id":"id","userLogin":"userLogin","_UserRole":"userRole"}]}]

