using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Pow : Node_Base
{
    override public void Start()
    {
        VariableName = "Pow";
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            var _variableName = VariableName.ToString() + "_" + id.ToString();
            var _variableType = VariableData.VariableType.float1;
            var _var = exporter[0].exportVariable = new VariableData(_variableName, _variableType);
            actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = pow(" + importer[0].importVariable.variableName + "," + importer[1].importVariable.variableName.ToString() + "); \n";
        }
    }
}
