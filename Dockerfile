FROM microsoft/dotnet:1.0.0-core
MAINTAINER alexellis2@gmail.com

# Note: this Dockerfile is a work in progress. 
RUN mkdir -p /root/dn/

WORKDIR /root/dn/

ADD ./src ./src
ADD ./test ./test

WORKDIR /root/dn/src/RateCalc.Engine/
RUN dotnet restore
RUN dotnet build

WORKDIR /root/dn/src/RateCalc.App/
RUN dotnet restore
RUN dotnet build

WORKDIR /root/dn/test/
RUN rm project.lock.json
RUN dotnet restore
RUN dotnet build
RUN dotnet test
WORKDIR /root/dn/RateCalc.App/

CMD ["dotnet", "run"]
