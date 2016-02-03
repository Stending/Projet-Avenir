using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VConsumptionPanel : MonoBehaviour {

	public GameManager gameManager;

	public VConsumptionElement childrenConsumption;

	public VConsumptionElement adultsConsumption;

	public VConsumptionElement oldsConsumption;
	
	void Start(){
		//gameManager.onConsumptionChange += updateSliders;
		gameManager.onConsumptionChange += updateConsumption;
	}



	public void updateConsumption(CPopulation pop){
		childrenConsumption.previsions.popVariation.text = ViewHelp.numberWithSign (pop.childrenVariation ());
		adultsConsumption.previsions.popVariation.text = ViewHelp.numberWithSign (pop.adultsVariation ());
		oldsConsumption.previsions.popVariation.text = ViewHelp.numberWithSign (pop.oldsVariation ());

		childrenConsumption.updateInfos (pop.children);
		adultsConsumption.updateInfos (pop.adults);
		oldsConsumption.updateInfos (pop.olds);
		
	}



}
