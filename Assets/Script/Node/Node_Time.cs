using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Time : Node_Base
{
    void Start()
    {
        VariableName = "Time";
        exporter[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }

    void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            exporter[0].VariableName = VariableName.ToString() + "_" + id.ToString();
            var importVar = "_Time";
            actionString = "float4 " + exporter[0].VariableName + " = " + importVar + "; \n";
        }
    }
}
