# Azure Design Studio

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0) [![build](https://github.com/chunliu/AzureDesignStudio/actions/workflows/build.yml/badge.svg)](https://github.com/chunliu/AzureDesignStudio/actions/workflows/build.yml)

Azure Design Studio is a web app that can help you:

- design solution architecture for Azure visually with consistent styling.
- export and use the design as pictures in your documents.
- save the design in the cloud to keep it alive and be accessible from anywhere.
- and most importantly, generate IaC _(Infrastructure as Code)_ code _(currently limited to ARM templates and Bicep)_ from the design automatically.

With Azure Design Studio, I hope it can save you some time from learning ARM or Bicep, and therefore improve the user experience of designing and deploying solutions on Azure. 

You can try Azure Design Studio here: https://www.azuredesign.app/.

![screenshot](/assets/AzureDesignStudio.gif)

## Contribution

All feedback and suggestions are welcome. Please feel free to create an issue if you have any. 

If you want to build and debug the code locally, please follow the instruction below. All PRs are welcome too.

### Build it locally

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

## Disclaimer

Azure Design Studio is a personal project without any warranty. It is neither an official product from Microsoft nor supported by Microsoft. Use it at your own risk.
