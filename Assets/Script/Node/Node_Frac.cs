using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Frac : Node_Base
{
    override public void Start()
    {
        VariableName = "Frac";
        importer[0]._Base = exporter[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            exporter[0].VariableName = VariableName + "_" + id.ToString();
            actionString = "float " + VariableName + "_" + id + " = frac(" + importer[0].importVariableName + ");\n";
        }
    }
}
