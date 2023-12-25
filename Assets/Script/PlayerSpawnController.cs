using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnController : MonoBehaviour
{
    [SerializeField] GameObject playerPrefab;
    [SerializeField] List<GameObject> spawnList = new List<GameObject>();
    float xSpeed;
    [SerializeField] float playerSpeed = 5;
    float maxXValue = 4.70f;
    void Update()
    {
        PlayerMovement();
    }
    void PlayerMovement()
    {
        float touchX = 0;
        float newXValue;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            xSpeed = 250f;
            touchX = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            xSpeed = 350f;
            touchX = Input.GetAxis("Mouse X");
        }
        newXValue = transform.position.x + xSpeed * touchX * Time.deltaTime;
        newXValue = Mathf.Clamp(newXValue, -maxXValue, maxXValue);
        Vector3 playerNewPosition = new Vector3(newXValue, transform.position.y, transform.position.z + playerSpeed * Time.deltaTime);
        transform.position = playerNewPosition;
    }

    public void PlayerSpawn(int gateValue)
    {
        for (int i = 0; i < gateValue; i++)
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
