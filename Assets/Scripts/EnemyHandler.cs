using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHandler : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;

    [SerializeField] GameObject spawnCoords;
    [SerializeField] UIUpdater uIUpdater;
    public static bool winCondition = false;


    // Start is called before the first frame update
    void Start()
    {
        winCondition = false;
        SpawnEnemy(); 
    }

    // Update is called once per frame
    void Update()
    {
        if (winCondition) {
            uIUpdater.toggleWinScreen(true);
        }
    }

    public static void setWinBool (bool newCondition) {
        winCondition = newCondition;
    }

    
    public void SpawnEnemy() {
        GameObject enemyInstance = Instantiate(enemyPrefab, spawnCoords.transform.position, Quaternion.identity);
    }


}
