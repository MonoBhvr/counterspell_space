using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class fix : MonoBehaviour
{
    public float brocken = 20;
    public Sprite brocken1;
    Player_movement player;

    public SpriteRenderer gage;
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
        brocken = Mathf.Clamp(brocken, 0, 20);
        gage.gameObject.transform.localScale = new Vector3(0.6f * brocken / 20, 0.05f, 1);
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
            StartCoroutine(fade(0));

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player")&& brocken > 0 && other.gameObject.GetComponent<Player_movement>().has_item)
        {
            other.gameObject.GetComponent<Animator>().SetBool("on_fix", true);
            StartCoroutine(fade(1));
        }
    }

    IEnumerator fade(int t)
    {
        for (int i = 0; i < 200; i++)
        {

            gage.color = new Color(gage.color.r, gage.color.g, gage.color.b, Mathf.Lerp(gage.color.a, t, i/200));
            yield return new Update();
        }
        
    }
}
