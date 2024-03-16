using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScript : MonoBehaviour
{
    public GameObject point;
    public GameObject pointWhite;
    public float summon = Random.Range(1, 2), summon1 = Random.Range(1, 2);
    private float timer = 0, timer1 = 0;
    public float widthOffset = 10;
    public LogicManager logicScript;
    // Start is called before the first frame update
    void Start()
    {
        logicScript = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float highestPoint = transform.position.x + widthOffset;
        float lowestPoint = transform.position.x - widthOffset;
        if(!logicScript.GetGameOver()){
            if(timer < summon){
                timer += Time.deltaTime;
            } else {
                Instantiate(point, new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y, 0), transform.rotation);
                timer = 0;
                summon = Random.Range(1, 4);
                Debug.Log("Random preto :" + summon);
            }

            if(timer1 < summon1){
                timer1 += Time.deltaTime;
            } else {
                Instantiate(pointWhite, new Vector3(Random.Range(lowestPoint, highestPoint), transform.position.y, 0), transform.rotation);
                timer1 = 0;
                summon1 = Random.Range(1, 4);
                Debug.Log("Random branco :" + summon1);
            }
        }
        
    }
}
