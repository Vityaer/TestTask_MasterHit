using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCanvasScript : MonoBehaviour{
	private Transform tr;
	void Awake()
	{
		tr = base.transform;
	}
    void LateUpdate()
    {
        tr.LookAt(Camera.main.transform, Vector3.down);
    }
}
