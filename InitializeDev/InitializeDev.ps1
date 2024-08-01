docker build -t dev.local/stitchfunction-template:1.0 --file Dockerfile_local .
docker run -dp 127.0.0.1:8080:8080 dev.local/stitchfunction-template:1.0
