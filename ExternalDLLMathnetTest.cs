using Godot;
using MathNet.Numerics.LinearAlgebra;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Reflection.Emit;

public partial class ExternalDLLMathnetTest : Node2D
{
	[Export] public RichTextLabel label;
	public Matrix<Complex> ScatteredMatrix { get; set; }
	public override void _Ready()
    {
        // this code uses the MathNet.Dll - an external dll for some matrix multiplication. 
        // it only works, when the property "<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies> " is set as true in the PropertyGroup of the csproj file. 
        // but that should not be the case - Godot should be able to detect the Nuget package Mathnet.Numerics (5.0.0) automatically. 
        if (label == null) GD.PrintErr("label is not assigned");
        CalculateSomeValuesUsingMathNetDLL();
        PrintSuccessMessage();
    }

    private void CalculateSomeValuesUsingMathNetDLL()
    {
        var pinIdStart = Guid.NewGuid();
        var pinIdEnd = Guid.NewGuid();

        var PinIDs = new List<Guid>() { pinIdStart, pinIdEnd };
        ScatteredMatrix = Matrix<Complex>.Build.Dense(PinIDs.Count, PinIDs.Count);
        ScatteredMatrix[0, 1] = new Complex(1, 0); // connection from start to end has a value of 1
    }

    private void PrintSuccessMessage()
    {
        var outputText = "######################\n" +
                    $"Welcome, the connection from 0 to 1 has a value of: {ScatteredMatrix[0, 1].Magnitude} and phase of {ScatteredMatrix[0, 1].Phase}" +
                    "\n######################\n";
        outputText += "This message basically means that now the code works correctly.";
        label.Text = outputText;
        GD.Print(outputText);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}
