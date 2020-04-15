using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyController : MonoBehaviour
{
    float speed;
    public float size;
    GameObject scoreText,scoreText1;
    public GameObject AstroidExplosion, ShipExplosion;

    // Start is called before the first frame update
    void Start()
    {
        speed=2f;
        scoreText =GameObject.FindGameObjectWithTag("Score");
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(size*Time.deltaTime,size*Time.deltaTime,size*Time.deltaTime);
        Vector2 position=transform.position;
        position= new Vector2(position.x,position.y-speed*Time.deltaTime);
        transform.position=position;
        Vector2 min=Camera.main.ViewportToWorldPoint(new Vector2(0,0));
        if(transform.position.y<min.y)
        {
            Destroy(gameObject);
        }
        
    }

    public void OnTriggerEnter2D(Collider2D other) 
    {
        if((gameObject.CompareTag("Asteriod")) && (other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Player"))) 
        {
            Destroy(gameObject);
            Debug.Log("hit");
            PlayAstroidExplosion();
        }   
        if((gameObject.CompareTag("Enemy")) && (other.gameObject.CompareTag("PlayerBullet") || other.gameObject.CompareTag("Player"))) 
        {
            PlayShipExplosion();
            Destroy(gameObject);
            scoreText.GetComponent<GameScore>().Score+=100;
            scoreText1.GetComponent<GameScore>().Score+=100;
        } 
    }

    void PlayAstroidExplosion()
    {
        GameObject astroidExplosion=(GameObject)Instantiate(AstroidExplosion);
        astroidExplosion.transform.position=transform.position;
    }
    
    void PlayShipExplosion()
    {
        GameObject shipExplosion=(GameObject)Instantiate(ShipExplosion);
        shipExplosion.transform.position=transform.position;
    }

}
