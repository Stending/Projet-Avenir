using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VConsumptionElement : MonoBehaviour {

	public Slider foodSlider;
	public Slider waterSlider;
	
	public VConsumptionPrevisionElement previsions;

	

	public void updateInfos(CPeople people){
		foodSlider.value = people.foodRatio * (foodSlider.maxValue / 2);
		waterSlider.value = people.waterRatio * (waterSlider.maxValue / 2);
		updateSliderColor (foodSlider);
		updateSliderColor (waterSlider);

		previsions.foodConsumption.text = ViewHelp.numberWithSign (-people.foodNeeded ());
		previsions.waterConsumption.text = ViewHelp.numberWithSign (-people.waterNeeded ());
	}




	private void updateSliderColor(Slider slider){
		Image fillArea = ViewHelp.getFillZoneSlider (slider);
		if (slider.value <= 5) {
			fillArea.color = Color.Lerp (Color.red, Color.blue, slider.value / 5.0f);
		} else {
			fillArea.color = Color.Lerp (Color.blue, Color.green, (slider.value - 5) / 5.0f);
		}
		
	}

}
