# Для сборки требуется:
### - .Net6.0.26 sdk
### - Docker version 25.0.2, build 29cf629

# Сборка:
docker build -f ".\user-permissions\Dockerfile" --force-rm -t user-permissions:1.0.0 --build-arg "BUILD_CONFIGURATION=Release" "."

GET: {host}/permissions << 
{"userRole":"userRole","permissions":["permissions","permissions"]}