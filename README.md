# Azure Design Studio

[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue.svg)](https://www.gnu.org/licenses/gpl-3.0) [![build](https://github.com/chunliu/AzureDesignStudio/actions/workflows/build.yml/badge.svg)](https://github.com/chunliu/AzureDesignStudio/actions/workflows/build.yml)

Azure Design Studio is a web application designed to simplify and streamline the process of creating solution architectures for Azure. With a focus on ease of use, efficiency, and consistency, it offers several key features:

- **Visual design**: Create solution architecture for Azure using a visually appealing and consistent styling.
- **Validation**: Ensure your design adheres to the rules and constraints of Azure resources to reduce errors.
- **Export**: Export your design as images for easy integration into your documents and presentations.
- **Cloud storage**: Save your design in the cloud for convenient access from any location.
- **Infrastructure as Code (IaC) generation**: Automatically generate IaC for your design, with support for both ARM templates and Bicep.

The primary goal of Azure Design Studio is to help users create high-quality solution architectures for Azure while reducing the learning curve associated with ARM and Bicep. By improving the overall user experience, Azure Design Studio enables more efficient design and deployment of solutions on Azure.

As an award winning project, Azure Design Studio won the [3rd Place Winner award](https://www.credly.com/badges/08684d43-a00e-418c-8cf3-4b5eb48f601f/linked_in_profile) of **Microsoft Global Hackathon 2022**. 

![screenshot](/assets/AzureDesignStudio.gif)

## Contribution

All feedback and suggestions are welcome. Please feel free to create an issue if you have any. 

If you want to build and debug the code locally, please follow the instruction below. All PRs are welcome too.

### Build it locally

To build and test the code locally, you will need the following tools:

- Visual Studio 2022 (latest version)
- (Optional) Azure CLI, if you want to debug and test the code locally.
- (Optional) Docker Desktop, if you want to build the docker image locally.

To build the code, clone the repo:

```bash
git clone --recursive https://github.com/chunliu/AzureDesignStudio.git
```

And then open the solution in Visual Studio 2022.

To launch and debug the code locally, set `AzureDesignStudio.Server` as the startup project in Visual Studio 2022. 

## Frameworks and Libraries

Azure Design Studio is built on top of the following frameworks and libraries:

- [Ant Design Blazor](https://antblazor.com/en-US/)
- [Blazor.Diagrams](https://github.com/Blazor-Diagrams/Blazor.Diagrams)
- [AutoMapper](https://automapper.org/)
- [BlazorApplicationInsights](https://github.com/IvanJosipovic/BlazorApplicationInsights)

## Disclaimer

Azure Design Studio is a personal project without any warranty. It is neither an official product from Microsoft nor supported by Microsoft. Use it at your own risk.
