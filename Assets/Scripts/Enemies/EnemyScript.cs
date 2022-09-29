using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EnemyScript : MonoBehaviour
{
	[SerializeField] private HPViewScript HPView;
	[SerializeField] private Characteristics characts;

	//Getters
	[SerializeField] public bool IsAlive{get => characts.IsAlive;}

	void Start()
	{
		HPView.SetMaxHP(characts.HP);
	}

	public void GetDamage(int damage)
	{
		Debug.Log("damage");
		characts.GetDamage(damage);
		HPView.SetCurrentHP(characts.HP);
		if(!characts.IsAlive)
		{
			OnDeath();
			gameObject.SetActive(false);
		}
	}

	private Action observerDeath;
	public void RegisterOnDeath(Action d){ observerDeath += d; }
	public void UnregisterOnDeath(Action d){ observerDeath -= d; }
	private void OnDeath()
	{
		if(observerDeath != null)
			observerDeath();
	}
}