using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFog : MonoBehaviour
{
    //public Shader fogShader;
    public Material fogMaterial = null;

    // Start is called before the first frame update
    void Start()
    {
        Camera cam = GetComponent<Camera>();
        cam.depthTextureMode = DepthTextureMode.Depth | DepthTextureMode.DepthNormals | DepthTextureMode.MotionVectors;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        Camera cam = GetComponent<Camera>();
        var mtx_view_inv = cam.worldToCameraMatrix.inverse;
        var mtx_proj_inv = cam.projectionMatrix.inverse;

        Matrix4x4 temp = cam.worldToCameraMatrix * cam.projectionMatrix;
        Matrix4x4 mtx_clip_to_world = temp.inverse;

        fogMaterial.SetMatrix("_mtx_clip_to_world", mtx_clip_to_world);
        fogMaterial.SetMatrix("_mtx_view_inv", mtx_view_inv);
        fogMaterial.SetMatrix("_mtx_proj_inv", mtx_proj_inv);

        Graphics.Blit(src, dest, fogMaterial);
    }
}