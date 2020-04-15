using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject EnemyBullet; 

    // Start is called before the first frame update
    void Start()
    {
        Invoke("FireEnemyBullet",1f);
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }

    public void FireEnemyBullet()
    {
        GameObject PlayerShip=GameObject.Find ("PlayerShip");

        if(PlayerShip!=null)
        {
            GameObject bullet =(GameObject)Instantiate(EnemyBullet);
            bullet.transform.position=transform.position;
            Vector2 direction=PlayerShip.transform.position - bullet.transform.position;
            bullet.GetComponent<EnemyBullet>().setDirection(direction);
        }
    }
}
