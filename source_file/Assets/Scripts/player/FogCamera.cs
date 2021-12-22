using UnityEngine;

[ExecuteInEditMode]
public class FogCamera : MonoBehaviour
{
    private Material material;
    public float fogEnd = 15;
    public float fogStart = 0.1f;
    NightVisionEffect m_effect;
    FlashLightLogic m_light;
    GameObject m_flash;

    private void Start() {
        m_flash=GameObject.Find("FlashLight");
        m_effect=GetComponent<NightVisionEffect>();
        m_light=m_flash.GetComponent<FlashLightLogic>();
        m_effect.enabled=false;
        //m_flash.SetActive(false);
        m_flash.GetComponent<Light>().enabled=false;
        m_light.enabled=false;
    }

    private void Update() {
        if(Input.GetButtonDown("light")){
            m_effect.enabled=!m_effect.enabled;
            //m_light.enabled=!m_light.enabled;
            m_flash.GetComponent<Light>().enabled=m_effect.enabled;
            m_light.enabled=m_effect.enabled;
            if(fogEnd==15){
                fogEnd=3.5f;
            }else{
                fogEnd=15;
            }
        }
        if(m_light){
            if(m_light.havebattery()){
                m_effect.enabled=false;
                m_flash.GetComponent<Light>().enabled=false;
                m_light.enabled=false;
                fogEnd=3.5f;
            }
        }
    }

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