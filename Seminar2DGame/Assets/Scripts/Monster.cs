using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour {

private float timeBtwShots;
public float startTimeBtwShots;	

public GameObject projectile;

void Start()
{
	timeBtwShots = startTimeBtwShots;
}

void Update()
{
	if (timeBtwShots <= 0)
	{
		Instantiate(projectile, transform.position, Quaternion.identity);
		timeBtwShots = startTimeBtwShots;
		
	}else{

		timeBtwShots -= Time.deltaTime;

		}
	}
}
