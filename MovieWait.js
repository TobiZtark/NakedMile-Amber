#pragma strict

function Start () {
 WaitforSec();
}

function WaitforSec()
	{
		yield WaitForSeconds(158);
		{
		Application.LoadLevel(Application.loadedLevel+ 1);
		}
	}

