# CustomVision Library
The default implementations of CustomVision APIs available on NuGet (both the [Training](https://www.nuget.org/packages/Microsoft.Cognitive.CustomVision.Training) and the [Prediction](https://www.nuget.org/packages/Microsoft.Cognitive.CustomVision.Prediction) Client libraries) aren't compatible with .NET Core and some PCL profiles (for example, they can't install on the default Xamarin PCL project).

**CustomVision Library** is a .NET Standard as well a PCL library that allows you to access the Custom Vision APIs from virtually any .NET project, on every platform.
