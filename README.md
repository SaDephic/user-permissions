Сборка проекта:

Сборка контейнера из каталога проекта:
  - docker run -p 21812:80 -P --name user-permissions --entrypoint tail userpermissions:dev -f /dev/null

сборка без контейнера.
- dotnet build -o /app/net

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

Пакеты:
- .Net6.0.26 sdk
- Docker version 25.0.2, build 29cf629
- liquibase
