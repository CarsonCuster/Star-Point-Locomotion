using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public bool isHighlighted = false;

    // Update is called once per frame
    void Update()
    {
        if(isHighlighted)
        {
            GetComponent<MeshRenderer>().material.color = Color.yellow;
        }
        else
        {
            GetComponent<MeshRenderer>().material.color = Color.blue;
        }
    }
}
