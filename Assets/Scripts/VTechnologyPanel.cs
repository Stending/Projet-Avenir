using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class VTechnologyPanel : MonoBehaviour {

	public GameManager gameManager;
	public Animator panelAnim;

	public VTechnologyButton[] techButtons;
	void Start(){
		techButtons = this.GetComponentsInChildren<VTechnologyButton> ();
		gameManager.onTechnologyChange += updateTechnologyButtons;
	}

	public void panelAppear(){
		panelAnim.SetBool ("Active", true);
	}
	
	public void panelDisappear(){
		panelAnim.SetBool ("Active", false);
	}

	public void updateTechnologyButtons(){
		foreach (VTechnologyButton techButton in techButtons) {
			techButton.updateView();
		}
	}
}
