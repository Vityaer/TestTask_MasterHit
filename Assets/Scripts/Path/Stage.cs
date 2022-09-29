using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Stage : MonoBehaviour
{
	[SerializeField] private Transform tr;
	[SerializeField] private List<EnemyScript> enemies = new List<EnemyScript>();

	//Getters
	public Transform Point{get => tr;}
	void Start()
	{
		foreach(EnemyScript enemy in enemies)
		{
			enemy.RegisterOnDeath(CheckFinish);
		}
	}

	private void CheckFinish()
	{
		bool existAliveEnemy = ( enemies.Find(x => (x.IsAlive == true)) != null );
		if(!existAliveEnemy)
		{
			OnFinishStage();
		}
	}

	private Action observerFinishStage;
	public void RegisterOnFinishStage(Action d){ observerFinishStage += d; }
	public void UnregisterOnFinishStage(Action d){ observerFinishStage -= d; }
	private void OnFinishStage()
	{
		if(observerFinishStage != null)
			observerFinishStage();
	}
}
