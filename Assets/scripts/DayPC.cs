using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayPC : MonoBehaviour
{ 
    public GameObject self;
    public GameObject DayMesh;
    public GameObject NightPC;
    // Start is called before the first frame update
    void Start()
    {
        self.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            DayMesh.SetActive(true);
            self.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            NightPC.SetActive(true);
            self.SetActive(false);
        }
    }
}