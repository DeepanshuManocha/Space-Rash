using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Player : MonoBehaviour
{
    public GameObject player, gameOver, PlayerBullet, bulletPos1, bulletPos2, enemySpawner;
    public Rigidbody2D rb;
    public float speed;
    public Image HealthBar;
    public float maxHealth = 100f;
    public static float health;
    public int bulletCount;
    public Text bulletCountText;
    public AudioSource playerShoot;
    private ShakeScreen Shake;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        bulletCount=0;
        Shake=GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<ShakeScreen>();
    }

    // Update is called once per frame
    void Update()
    {
        if((Input.GetKeyDown("space") || Input.GetMouseButtonDown(0)) && bulletCount>0 )
        {
            playerShoot.Play();
            GameObject bullet1 =(GameObject)Instantiate(PlayerBullet);
            bullet1.transform.position = bulletPos1.transform.position;

            GameObject bullet2 =(GameObject)Instantiate(PlayerBullet);
            bullet2.transform.position = bulletPos2.transform.position;

            bulletCount--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, 0);

        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-speed*Time.deltaTime, 0);
        }
        if(Input.GetKeyUp(KeyCode.D) )
        { 
            rb.velocity = new Vector2(0, 0);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            rb.velocity = new Vector2(0, 0);
        }
        bulletCountText.text=bulletCount.ToString();
        HealthBar.fillAmount = health / maxHealth;
    }

    void GameOver()
    {
        gameOver.SetActive(true);
        enemySpawner.SetActive(false);
        //Time.timeScale=0f;
        Destroy(player);
    }

    private void OnTriggerEnter2D(Collider2D other) 
    { 
        if(other.gameObject.CompareTag("Asteriod"))
        {
            health=health-(health/2);
            //Destroy(other.gameObject);
            if(Player.health<=0)
            {
                GameOver();
            }
        }
        else if(other.gameObject.CompareTag("Bullet"))
        {
            health-=20f;
            Destroy(other.gameObject);
            Shake.CamShake();
            if(Player.health<=0)
            {
                GameOver();
            }
        }
        else if(other.gameObject.CompareTag("Enemy"))
        {
            health-=5.0f;
            
            bulletCount++;
            
            if(Player.health<=0)
            {
                GameOver();
            }
        }
        else if(other.gameObject.CompareTag("Health")&&health<100f)
        {
            if(health<=90)
            {
                health+=10f;
            }
            else if(health>90)
            {
                health = maxHealth;
            }
            Destroy(other.gameObject);
        }
    }

}
