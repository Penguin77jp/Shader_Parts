using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeManager : SingletonMonoBehaviour<NodeManager>
{
    public RenderTexture srcTexture;
    public RenderTexture destTexture;

    public enum VariableType
    {
        float1, float2, float3, float4
    }

    public List<Node_Base> node_bases;
    private struct SerchNode
    {
        public Node_Base _base;
        public bool _done;
    }
    private SerchNode newSerchNode(Node_Base getBase, bool isDone = false)
    {
        var newNode = new SerchNode();
        newNode._base = getBase;
        newNode._done = isDone;
        return newNode;
    }

    void Awake()
    {
        node_bases = new List<Node_Base>();
    }

    public List<Node_Base> Node_sort(Node_Base getBase)
    {
        Debug.Log("sort done");
        var _sort = new List<SerchNode>();
        _sort.Add(newSerchNode(getBase));
        while (true)
        {
            Node_Base serchingNode = null;
            foreach (var get in _sort)
            {
                if (!get._done)
                {
                    serchingNode = get._base;
                    break;
                }
            }
            if (_sort.TrueForAll(x => x._done))
            {
                break;
            }

            foreach (var get in serchingNode.importer)
            {
                if (get.pipline != null && _sort.TrueForAll(x => x._base != get.pipline.pointExporter._Base))
                {
                    _sort.Add(newSerchNode(get.pipline.pointExporter._Base));
                    Debug.Log(get.pipline.pointExporter._Base.gameObject + " id:" + _sort.IndexOf(_sort[_sort.Count - 1]));
                }
            }
            // _sort.FindAll(x => x._base == serchingNode).ConvertAll(x => newSerchNode(x._base, true));
            for (var n = 0; n < _sort.Count; n++)
            {
                if (_sort[n]._base == serchingNode)
                {
                    _sort[n] = newSerchNode(_sort[n]._base, true);
                }
            }
        }
        _sort.ForEach(x => x._base.id = _sort.IndexOf(x));
        node_bases = new List<Node_Base>(_sort.ConvertAll(x => x._base).ToArray());
        return _sort.ConvertAll(x => x._base);
    }
}
