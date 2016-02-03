using UnityEngine;
using System.Collections;

public class VTaskAssignmentPanel : MonoBehaviour {

	public GameManager gameManager;

	public VTaskAssignmentElement childrenAssignment;
	
	public VTaskAssignmentElement adultsAssignment;
	
	public VTaskAssignmentElement oldsAssignment;

	public VSelectedTechnology selectedTechnology;

	void Start(){
		//gameManager.onConsumptionChange += updateSliders;
		gameManager.onTaskAssignmentChange += updateAssignment;
		gameManager.onTechnologyBarChange += updateTechnology;
	}

	public void updateAssignment(CPopulation pop){
		childrenAssignment.updateInfos (pop.children);
		adultsAssignment.updateInfos (pop.adults);
		oldsAssignment.updateInfos (pop.olds);
	}

	public void updateTechnology(Technology tech, CPopulation pop){
		if (tech != null)
			selectedTechnology.updateInfos (tech, pop);
		else
			selectedTechnology.updateToNull (pop);
	}



}
