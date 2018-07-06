using UnityEngine;
using System.Collections;
public class EnemyAI: MonoBehaviour
{
	public Transform target;
	public int moveSpeed;
	public int turnSpeed;
	private GameObject enemy;

	void Awake()
	{
		enemy = GameObject.Find("enemy");
	}

	void Start()
{
		target= GameObject.FindGameObjectWithTag("Player").transform;
}

	void Update()
{
		transform.rotation = Quaternion.Slerp(transform.rotation,Quaternion.LookRotation(target.position - transform.position), turnSpeed * Time.deltaTime);
		if(Vector3.Distance(transform.position,target.position)> 0)
		{
			transform.position += transform.forward * moveSpeed *Time.deltaTime;
		}
}
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "amazon") {
			enemy.SetActive (false);
		}
	}
}