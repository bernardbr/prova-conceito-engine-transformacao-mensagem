# Imagem base para execução do serviço.
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine 
# Define a data e hora para o padrão Brasil.
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone
# Define o diretório de execução do serviço.
WORKDIR /app
# Define as variáveis de ambiente
ENV ASPNETCORE_URLS http://*:5000
# Define a porta de exposição.
EXPOSE 5000
# Define o ponto de entrada de execução da aplicação.
ENTRYPOINT ["dotnet", "api.dll"]
# Realiza a cópia dos dados da pasta atual para a pasta app.
COPY output /app