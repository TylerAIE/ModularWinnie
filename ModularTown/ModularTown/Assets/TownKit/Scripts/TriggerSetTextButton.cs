using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerSetTextButton : MonoBehaviour {

	public Text questTextObject;
	public string questText;
	public bool onceOnly;
	public float waitTime;
	public float displayTime;

	private bool inTrigger;

	public bool itemRequired;
	public string inventoryItem;

	private GameObject inventoryObject;
	private Inventory inv;

	private bool doTheThing;

	void Start()
	{
		inventoryObject = GameObject.FindGameObjectWithTag ("Inventory");
		inv = inventoryObject.GetComponent<Inventory> ();
	}

	private bool CheckInventory()
	{
		for (int i = 0; i < inv.inventoryItems.Count; i++)
		{
			if (inv.inventoryItems[i] == inventoryItem)
				return true;
		}
		return false;
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.E))
		{
			if (inTrigger == true)
			{
				StartCoroutine (WaitTimer ());
			}
		}
	}

	void OnTriggerStay (Collider other)
	{
		if (other.tag == "Player")
			inTrigger = true;
	}

	void OnTriggerExit (Collider other)
	{
		inTrigger = false;
	}

	IEnumerator WaitTimer()
	{
		yield return new WaitForSeconds (waitTime);

		if (itemRequired == true)
		{
			if (CheckInventory () == true)
				doTheThing = true;	
			else
				doTheThing = false;	
		}
		else
			doTheThing = true;	


		if (doTheThing == true)
		{
			questTextObject.gameObject.transform.parent.gameObject.SetActive (true);
			questTextObject.text = questText;

			yield return new WaitForSeconds (displayTime);

			questTextObject.text = "";
			questTextObject.gameObject.transform.parent.gameObject.SetActive (false);

			if (onceOnly == true)
			{
				gameObject.SetActive (false);
			}
		}
	}
}
