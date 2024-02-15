:: i = INITIALIZE u = UPDATE

@echo off
chcp 65001

if "%~2"=="" (goto build)

if "%~2"=="i" (goto create)

if "%~2"=="u" (goto update)

:create

:create
echo Удаление существующего
RD /S/Q user-permissions
echo clone
cmd /c git clone https://github.com/SaDephic/user-permissions.git
goto build

:update
git pull
goto build

:build
echo В дирректории проекта
cd .\user-permissions

if "%~1"=="" (echo ВНИМАНИЕ! Укажите версию сборки & goto end)

::Проверка версии
echo current %1
pause

echo Сборка артефактов
cmd /c docker build -f ".\user-permissions\Dockerfile" --force-rm -t user-permissions:%1 --build-arg "BUILD_CONFIGURATION=Release" "."

echo Данные авторизации
echo https://repo.gba.ls-dev.ru/#browse/browse:chr-tmp
echo docker login chr-dev.gba.ls-dev.ru
echo chr-dev
echo Yohyai7phee3maiYaB0nahGh

echo tag версии
cmd /c docker tag user-permissions:%1 chr-dev.gba.ls-dev.ru/user-permissions:%1

echo отправка на сервер
cmd /c docker push chr-dev.gba.ls-dev.ru/user-permissions:%1

echo Указать переменную отправки и выполнить раскатывание при помощи helm указав в качестве тега необходимую версию
echo OLD: cmd /c ${env:KUBECONFIG} = "${home}\.kube\kubeconfig-dev01-user-permissions.yaml" && helm upgrade -n default --install user-permissions helm -f helm/values-dev.yaml --set image.tag=%1
cmd /c ${env:KUBECONFIG} = "${home}\.kube\kubeconfig-dev01-user-permissions.yaml" && helm upgrade -n default --install user-permissions helm -f helm/values-dev.yaml --set image.tag=%1 --set envFrom=envfile_up.env

::Загрузить в конфигурацию кубера набор переменных
::kubectl create configmap user-permissions-env-configmap -n default
::Используется только при первом деплое сервиса в Кубер, при замене существующих конфиг мапа остается.

:end
echo Вернулся в исходное положение
cd ..