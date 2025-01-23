using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class tool_box : MonoBehaviour
{
    public GameObject player;
    public float taken = 10;
    public List<Sprite> items;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") && Input.GetKeyDown(KeyCode.Space))
        {
            Image item = player.GetComponent<Player_movement>().item_bar.GetComponent<Image>();
            item.sprite = items[Random.Range(0, items.Count)];
            item.SetNativeSize();
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            taken = 10;
            player.GetComponent<Animator>().SetBool("on_fix", false);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<Animator>().SetBool("on_fix", true);
        }
    }
}
