using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blocks : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rb;
    map_repeat map_repeat;
    
    // Start is called before the first frame update
    void Start()
    {
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
        if (map_repeat.map.transform.position.x - 52 > transform.position.x)
        {
            GameObject a = Instantiate(gameObject);
            Destroy(a.GetComponent<blocks>());
            Destroy(a, 0.10f);
            transform.position = new Vector3(transform.position.x + 206, transform.position.y, transform.position.z);
        }
        //뒤로 벗어나면 앞으로 이동
        if (map_repeat.map.transform.position.x + 52+103 < transform.position.x)
        {
            transform.position = new Vector3(transform.position.x - 206, transform.position.y, transform.position.z);
        }
    }
}