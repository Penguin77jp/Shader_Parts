using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node_BlitCamera : MonoBehaviour
{
    public Node_importer importTexture;
    void Update()
    {
        if (importTexture.pipline != null)
        {
            // NodeManager.Instance.destTexture = importTexture.import;
        }
    }
}
