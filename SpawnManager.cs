using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour {

	public GameObject Target;
	public GameObject[] enemies;
	public int amount;
	private Vector3 spawnPoint;


	// Update is called once per frame
	void Update ()
	{
		enemies = GameObject.FindGameObjectsWithTag ("Enemy");
		amount = enemies.Length;

		if (amount != 15) {
			InvokeRepeating ("spawnEnemy", 5, 10f);
		}
	}
		void spawnEnemy()
		{
			spawnPoint.x = Random.Range (88,157);
			spawnPoint.y = 5.98f;
			spawnPoint.z = Random.Range (-604,24);

			Instantiate (enemies[UnityEngine.Random.Range(0,enemies.Length -1)], spawnPoint, Quaternion.identity);
			CancelInvoke();
		  if (Target== false)
		{
			return;
		}
		}
}
