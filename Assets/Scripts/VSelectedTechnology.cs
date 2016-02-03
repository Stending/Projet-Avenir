using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class VSelectedTechnology : MonoBehaviour {

	public Text codeText;
	public Image fillBar;

	public Text valueText;
	public Text maxText;

	public void updateInfos(Technology tech, CPopulation pop){
		codeText.text = tech.code;
		fillBar.fillAmount = (float)tech.value / (float)tech.valueNeeded;
		valueText.text = tech.value.ToString()+" (+"+pop.TotalTechnologyPointToGet+")";
		maxText.text = "/" + tech.valueNeeded.ToString();
		if (tech.IsLearned) {
			fillBar.color = Color.green;
		}
	}

	public void updateToNull(CPopulation pop){
		codeText.text = " ";
		fillBar.fillAmount = 0;
		valueText.text = "0 (+"+pop.TotalTechnologyPointToGet+")";;
		maxText.text = "/0";
	}

}
