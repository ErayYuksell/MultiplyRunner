using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GateController : MonoBehaviour
{
    BoxCollider gateCollider;
    [SerializeField] int gateValue;
    [SerializeField] TextMeshProUGUI gateText;
    void Start()
    {
        gateCollider = GetComponent<BoxCollider>();
        GateStart();
    }


    void Update()
    {

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            var playerSpawner = other.GetComponentInParent<PlayerSpawnController>();
            playerSpawner.PlayerSpawn(gateValue);
            StartCoroutine(CloseGateCollider());
        }
    }
    public IEnumerator CloseGateCollider()
    {
        gateCollider.enabled = false;
        yield return new WaitForSeconds(1);
        gateCollider.enabled = true;
    }
    void GateStart()
    {
        gateText.text = "+" + gateValue.ToString();
    }
}
