using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<GameObject> spawnList = new List<GameObject>();
    void Start()
    {

    }


    void Update()
    {

    }

    public void PlayerSpawn()
    {
        for (int i = 0; i < 6; i++)
        {
            var obj = Instantiate(playerPrefab, RandomPos(), Quaternion.identity, transform);
            spawnList.Add(obj);
        }
    }
    Vector3 RandomPos()
    {
        Vector3 pos = Random.onUnitSphere * 0.1f;
        Vector3 ob = spawnList[0].transform.position + pos;
        return ob;
    }
}
