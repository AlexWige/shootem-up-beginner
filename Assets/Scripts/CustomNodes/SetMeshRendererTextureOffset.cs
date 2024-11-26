using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;

[UnitCategory("Custom/Renderer")]
[UnitTitle("MeshRenderer: Set Texture Offset")]
[UnitShortTitle("Texture Offset")]
[TypeIcon(typeof(MeshRenderer))]
public class SetMeshRendererTextureOffset : Unit
{
    [DoNotSerialize]
    public ControlInput inputTrigger;

    [DoNotSerialize]
    public ControlOutput outputTrigger;

    [DoNotSerialize]
    public ValueInput meshRenderer;

    [DoNotSerialize]
    public ValueInput textureOffset;

    MaterialPropertyBlock propertyBlock;

    protected override void Definition()
    {
        meshRenderer = ValueInput<MeshRenderer>("MeshRenderer", null);
        textureOffset = ValueInput<Vector2>("Texture Offset", new(0, 0));

        inputTrigger = ControlInput("Input", (flow) =>
        {
            MeshRenderer meshRendererValue = flow.GetValue<MeshRenderer>(meshRenderer);
            Vector2 textureOffsetValue = flow.GetValue<Vector2>(textureOffset);

            propertyBlock ??= new MaterialPropertyBlock();
            meshRendererValue.GetPropertyBlock(propertyBlock);
            propertyBlock.SetVector("_MainTex_ST", new Vector4(1, 1, textureOffsetValue.x, textureOffsetValue.y));
            meshRendererValue.SetPropertyBlock(propertyBlock);

            flow.Invoke(outputTrigger);
            return outputTrigger;
        });

        outputTrigger = ControlOutput("Output");
        Succession(inputTrigger, outputTrigger);
    }
}