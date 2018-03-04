using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace TestProject
{
    public class TextManager
    {
        private static TextManager instance;
        Text text;

        private TextManager()
        {
            text = GameObject.FindWithTag("UI").GetComponent<Text>();
            Debug.Log("Instanced " + this.GetType());
        }

        public static TextManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TextManager();
                }
                return instance;
            }
        }
    }
}
