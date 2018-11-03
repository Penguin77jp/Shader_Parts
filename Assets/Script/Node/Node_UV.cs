using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_UV : Node_Base
{
    void Start()
    {
        VariableName = "UV";
        base.Start();
    }

    void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            var _variableName = VariableName.ToString() + "_" + id.ToString();
            var _variableType = VariableData.VariableType.float2;
            var _var = exporter[0].exportVariable = new VariableData(_variableName, _variableType);
            var importVar = "i.uv";
            actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = " + importVar + "; \n";
        }
    }
}
