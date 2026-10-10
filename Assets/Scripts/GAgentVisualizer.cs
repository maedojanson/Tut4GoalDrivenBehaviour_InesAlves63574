using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class GAgentVisualizer : MonoBehaviour
{
    public GAgent thisAgent;

    void Start()
    {
        thisAgent = this.GetComponent<GAgent>();
    }

    void Update()
    {
        if (thisAgent == null)
        {
            thisAgent = this.GetComponent<GAgent>();
        }
    }
}
