FROM 215743319971.dkr.ecr.us-east-1.amazonaws.com/khq-base-container-images-dotnet-aspnet-8:latest
WORKDIR /app
COPY app ./
ENTRYPOINT ["dotnet", "Kubra.StitchFunction.Api.dll"]
