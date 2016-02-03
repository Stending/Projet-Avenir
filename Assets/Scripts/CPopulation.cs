using UnityEngine;
using System.Collections;
[System.Serializable]

public class CPopulation {

	public CPeople children;
	public CPeople adults;
	public CPeople olds;

	public float cToABaseRatio = 1.0f; //Children to Adults
	public float aToOBaseRatio = 1.0f; //Adults to Olds
	public float oToDBaseRatio = 1.0f; //Olds to Death

	public float cToARatioCoef = 0f; //Children to Adults
	public float aToORatioCoef = 0f; //Adults to Olds
	public float oToDRatioCoef = 0f; //Olds to Death

	public CPopulation(){
		children = new CPeople (0.5f, 0.5f, 2.0f, 0.5f, 0.1f, 0.3f);
		adults = new CPeople (2.0f, 1.0f, 2.0f, 3.0f, 2.0f, 1.0f);
		olds = new CPeople (1.0f, 1.5f, 0.3f, 1.5f, 0.5f, 3.0f);
	}

	public void RegulateAlimentation(CResources res){
		while (isAlimentationProblem(res)) {

			if (isFoodAlimentationProblem (res)) {
				children.foodRatio -= 0.2f;
				if (children.foodRatio < 0)
					children.foodRatio = 0;

				if (isFoodAlimentationProblem (res)) {
					adults.foodRatio -= 0.2f;
					if (adults.foodRatio < 0)
						adults.foodRatio = 0;

					if (isFoodAlimentationProblem (res)) {
						olds.foodRatio -= 0.2f;
						if (olds.foodRatio < 0)
							olds.foodRatio = 0;
					}
				}
			}


			if (isWaterAlimentationProblem (res)) {
				children.waterRatio -= 0.2f;
				if (children.waterRatio < 0)
					children.waterRatio = 0;
				
				if (isWaterAlimentationProblem (res)) {
					adults.waterRatio -= 0.2f;
					if (adults.waterRatio < 0)
						adults.waterRatio = 0;
					
					if (isWaterAlimentationProblem (res)) {
						olds.waterRatio -= 0.2f;
						if (olds.waterRatio < 0)
							olds.waterRatio = 0;
					}
				}
			}


		}
	}
	public int TotalExplorationValue{
		get{
			return children.ExplorationValue + adults.ExplorationValue + olds.ExplorationValue;
		}
		set{ ;}
	}

	public int totalPopulation(){
		return children.population + adults.population + olds.population;
	}
	

	public void AlimentationChange(){
		children.population += childrenVariation ();
		adults.population += adultsVariation ();
		olds.population += oldsVariation ();
	}

	public void Grow(){
		int o = oldsToDeath ();
		olds.population -= o;

		int a = adultsToOlds ();
		adults.population -= a;
		olds.population += a;

		int c = childrenToAdults ();
		children.population -= c;
		adults.population += c;
	}

	public int TotalTechnologyPointToGet{
		get{ return children.TechnologyPoint + adults.TechnologyPoint + olds.TechnologyPoint;}
	}

	public int childrenVariation(){
		int num = -children.peopleToDie ();
		num += adults.childrenToBorn ();
		return num;
	}

	public int adultsVariation(){
		int num = -adults.peopleToDie ();
		return num;
	}

	public int oldsVariation(){
		int num = -olds.peopleToDie ();
		return num;
	}
	
	public int childrenToAdults(){
		return (int)(children.population * ((cToABaseRatio*cToARatioCoef) / 100.0f));
	}

	public int adultsToOlds(){
		return (int)(adults.population * ((aToOBaseRatio*aToORatioCoef)/ 100.0f));
	}

	public int oldsToDeath(){
		return (int)(olds.population * ((oToDBaseRatio*oToDRatioCoef)/ 100.0f));
	}

	public int totalFoodConsumption(){
		return children.foodNeeded () + adults.foodNeeded () + olds.foodNeeded ();
	}

	public int totalWaterConsumption(){
		return children.waterNeeded () + adults.waterNeeded () + olds.waterNeeded ();
	}


	public bool isAlimentationProblem(CResources res){
		return isFoodAlimentationProblem (res) || isWaterAlimentationProblem (res);
	}

	public bool isFoodAlimentationProblem(CResources res){
		return ((children.foodNeeded () + adults.foodNeeded () + olds.foodNeeded ()) > res.food);
	}

	public bool isWaterAlimentationProblem(CResources res){
		return ((children.waterNeeded () + adults.waterNeeded () + olds.waterNeeded ()) > res.water);
	}
}
