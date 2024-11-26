using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[UnitCategory("Custom/Vector2")]
[UnitTitle("Add (Vector2)")]
[UnitShortTitle("Add")]
[TypeIcon(typeof(Vector2))]
public class Vector2Add : Unit
{
    [DoNotSerialize]
    public ValueInput aInput;

    [DoNotSerialize]
    public ValueInput bInput;

    [DoNotSerialize]
    public ValueOutput vector2Output;

    protected override void Definition()
    {
        aInput = ValueInput("A", new Vector2(0, 0));
        bInput = ValueInput("B", new Vector2(0, 0));
        vector2Output = ValueOutput("Vector2", (flow) =>
        {
            Vector2 a = flow.GetValue<Vector2>(aInput);
            Vector2 b = flow.GetValue<Vector2>(bInput);
            Vector2 result = a + b;
            flow.SetValue(vector2Output, result);
            return result;
        });
    }
}