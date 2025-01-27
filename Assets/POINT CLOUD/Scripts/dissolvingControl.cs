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
    public Camera playerCamera;
    //public Material skyboxMaterial_diurno;
    //public Material skyboxMaterial_notturno;
    [SerializeField] private Material pcmaterials1;
    [SerializeField] private Material pcmaterials2;
    [SerializeField] private Material pcmaterials3;
    [SerializeField] private Material pcmaterials4;
    [SerializeField] private Material pcmaterials5;
    [SerializeField] private Material pcmaterials6;
    [SerializeField] private Material pcmaterials7;
    private GameObject pcObject;


    void Start()
    {

        if (playerCamera == null)
        {
            Debug.LogError("PlayerCamera non è assegnata. Assegna la camera nello script.");
            return;
        }

        //defaultSkybox = RenderSettings.skybox;
        //playerCamera.clearFlags = CameraClearFlags.Skybox;
        //skyboxMaterial_diurno = RenderSettings.skybox;

        mesh = GetComponent<MeshRenderer>();

        pcObject = GameObject.Find("PC");

        pcObject.SetActive(false); 


        if (mesh != null)
        {
            meshMaterial = mesh.material;
        }
        else
        {
            Debug.LogWarning("Non è stata trovata la mesh!");
        }

        /*sceneLights = FindObjectsOfType<Light>();
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
        }*/
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
        float pc_counter = 1;

        meshMaterial.SetFloat("_dissolve_amount", counter);
        pcmaterials1.SetFloat("_dissolve_amount", pc_counter);
        pcmaterials2.SetFloat("_dissolve_amount", pc_counter);
        pcmaterials3.SetFloat("_dissolve_amount", pc_counter);
        pcmaterials4.SetFloat("_dissolve_amount", pc_counter);
        pcmaterials5.SetFloat("_dissolve_amount", pc_counter);
        pcmaterials6.SetFloat("_dissolve_amount", pc_counter);
        pcmaterials7.SetFloat("_dissolve_amount", pc_counter);


        while (counter < 1 && pc_counter > 0)
        {
            pcObject.SetActive(true);

            counter += dissolveRate;
            meshMaterial.SetFloat("_dissolve_amount", counter);
            
            pc_counter -= dissolveRate;
            pcmaterials1.SetFloat("_dissolve_amount", pc_counter);
            pcmaterials2.SetFloat("_dissolve_amount", pc_counter);
            pcmaterials3.SetFloat("_dissolve_amount", pc_counter);
            pcmaterials4.SetFloat("_dissolve_amount", pc_counter);
            pcmaterials5.SetFloat("_dissolve_amount", pc_counter);
            pcmaterials6.SetFloat("_dissolve_amount", pc_counter);
            pcmaterials7.SetFloat("_dissolve_amount", pc_counter);

            yield return new WaitForSeconds(refreshRate);
        }


        /*Debug.Log(counter);


        while (counter > 0)
        {
            RenderSettings.skybox = skyboxMaterial_notturno;
            Debug.Log("torno indietro");
            counter -= dissolveRate;
            counter = Mathf.Clamp01(counter);
            meshMaterial.SetFloat("_dissolve_amount", counter);
            /*for (int i = 0; i < sceneLights.Length; i++)
            {
                for (int j = 0; j < originalIntensities[i]; j++)
                    sceneLights[i].intensity += dissolveRate;
            }*/

            //yield return new WaitForSeconds(refreshRate);
        //}
    
    }
}
