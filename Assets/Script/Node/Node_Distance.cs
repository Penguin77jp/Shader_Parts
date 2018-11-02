using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Distance : Node_Base
{
    void Start()
    {
        importer[0]._Base = importer[1]._Base = GetComponent<Node_Base>();
        VariableName = "Distance";
        exporter[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }

    void Update()
    {
        if (importer.TrueForAll(x => x.pipline != null) && exporter[0].pipline != null)
        {
            //export
            exporter[0].VariableName = VariableName.ToString() + "_" + id.ToString();
            actionString = "float " + VariableName.ToString() + "_" + id.ToString() + " = distance(" + importer[0].importVariableName + "," + importer[1].importVariableName + "); \n";
        }
    }
}
