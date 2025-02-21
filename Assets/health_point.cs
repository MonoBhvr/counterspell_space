using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class health_point : MonoBehaviour
{
    public float max_hp = 3;

    public float hp = 3;

    public GameObject hp_bar;

    public bool on_damage = false;
    public bool isdead = false;
    
    public CanvasGroup canvasGroup;
    public GameObject text;

    private GameObject s;
    public void Start()
    {
        s = GameObject.Find("Canvas");
        text.SetActive(false);
    }
    void Update()
    {
        hp_bar.transform.localScale = Vector3.Lerp(hp_bar.transform.localScale, new Vector3(0.5f * hp / max_hp, 0.05f, 1), 0.2f);
        hp_bar.GetComponent<SpriteRenderer>().color = Color.Lerp(new Color(0,1,0,hp_bar.GetComponent<SpriteRenderer>().color.a), new Color(1,0,0,hp_bar.GetComponent<SpriteRenderer>().color.a), (max_hp - hp) / max_hp);
        hp = Mathf.Clamp(hp, 0, max_hp);
        if (on_damage)
        {
            //change alpha 0 to 1
            hp_bar.GetComponent<SpriteRenderer>().color = new Color(hp_bar.GetComponent<SpriteRenderer>().color.r, hp_bar.GetComponent<SpriteRenderer>().color.g, hp_bar.GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(hp_bar.GetComponent<SpriteRenderer>().color.a, 1, 6f * Time.deltaTime));
        }
        else
        {
            //change alpha 1 to 0
            hp_bar.GetComponent<SpriteRenderer>().color = new Color(hp_bar.GetComponent<SpriteRenderer>().color.r, hp_bar.GetComponent<SpriteRenderer>().color.g, hp_bar.GetComponent<SpriteRenderer>().color.b, Mathf.Lerp(hp_bar.GetComponent<SpriteRenderer>().color.a, 0, 6f * Time.deltaTime));
        }

        if (hp <= 0 && !isdead)
        {
            GetComponent<Animator>().SetBool("dead", true);
            Destroy(GetComponent<Player_movement>());
            GetComponent<Animator>().SetTrigger("die");
            isdead = true;
            Destroy(s.transform.GetChild(0).gameObject);
            Destroy(s.transform.GetChild(1).gameObject);
        }
    }

    private void FixedUpdate()
    {
        if (isdead)
        {
            text.SetActive(true);
            canvasGroup.alpha = Mathf.Lerp(canvasGroup.alpha, 1, 0.5f * Time.deltaTime);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 0, transform.position.z), 0.5f);

            if (canvasGroup.alpha >= 0.9f)
            {
                Camera.main.cullingMask = 0;
            }

            if(Input.GetKeyDown(KeyCode.Escape))    //change scene
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
            }
        }
    }


    public void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Trash"))
        {
            float vel = (other.gameObject.GetComponent<Rigidbody2D>().velocity - GetComponent<Rigidbody2D>().velocity).magnitude;
            hp -= vel * 0.1f;
            on_damage = true;
            Invoke("reee", 1.5f);
        }
    }

    void reee()
    {
        on_damage = false;
    }
}
