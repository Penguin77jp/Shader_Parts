using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Time : Node_Base
{
    void Start()
    {
        VariableName = "Time";
        base.Start();
    }

    void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            var _variableName = VariableName.ToString() + "_" + id.ToString();
            var _variableType = VariableData.VariableType.float4;
            var _var = exporter[0].exportVariable = new VariableData(_variableName, _variableType);
            var importVar = "_Time";
            actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = " + importVar + "; \n";
        }
    }
}
