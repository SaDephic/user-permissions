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

echo Проверка версии
echo current %1
pause

echo Сборка артефактов
cmd /c docker build -f ".\user-permissions\Dockerfile" --force-rm -t user-permissions:%1 --build-arg "BUILD_CONFIGURATION=Release" "."

echo Соединение с хранилищем артефактов куда будем отправлять наш докер образ
echo docker login chr-dev.gba.ls-dev.ru
echo УЗ chr-dev
echo Пароль Yohyai7phee3maiYaB0nahGh
echo https://repo.gba.ls-dev.ru/#browse/browse:chr-tmp

echo tag версии
cmd /c docker tag user-permissions:%1 chr-dev.gba.ls-dev.ru/user-permissions:%1

echo Отправка собранного образа из локального хранилища в удаленное (chr-dev.gba.ls-dev.ru)
cmd /c docker push chr-dev.gba.ls-dev.ru/user-permissions:%1

echo Указать переменную отправки и выполнить раскатывание при помощи helm указав в качестве тега необходимую версию
echo "--------------------"
echo          OLD
echo "--------------------"
echo $env:KUBECONFIG = "$home\.kube\kubeconfig-dev01-user-permissions.yaml"
echo helm upgrade -n default --install user-permissions helm -f helm/values-dev.yaml --set image.tag=%1
echo "--------------------"
echo ! ВЫПОЛНИТЬ ВРУЧНУЮ !
echo "--------------------"
echo Передать переменную (на какой кластер Kubernetes смотрим/работаем)
echo $env:KUBECONFIG = "$home\.kube\kubeconfig-dev01-user-permissions.yaml"
echo Выполнить раскатывание при помощи helm указав в качестве тега необходимую версию
echo helm upgrade -n default --install user-permissions helm -f helm/values-dev.yaml --set image.tag=%1 --set envFrom=envfile_up.env
echo "--------------------"

echo
echo Проверить что в Kubernetes поднялся наш артефакт.
echo kubectl get po
echo

::Загрузить в конфигурацию кубера набор переменных
::kubectl create configmap user-permissions-env-configmap -n default
::Используется только при первом деплое сервиса в Кубер, при замене существующих конфиг мапа остается.

:end
echo Вернулся в исходное положение
cd ..