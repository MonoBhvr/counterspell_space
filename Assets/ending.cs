using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ending : MonoBehaviour
{
    public CanvasGroup canvasGroup;
    private fix f;

    public bool trigger = false;
    // Start is called before the first frame update
    void Start()
    {
        f = GameObject.FindWithTag("fix").GetComponent<fix>();
        transform.GetChild(0).gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (f.brocken <= 0)
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && f.brocken <= 0 && !trigger)
        {
            trigger = true;
            StartCoroutine(fade_out());
        }
    }

    IEnumerator fade_out()
    {
        while (canvasGroup.alpha <1)
        {
            canvasGroup.alpha += Time.deltaTime;
            yield return null;
        }
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }
}
