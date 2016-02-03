using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VTechnologyButton : MonoBehaviour {

	public Technology technology;
	public Image line;

	public Sprite blockedLine;
	public Sprite unlockedLine;
	public Sprite learnedLine;


	public void updateView(){
	
			if (technology.IsLearned) {
				this.GetComponent<Image>().color = Color.green;
				if (line != null) 
					line.sprite = learnedLine;
			} else if (technology.IsUnlocked) {
				this.GetComponent<Image>().color = Color.blue;
				if (line != null)
					line.sprite = unlockedLine;
			} else {
				this.GetComponent<Image>().color = Color.grey;
				if (line != null)
					line.sprite = blockedLine;
			}
		}



}
