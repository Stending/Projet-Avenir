using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VPeoplePanel : MonoBehaviour {

	public GameManager gameManager = null;
	
	public Text childrenText;
	public Text adultsText;
	public Text oldsText;

	public Text totalPopText;

	public Text cToAText;
	public Text aToOText;
	public Text oToDText;
	
	void Start(){
		gameManager.onPopulationChange += updatePopulation;
	}

	public void updatePopulation(CPopulation pop){
		childrenText.text = pop.children.population.ToString ();
		adultsText.text = pop.adults.population.ToString ();
		oldsText.text = pop.olds.population.ToString ();

		totalPopText.text = "Total : " + pop.totalPopulation ().ToString();

		cToAText.text = pop.childrenToAdults ().ToString();
		aToOText.text = pop.adultsToOlds ().ToString();
		oToDText.text = pop.oldsToDeath ().ToString();
	}
}
