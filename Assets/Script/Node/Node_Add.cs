using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Add : Node_Base
{
    override public void Start()
    {
        VariableName = "Add";
        base.Start();
    }

    void Update()
    {
        if (importer[0].importVariable != null)
        {
            //export
            var variableType = VariableData.VariableType.float1;
            var _var = exporter[0].exportVariable = new VariableData(VariableName.ToString() + "_" + id.ToString(), variableType);
            actionString = _var.VariableType2string(variableType) + " " + VariableName + "_" + id + " = " + importer[0].importVariable.variableName + " + " + importer[1].importVariable.variableName + "; \n";
        }
    }
}
