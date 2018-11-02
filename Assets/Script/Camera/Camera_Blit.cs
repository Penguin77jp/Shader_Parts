using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Blit : MonoBehaviour
{

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (NodeManager.Instance.destTexture != null)
        {
            Graphics.Blit(NodeManager.Instance.destTexture, dest);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }
}
