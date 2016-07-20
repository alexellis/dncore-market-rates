FROM microsoft/dotnet:latest
ADD ./lib ./lib
ADD ./test ./test

RUN dotnet restore
RUN dotnet build

CMD ["dotnet", "run"]

