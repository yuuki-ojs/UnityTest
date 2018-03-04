using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour {

    String refstr;

	// Use this for initialization
    void Start () {
        refstr = "refstr";
        DebugManager.Instance.AddText("lefttext", ref refstr);
	}
	
	// Update is called once per frame
	void Update () {
        TestProject.LogManager.Instance.getLogger().Log("test");
        refstr = Time.timeSinceLevelLoad.ToString();
	}
}
