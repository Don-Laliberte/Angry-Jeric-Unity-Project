using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinHandler : MonoBehaviour
{
    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private GameObject spawnCoords;

    private void Awake() {
    }

    // Start is called before the first frame update
    void Start()
    {
        SpawnCoin();
    }

        // Update is called once per frame
    void Update()
    {
        
    }

    void SpawnCoin() {
        GameObject coinInstance = Instantiate(coinPrefab, spawnCoords.transform.position, Quaternion.identity);  
    }
}