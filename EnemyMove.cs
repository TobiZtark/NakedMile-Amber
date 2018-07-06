using UnityEngine;
using System.Collections;

public class EnemyMove : MonoBehaviour {


	public Transform player;
	private float moveSpeed = 4;


	// Update is called once per frame
	void Update () 
	{
		float move = moveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards (transform.position, player.position, move);

		if (player == false)
		{
			return;
		}
	}


	void OnTriggerEnter(Collider other)
{
		if (other.name == "Amber") 
		{
			Debug.Log("Contact");
		}
}
}
     