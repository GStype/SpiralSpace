using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner2 : MonoBehaviour
{

    public GameObject[] enemies;
    public List<int> enemyIndexes;
    public Vector3 spawnValues;
    
    public float spawnRate;
    
    public float spawnMaxRate;
    public float spawnMinRate;
    
    public float minY; //min y axis value
    public float maxY; //max y axis value
    
    public int startDelay; //set how long the game waits until it start spawning enemies

    float sMinM = 0.998f; //spawnMinRate Modifier
    float sMaxM = 0.998f; //spawnMaxRate Modifier
    public bool stop;

    //int randomEnemy;


    void Start()
    {
        
        enemyIndexes = new List<int>(){0, 0, 0, 0, 0, 1, 1, 1, 1, 2, 2}; //0 = Revanchist, 1 = Scout and 2 = Goliath
                                                                         //There are higher odds for the random spawner to pick a 0 than a 1 or 2,
                                                                         //and higher chances to pick a 1 than a 2.
        
        StartCoroutine(delaySpawner());
        
    }



    void Update()
    {
        
        
    }


    IEnumerator delaySpawner()
    {
        yield return new WaitForSeconds(startDelay);
        
        while(!stop)
        {
            
            if(spawnMinRate >= 4)
            {
                
                spawnMaxRate = spawnMaxRate * sMaxM; //make enemies spawn slower or faster as the game goes on.
                spawnMinRate = spawnMinRate * sMinM; //make enemies spawn slower or faster as the game goes on.
                spawnRate = Random.Range(spawnMaxRate, spawnMinRate); //picks a random number and spawns the next enemy unit afer that many seconds.
                
            }
            int randomEnemyIndex = enemyIndexes[Random.Range(0, enemyIndexes.Count - 1)];


            //Debug.Log(randomEnemyIndex);

            Instantiate (enemies[randomEnemyIndex], new Vector3(10, Random.Range(minY, maxY), transform.position.z), enemies[randomEnemyIndex].transform.rotation); //picks a random enemy and spawns it 

            yield return new WaitForSeconds(spawnRate);
            
        }
    }
}
