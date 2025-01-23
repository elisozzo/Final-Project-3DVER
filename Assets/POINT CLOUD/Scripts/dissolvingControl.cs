using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dissolvingControl : MonoBehaviour
{
    private MeshRenderer mesh; // Dichiarazione del MeshRenderer
    private Material meshMaterial; // Dichiarazione del Material
    public float dissolveRate = 0.0125f;
    public float refreshRate = 0.025f;

    // Start is called before the first frame update
    void Start()
    {
        // Recupera il MeshRenderer
        mesh = GetComponent<MeshRenderer>();

        if (mesh != null)
        {
            // Recupera il materiale associato
            meshMaterial = mesh.material;
        }
        else
        {
            Debug.LogError("Non è stato trovato alcun MeshRenderer!");
        }
    }

    // Update is called once per frame
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
            Debug.LogError("Materiale non trovato. Impossibile avviare la dissolvenza.");
            yield break;
        }

        float counter = 0;

        // Imposta il valore iniziale della dissolvenza
        meshMaterial.SetFloat("_dissolve_amount", counter);

        // Continua a incrementare il valore di dissolvenza fino a 1
        while (counter < 1)
        {
            counter += dissolveRate;
            meshMaterial.SetFloat("_dissolve_amount", counter);
            yield return new WaitForSeconds(refreshRate);
        }
    }
}
