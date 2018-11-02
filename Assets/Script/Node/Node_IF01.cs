using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_IF01 : Node_Base
{
    public List<Toggle> toggle;
    override public void Start()
    {
        VariableName = "IF01";

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
            var if_c = string.Empty;
            if (toggle[0].isOn)
            {
                if_c = "<";
            }
            else if (toggle[1].isOn)
            {
                if_c = "==";
            }
            else if (toggle[2].isOn)
            {
                if_c = ">";
            }
            actionString = "int " + VariableName + "_" + id + " = (" + importer[0].importVariableName + " " + if_c + " " + importer[1].importVariableName + "); \n";
        }
    }
}
