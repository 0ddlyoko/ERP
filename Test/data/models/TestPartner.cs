﻿using lib.field.attributes;

namespace Test.data.models;

using lib.model;

[ModelDefinition("test_partner", Description = "Contact")]
public class TestPartner: Model
{
    [FieldDefinition(Description = "Name of the partner")]
    [DefaultValue("Test")]
    public string Name = "";

    [FieldDefinition(Name="Age 2", Description = "Age of the partner")]
    [DefaultValue(42)]
    public int Age = 0;

    [FieldDefinition]
    [DefaultValue(nameof(DefaultRandomColor), isMethod: true)]
    public int Color = 0;

    // Compute
    [FieldDefinition(Description = "Name to display of the partner")]
    [DefaultValue(nameof(ComputeDisplayName), isMethod: true)]
    public string DisplayName = "";
    
    // Default method
    public static int DefaultRandomColor() => 42;

    // Compute method
    [Computed(["Name", "Age"])]
    public void ComputeDisplayName()
    {
        DisplayName = $"Name: {Name}, Age: {Age}";
    }
}

[ModelDefinition("test_partner", Description = "Contact :D")]
public class TestPartner2: Model
{
    [FieldDefinition(Description = "Not the name of the partner")]
    [DefaultValue("LoL")]
    public string Name = "";

    [FieldDefinition]
    public int Test = 0;
}

[ModelDefinition("test_partner")]
public class TestPartner3: Model
{
    [FieldDefinition(Name="Not his Age", Description = "Age of him")]
    [DefaultValue(nameof(DefaultAge), isMethod: true)]
    public int Age = 0;

    [FieldDefinition]
    [DefaultValue(30)]
    public int Test = 0;
    
    public static int DefaultAge() => 70;
}