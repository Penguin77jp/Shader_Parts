using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class New_Node : MonoBehaviour
{
    public Dropdown _dropDown;
    private DirectoryInfo fileInfo;
    void Start()
    {
        fileInfo = new DirectoryInfo(Application.dataPath + "/Resources/Prefab/Node/");
        var optionData = new List<Dropdown.OptionData>();
        foreach (var get in fileInfo.GetFiles())
        {
            if (get.Extension != ".meta")
            {
                var test = new Dropdown.OptionData();
                test.text = get.Name;
                optionData.Add(test);
            }
        }
        _dropDown.options = optionData;
    }
    public void Create_Node()
    {
        var test = Resources.Load("Prefab/Node/" + fileInfo.GetFiles()[_dropDown.value * 2].Name.Split('.')[0], typeof(GameObject)) as GameObject;
        var obj = Instantiate(test, transform.position, transform.rotation, transform.parent);
        Destroy(gameObject);
    }
}
