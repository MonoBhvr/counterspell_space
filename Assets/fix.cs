using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fix : MonoBehaviour
{
    public float brocken = 20;
    public Sprite brocken1;
    Player_movement player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<Player_movement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (brocken <= 0)
        {
            GetComponent<SpriteRenderer>().sprite = brocken1;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && brocken > 0 && other.gameObject.GetComponent<Player_movement>().has_item)
        {
            brocken -= Time.deltaTime * 4;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&& brocken > 0 && other.gameObject.GetComponent<Player_movement>().has_item)
        {
            other.gameObject.GetComponent<Animator>().SetBool("on_fix", false);
            other.gameObject.GetComponent<Player_movement>().lost_item();
            
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&& brocken > 0 && other.gameObject.GetComponent<Player_movement>().has_item)
        {
            other.gameObject.GetComponent<Animator>().SetBool("on_fix", true);
        }
    }
}
