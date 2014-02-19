using UnityEngine;
using System.Collections;

public class ItemBox : MonoBehaviour 
{
	public GameObject box;
	public Color color1 = Color.red;
	public Color color2 = Color.blue;

	public float spinspeed = 10;
	public float floatspeed = 10;

	public int maxX = 10;
	public int maxY = 10;

	void Update()
	{
		float colorTime = Mathf.PingPong(Time.time, 1);

		box.transform.localPosition = new Vector3(0, Mathf.PingPong(Time.time*floatspeed, maxY), 0);
		box.transform.Rotate(0,floatspeed*Time.deltaTime*100, 0);
		box.renderer.material.color = Color.Lerp(color1,color2,colorTime);

		

	}
}