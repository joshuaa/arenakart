using UnityEngine;
using System.Collections;

public class MultiplayerManager : MonoBehaviour 
{
	public string thisKart;
	public string thisCharacter;

	public GameObject thisPlayer;

	void Awake()
	{
		DontDestroyOnLoad(transform.gameObject);
	}
}