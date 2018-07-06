using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class PlayerScript: MonoBehaviour
{
	public RectTransform healthTransform;
	private float cachedY;
	private float minXValue;
	private float maxXValue;
	private int currentHealth;

	private int CurrentHealth
	{
		get{ return currentHealth;}
		set{ currentHealth = value;
		     HandleHealthBar();
			}
	}
	public int maxHealth;
	public Text healthText;
	//public Text itemText;

	public Image visualHealth;
	public float coolDown;
	private bool onCD;
	public AudioSource clickAudio;
	private GameObject HealthCanvas,GOCanvas,NLCanvas,ItemCanvas;
	private GameObject Amber;

	void Awake()
	{
		HealthCanvas= GameObject.Find("HealthCanvas");
		GOCanvas= GameObject.Find("GOCanvas");
		NLCanvas= GameObject.Find("NLCanvas");
		Amber =GameObject.Find("Amber");
		ItemCanvas= GameObject.Find("ItemCanvas");
	}

	void Start()
	{
		cachedY = healthTransform.position.y;
		maxXValue = healthTransform.position.x;
		minXValue = healthTransform.position.x - healthTransform.rect.width;
		currentHealth = maxHealth;
		onCD = false;
		HealthCanvas.SetActive (true);
		GOCanvas.SetActive(false);
		NLCanvas.SetActive(false);
		Amber.SetActive (true);
		ItemCanvas.SetActive(true);
	}

	void Update()
	{
		if (currentHealth <= 0)
		{
			Amber.SetActive (true);
			HealthCanvas.SetActive (false);
			GOCanvas.SetActive(true);
			NLCanvas.SetActive(false);
			ItemCanvas.SetActive(true);
			Time.timeScale = 0f;
			//RestartLevel();

		}
	}
	private void HandleHealthBar()
	{
		healthText.text = "Health: " + currentHealth;
		float currentXValue = MapValues (currentHealth, 0, maxHealth, minXValue, maxXValue);
		healthTransform.position = new Vector3(currentXValue, cachedY);
		if (currentHealth > maxHealth/2)
		{
			visualHealth.color = new Color32((byte)MapValues(currentHealth,maxHealth/2,maxHealth,255,0),255,0,255);
		}
		else
		{
			visualHealth.color = new Color32(255,(byte)MapValues(currentHealth,0,maxHealth/2,0,255),0,255);
		}
	}
	IEnumerator CoolDownDmg()
	{
		onCD = true;
		yield return new WaitForSeconds(coolDown);
		onCD = false;
	}

	void OnTriggerStay(Collider other)
	{
		if (other.tag == "Enemy") {
			if (!onCD && currentHealth > 0) {
				StartCoroutine (CoolDownDmg ());
				CurrentHealth -= 10;
			}
		}
		if (other.name == "pickups") {
			if (!onCD && currentHealth < maxHealth) {
				StartCoroutine (CoolDownDmg ());
				CurrentHealth += 10;
			}
		}
		if (other.name == "amazon") {
			if (currentHealth > 0) {
				if ((other.tag == "Pick") == false) {
					HealthCanvas.SetActive (false);
					GOCanvas.SetActive (false);
					NLCanvas.SetActive (true);
					Amber.SetActive (true);
					clickAudio.Play ();
				}

			}

		}
	}

	private float MapValues(float x, float inMin, float inMax, float outMin, float outMax)
	{
		return (x-inMin) * (outMax-outMin)/ (inMax-inMin)+ outMin;
	}


	//public void RestartLevel ()
	//{
		//Application.LoadLevel (Application.loadedLevel);
	//}

}