using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunScript : MonoBehaviour
{
	[SerializeField] private Transform pointStartGunBurrel;
	[SerializeField] private BulletPoolScript bulletPool; 
	void Update(){
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Input.GetMouseButtonDown(0)){
	        if (Physics.Raycast(ray, out hit)){
                bulletPool.GetBullet().Active(pointStartGunBurrel.position, hit.point);
            }
        }
    }
}
