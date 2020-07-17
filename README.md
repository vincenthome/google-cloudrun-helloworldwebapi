# Guide on Cloud Run hosting dotnet core Webapi container 
* [Google Cloud Run](https://cloud.google.com/run)
* [Walkthrough](https://cloud.google.com/run/docs/quickstarts/build-and-deploy#c) 

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
