using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolvingControl : MonoBehaviour
{
    private MeshRenderer mesh; 
    private Material meshMaterial; 
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;
    private Light[] sceneLights;
    private float[] originalIntensities;


    void Start()
    {
        mesh = GetComponent<MeshRenderer>();

        if (mesh != null)
        {
            meshMaterial = mesh.material;
        }
        else
        {
            Debug.LogWarning("Non è stata trovata la mesh!");
        }

        sceneLights = FindObjectsOfType<Light>();
        if (sceneLights.Length == 0)
        {
            Debug.LogWarning("Nessuna luce trovata nella scena.");
        }
        else
        {
            originalIntensities = new float[sceneLights.Length];
            for (int i = 0; i < sceneLights.Length; i++)
            {
                originalIntensities[i] = sceneLights[i].intensity;
                sceneLights[i].intensity = 0;
            }
        }
      
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            StartCoroutine(DissolveCo());
        }
    }

    IEnumerator DissolveCo()
    {
        if (meshMaterial == null)
        {
            Debug.LogError("Materiale non trovato.");
            yield break;
        }

        float counter = 0;

        meshMaterial.SetFloat("_dissolve_amount", counter);


        while (counter < 1)
        {
            counter += dissolveRate;
            meshMaterial.SetFloat("_dissolve_amount", counter);
            yield return new WaitForSeconds(refreshRate);
        }

        Debug.Log(counter);

        while (counter > 0)
        {

            Debug.Log("torno indietro");
            counter -= dissolveRate;
            counter = Mathf.Clamp01(counter);
            meshMaterial.SetFloat("_dissolve_amount", counter);
            for (int i = 0; i < sceneLights.Length; i++)
            {
                for (int j = 0; j < originalIntensities[i]; j++)
                    sceneLights[i].intensity += dissolveRate;
            }

            yield return new WaitForSeconds(refreshRate);
        }
 
    }
}
