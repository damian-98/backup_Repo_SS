using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossA : MonoBehaviour
{
	public Vector3 attackOffset;
	public float attackRange = 1f;
	public GameObject gameover;
	public Animator animator;

	public void Attack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Heart.numOfHearts -= 1;
		Over();
	}

	public void EnragedAttack()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Heart.numOfHearts -= 1;
	}

	public void Over()
	{
		if (Heart.numOfHearts == 0)
		{
			StartCoroutine("GameOver");
		}
	}

	void OnDrawGizmosSelected()
	{
		Vector3 pos = transform.position;
		pos += transform.right * attackOffset.x;
		pos += transform.up * attackOffset.y;

		Gizmos.DrawWireSphere(pos, attackRange);
	}

	IEnumerator GameOver()
	{
		FindObjectOfType<AudioManager>().Play("PlayerDeath");
		FindObjectOfType<AudioManager>().Play("GameOver");
		animator.SetBool("Dead", true);
		yield return new WaitForSeconds(0.8f);
		gameover.SetActive(true);//SetActive true just enables the Game Over text.
		Time.timeScale = 0;
	}
}
