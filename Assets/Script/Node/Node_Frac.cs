using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Frac : Node_Base
{
    override public void Start()
    {
        VariableName = "Frac";
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            var _variableName = VariableName + "_" + id.ToString();
            var variableType = VariableData.VariableType.float1;
            exporter[0].exportVariable = new VariableData(_variableName, variableType);
            actionString = exporter[0].exportVariable.VariableType2string(variableType) + " " + _variableName + " = frac(" + importer[0].importVariable.variableName + ");\n";
        }
    }
}
