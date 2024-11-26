using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[UnitCategory("Custom/Inputs")]
[UnitTitle("Get Movement Vector (Keys)")]
[UnitShortTitle("Get Movement")]
[TypeIcon(typeof(Vector2))]
public class GetMovementKeys : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;

    [DoNotSerialize]
    public ValueInput leftKey;

    [DoNotSerialize]
    public ValueInput rightKey;

    [DoNotSerialize]
    public ValueInput upKey;

    [DoNotSerialize]
    public ValueInput downKey;

    [DoNotSerialize]
    public ValueOutput vector2Output;

    protected override void Definition()
    {
        leftKey = ValueInput("Left Key", KeyCode.A);
        rightKey = ValueInput("Right Key", KeyCode.D);
        upKey = ValueInput("Up Key", KeyCode.W);
        downKey = ValueInput("Down Key", KeyCode.S);
        vector2Output = ValueOutput("Vector2", (flow) => { 
            KeyCode left = flow.GetValue<KeyCode>(leftKey);
            KeyCode right = flow.GetValue<KeyCode>(rightKey);
            KeyCode up = flow.GetValue<KeyCode>(upKey);
            KeyCode down = flow.GetValue<KeyCode>(downKey);

            Vector2 result = new(0, 0);
            if (Input.GetKey(left)) result.x -= 1;
            if (Input.GetKey(right)) result.x += 1;
            if (Input.GetKey(up)) result.y += 1;
            if (Input.GetKey(down)) result.y -= 1;

            if (result.SqrMagnitude() > 1)
            {
                result.Normalize();
            }
            
            flow.SetValue(vector2Output, result);
            return result;
        });

        inputTrigger = ControlInput("Input", (flow) => outputTrigger);
        outputTrigger = ControlOutput("Output");
        Succession(inputTrigger, outputTrigger);
    }
}