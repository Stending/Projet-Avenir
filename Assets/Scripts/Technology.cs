using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Technology : MonoBehaviour {
	public string name = "Technolgy";
	public string code;

	public List<Technology> prerequired = new List<Technology>();

	public int valueNeeded = 100;
	public int value = 0;


	public bool IsLearned{
		get {
			return value >= valueNeeded;
		}
		set{ ;}
	}

	public int Value {
		get{ return this.value;}
		set { 
			if (value > valueNeeded)
				this.value = valueNeeded;
			else
				this.value = value;
		}
	}

	public bool IsUnlocked{
		get {
			foreach(Technology tech in prerequired){

				if(!tech.IsLearned){
					return false;
				}
			}

			return true;
		}
		set{ ;}
	}
}
