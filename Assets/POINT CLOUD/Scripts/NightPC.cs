using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightPC : MonoBehaviour
{

    public GameObject self;
    public GameObject NightMesh;
    public GameObject DayPC;
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
            NightMesh.SetActive(true);
            self.SetActive(false);
        }

        if (Input.GetKeyDown(KeyCode.Z))
        {
            DayPC.SetActive(true);
            self.SetActive(false);
        }
    }
}