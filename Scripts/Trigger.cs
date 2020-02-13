using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    void OnTriggerEnter(Collider col)
    {
        if(col.tag == "Ball")
        {
            Application.LoadLevel("Menu");
        }
    }
}
