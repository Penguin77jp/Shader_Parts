using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Sin : Node_Base
{
    override public void Start()
    {
        VariableName = "Sin";
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            var _variableName = VariableName + "_" + id.ToString();
            var _variableType = VariableData.VariableType.float1;
            exporter[0].exportVariable = new VariableData(_variableName, _variableType);
            actionString = exporter[0].exportVariable.VariableType2string(_variableType) + " " + _variableName + " = sin(" + importer[0].importVariable.variableName + ");\n";
        }
    }
}
