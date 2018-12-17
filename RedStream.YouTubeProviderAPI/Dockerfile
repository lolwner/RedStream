FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["RedStream.YouTubeProviderAPI/RedStream.YouTubeProviderAPI.csproj", "RedStream.YouTubeProviderAPI/"]
RUN dotnet restore "RedStream.YouTubeProviderAPI/RedStream.YouTubeProviderAPI.csproj"
COPY . .
WORKDIR "/src/RedStream.YouTubeProviderAPI"
RUN dotnet build "RedStream.YouTubeProviderAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "RedStream.YouTubeProviderAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "RedStream.YouTubeProviderAPI.dll"]