# Just Inject - Lightweight experimental dependency injection framework for Unity

Just Inject is a lightweight experimental dependency injection framework. I started this project as a little side project and is currently in a mostly functional state. Feel free to try it out and experiment with it. If you have any suggestions or improvements dont't hesitate to contribute.

# Table of Contents

- [Installation](#installation)
- [Quick Start](#quick-start)
- [Contributing](#contributing)

# Installation

Currently the best way to include this package in your project is through the unity package manager. Add the package using the git URL of this repo: https://github.com/justinleemans/just-inject.git

# Quick Start

## Bootstrapper

Start setting up your dependencies by first making a new class inheriting from `Bootstrapper.cs` with the type of the class you just created. Next include the required override `OnInstallBindings()`. This method is where you will define your bindings for this bootstrapper.

```c#
public class ExampleBootstrapper : Bootstrapper<ExampleBootstrapper>
{
	protected override void OnInstallBindings()
	{
	}
}
```

After you created this class you can go to your scene and create a empty gameobject and at this script to it. You can choose to make this bootstrapper global or not. When made global this bootstrapper will act like a singleton and persist through scenes and will carry over it's configured dependencies.

You can choose to create one or multiple bootstrappers (global or not) for any purpose. You can choose to make a single global bootstrapper to carry dependencies for the entire project. You can choose to make bootstrappers for scenes to hold scene specific dependencies. And you can choose to make bootstrappers for specific systems if these systems are repeated in certain places in the project.

## Binding

After setting up a bootstrapper you can start adding dependencies. To simply add a dependency use the `ServiceContainer` within the `OnInstallBindings` method by calling `Bind<T>()`. This will create the most basic binding.

```c#
ServiceContainer.Bind<ExampleService>();
```

This will assume that the type you bind will also be the type to inject to. If you want to choose to bind a specific class to it's interface('s) you can use the `Bind<T>()` method for the interface and add the `To<T>()` method to choose what type to use for this interface.

```c#
ServiceContainer.Bind<IExampleService>().To<ExampleService>();
```

In case you want to bind a single class to multiple of it's own interfaces you can simply add more bindings.

```c#
ServiceContainer.Bind<IExampleService>().To<ExampleService>();
ServiceContainer.Bind<ISomeOtherInterface>().To<ExampleService>();
```

By default the binding will assume it needs to create a new instance everytime a field of this type needs to be populated. If you want to explicitly show this in you bootstrapper you can add the method `FromNew()` to the end. If you want to use and already existing instance of this type than you can add `FromInstance(instance)` at the end.

```c#
ServiceContainer.Bind<ExampleService>().FromNew();
...
ServiceContainer.Bind<ExampleService>().FromInstance(instance);
```

Finally if you want the binding to be forced to use the same instance everytime you can choose to make your binding a singleton. Simply add `AsSingleton()` to the end of the binding.

```c#a
ServiceContainer.Bind<ExampleService>().AsSingleton();
```

Note: currently when creating a binding using `FromInstance(instance)` the binding will automatically be converted to a singleton. This behaviour might change in a later stage.

# Contributing

Currently I have no set way for people to contribute to this project. If you have any suggestions regarding improving on this project you can make a ticket on the GitHub repository or contact me directly.