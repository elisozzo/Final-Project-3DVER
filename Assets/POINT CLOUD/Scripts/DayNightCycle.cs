using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayNight : MonoBehaviour
{
    private Light[] sceneLights;
    private float[] originalIntensities;
    public float dissolveRate = 0.0125f;
    [SerializeField] private Light sun;
    [SerializeField, Range(0, 24)] private float timeOfDay;
    [SerializeField] private float sunRotationSpeed;
    [Header("LightingPreset")]
    [SerializeField] private Gradient skyColor;
    [SerializeField] private Gradient equatorColor;
    [SerializeField] private Gradient sunColor;
  

    void Start()
    {
        sceneLights = FindObjectsOfType<Light>();
        originalIntensities = new float[sceneLights.Length];
        for (int i = 0; i < sceneLights.Length; i++)
        {
            originalIntensities[i] = sceneLights[i].intensity;
            //sceneLights[i].intensity = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timeOfDay += Time.deltaTime * sunRotationSpeed;
        if (timeOfDay > 24)
            timeOfDay = 0;
        UpdateSunRotation();
        UpdateLighting();

        if (timeOfDay > 7 && timeOfDay < 18.30)
        {
            for (int i = 0; i < sceneLights.Length; i++)
            {
                sceneLights[i].intensity = 0;
            }
        }

        else
        {
            for (int i = 0; i < sceneLights.Length; i++)
            {
                //for (int j = 0; j < originalIntensities[i]; j++)
                //sceneLights[i].intensity += dissolveRate;
                sceneLights[i].intensity = originalIntensities[i];
            }
        }

    }

    private void OnValidate()
    {
        UpdateSunRotation();
        UpdateLighting();
    }

    private void UpdateSunRotation()
    {
        //update sun rotation
        float sunRotationX = Mathf.Lerp(270, -90, timeOfDay / 24);
        float sunRotationY = Mathf.Lerp(-90, 270, timeOfDay / 24);
        sun.transform.rotation = Quaternion.Euler(sunRotationX, sunRotationY, sun.transform.rotation.z);
    }

    private void UpdateLighting()
    {
        //update the lighting
        float timeFraction = timeOfDay / 24;
        RenderSettings.ambientEquatorColor = equatorColor.Evaluate(timeFraction);
        RenderSettings.ambientSkyColor = skyColor.Evaluate(timeFraction);
        sun.color = sunColor.Evaluate(timeFraction);
    }
}
