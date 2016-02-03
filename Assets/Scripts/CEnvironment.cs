using UnityEngine;
using System.Collections;
[System.Serializable]

public class CEnvironment {

	public Vector2 foodCoef;
	public Vector2 waterCoef;
	public Vector2 materialCoef;
	public Vector2 electronicCoef;

	public Vector2 peopleLostCoef;
	public Vector2 peopleFoundCoef;


	public Vector2 calculateFoodProba(int exploValue){
		return new Vector2 (Mathf.Round(exploValue * foodCoef.x), Mathf.Round(exploValue * foodCoef.y));
	}

	
	public Vector2 calculateWaterProba(int exploValue){
		return new Vector2 (Mathf.Round(exploValue * waterCoef.x), Mathf.Round(exploValue * waterCoef.y));
	}

	public Vector2 calculateMaterialProba(int exploValue){
		return new Vector2 (Mathf.Round(exploValue * materialCoef.x), Mathf.Round(exploValue * materialCoef.y));
	}

	public Vector2 calculateElectronicProba(int exploValue){
		return new Vector2 (Mathf.Round(exploValue * electronicCoef.x), Mathf.Round(exploValue * electronicCoef.y));
	}

	public Vector2 calculatePeopleFoundProba(int exploValue){
		return new Vector2 (Mathf.Round(exploValue * peopleFoundCoef.x), Mathf.Round(exploValue * peopleFoundCoef.y));
	}
	
	public Vector2 calculatePeopleLostProba(int exploValue){
		return new Vector2 (Mathf.Round(exploValue * peopleLostCoef.x), Mathf.Round(exploValue * peopleLostCoef.y));
	}

}
