using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_SrcTexture : MonoBehaviour
{

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        NodeManager.Instance.srcTexture = src;
        Graphics.Blit(src, dest);
    }
}
