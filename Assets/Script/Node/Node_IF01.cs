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
        base.Start();
    }

    void Update()
    {
        if (importer[0].pipline != null)
        {
            //export
            var _variableName = VariableName.ToString() + "_" + id.ToString();
            var _variableType = VariableData.VariableType.float1;
            exporter[0].exportVariable = new VariableData(_variableName, _variableType);
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
            actionString = exporter[0].exportVariable.VariableType2string(_variableType) + " " + _variableName + " = (" + importer[0].importVariable.variableName + " " + if_c + " " + importer[1].importVariable.variableName + "); \n";
        }
    }
}
