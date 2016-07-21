#FROM microsoft/dotnet:1.0.0-preview1
FROM microsoft/dotnet:1.0.0-preview2-sdk
MAINTAINER alexellis2@gmail.com

# Note: this Dockerfile is a work in progress. 
RUN mkdir -p /root/dn/

WORKDIR /root/dn/
ADD ./global.json ./

ADD ./src ./src
ADD ./test ./test

RUN dotnet restore

WORKDIR /root/dn/test/RateCalc.Engine.Tests/

RUN dotnet build
RUN dotnet test

WORKDIR /root/dn/src/RateCalc.App/

CMD ["dotnet", "run"]
