﻿using lib.field.attributes;

namespace main.models;

using lib.model;

[ModelDefinition("partner", Description = "Contact")]
public class Partner: Model
{
    [FieldDefinition(Description = "Name of the partner")]
    [DefaultValue("Test")]
    public string Name = "";

    [FieldDefinition(Description = "Age of the partner")]
    [DefaultValue(42)]
    public int Age = 0;

    [FieldDefinition]
    [DefaultValue(nameof(DefaultRandomColor), isMethod: true)]
    public int Color = 0;

    // Compute
    public string DisplayName => $"Name: {Name}, Age: {Age}";
    
    // Default method
    public static int DefaultRandomColor() => 42;
}

[ModelDefinition("partner", Description = "Contact")]
public class Partner2: Model
{
    [FieldDefinition(Description = "Not the name of the partner")]
    [DefaultValue("LoL")]
    public string Name = "";

    [FieldDefinition]
    public int Test = 0;
}

[ModelDefinition("partner", Description = "Contact")]
public class Partner3: Model
{
    [FieldDefinition(Name="Not his Age", Description = "Age of him")]
    public int Age = 0;

    [FieldDefinition]
    [DefaultValue(30)]
    public int Test = 0;
}
