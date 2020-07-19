# Guide on Cloud Run 

## ASP.NET Core Webapi container with Kestrel

[Google Cloud Run](https://cloud.google.com/run)  

[ASP.NET Core Web API - Walkthrough](https://cloud.google.com/run/docs/quickstarts/build-and-deploy#c)   

1. Create new dotnet core webapi `dotnet new webapi -n helloworld` [tutorial](https://medium.com/@laroccanicola/creating-our-first-web-api-with-net-core-2-and-visual-studio-code-on-linux-ubuntu-d5d3458ae989)
   * In CreateHostBuilder, setup listening port on localhost:
    ```
    string port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
    string url = String.Concat("http://0.0.0.0:", port);
    webBuilder.UseStartup<Startup>().UseUrls(url);
    ```
2. Add .gitignore. `dotnet new gitignore`
3. Dockerfile
   1. Add Dockerfile/.dockerignore. `⌘⇧P: Docker: Add Docker Files ...` 
   2. Switch to alpine images. 
      * `mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine`
      * `mcr.microsoft.com/dotnet/core/sdk:3.1-alpine`
   3. Expose Container Port. `EXPOSE 8080`
4. Docker Build. `⌘⇧P: Docker: Build Image`
5. Google Container Registry GCR. `gcloud builds submit --tag gcr.io/cloudrunmyproject/helloworld`
6. Deploy Cloud Run. `gcloud run deploy --image gcr.io/cloudrunmyproject/helloworld --platform managed`

## Angular Client with Nginx

  * [tutorial](https://medium.com/@wkrzywiec/build-and-run-angular-application-in-a-docker-container-b65dbbc50be8)
  * [tutorial 2](https://dev.to/usmslm102/containerizing-angular-application-for-production-using-docker-3mhi)

## Adding Google Sign-In Authentication OAuth 

* [sample code - JS client, Express server](https://github.com/momander/serverlesstoolbox/tree/master/dessert-api-rest-sql-auth)


## Authentication using Google Sign-In
  * [Backend Verify ID token](https://developers.google.com/identity/sign-in/web/backend-auth#verify-the-integrity-of-the-id-token)
    * [dotnet](https://stackoverflow.com/questions/44141439/validate-google-id-token-with-c-sharp)
    * https://medium.com/mickeysden/react-and-google-oauth-with-net-core-backend-4faaba25ead0
    * https://github.com/mickeysden/dotnet-core-react-oauth-example/tree/master/backend
    * https://stackoverflow.com/questions/48727900/google-jwt-authentication-with-aspnet-core-2-0
    * 
