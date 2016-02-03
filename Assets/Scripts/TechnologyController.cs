using UnityEngine;
using System.Collections;

public class TechnologyController : MonoBehaviour {

	public GameManager gameManager;
	public VTechnologyPanel techPanel;

	public void selectTechnology(Technology tech){
		if (tech.IsUnlocked && !tech.IsLearned) {
			gameManager.selectTechnology (tech);
			techPanel.panelDisappear();
		}
	}

}
