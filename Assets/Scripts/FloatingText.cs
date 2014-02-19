using UnityEngine;
using System.Collections;

public class FloatingText : MonoBehaviour 
{
	public GUIText normalText;
	public GUIText floatingText;

	public int maxX = 10;
	public int maxY = 10;

	public float speed = 10;

	void Update()
	{
		floatingText.pixelOffset = new Vector2(Mathf.PingPong(Time.time*speed, maxX), Mathf.PingPong(Time.time*speed, maxY));
	}
}