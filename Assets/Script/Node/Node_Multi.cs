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
            actionString = _var.VariableType2string(_variableType) + " " + _variableName + " = " + (inputFloat.text == string.Empty ? "0" : importer[0].importVariable.variableName + "*" + inputFloat.text).ToString() + "; \n";
        }
    }
}
