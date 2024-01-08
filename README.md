# System

* Godot 4.2.1 C# DotNet
* Windows 11

# GodotNugetBug
this tests if godot 4.2.1 can load nuget packages properly when using / not using &lt;EnableDynamicLoading>true&lt;/EnableDynamicLoading>

simply open the project and edit the .csproj file as you like it. set the 
`<EnableDynamicLoading>true</EnableDynamicLoading>`

to true or false and run the project in your godot editor to see the effects that this property has on your execution. 

It will only be able to load the Mathnet.Numerics Nuget Package and basically the Mathnet.DLL, IF you have set the EnableDynamicLoading to True. 
But this should not be the case like that.
