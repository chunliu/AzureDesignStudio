# Azure Design Studio

A web app which can help you design a solution architecture for Azure visually, export and use the design in your documents, and most importantly, generate IaC code (currently limit to ARM templates) from the design so that it can be deployed and verified easily.

![screenshot](/assets/ads.png)

## Build it locally

To build and test the code locally, you will need the following tools:

- Visual Studio 2022
- (Optional) Azure CLI, if you want to debug and test the code locally.
- (Optional) Docker Desktop, if you want to build the docker image locally.

To build the code, clone the repo:

```bash
git clone --recursive https://github.com/chunliu/AzureDesignStudio.git
```

And then open the solution in Visual Studio 2022.

## Frameworks and Libraries

Azure Design Studio is built on top of the following frameworks and libraries:

- [Ant Design Blazor](https://antblazor.com/en-US/)
- [Blazor.Diagrams](https://github.com/Blazor-Diagrams/Blazor.Diagrams)
- [AutoMapper](https://automapper.org/)
- [BlazorApplicationInsights](https://github.com/IvanJosipovic/BlazorApplicationInsights)
