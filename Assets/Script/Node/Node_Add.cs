using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Add : Node_Base
{
    override public void Start()
    {
        VariableName = "Add";

        importer[0]._Base = importer[1]._Base = GetComponent<Node_Base>();
        exporter[0]._Base = GetComponent<Node_Base>();


        base.Start();
    }

    void Update()
    {
        if (importer[0].pipline != null)
        {
            //export
            exporter[0].VariableName = VariableName.ToString() + "_" + id.ToString();
            actionString = "float " + VariableName + "_" + id + " = " + importer[0].importVariableName + " + " + importer[1].importVariableName + "; \n";
        }
    }
}
