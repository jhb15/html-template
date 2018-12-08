echo "$ENCRYPTED_DOCKER_PASSWORD" | docker login -u "$ENCRYPTED_DOCKER_USERNAME" --password-stdin
docker build -t sem56402018/layout-service:$1 -t sem56402018/layout-service:$TRAVIS_COMMIT .
docker push sem56402018/layout-service:$TRAVIS_COMMIT
docker push sem56402018/layout-service:$1
