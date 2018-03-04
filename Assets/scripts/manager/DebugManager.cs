using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

/// <summary>
/// デバッグマネージャクラス
/// Dキーでデバッグマネージャの機能の有無を切り替えられます
/// AddTextに名前(string)とDebugManagerClassの参照を渡すとデバッグ欄に表示してくれます
/// 渡したDebugManagerClassは更新処理をきちんと行ってください(UniRxを使用すると楽です
/// </summary>
public class DebugManager : TestProject.AbstractSingletonManager<DebugManager>
{

    public static bool isDebug = false;

    GUIStyle GuiStyle = new GUIStyle();
    GUIStyleState GuiStyleState = new GUIStyleState();

    List<string> LabelList = new List<string>();
    int RefStringCounter = 0;


    public void DebugStart()
    {
        //  デバッグ機能開始
        //  現状は自分自身をインスタンスするための関数
    }

    void Awake()
    {
        GuiStyleState.textColor = Color.white;
        GuiStyle.fontSize = 12;
        GuiStyle.margin = new RectOffset(10, 0, 10, 0);
        GuiStyle.normal = GuiStyleState;

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            isDebug = !isDebug;
        }
    }
    void testfunc()
    {
        Debug.Log("test");
    }

    void OnGUI()
    {
        if (!isDebug) return;

        GUILayout.BeginVertical("box");

        LabelList.ForEach(str=>{
            GUILayout.Label(str, GuiStyle);
        });

        GUILayout.EndVertical();
    }

    public bool AddText(string lefttext, string righttext)
    {
        try
        {
            var isExist = LabelList.Any(label => label.StartsWith(lefttext, StringComparison.OrdinalIgnoreCase));
            LabelList.Where(label => label.StartsWith(lefttext, StringComparison.OrdinalIgnoreCase))
                                      .Select(str => str = lefttext + " : " + righttext);
        }
        catch
        {
            Debug.Log("Exception handling : AddText(" + lefttext + "," + righttext + ");");
            return false;
        }
        return true;
    }
}
