using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateController : MonoBehaviour
{
    BoxCollider gateCollider;
    void Start()
    {
        gateCollider = GetComponent<BoxCollider>();
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerSpawner = other.GetComponentInParent<PlayerSpawnController>();
            playerSpawner.PlayerSpawn();
            StartCoroutine(CloseGateCollider());
        }
    }
    public IEnumerator CloseGateCollider()
    {
        gateCollider.enabled = false;
        yield return new WaitForSeconds(1);
        gateCollider.enabled = true;
    }
}
