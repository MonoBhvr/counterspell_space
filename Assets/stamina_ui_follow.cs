using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stamina_ui_follow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        //ui image follow player
        RectTransform rt = GetComponent<RectTransform>();
        Vector3 player_pos = Camera.main.WorldToScreenPoint(player.transform.position);
        // rt.anchoredPosition = new Vector3(player.transform.position.x-218, player.transform.position.y, 0);
        rt.anchoredPosition = Vector3.Lerp(rt.anchoredPosition, new Vector3(player_pos.x - 218, player_pos.y, 0), 0.2f);    
    }
}
