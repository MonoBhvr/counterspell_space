using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class map_repeat : MonoBehaviour
{
    public List<GameObject> maps;
    public GameObject player;
    public int map_chosen = 0;
    public GameObject map;
    public List<bool> map_room = new List<bool>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        map_chosen = (int)map_chosen % maps.Count;
        //왼쪽으로 무한히 반복되는 맵, 플레이어가 선택된 맵의 다음 맵의 중앙에 위치하면 다음 맵이 x축으로 -103만큼 이동
        if (player.transform.position.x < maps[map_chosen].transform.position.x - (map_room[map_chosen] ? 45.25f : 103))
        {
            maps[map_chosen].transform.position = new Vector3(maps[map_chosen].transform.position.x - 206, maps[map_chosen].transform.position.y, maps[map_chosen].transform.position.z);
            map_chosen++;
        }
        
        //플레이어가 선택된 맵의 이전 맵의 중앙에 위치하면 플레이어를 다음 맵의 중앙으로 이동
        // if (player.transform.position.x > maps[map_chosen].transform.position.x + 103)
        // {
        //     player.transform.position = new Vector3(player.transform.position.x - 206, player.transform.position.y, player.transform.position.z);
        // }
        map = maps[(map_chosen+1)%2];
    }
}
