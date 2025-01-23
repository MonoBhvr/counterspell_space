using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Screen = UnityEngine.Device.Screen;

public class stamina_ui_follow : MonoBehaviour
{
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //17.32 : Screen.width = ? : Screen.height
        //? = 17.32 * Screen.width / Screen.height
        //ui image follow player
        Vector3 player_pos = Camera.main.WorldToScreenPoint(player.transform.position + (Vector3)Vector2.left * 0.8f);
        RectTransform rt = GetComponent<RectTransform>();
        Vector2 screenPoint = new Vector2(player_pos.x, player_pos.y);
        Vector2 localPoint;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(rt.parent as RectTransform, screenPoint, Camera.main, out localPoint);
        rt.anchoredPosition = Vector2.Lerp(rt.anchoredPosition, localPoint, 0.2f);        
    }
}
