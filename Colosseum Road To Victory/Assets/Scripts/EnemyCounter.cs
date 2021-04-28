using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyCounter : MonoBehaviour
{
   	Text enemyText;
	public static int enemyAmount;

	void Start()
	{
		enemyText = GetComponent<Text>();
	}

	void Update()
	{
		enemyText.text = enemyAmount.ToString("0");
	}
}
