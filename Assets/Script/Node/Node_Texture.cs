using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Node_Texture : Node_Base
{
    public Dropdown _dropDown;
    private DirectoryInfo fileInfo;
    public Image uiImage;
    public override void Start()
    {
        VariableName = "Texture";
        fileInfo = new DirectoryInfo(Application.dataPath + "/Resources/Texture/");
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
        base.Start();
    }
    public void GetTexture()
    {
        var getTexture = Resources.Load("Texture/" + fileInfo.GetFiles()[_dropDown.value * 2].Name.Split('.')[0], typeof(Texture2D)) as Texture2D;
        var getSprite = Sprite.Create(getTexture, new Rect(0, 0, getTexture.width, getTexture.height), Vector2.zero);
        uiImage.sprite = getSprite;
    }
}
