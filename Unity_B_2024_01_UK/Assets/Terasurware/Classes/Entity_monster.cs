using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Entity_monster : ScriptableObject
{	
	public List<Sheet> sheets = new List<Sheet> ();

	[System.SerializableAttribute]
	public class Sheet
	{
		public string name = string.Empty;
		public List<Param> list = new List<Param>();
	}

	[System.SerializableAttribute]
	public class Param
	{
		
		public double index;
		public double hp;
		public double mp;
		public string name;
	}
}

