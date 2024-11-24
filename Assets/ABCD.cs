using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ABCD : MonoBehaviour
{
    public int rate = 20;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(0, player.transform.position.y, -10);
    }
}
