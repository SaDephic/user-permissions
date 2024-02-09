- if [ -z "$DOTENV_DEV" ]; then echo "DOTENV_DEV var EMPTY" ; else cp $DOTENV_DEV envfile.env ; fi
kubectl create configmap user-permissions-env-configmap --from-env-file=envfile.env -n default
helm upgrade -n default --install user-permissions . --set envFrom=envfile.env
