FROM microsoft/dotnet
WORKDIR /docker
RUN dotnet new console --name HelloDocker
WORKDIR /docker/HelloDocker
CMD [ "dotnet", "run" ]
# We want dotnet run when we call the image