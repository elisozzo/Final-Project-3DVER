using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayMesh : MonoBehaviour
{
    
    public GameObject self;
    public GameObject DayPC;
    public GameObject NightMesh;    
    // Start is called before the first frame update
    void Start()
    {
        self.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DayPC.SetActive(true);
            self.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            NightMesh.SetActive(true);
            self.SetActive(false);
        }
    }
}