using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Node_ExportColor : Node_Base
{
    public RenderTexture export_R;
    public RenderTexture export_G;
    public RenderTexture export_B;
    public RenderTexture export_A;
    [SerializeField] private Material mat;
    [SerializeField] private Dropdown ExportType;

    override public void Start()
    {
        VariableName = "ExportColor";
        base.Start();
    }

    void Update()
    {
        if (importer[0].pipline != null)
        {

            //export
            exporter[0].exportVariable = new VariableData(VariableName.ToString() + "R_" + id.ToString(), VariableData.VariableType.float1);
            exporter[0].exportVariable = new VariableData(VariableName.ToString() + "G_" + id.ToString(), VariableData.VariableType.float1);
            exporter[0].exportVariable = new VariableData(VariableName.ToString() + "B_" + id.ToString(), VariableData.VariableType.float1);
            exporter[0].exportVariable = new VariableData(VariableName.ToString() + "A_" + id.ToString(), VariableData.VariableType.float1);
            var imp0 = importer[0].importVariable.variableName;
            if (ExportType.value == 0)
            {
                actionString = "float " + VariableName + "R_" + id + " = " + imp0 + ".x; \n" +
           "float " + VariableName + "G_" + id + " = " + imp0 + ".y; \n";

            }
            else if (ExportType.value == 1)
            {
                actionString = "float " + VariableName + "R_" + id + " = " + imp0 + ".x; \n" +
           "float " + VariableName + "G_" + id + " = " + imp0 + ".y; \n" +
           "float " + VariableName + "B_" + id + " = " + imp0 + ".z; \n";

            }
            else if (ExportType.value == 2)
            {
                actionString = "float " + VariableName + "R_" + id + " = " + imp0 + ".x; \n" +
           "float " + VariableName + "G_" + id + " = " + imp0 + ".y; \n" +
           "float " + VariableName + "B_" + id + " = " + imp0 + ".z; \n" +
             "float " + VariableName + "A_" + id + " = " + imp0 + ".w; \n";
            }
        }
    }

    public void ChangedExportType()
    {
        exporter[2].gameObject.SetActive(ExportType.value >= 1);
        exporter[3].gameObject.SetActive(ExportType.value >= 2);
        SetTerminalPosition();
    }
}
