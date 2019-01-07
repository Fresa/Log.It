# Log.It
Log.It is an abstract logging framework. It simplifies how you use logging frameworks in your everyday code. For a full example, please see the the `Log.It.Tests` project.

[![Build status](https://ci.appveyor.com/api/projects/status/0brskjpilxrbh4cc?svg=true)](https://ci.appveyor.com/project/Fresa/log-it)

[![Build history](https://buildstats.info/appveyor/chart/Fresa/log-it)](https://ci.appveyor.com/project/Fresa/log-it/history)

## Download
https://www.nuget.org/packages/Log.It/

## Getting Started
You may use the `LogFactory` to create loggers either based on a type or a string which will be the logger name. ~~The `LogFactory` uses an internal factory implementing `ILoggerFactory` which you implement by your own liking, maybe by using NLog or Log4net or anything else for that matter. The `ILoggerFactory` implementation is resolved by specifying the type name in a config file.~~

### ~~Config File Example~~
~~`MyLoggerFactory`, which implements `ILoggerFactory`, can be specified as following.~~
~~<configuration>
  <configSections>
    <section name="Logging" type="Log.It.LoggingSection, Log.It" />
  </configSections>
  <Logging Factory="My.Assembly.MyLoggerFactory, My.Assembly" />
</configuration>~~

### Usage
To create a logger instance, use the `LogFactory` directly in a class or use dependency injection. Make sure the `LogFactory` has been initialized with a `ILogFactory` before using it. If you still want to use the old configuration section to specify the logger factory, you need to implement this functionality your self. 

#### Static Creation Example
```
public class Foo
{
    private readonly ILogger _logger = LogFactory.Create<Foo>();
}
```

#### Dependency Injection Example (with SimpleInjector)
```
public class Foo
{
    private readonly ILogger _logger;

    public Foo(ILogger logger)
    {
        _logger = logger;
    }
}
```
Using this context extension of SimpleInjector: https://github.com/simpleinjector/SimpleInjector/blob/master/src/SimpleInjector.CodeSamples/ContextDependentExtensions.cs
```
public static class Application
{
    public static void Start()
    {
        var container = new Container();
        container.RegisterWithContext<ILogger>(context => LoggerFactory.Create(context.ImplementationType.Name));

        // Injects a logger called "Foo" into the instance of Foo
        var foo = container.GetInstance<Foo>();
    }
}
```

## Logical Logging Context 
`ILogger` also provides a `LogicalThread` property which can be used to transfer logdata through the logical execution path. It can be used to set context which can be used by all loggers further down the execution path where the information might not be available anymore.

`LogicalThreadContext` is one implementation that uses `System.Runtime.Remoting.Messaging.CallContext`.

## Format Annotations for ReSharper
ReSharper is a great tool which can use some predefined attributes to enhance it's code inspection functionality. `Log.It.Annotations.ResharperAnnotations` includes among other things attributes which is used for specifying formatting of `ILogger`. You can read more about ReSharper annotations here: https://www.jetbrains.com/help/resharper/Code_Analysis__Code_Annotations.html
