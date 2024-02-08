Для сборки требуется:
- .Net6.0.26 sdk
- Docker version 25.0.2, build 29cf629

Команды сборки контейнера из каталога проекта (Windows):

-- сборка образа проекта

#Создание образа
docker build  -f ".\user-permissions\Dockerfile"  --force-rm -t userpermissions  --build-arg "BUILD_CONFIGURATION=Release" ".\"

#Создание контейнера
docker run -dt -e "ASPNETCORE_LOGGING__CONSOLE__DISABLECOLORS=true" -e "ASPNETCORE_ENVIRONMENT=Development"  -p 21812:80 --name user-permissions  --entrypoint tail userpermissions  -f /dev/null

После сборки:
 GET: http://localhost:21812/usersRoles 
 
 request: 
 [
    {
        "data": [
            {
                "id": "id",
                "userLogin": "userLogin",
                "_UserRole": "userRole"
            },
            {
                "id": "id",
                "userLogin": "userLogin",
                "_UserRole": "userRole"
            }
        ]
    },
    {
        "data": [
            {
                "id": "id",
                "userLogin": "userLogin",
                "_UserRole": "userRole"
            },
            {
                "id": "id",
                "userLogin": "userLogin",
                "_UserRole": "userRole"
            }
        ]
    }
]

Страница описания:
http://localhost:21812/swagger/index.html

