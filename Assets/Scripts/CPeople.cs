using UnityEngine;
using System.Collections;
[System.Serializable]

public class CPeople {

	public int population;

	public int toExploration = 0;
	public int toBuilding = 0;
	public int toDefense = 0;
	public int toResearch = 0;


	public float explorationCoef = 0;
	public float buildingCoef = 0;
	public float defenseCoef = 0;
	public float researchCoef = 0;

	public float foodCons = 0;
	public float waterCons = 0;

	public float foodRatio = 0;
	public float waterRatio = 0;

	public float foodDeathRatio = 0.75f;
	public float waterDeathRatio = 0.33f;

	public float reproductionCoef = 0.0f;

	public CPeople(float fCons, float wCons, float eCoef, float bCoef, float dCoef, float rsCoef){
		this.foodCons = fCons;
		this.waterCons = wCons;

		this.explorationCoef = eCoef;
		this.buildingCoef = bCoef;
		this.defenseCoef = dCoef;
		this.researchCoef = rsCoef;
	}

	public int foodNeeded(){
		return (int)(population * foodCons * foodRatio);
	}
	public int waterNeeded(){
		return (int)(population * waterCons * waterRatio);
	}

	public int peopleToDie(){
		int numToDie = 0;
		numToDie += peopleToDieBecauseOfFood();
		numToDie += peopleToDieBecauseOfWater();
		

		return numToDie;
	}

	private int peopleToDieBecauseOfFood (){
		if (foodRatio < 1)
			return (int)(((((1 - foodRatio) * foodDeathRatio)) * population));
		else
			return 0;
	}

	private int peopleToDieBecauseOfWater(){
		if(waterRatio < 1)
			return (int)(((((1-waterRatio) * waterDeathRatio)) * (population-peopleToDieBecauseOfFood())));
		else
			return 0;
	}
	public int childrenToBorn(){
		int numToBorn = 0; 
		if (foodRatio > 1) {
			numToBorn += (int)(((((foodRatio-1) * reproductionCoef)) * population));
		}
		return numToBorn;
	}

	public int effectifLeft(){
		return (100 - toExploration - toDefense - toBuilding - toResearch);
	}

	public int effectifTotal(){
		return (toExploration + toDefense + toBuilding + toResearch);
	}

	public int TechnologyPoint{
		get{ return (int)((int)(population * ((float)toResearch/100.0f)) * researchCoef);}
	}

	public int ToExploration {
		get {
			return this.toExploration;
		}
		set {
			if((effectifTotal() - toExploration + value <= 100))
				toExploration = value;
			else
				toExploration += effectifLeft();
		}
	}

	public int ToDefense {
		get {
			return this.toDefense;
		}
		set {
			if((effectifTotal() - toDefense + value <= 100))
				toDefense = value;
			else
				toDefense += effectifLeft();
		}
	}

	public int ToBuilding {
		get {
			return this.toBuilding;
		}
		set {
			if((effectifTotal() - toBuilding + value <= 100))
				toBuilding = value;
			else
				toBuilding += effectifLeft();
		}
	}

	public int ToResearch {
		get {
			return this.toResearch;
		}
		set {
			if((effectifTotal() - toResearch + value <= 100))
				toResearch = value;
			else
				toResearch += effectifLeft();
		}
	}


	public int PeopleToExploration{
		get {
			return (int)(((float)population / 100) * ToExploration);
		}
		set{;}
	}


	public int ExplorationValue{
		get{
			return (int)(PeopleToExploration*explorationCoef);
		}
		set{ ;}
	}
}
