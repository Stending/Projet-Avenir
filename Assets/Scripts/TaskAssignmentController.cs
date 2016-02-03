using UnityEngine;
using System.Collections;

public class TaskAssignmentController : MonoBehaviour {

	public GameManager gameManager;

	public void setChildrenExploration(float value){
		gameManager.changeTaskAssignment(value,  "children", "exploration");
	}

	public void setChildrenDefense(float value){
		gameManager.changeTaskAssignment(value,  "children", "defense");
	}

	public void setChildrenBuilding(float value){
		gameManager.changeTaskAssignment(value,  "children", "building");
	}

	public void setChildrenResearch(float value){
		gameManager.changeTaskAssignment(value,  "children", "research");
	}

	//------------

	public void setAdultsExploration(float value){
		gameManager.changeTaskAssignment(value,  "adults", "exploration");
	}
	
	public void setAdultsDefense(float value){
		gameManager.changeTaskAssignment(value,  "adults", "defense");
	}
	
	public void setAdultsBuilding(float value){
		gameManager.changeTaskAssignment(value,  "adults", "building");
	}
	
	public void setAdultsResearch(float value){
		gameManager.changeTaskAssignment(value,  "adults", "research");
	}

	//-----------

	public void setOldsExploration(float value){
		gameManager.changeTaskAssignment(value,  "olds", "exploration");
	}
	
	public void setOldsDefense(float value){
		gameManager.changeTaskAssignment(value,  "olds", "defense");
	}
	
	public void setOldsBuilding(float value){
		gameManager.changeTaskAssignment(value,  "olds", "building");
	}
	
	public void setOldsResearch(float value){
		gameManager.changeTaskAssignment(value,  "olds", "research");
	}



}
