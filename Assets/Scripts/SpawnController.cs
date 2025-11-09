using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Vector3 spawnReferencePosition;
    public int amountToSpawn;
    public Vector3 spawnRotation;

    private void Start(){
        for (int i=0; i<amountToSpawn; i++){
            Vector3 randomPosition = new Vector3(Random.Range(-spawnReferencePosition.x, spawnReferencePosition.x),
                spawnReferencePosition.y, spawnReferencePosition.z);
            
            SpawnEnemy(randomPosition);
        }
    }

    public void SpawnEnemy(Vector3 enemyPosition){
        Quaternion rotation = Quaternion.Euler(spawnRotation);
        Instantiate(enemyPrefab, enemyPosition, rotation);  
    }
}