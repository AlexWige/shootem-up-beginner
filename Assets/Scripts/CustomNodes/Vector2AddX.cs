using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[UnitCategory("Custom/Vector2")]
[UnitTitle("Add X (Vector2)")]
[UnitShortTitle("Add X")]
[TypeIcon(typeof(Vector2))]
public class Vector2AddX : Unit
{
    [DoNotSerialize]
    public ValueInput vector2Input;

    [DoNotSerialize]
    public ValueInput floatInput;

    [DoNotSerialize]
    public ValueOutput vector2Output;

    protected override void Definition()
    {
        vector2Input = ValueInput("Vector2", new Vector2(0, 0));
        floatInput = ValueInput<float>("Float", 0);
        vector2Output = ValueOutput("Vector2", (flow) =>
        {
            Vector2 vector2 = flow.GetValue<Vector2>(vector2Input);
            float a = flow.GetValue<float>(floatInput);
            Vector2 result = new(vector2.x + a, vector2.y);
            flow.SetValue(vector2Output, result);
            return result;
        });
    }
}