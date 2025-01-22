using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolvingControl : MonoBehaviour
{
    public MeshRenderer mesh;
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    public Material meshMaterial;
    // Start is called before the first frame update
    void Start()
    {
        if (mesh != null)
            meshMaterial = mesh.material;
        else
        {
            Debug.LogError("non c'è materiale");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown (KeyCode.Return))
        {
            StartCoroutine(DissolveCo());
        }
    }

    IEnumerator DissolveCo ()
    {
        float counter = 0;

        // Esegui la dissolvenza
        meshMaterial.SetFloat("_dissolve_amount", counter);
        Debug.LogError("sono qua");


        while (meshMaterial.GetFloat("_dissolve_amount") < 1)
            {
                counter += dissolveRate;
            Debug.LogError("dentro while");

            meshMaterial.SetFloat("_dissolve_amount", counter);

                yield return new WaitForSeconds(refreshRate);
            }
        
    }
}
