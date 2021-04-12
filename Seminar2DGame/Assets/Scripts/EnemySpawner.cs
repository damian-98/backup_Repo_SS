/*  
	#
	# 1: Title: "How to Spawn Monsters Randomly from different Spawn Points and Make them Follow the Player in Unity." | Author: Alexander Zotov | Source: https://www.youtube.com/watch?v=q1gAtOWTs-o&list=WL&index=181&t=125s | Date retrieved: 4/9/2021 @ 1:30pm
    #
*/

// #1: ####################################################################################################################################################

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{

    public Transform[] spawnPoints; //Array of Spawn Points
    public GameObject[] enemyPrefabs; //Array of enemies
    int randomSpawn, randomEnemy; // vairables
    public static bool spawnAllowed; // bool for spawnAllowed to
                                     //instantiate only if player is alive
    public int numberOfEnemiesToKillToWin = 2;                                        

    void Start()
    {
        spawnAllowed = true;
        InvokeRepeating("SpawnAEnemy", 0f, 15f); //Instantiate enemy respawn by 15 sec
                                                 //by Invoking SpawnAEnemy method
    }


    /*
	This if statment is saying if (spawnAllowed)
	then randomEnemy will calulate range from 0 to enemy array length
	also exact same thing with randomSpawn. Then new randomEnemy will instantiate
	in new randomSpawn postion. Also Quaternion.identity means no rotaion that the object
	is perfectly aligned with the world or parent axes.
	*/
    void SpawnAEnemy()
    {
        if (spawnAllowed)
        {

            randomEnemy = Random.Range(0, enemyPrefabs.Length);
            randomSpawn = Random.Range(0, spawnPoints.Length);

            Instantiate(enemyPrefabs[randomEnemy], spawnPoints[randomSpawn].position, Quaternion.identity);
        }
    }

    public int GetnumberOfEnemies()
    {
        return numberOfEnemiesToKillToWin;
    }
}
// #1: ####################################################################################################################################################
