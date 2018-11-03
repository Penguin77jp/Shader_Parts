using UnityEngine;

public class VariableData
{
    public string variableName;
    public VariableType variableType;
    public bool isGlobal;
    public enum VariableType
    {
        float1, float2, float3, float4
    }
    public VariableData(string name, VariableType type, bool isGrobal = false)
    {
        this.variableName = name;
        this.variableType = type;
        this.isGlobal = isGlobal;
    }
    public string VariableType2string()
    {
        var typeString = string.Empty;
        switch (variableType)
        {
            case VariableType.float1:
                typeString = "float";
                break;
            case VariableType.float2:
                typeString = "float2";
                break;
            case VariableType.float3:
                typeString = "float3";
                break;
            case VariableType.float4:
                typeString = "float4";
                break;
        }
        return typeString;
    }
    public string VariableType2string(VariableType getType)
    {
        var typeString = string.Empty;
        switch (getType)
        {
            case VariableType.float1:
                typeString = "float";
                break;
            case VariableType.float2:
                typeString = "float2";
                break;
            case VariableType.float3:
                typeString = "float3";
                break;
            case VariableType.float4:
                typeString = "float4";
                break;
        }
        return typeString;
    }
}