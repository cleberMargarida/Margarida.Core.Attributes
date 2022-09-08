Margarida Core Attributes 
=========

[![Latest version](https://img.shields.io/nuget/v/Margarida.Core.Attributes.svg)](https://www.nuget.org/packages?q=Margarida.Core.Attributes) [![License LGPLv3](https://img.shields.io/badge/license-LGPLv3-green.svg)](https://www.gnu.org/licenses/lgpl-3.0.html)

## Overview

A quick way to add description to enums inside **.NET Core applications**.

Installation
-------------

Margarida Core Attributes is available as a NuGet package. You can install it using the NuGet Package Console window:

```
PM> Install-Package Margarida.Core.Attributes
```

Usage
------

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
