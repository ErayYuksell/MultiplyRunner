using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RazorController : MonoBehaviour
{
  
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            var playerSpawn = other.GetComponentInParent<PlayerSpawnController>();
            playerSpawn.PlayerDestroy(other.gameObject);
        }
    }
}
