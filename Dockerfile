#Here we create application
FROM microsoft/dotnet as build
WORKDIR /docker
RUN dotnet new mvc --name HelloMVC
WORKDIR /docker/HelloMVC
RUN dotnet build
RUN dotnet publish
RUN ls -lrt
ENTRYPOINT [ "dotnet" ]

# What is a stage build ?
# The ability to run a peice of code when you don't need anything
# In Jenkins pipeline, you only deployed just the application
# We do not need to attach to application the build tools
# We need aspnetcore to create application
# but we only need runtime to deploy.

#Here we install runtime
FROM microsoft/aspnetcore
WORKDIR /publish
COPY --from=build /docker/HelloMVC/bin/Debug/netcoreapp2.0 .
RUN ls -lrt
ENV ASPNET_URLS="http://*:4200"
EXPOSE 4200 80
CMD [ "dotnet", "HelloMVC.dll" ]



# We want dotnet run when we call the image