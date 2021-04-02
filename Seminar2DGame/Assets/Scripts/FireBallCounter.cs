using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireBallCounter : MonoBehaviour
{
	Text fireText;
	public static int fireAmount;

	void Start()
	{
		fireText = GetComponent<Text>();
	}

	void Update()
	{
		fireText.text = fireAmount.ToString("0");
	}
}
