using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[UnitCategory("Custom/GameObject")]
[UnitTitle("GameObject: Compare Layer")]
[UnitShortTitle("Compare Layer")]
[TypeIcon(typeof(LayerMask))]
public class GameObjectCompareLayer : Unit
{
    [DoNotSerialize]
    public ValueInput gameObjectInput;

    [DoNotSerialize]
    public ValueInput layerNameInput;

    [DoNotSerialize]
    public ValueOutput boolOutput;

    protected override void Definition()
    {
        gameObjectInput = ValueInput<GameObject>("GameObject", null);
        layerNameInput = ValueInput<string>("Layer Name", "Default");

        boolOutput = ValueOutput("Bool", (flow) => { 
            GameObject gameObject = flow.GetValue<GameObject>(gameObjectInput);
            string layerName = flow.GetValue<string>(layerNameInput);
            bool result = gameObject.layer == LayerMask.NameToLayer(layerName);
            return result;
        });
    }
}