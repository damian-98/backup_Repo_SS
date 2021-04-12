using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFireball : MonoBehaviour {

	public float speed;

	private Transform Player;
	private Vector2 target;

	void Start()
	{
		Player = GameObject.FindGameObjectWithTag("Player").transform;

		target = new Vector2(Player.position.x, Player.position.y);
	}

	void Update()
	{
		transform.position = Vector2.MoveTowards(transform.position,target, speed * Time.deltaTime);
		
		if(transform.position.x == target.x && transform.position.y == target.y)
		{
			DestroyProjectile();
		}
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.CompareTag("Player"))
		{
			DestroyProjectile();
		}
	}

	void DestroyProjectile()
	{
		Destroy(gameObject);
	}
}