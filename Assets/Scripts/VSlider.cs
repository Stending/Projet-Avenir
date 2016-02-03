using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VSlider : MonoBehaviour {

	public enum Type{Coef, Percent}

	public Type type = Type.Coef;
	//public Slider slider;
	public Text valueText;

	public float coef;


	public void setValue(float value){
		if (type == Type.Coef)
			valueText.text = (value * coef).ToString ("0.0") + "x";
		else if (type == Type.Percent)
			valueText.text = value + "%";
	}


}
