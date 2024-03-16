using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CameraScript : MonoBehaviour
{
    // Start is called before the first frame update
    public LogicManager logicScript;
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(logicScript.corBranca){
            Camera.main.backgroundColor = Color.white;
        } else{
            Camera.main.backgroundColor = Color.gray;
        }
    }
}
