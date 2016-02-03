using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VTaskAssignmentElement : MonoBehaviour {

	public Slider explorationSlider;
	public Slider defenseSlider;
	public Slider buildingSlider;
	public Slider researchSlider;

	public Text percentLeft;
	
	public void updateInfos(CPeople people){
		explorationSlider.value = people.ToExploration;
		defenseSlider.value = people.ToDefense;
		buildingSlider.value = people.ToBuilding;
		researchSlider.value = people.ToResearch;

		percentLeft.text = people.effectifLeft () + "%";
	}


}
