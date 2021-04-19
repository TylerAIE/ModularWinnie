using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTeleport : MonoBehaviour {

	public GameObject teleportObject;
	public GameObject teleportLocation;
	public float waitTime;

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

	void OnTriggerEnter (Collider other)
	{
		StartCoroutine (WaitTimer (other));
	}

	IEnumerator WaitTimer(Collider other)
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
			if (other.tag == "Player")
			{
				teleportObject.transform.position = teleportLocation.transform.position;
			}
		}
	}
}
