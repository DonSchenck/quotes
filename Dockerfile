FROM registry.access.redhat.com/ubi8/dotnet-50
USER 1001
RUN mkdir quotes
WORKDIR quotes
ADD . .

RUN dotnet publish -c Release

EXPOSE 8080

CMD ["dotnet", "./bin/Release/net5.0/publish/quotes.dll"]