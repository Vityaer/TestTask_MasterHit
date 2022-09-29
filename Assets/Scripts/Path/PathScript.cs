using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PathScript : MonoBehaviour
{
    [SerializeField] private List<Stage> stages = new List<Stage>();
    [SerializeField] private Transform startPoint, finishPoint;
    private int currentNumPoint = 0;
    private bool isFinish = false;
    //Getter
    public bool IsFinish{ get => isFinish;}
    public Transform GetStartPoint { get => startPoint; }
    public Transform GetFinishPoint { get => finishPoint; }
    
    void Start()
    {
    	foreach(Stage stage in stages)
    	{
    		stage.RegisterOnFinishStage(OnFinishStage);
    	}
    }

    public Transform GetNextPoint()
    {
    	currentNumPoint += 1;
    	isFinish = (currentNumPoint == (stages.Count - 1) );
    	return stages[currentNumPoint].Point;
    }

    private void OnFinishStage()
    {
    	if(observerFinishStage != null)
    		observerFinishStage();
    }
	private void OnFinishPath()
	{
		if(observerFinishPath != null)
			observerFinishPath();
	}


    private Action observerFinishPath, observerFinishStage;
	public void RegisterOnPathFinish(Action d){ observerFinishPath += d; }
	public void UnregisterOnPathFinish(Action d){ observerFinishPath -= d; }

	public void RegisterOnStageFinish(Action d){ observerFinishStage += d; }
	public void UnregisterOnStageFinish(Action d){ observerFinishStage -= d; }

}
