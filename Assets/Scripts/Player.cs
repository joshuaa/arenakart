using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour 
{
	public AudioClip car2Clip;
	public AudioClip car3Clip;
	public AudioClip car4Clip;

	private AudioSource carNoise;

	private MultiplayerManager mm;
	public GameObject sprite;

	public bool inversedControlls = false;

	public string item = "bomb";
	public string kart = "kart";

	private float speed = 15;
	private float turn = 5;

	private float acceleration = 0;
	private bool accelerating = false;

	private bool waitingforRoad = false;

	void Start()
	{
		mm = GameObject.FindWithTag("MultiplayerManager").GetComponent<MultiplayerManager>();
		kart = mm.thisKart;
		carNoise = GetComponent<AudioSource>();
		if(kart == "kart")
		{
			sprite.renderer.material.mainTextureOffset = new Vector2(0,0);
			turn = 5;
			speed = 15;
			carNoise.clip = car2Clip;
			carNoise.loop = true;
			carNoise.Play();	
		}
		else if(kart == "dirtbike")
		{
			sprite.renderer.material.mainTextureOffset = new Vector2(0.03125f,0);
			turn = 7;
			speed = 20;
			carNoise.clip = car3Clip;
			carNoise.loop = true;
			carNoise.Play();
		}
		else if(kart == "tricycle")
		{
			sprite.renderer.material.mainTextureOffset = new Vector2((0.03125f)*2,0);
			turn = 5;
			speed = 12;
			carNoise.clip = car4Clip;
			carNoise.loop = true;
			carNoise.Play();
		}
	}

	void FixedUpdate()
	{
		carNoise = GetComponent<AudioSource>();
		moveCar ();
		if(Input.GetKeyDown(KeyCode.W))
			useItem();
	}

	void Update()
	{
		makeNoise();
	}

	void makeNoise()
	{
		//carNoise.pitch = (acceleration*speed*0.5f)+1;
		//carNoise.pan = transform.position.x/100;
		if(kart == "kart")
		{
			carNoise.pitch = (acceleration*speed*0.5f)+1;
			carNoise.pan = transform.position.x/100;	
		}
		else if(kart == "dirtbike")
		{
			carNoise.pitch = (acceleration*speed*0.25f)+1;
			carNoise.pan = transform.position.x/100;
		}
		else if(kart == "tricycle")
		{
			carNoise.pitch = (acceleration*speed*0.5f)+2;
			carNoise.pan = transform.position.x/100;

		}
	}

	void moveCar()
	{
		transform.Translate(0,acceleration*speed*Time.deltaTime,0);

		/***********************************************************
		* Okay, get ready for some ugly code. Basically, pressing D *
		* will turn your kart. Pressing A will make you turn it the *
		* opposite way. Pressing either button will accelerate your *
		* car. Accelerating makes your speed slowly increase over   *
		* time, until you're at your max speed. When you stop 		*
		* pressing either A or D you'll slow down (kinda slowly).   *
		* pressing S will make you stop much faster.                *
		************************************************************/

		if (!inversedControlls)
		{
			if (!Input.GetKey(KeyCode.S))
			{
				if (Input.GetKey(KeyCode.D))
				{
					accelerating = true;

					if (!Input.GetKey(KeyCode.A))
						transform.Rotate(0,0,-turn*acceleration);
				}

				if (Input.GetKey(KeyCode.A))
				{
					accelerating = true;

					if (!Input.GetKey(KeyCode.D))
						transform.Rotate(0,0,turn*acceleration);
				}

				if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
				{
					accelerating = false;
				}
			}
			else
			{
				accelerating = false;
			}
		}
		if (inversedControlls)
		{
			if (!Input.GetKey(KeyCode.S))
			{
				if (Input.GetKey(KeyCode.A))
				{
					accelerating = true;

					if (!Input.GetKey(KeyCode.D))
						transform.Rotate(0,0,-turn*acceleration);
				}

				if (Input.GetKey(KeyCode.D))
				{
					accelerating = true;

					if (!Input.GetKey(KeyCode.A))
						transform.Rotate(0,0,turn*acceleration);
				}

				if (!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
				{
					accelerating = false;
				}
			}
			else
			{
				accelerating = false;
			}
		}
		accelerationAmmount();
	}

	void accelerationAmmount()
	{
		if(!waitingforRoad)
		{
			if (accelerating && acceleration < 1)
			{
				acceleration += 0.01f;
			}
			else if (accelerating && acceleration > 1)
			{
				acceleration += 0.001f;
			}
			else if (acceleration > 0 && !Input.GetKey(KeyCode.S))
			{
				acceleration -= 0.01f;
			}
			else if (acceleration > 0 && Input.GetKey(KeyCode.S))
			{
				acceleration -= 0.03f;
			}
			else
			{
				acceleration = 0;
			}
		}
		else
		{
			acceleration = 0.25f;
		}

		
	}

	void useItem()
	{
		if(item == "bomb")
		{

		}
	}
}