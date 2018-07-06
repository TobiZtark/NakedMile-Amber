#pragma strict


var OBCanvas: GameObject;

function Awake()
{
	OBCanvas=GameObject.Find("OBCanvas");
}
function Start () {
OBCanvas.SetActive(true);
 WaitforObj();

}

function WaitforObj()
	{
		yield WaitForSeconds(5);
		{
		OBCanvas.SetActive(false);
		
		}
	}

