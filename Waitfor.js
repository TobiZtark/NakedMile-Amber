#pragma strict

function Start () {
 WaitforSec();
}

function WaitforSec()
	{
		yield WaitForSeconds(5);
		{
		Application.LoadLevel(Application.loadedLevel+ 1);
		}
	}

