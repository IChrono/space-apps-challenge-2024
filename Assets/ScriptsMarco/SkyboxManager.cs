using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxManager : MonoBehaviour
{

    [SerializeField]
    private GameObject floor;

    [SerializeField]
    private GameObject skyboxSphere;

    [SerializeField]
    private Texture2D[] textures;

    private IEnumerator IncreaseFloatOverTime(float duration, float value)
    {
        float currentTime = 0f;
        float startValue = skyboxSphere.GetComponent<Renderer>().sharedMaterial.GetFloat("_Cutoff_Height");
        float targetValue = value;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newValue = Mathf.Lerp(startValue, targetValue, currentTime / duration);
            skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetFloat("_Cutoff_Height", newValue);
            yield return null;
        }

        // Ensure the value is exactly 1 at the end
        skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetFloat("_Cutoff_Height", targetValue);
    }   


     public void ResetSkyboxToHidden()
    {
        skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetFloat("_Cutoff_Height", 1f);

    }

    public void SetSkyboxToVisible(int skyboxid)
    {
        skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetFloat("_Cutoff_Height", -1f);
    }   


    void Start() {
        ResetSkyboxToHidden();
    }

    public IEnumerator IncreaseFloatOverTime(float duration, float value, int skyboxid)
    {
        skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetTexture("_Base_Texture", textures[skyboxid] );
        float currentTime = 0f;
        float startValue = skyboxSphere.GetComponent<Renderer>().sharedMaterial.GetFloat("_Cutoff_Height");
        float targetValue = value;

        while (currentTime < duration)
        {
            currentTime += Time.deltaTime;
            float newValue = Mathf.Lerp(startValue, targetValue, currentTime / duration);
            skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetFloat("_Cutoff_Height", newValue);
            yield return null;
        }

        // Ensure the value is exactly 1 at the end
        skyboxSphere.GetComponent<Renderer>().sharedMaterial.SetFloat("_Cutoff_Height", targetValue);
    }

    
}
