using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    map_repeat map_repeat;
    public List<Sprite> blocks_;
    
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = blocks_[UnityEngine.Random.Range(0, blocks_.Count)];
        rb = GetComponent<Rigidbody2D>();
        map_repeat = GameObject.Find("Map").GetComponent<map_repeat>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x < speed)
        {
            rb.AddForce(Vector2.left * speed * Time.deltaTime);
        }
        //map_repeat에서 값을 받아와서 맵을 벗어나면 복제해서 뒤로 이동
        if (map_repeat.map.transform.position.x - 74.36f * map_repeat.maps.Count+74.36f*0.5f > transform.position.x)
        {
            GameObject a = Instantiate(gameObject);
            Destroy(a.GetComponent<blocks>());
            Destroy(a, 0.10f);
            transform.position = new Vector3(transform.position.x + 74.36f * map_repeat.maps.Count, transform.position.y, transform.position.z);
        }
        //뒤로 벗어나면 앞으로 이동
        if (map_repeat.map.transform.position.x + 74.36f*0.5f < transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 74.36f * map_repeat.maps.Count, transform.position.y, transform.position.z);
        }
    }
}
