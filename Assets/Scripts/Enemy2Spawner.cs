using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Spawner : MonoBehaviour
{
    public GameObject EnemyShip, Asteriod;
    float maxSpwanRateInSec = 8f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpwanEnemy1",maxSpwanRateInSec);
        InvokeRepeating("InstantiateAsteriod",0f,8f);        
        InvokeRepeating("increaseSpwanRate",0f,60f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SpwanEnemy1()
    {
       Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
       Vector2 max=Camera.main.ViewportToWorldPoint(new Vector2(1,1));
       GameObject Enemy =(GameObject)Instantiate(EnemyShip);
       Enemy.transform.position=new Vector2(Random.Range(min.x,max.x),max.y);
       ScheduleNextEnemy();
    }
    public void InstantiateAsteriod()
    {
       Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
       Vector2 max=Camera.main.ViewportToWorldPoint(new Vector2(1,1));
       GameObject Enemy =(GameObject)Instantiate(Asteriod);
       Enemy.transform.position=new Vector2(Random.Range(min.x,max.x),max.y);
       
    }

    public void ScheduleNextEnemy()
    {
        float spwanInSec;
        if(maxSpwanRateInSec>1f)
        {
            spwanInSec=Random.Range(1f,maxSpwanRateInSec);
        }
        else
        {
            spwanInSec=1f;
        }
        Invoke("SpwanEnemy1",spwanInSec);
        
    }

    void increaseSpwanRate()
    {
        if(maxSpwanRateInSec>1f)
        maxSpwanRateInSec--;
        if(maxSpwanRateInSec==1)
        CancelInvoke("increaseSpwanRate");
    }
}
