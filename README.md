# Xamarin.Mac Running Prism DryIoC Demo

I'm used to building Xamarin.Forms apps using [Prism](https://github.com/PrismLibrary/Prism). More widely I'm used to building any kind of enterprise grade application using a DI container. I've worked with a few, .NET Core even ships with a built in DI container! I'm currently writing a Mac application for work and don't want the headache of native mac without an IoC container to easily resolve my services. Unfortunately for this project Xamarin.Forms is not appropriate as I need to implement features at an OS level so Forms would just slow me down.

This repo shows a sample of Prism & DryIoC running on a Xamarin.Mac native app.

Steps to convert a Xamarin.Mac app to support Prism, all the code is in this sample project:

- Instal Prism.DryIoc.Forms
  - *No forms components are being used, I couldn't get Prism.Core to install without the Forms dependency*
- Inherit PrismApplicationDelegate
- In Xcode untick "Is Initial View Controller" in Main.Storyboard
- Register storyboard for navigation in `RegisterTypes()`
- Navigate using `INativeNavigationService`



There is alot to implement to get a feature rich experience akin to the main Prism repo, however I'm going to be updating my sample as and when I need to implement a new feature so hopefully this repo grows and becomes semi functional.



## Roadmap

| Feature Goal                                                 | Completed |
| ------------------------------------------------------------ | --------- |
| Get DryIoc Running in Xamarin.Mac                            | ✅         |
| Custom AppDelegate Class To Support Prism                    | ✅         |
| Resolve & use something within a view                        | ✅         |
| Custom navigation service so Container.Resolve<T>() is not necessary | ⚠️         |
| MVVM / MVU abstraction layer to seperate view from business logic | ⚠️         |