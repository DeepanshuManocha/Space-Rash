using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour
{
    public GameObject bg, game;
    public List<GameObject> li = new List<GameObject>();
    public Transform CameraTransform;
    
    // Start is called before the first frame update
    void Start()
    {
        //li.Add(bg);
        float actualWidth = bg.GetComponent<SpriteRenderer>().sprite.rect.height;
        float scaledWidth = (bg.transform.localScale.y * actualWidth)/100.0f;
        CameraTransform = Camera.main.transform;
        
        for (int i = 0; i < 5; i++)
        {
            GameObject newbg1 = Instantiate<GameObject>(bg);
            newbg1.transform.position =new Vector2(0,((bg.transform.position.x)+(i + 1) * scaledWidth) );
            newbg1.transform.SetParent(game.transform);
            li.Add(newbg1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var bg2 in li)
        {
            float actualWidth = bg.GetComponent<SpriteRenderer>().sprite.rect.height;
            float scaledWidth = (bg.transform.localScale.y * actualWidth) / 100.0f;
            if (bg2.transform.position.y + 12 < CameraTransform.position.y)
                bg2.transform.position = new Vector3(0 ,bg2.transform.position.y+(scaledWidth * li.Count), bg.transform.position.z);
        }
    }
}
