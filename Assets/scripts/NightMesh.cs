using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightMesh: MonoBehaviour
{

    public GameObject self;
    public GameObject NightPC;
    public GameObject DayMesh;
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
            NightPC.SetActive(true);
            self.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DayMesh.SetActive(true);
            self.SetActive(false);
        }
    }
}