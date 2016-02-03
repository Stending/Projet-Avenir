using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VExplorationPrevisionPanel : MonoBehaviour {

	public GameManager gameManager;

	public Text foodPrevisionText;
	public Text waterPrevisionText;
	public Text materialPrevisionText;
	public Text electronicPrevisionText;

	public Text peopleFoundPrevisionText;
	public Text peopleLostPrevisionText;


	void Start(){
		gameManager.onExplorationChange += updatePrevision;
	}

	public void updatePrevision(CPopulation pop, CEnvironment env){
		Vector2 foodProbs = env.calculateFoodProba (pop.TotalExplorationValue);
		Vector2 waterProbs = env.calculateWaterProba (pop.TotalExplorationValue);
		Vector2 materialProbs = env.calculateMaterialProba (pop.TotalExplorationValue);
		Vector2 electronicProbs = env.calculateElectronicProba (pop.TotalExplorationValue);
		Vector2 peopleFoundProbs = env.calculatePeopleFoundProba (pop.TotalExplorationValue);
		Vector2 peopleLostProbs = env.calculatePeopleLostProba (pop.TotalExplorationValue);

		foodPrevisionText.text = "+ " + foodProbs.x + "-" + foodProbs.y;
		waterPrevisionText.text = "+ " + waterProbs.x + "-" + waterProbs.y;
		materialPrevisionText.text = "+ " + materialProbs.x + "-" + materialProbs.y;
		electronicPrevisionText.text = "+ " + electronicProbs.x + "-" + electronicProbs.y;

		peopleFoundPrevisionText.text = "+ " + peopleFoundProbs.x + "-" + peopleFoundProbs.y;
		peopleLostPrevisionText.text = "+ " + peopleLostProbs.x + "-" + peopleLostProbs.y;



	}

}
