using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPoolScript : MonoBehaviour
{
	private List<BulletScript> bullets = new List<BulletScript>();
	[SerializeField] private GameObject prefabBullet;

	public BulletScript GetBullet()
	{
		BulletScript result = bullets.Find(x => (x.IsActive == false) ); 
		if(result == null) result = CreateNewBullet();
		return result;
	}

	private BulletScript CreateNewBullet()
	{
		BulletScript newBullet = Instantiate(prefabBullet).GetComponent<BulletScript>();
		bullets.Add(newBullet);
		return newBullet;
	}

}