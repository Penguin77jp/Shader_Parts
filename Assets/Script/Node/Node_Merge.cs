using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Merge : Node_Base
{
    public Dropdown _dropDown;

    void Start()
    {
        VariableName = "Merge4";
        importer[0]._Base = importer[1]._Base = importer[2]._Base = importer[3]._Base = GetComponent<Node_Base>();
        exporter[0]._Base = GetComponent<Node_Base>();
        base.Start();
    }

    void Update()
    {
        if (exporter[0].pipline != null)
        {
            var copy = new List<Node_importer>(importer);
            var conv = copy.ConvertAll(x => (string)(x.pipline == null ? "0" : x.importVariableName));
            //export
            exporter[0].VariableName = VariableName.ToString();
            if (_dropDown.value == 0)
            {
                actionString = "float2 " + VariableName.ToString() + "_" + id.ToString() + " = fixed2(" + conv[0] + "," + conv[1] + "); \n";
            }
            else if (_dropDown.value == 1)
            {
                actionString = "float3 " + VariableName.ToString() + "_" + id.ToString() + " = fixed3(" + conv[0] + "," + conv[1] + "," + conv[2] + "); \n";
            }
            else if (_dropDown.value == 2)
            {
                actionString = "float4 " + VariableName.ToString() + "_" + id.ToString() + " = fixed4(" + conv[0] + "," + conv[1] + "," + conv[2] + "," + conv[3] + "); \n";
            }
            exporter[0].VariableName = VariableName.ToString() + "_" + id.ToString();
        }
    }

    public void ChangedDropDown()
    {
        importer[2].gameObject.SetActive(_dropDown.value >= 1);
        importer[3].gameObject.SetActive(_dropDown.value >= 2);
        SetTerminalPosition();
    }
}
