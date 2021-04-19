using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public Text inventoryText;

	[HideInInspector]
	public List<string> inventoryItems = new List<string>(); 

	private string tempText;

	void Start ()
	{
		inventoryItems.Add ("Hat");	
	}

	void Update ()
	{
		tempText = "";

		for (int i = 0; i < inventoryItems.Count; i++)
		{
			tempText += inventoryItems [i] + "\n";
		}

		inventoryText.text = tempText;
	}
}
