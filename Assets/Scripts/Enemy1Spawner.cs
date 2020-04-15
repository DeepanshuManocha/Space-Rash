using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1Spawner : MonoBehaviour
{
    public GameObject EnemyShip, Asteriod, powerUp;
    float maxSpwanRateInSec = 5f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpwanEnemy1",maxSpwanRateInSec);
        InvokeRepeating("increaseSpwanRate",0f,45f);
        InvokeRepeating("InstantiateAsteriod",0f,5f);
        InvokeRepeating("InstantiatePowerUp",0f,15f);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateAsteriod()
    {
       Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
       Vector2 max=Camera.main.ViewportToWorldPoint(new Vector2(1,1));
       GameObject Enemy =(GameObject)Instantiate(Asteriod);
       Enemy.transform.position=new Vector2(Random.Range(min.x,max.x),max.y);
    }
    
    public void InstantiatePowerUp()
    {
       Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
       Vector2 max=Camera.main.ViewportToWorldPoint(new Vector2(1,1));
       GameObject Enemy =(GameObject)Instantiate(powerUp);
       Enemy.transform.position=new Vector2(Random.Range(min.x,max.x),max.y);
    }

    public void SpwanEnemy1()
    {
       Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
       Vector2 max=Camera.main.ViewportToWorldPoint(new Vector2(1,1));
       GameObject Enemy =(GameObject)Instantiate(EnemyShip);
       Enemy.transform.position=new Vector2(Random.Range(min.x,max.x),max.y);
       ScheduleNextEnemy();
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
