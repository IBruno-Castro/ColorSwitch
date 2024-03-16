using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreBallScript : MonoBehaviour
{
    public float velocidade = 5;
    public LogicManager logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!logicScript.GetGameOver()){
            transform.position += (Vector3.down * velocidade) * Time.deltaTime;

            if(transform.position.y < -2.15) Destroy(gameObject);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        Destroy(gameObject);
    }

    
}
