FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RedStream.WebUI/RedStream.WebUI.csproj", "RedStream.WebUI/"]
RUN dotnet restore "RedStream.WebUI/RedStream.WebUI.csproj"
COPY . .
WORKDIR "/src/RedStream.WebUI"
RUN dotnet build "RedStream.WebUI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RedStream.WebUI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RedStream.WebUI.dll"]