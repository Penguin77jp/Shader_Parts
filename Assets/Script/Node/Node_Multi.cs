using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Multi : Node_Base
{
    [SerializeField]
    private InputField inputFloat;
    override public void Start()
    {
        VariableName = "Multi";

        importer[0]._Base = exporter[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            exporter[0].VariableName = VariableName.ToString() + "_" + id.ToString();
            actionString = "float " + VariableName.ToString() + "_" + id.ToString() + " = " + (inputFloat.text == string.Empty ? "0" : importer[0].importVariableName + "*" + inputFloat.text).ToString() + "; \n";
        }
    }
}
