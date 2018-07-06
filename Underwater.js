#pragma strict
var waterLevel: float;
private var isUnderwater:boolean;
private var normalColor:Color;
private var underwaterColor:Color;
function Start () 
{
 normalColor = new Color(0.5f,0.5f,0.5f,0.5f);
 underwaterColor = new Color(0.22f,0.65f,0.77f,0.5f);
}

function Update ()
 {
  if(transform.position.y < waterLevel != isUnderwater)
  {
   isUnderwater = transform.position.y < waterLevel;
   if(isUnderwater)SetisUnderwater();
   if(!isUnderwater) Setnormal();
  }
}
function Setnormal()
{
 RenderSettings.fogColor= normalColor;
 RenderSettings.fogDensity= 0.002f;
}

function SetisUnderwater()
{
 RenderSettings.fogColor= underwaterColor;
 RenderSettings.fogDensity= 0.03f;
}