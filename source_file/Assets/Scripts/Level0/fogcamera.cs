using UnityEngine;

[ExecuteInEditMode]
public class fogcamera : MonoBehaviour
{
    private Material material;
    public float fogEnd = 15;
    public float fogStart = 0.1f;


    private void OnEnable()
    {
        Camera.main.depthTextureMode |= DepthTextureMode.Depth;
        material = new Material(Shader.Find("Fog"));
    }

    private void OnDisable()
    {
        Camera.main.depthTextureMode &= ~DepthTextureMode.Depth;
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        var inverseProjectionMatrix = Camera.main.projectionMatrix.inverse;
        material.SetMatrix("_ClipToCameraMatrix", inverseProjectionMatrix);
        material.SetFloat("_FogStart", fogStart);
        material.SetFloat("_FogEnd", fogEnd);
        Graphics.Blit(source, destination, material);
    }
}