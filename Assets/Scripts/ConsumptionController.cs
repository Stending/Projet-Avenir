using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ConsumptionController : MonoBehaviour {

	public GameManager gameManager;
	
	public void setChildrenFood(float value){
		gameManager.changeConsumption(value/5,  "children", "food");
	}
	public void setChildrenWater(float value){
		gameManager.changeConsumption(value/5,  "children", "water");
	}

	public void setAdultsFood(float value){
		gameManager.changeConsumption(value/5,  "adults", "food");
	}
	public void setAdultsWater(float value){
		gameManager.changeConsumption(value/5,  "adults", "water");
	}

	public void setOldsFood(float value){
		gameManager.changeConsumption(value/5,  "olds", "food");
	}
	public void setOldsWater(float value){
		gameManager.changeConsumption(value/5,  "olds", "water");
	}
}
