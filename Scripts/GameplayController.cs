using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayController : MonoBehaviour
{

	public static GameplayController instance;

	[HideInInspector]
	public bool gamePlaying;

	[SerializeField]
	private GameObject tile;

	private Vector3 currentTilePosition;

	private AudioSource audioSource;

	[SerializeField]
	private Material tileMat;

	[SerializeField]
	private Light dayLight;

	private Camera mainCamera;

	private bool camColorLerp;

	private Color cameraColor;


	private float timer;
	private float timerInterval = 5f;

	private float camLerpTimer;
	private float camLerpInterval = 1f;

	private int direction = 1;

	void Awake()
	{
		MakeSingleton();
		audioSource = GetComponent<AudioSource>();

		currentTilePosition = new Vector3(-2, 0, 2);

		mainCamera = Camera.main;

		cameraColor = mainCamera.backgroundColor;

		// UNCOMMENT IT LATER
		
	}

	void Start()
	{
		for (int i = 0; i < 50; i++)
		{
			CreateTiles();
		}
	}

	void Update()
	{
		CheckLerpTimer();
	}

	void OnDisable()
	{
		instance = null;
		
	}

	void MakeSingleton()
	{
		if (instance == null)
		{
			instance = this;
		}
	}

	void CreateTiles()
	{
		Vector3 newTilePosition = currentTilePosition;
		int rand = Random.Range(0, 100);

		if (rand < 50)
		{
			newTilePosition.x -= 1f;
		}
		else
		{
			newTilePosition.z += 1f;
		}
		currentTilePosition = newTilePosition;
		Instantiate(tile, currentTilePosition, Quaternion.identity);
	}

	void CheckLerpTimer()
	{
		timer += Time.deltaTime;

		if (timer > timerInterval)
		{
			timer -= timerInterval;
			camColorLerp = true;
			camLerpTimer = 0f;
		}

		if (camColorLerp)
		{
			camLerpTimer += Time.deltaTime;
			float percent = camLerpTimer / camLerpInterval;

			if (direction == 1)
			{
				mainCamera.backgroundColor = Color.Lerp(cameraColor, Color.black, percent);
                dayLight.intensity = 1f - percent;
			}
			else
			{
				mainCamera.backgroundColor = Color.Lerp(Color.black, cameraColor, percent);
                dayLight.intensity = percent;
			}

			if (percent > 0.98f)
			{
				camLerpTimer = 1f;
				direction *= -1;
				camColorLerp = false;

				if (direction == -1)
				{
                }

			}

		}


	}

	public void ActiveTileSpawner()
	{
		StartCoroutine(SpawnNewTiles());
	}

	public void PlayCollectableSound()
	{
		audioSource.Play();
	}

	IEnumerator SpawnNewTiles()
	{
		yield return new WaitForSeconds(0.3f);
		CreateTiles();

		if (gamePlaying)
		{
			StartCoroutine(SpawnNewTiles());
		}
	}

} // class
