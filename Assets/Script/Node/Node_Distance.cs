using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_Distance : Node_Base
{
    void Start()
    {
        VariableName = "Distance";
        base.Start();
    }

    void Update()
    {
        if (importer.TrueForAll(x => x.pipline != null) && exporter[0].pipline != null)
        {
            //export
            var variableType = VariableData.VariableType.float1;
            exporter[0].exportVariable = new VariableData(VariableName.ToString() + "_" + id.ToString(), variableType);
            actionString = exporter[0].exportVariable.VariableType2string(variableType) + " " + VariableName.ToString() + "_" + id.ToString() + " = distance(" + importer[0].importVariable.variableName + "," + importer[1].importVariable.variableName + "); \n";
        }
    }
}
