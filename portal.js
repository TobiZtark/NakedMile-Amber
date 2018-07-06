#pragma strict
var spawnPoint:Transform [];
function Start () {

}

function Update () 
{

}
function OnTriggerEnter(man:Collider)
{
 if(man.GetComponent.<Collider>().tag=="Player")
 {
  
  var element:int = Random.Range (0,spawnPoint.length);
  man.transform.position= spawnPoint [element].position;
 }
 else {
 
 }
}