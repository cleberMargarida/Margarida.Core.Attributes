[![Latest version](https://img.shields.io/nuget/v/Margarida.Core.Attributes.svg)](https://www.nuget.org/packages?q=Margarida.Core.Attributes) [![License LGPLv3](https://img.shields.io/badge/license-LGPLv3-green.svg)](https://www.gnu.org/licenses/lgpl-3.0.html)

# Margarida Core Attributes 
## Overview
A collection of shared **attributes** for **.NET Core applications**

Installation
-------------

Margarida Core Attributes is available as a NuGet package. You can install it using the NuGet Package Console window:

```
PM> Install-Package Margarida.Core.Attributes
```

## List of attributes
 - [Description](#descriptionattribute) 
 - [Scoped, Transient, Singleton](#singleton-transient-scoped-attributes) 
  
## DescriptionAttribute
A quick way to add description to enums inside .NET Core applications.

#### Usage
```csharp
enum Colors
{
    [Description("Black")]
    Black = 0,

    [Description("White")]
    White = 1
}

string black = Colors.Black.GetDescription(); //<---- "Black"
string white = Colors.White.GetDescription(); //<---- "White"
```

## Singleton Transient Scoped Attributes
Points to AddMarkedByAttributes extension, Add a scoped, transient or singleton services of the types that marked these attributes.

#### Usage
```csharp
[Scoped]
public class ScopeClass 
{
}

[Transient]
public class TransientClass 
{
}

[Singleton]
public class SingletonClass 
{
}

public class Startup
{
    public void ConfigureServices()
    {
        services.AddMarkedByAttributes(x => x.RegisterFromAssembly(GetType().Assembly));
    }
}
```
