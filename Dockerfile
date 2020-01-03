FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS DOTNET_CORE_TOOL_CHAIN

COPY ./ /tmp/

WORKDIR /tmp/OfficeAutomaticManage

RUN dotnet publish -c Release


FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

MAINTAINER harriszhang@live.cn

COPY --from=DOTNET_CORE_TOOL_CHAIN /tmp/OfficeAutomaticManage/bin/Release/netcoreapp3.0/publish /app

WORKDIR /app

ENTRYPOINT ["dotnet", "Canos.OfficeAutomatic.dll"]