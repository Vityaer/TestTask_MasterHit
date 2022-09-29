using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HelpFuction;

public class BulletScript : MonoBehaviour
{
	private Rigidbody rb;
	private float timeFly  = 10f;
	[SerializeField] private float speed = 10f;
	private Transform tr;
    private TimerScript Timer;
    private GameTimer timer = null;
    private bool isActive = false;
    [SerializeField] private int damage;

    //Getters
    public bool IsActive{ get => isActive; }
	void Awake()
	{
		tr = base.transform;
		rb = GetComponent<Rigidbody>();
	}

	public void Active(Vector3 startPosition, Vector3 targetPosition)
	{
		gameObject.SetActive(true);
		Vector3 direction = targetPosition - startPosition;
		direction.Normalize();
		tr.position = startPosition;
		tr.LookAt(targetPosition);
		rb.velocity = direction * speed;
		timer = TimerScript.Timer.StartTimer(timeFly, Disable);
		isActive = true;
	}
	public void Disable()
	{
		TimerScript.Timer.StopTimer(timer);
		isActive = false;
		rb.velocity = Vector3.zero;
		gameObject.SetActive(false);
	}

	void OnTriggerEnter(Collider other)
	{
		if(isActive)
		{
			isActive = false;
	        if(other.gameObject.CompareTag("Enemy"))
	        {
	        	other.gameObject.GetComponent<EnemyScript>()?.GetDamage(damage);
	        	Disable();
	        }else 
			if(other.gameObject.CompareTag("Terrain"))
			{
				Disable();
			}
	    }
	}
}
