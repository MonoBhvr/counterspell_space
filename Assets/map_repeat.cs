using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class map_repeat : MonoBehaviour
{
    public List<GameObject> maps;
    public GameObject player;
    public int map_chosen = 0;
    public GameObject map;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        map_chosen = map_chosen % maps.Count;
        map = maps[map_chosen];
        if (player.transform.position.x < map.transform.position.x - 74.36f + 1.3f)
        {
            map_chosen++;
            map.transform.position = new Vector3(map.transform.position.x - (74.36f-1.3f) * maps.Count, map.transform.position.y, map.transform.position.z);
        }
    }
}