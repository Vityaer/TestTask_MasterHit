using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameUIScript : MonoBehaviour
{
	[SerializeField] private GameObject UIStartCanvas;
	[SerializeField] private PlayerScript player;
	public void StartGame()
	{
		UIStartCanvas.SetActive(false);
		player.StartGame();
	}
	public void StartRestartLevel()
	{
        StartCoroutine(RestartLevel());
	}
    IEnumerator RestartLevel()
    {
        yield return new WaitForSeconds(1f); 
        FadeInOut.Instance.RestartLevel();

    }
	private static GameUIScript instance;
	public static GameUIScript Instance{get => instance;}
	void Awake()
	{
		instance = this;
	}
}
