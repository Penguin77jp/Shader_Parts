using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Pow : Node_Base
{
    override public void Start()
    {
        VariableName = "Pow";

        importer[0]._Base = exporter[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            exporter[0].VariableName = VariableName.ToString() + "_" + id.ToString();
            actionString = "float " + VariableName.ToString() + "_" + id.ToString() + " = pow(" + importer[0].importVariableName + "," + importer[1].importVariableName.ToString() + "); \n";
        }
    }
}
