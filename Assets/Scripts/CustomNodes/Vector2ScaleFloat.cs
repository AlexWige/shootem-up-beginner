using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[UnitCategory("Custom/Vector2")]
[UnitTitle("Scale by Float (Vector2)")]
[UnitShortTitle("Scale")]
[TypeIcon(typeof(Vector2))]
public class Vector2ScaleFloat : Unit
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
            float s = flow.GetValue<float>(floatInput);
            Vector2 result = vector2 * s;
            flow.SetValue(vector2Output, result);
            return result;
        });
    }
}