FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/dotnet:2.1-sdk AS build
WORKDIR /src
COPY ["ShoppingList/ShoppingList.csproj", "ShoppingList/"]
RUN dotnet restore "ShoppingList/ShoppingList.csproj"
COPY . .
WORKDIR "/src/ShoppingList"
RUN dotnet build "ShoppingList.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ShoppingList.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ShoppingList.dll"]