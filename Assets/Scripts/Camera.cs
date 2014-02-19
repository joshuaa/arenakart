using UnityEngine;
using System.Collections;

public class Camera : MonoBehaviour 
{
	private GameObject player;
	public GameObject blackScreen;
	public float slide = 25;

	void Start ()
	{
		player = GameObject.FindWithTag("Player");
		blackScreen.renderer.material.color = Color.black;
		audio.Play();
		audio.Play();
	}

	void FixedUpdate()
	{
		float endSize = 3*Mathf.Abs(Mathf.Sqrt(Mathf.Pow(player.transform.position.x, 2)+ Mathf.Pow(player.transform.position.y, 2)))/4;
		endSize = Mathf.Clamp(endSize, 10, 20);
		transform.position = new Vector3((player.transform.position.x + 0)/2,(player.transform.position.y + 0)/2,-10);
		//camera.orthographicSize = 3*Mathf.Abs(Mathf.Sqrt(Mathf.Pow(player.transform.position.x, 2)+ Mathf.Pow(player.transform.position.y, 2)))/4;
		//camera.orthographicSize = Mathf.Clamp(camera.orthographicSize, 10, 30);
		camera.orthographicSize += (endSize - camera.orthographicSize)/slide;

		blackScreen.renderer.material.color = Color.Lerp(Color.black, new Color(0,0,0,0), Time.time);
	}
}