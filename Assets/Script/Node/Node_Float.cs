using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_Float : Node_Base
{
    [SerializeField]
    private InputField inputFloat;
    public Toggle grobalToggle;
    override public void Start()
    {
        VariableName = "Float";
        base.Start();
    }

    public void Update()
    {
        if (exporter[0].pipline != null)
        {
            //export
            exporter[0].exportVariable = new VariableData(VariableName.ToString() + "_" + id.ToString(), VariableData.VariableType.float1, grobalToggle.isOn);
            actionString = "float " + VariableName.ToString() + "_" + id.ToString() + " = " + (inputFloat.text == string.Empty ? "0" : inputFloat.text).ToString() + "; \n";
        }
    }
}
