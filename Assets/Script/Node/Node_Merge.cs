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
        base.Start();
    }

    void Update()
    {
        if (exporter[0].pipline != null)
        {
            var copy = new List<Node_importer>(importer);
            var conv = copy.ConvertAll(x => (string)(x.pipline == null ? "0" : x.importVariable.variableName));
            //export
            var _variableName = VariableName.ToString() + "_" + id.ToString();
            var _variableType = VariableData.VariableType.float1;

            if (_dropDown.value == 0)
            {
                _variableType = VariableData.VariableType.float2;
            }
            else if (_dropDown.value == 1)
            {
                _variableType = VariableData.VariableType.float3;
            }
            else if (_dropDown.value == 2)
            {
                _variableType = VariableData.VariableType.float4;
            }

            var _var = exporter[0].exportVariable = new VariableData(_variableName, _variableType);

            if (_dropDown.value == 0)
            {
                actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = fixed2(" + conv[0] + "," + conv[1] + "); \n";
            }
            else if (_dropDown.value == 1)
            {
                actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = fixed3(" + conv[0] + "," + conv[1] + "," + conv[2] + "); \n";
            }
            else if (_dropDown.value == 2)
            {
                actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = fixed4(" + conv[0] + "," + conv[1] + "," + conv[2] + "," + conv[3] + "); \n";
            }

        }
    }

    public void ChangedDropDown()
    {
        importer[2].gameObject.SetActive(_dropDown.value >= 1);
        importer[3].gameObject.SetActive(_dropDown.value >= 2);
        SetTerminalPosition();
    }
}
