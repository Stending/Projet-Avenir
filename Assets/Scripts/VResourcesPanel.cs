using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VResourcesPanel : MonoBehaviour {

	public GameManager gameManager = null;
	
	public Text foodText;
	public Text waterText;
	public Text materialsText;
	public Text electronicsText;

	public Text foodPrevisionText;
	public Text waterPrevisionText;
	public Text materialsPrevisionText;
	public Text electronicsPrevisionText;
	
	void Start(){
		gameManager.onResourcesChange += updateResources;		

	}
	
	public void updateResources(CResources res, CPopulation pop){
		foodText.text = res.food.ToString ();
		waterText.text = res.water.ToString ();
		materialsText.text = res.materials.ToString ();
		electronicsText.text = res.electronics.ToString ();

		foodPrevisionText.text = ViewHelp.numberWithSign (-pop.totalFoodConsumption ());
		waterPrevisionText.text = ViewHelp.numberWithSign (-pop.totalWaterConsumption ());


	}
	

}
