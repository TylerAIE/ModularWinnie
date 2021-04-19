using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryToggle : MonoBehaviour {

	public Text invText;

	void Awake ()
	{
		invText.gameObject.SetActive (false);
	}

	void Update ()
	{
		if (Input.GetKey(KeyCode.Tab))
		{
			invText.gameObject.SetActive (true);
		}

		if (Input.GetKeyUp(KeyCode.Tab))
		{
			invText.gameObject.SetActive (false);
		}
	}
}
