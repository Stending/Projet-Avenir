using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ViewHelp {


	public static string numberWithSign(int number){
		return ((number >= 0)?"+":"") + number.ToString();
	}


	public static Image getFillZoneSlider(Slider slider){
		Transform fillArea = getChild (slider.transform, "Fill Area");
		Transform fill = getChild (fillArea.transform, "Fill");
		return fill.GetComponent<Image> ();
	}


	public static Transform getChild(Transform trans, string name){
		foreach (Transform child in trans) {
			if (child.name == name){
				return child;
			}
		}
		return null;
	}
}
