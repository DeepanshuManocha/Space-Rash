using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    float speed;
    bool isReady;
    Vector2 dir;
    
    void Awake() 
    {
        speed=5f;
        isReady=false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void setDirection(Vector2 direction)
    {
        dir=direction.normalized;
        isReady=true;
    }

    // Update is called once per frame
    void Update()
    {
        if(isReady==true)
        {
            Vector2 position =transform.position;
            position+= dir*speed*Time.deltaTime;
            transform.position=position;

            Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
            Vector2 max=Camera.main.ViewportToWorldPoint(new Vector2(1,1));

            if((transform.position.x<min.x) || (transform.position.x>max.x) || (transform.position.y<min.y) ||(transform.position.y>max.y))
            {
                Destroy(gameObject);
            }
        }
    }
}
