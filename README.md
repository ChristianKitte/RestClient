# RestClient
Das vorliegende Projekt ist eine Übung für die Erstellung einer ASP MVC Anwendung mit C# und .NET Core 5 auf 
Basis einer SQLite Datenbank. Im Detail soll folgendes exemplarisch umgesetzt werden:

### Umfang
*	ASP MVC Webanwendung auf BAsis von C# und .NET Core 5 (REST Funktionen)
*	Nutzen des MVC Pattern
*	Zugriff und Nutzen einer nicht lokalen SQLite Datenbank mittels REST API
* Verwenden einer HttpClientFactory zur Vermeidung von [Problemen](https://docs.microsoft.com/de-de/dotnet/architecture/microservices/implement-resilient-applications/use-httpclientfactory-to-implement-resilient-http-requests)
* Nutzen der Build In Konfiguration und DI Unterstützung
* (offen) Der Implementierung einer Zugangsverwaltung
* (offen) Nutzen einer geschützten REST API
* Implementieren einer Docker Unterstützung
* (offen) Ausführung des Clients und der REST API aus [**DockerWebAPI**](https://github.com/ChristianKitte/DockerWebAPI) mit Docker Composer 

Die aktuelle Anwendung verwendet als Quelle für die Datenbank einen Webserver an der Basisadresse 
**```http://127.0.0.1/api/v1/```**. Die Einstellung ist in der **appsetting.json** gehalten und kann hier angepasst werden.
Der Webserver, welcher die REST API veröffentlicht, ist auf GitHub als Teil des Projektes [**DockerWebAPI**](https://github.com/ChristianKitte/DockerWebAPI) 
verfügbar. Alternativ kann auch das [**Docker Image**](https://hub.docker.com/r/ckitte/dbserver) genutzt werden.

### Docker
Hierfür muss das entsprechende Image **ckitte/dbserver** herunter geladen werden. Nach dem herunterladen kann ein Container mit dem 
Befehl **docker run -p 8080:80 ckitte/dbserver** gestartet werden. Hierbei ist 8080 der Port außerhalb des Containers, hier 
127.0.0.1:8080, und 80 der Port innerhalb des Containers. **Somit horcht der Service im Container am Port 80 und ich spreche ihn von 
außen mit 8080 an**. 

```
docker pull ckitte/dbserver
docker run -d -p 8080:80 ckitte/dbserver
```

Nach dem Start des Images ist der oben genannte Port verfügbar.

### Information
Es ist nicht einfach möglich, diese Anwendung und [**DockerWebAPI**](https://github.com/ChristianKitte/DockerWebAPI) jeweils als Container 
auszuführen und zusammenarbeiten zu lassen.

### Umsetzung
Bei der Umsetzung wurde primär auf eine gute Nachvollziehbarkeit und Einfachheit geachtet, so dass das Projekt gut
nachvollzogen und als Ausgangspunkt für andere Projekte dienen kann. 

Als Ausgangspunkt dient der durch das Projekttemplate beim Anlegen erzeugte Code mit dessen Layout. Die verwendeten 
Views wurde ebenfalls initial mit Hilfe der hinterlegten Templates angelegt und im Anschluss entsprechend angepasst 
und erweitert. Es kamen hierbei keine anderen Tools als Visual Studio zum Einsatz.

Eine Instanz von HttpClientFactory, die aktuelle Konfiguration sowie die Basisadresse werden mit Hilfe der native DI Unterstützung 
verfügbar gemacht. 

Hierdurch ergibt sich ein voll funktionsfähiges, aber dennoch recht einfaches Grundgerüst für eine ASP MVC Anwendung mit Core 5.

