using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour {

	public CPopulation population = new CPopulation ();
	public CResources resources = new CResources();
	public CEnvironment environment = new CEnvironment ();

	public Technology technology;

	public delegate void guiSimpleVariableChangeAction(int value);

	public delegate void guiPopulationChangeAction(CPopulation pop);
	public event guiPopulationChangeAction onPopulationChange = delegate {};

	public delegate void guiConsumptionChangeAction(CPopulation pop);
	public event guiPopulationChangeAction onConsumptionChange = delegate {};

	public delegate void guiTaskAssignmentChangeAction(CPopulation pop);
	public event guiTaskAssignmentChangeAction onTaskAssignmentChange = delegate {};

	public delegate void guiTechnologyBarChangeAction(Technology tech, CPopulation pop);
	public event guiTechnologyBarChangeAction onTechnologyBarChange = delegate {};

	
	public delegate void guiExplorationChangeAction(CPopulation pop, CEnvironment env);
	public event guiExplorationChangeAction onExplorationChange = delegate {};

	public delegate void guiTechnologyChangeAction();
	public event guiTechnologyChangeAction onTechnologyChange = delegate {};


	public delegate void guiResourcesChangeAction(CResources res, CPopulation pop);
	public event guiResourcesChangeAction onResourcesChange = delegate {};

	void Start () {
		onResourcesChange (resources, population);
		onPopulationChange (population);
		onConsumptionChange (population);
		onTaskAssignmentChange (population);
		onTechnologyBarChange (technology, population);
		onTechnologyChange ();
	}
	
	public void PlayTurn(){
		foodConsumption (population);
		waterConsumption (population);

		research ();
		population.AlimentationChange ();

		population.Grow ();



		population.RegulateAlimentation (resources);

		onConsumptionChange (population);
		onResourcesChange (resources, population);
		onPopulationChange (population);
		onTechnologyBarChange (technology, population);
		onTechnologyChange ();
	}

	public void executeExploration(){

	}

	public void foodConsumption(CPopulation pop){
		foodConsumption (pop.children);
		foodConsumption (pop.adults);
		foodConsumption (pop.olds);
	}

	public void foodConsumption(CPeople people){
		if (people.foodNeeded () < resources.food) {
			resources.food -= people.foodNeeded();
		}
	}

	public void waterConsumption (CPopulation pop){
		waterConsumption (pop.children);
		waterConsumption (pop.adults);
		waterConsumption (pop.olds);
	}
	
	public void waterConsumption(CPeople people){
		if (people.waterNeeded () < resources.water) {
			resources.water -= people.waterNeeded();
		}
	}
	public void selectTechnology(Technology tech){
		technology = tech;
		onTaskAssignmentChange (population);
		onTechnologyBarChange (technology, population);
	}

	public void research(){
		if (technology != null) {
			technology.Value += population.TotalTechnologyPointToGet;
			onTechnologyBarChange (technology, population);
		}
	}

	public void changeConsumption(float value, string age, string type){
		CPeople people;

		switch (age) {
			case "children":
				people = population.children;
				break;
			case "adults":
				people = population.adults;
				break;
			case "olds":
				people = population.olds;
				break;
			default:
				people = population.children;
				break;
		}

		float prec;
		if (type == "food") {
			prec = people.foodRatio;
			people.foodRatio = value;
		} else if (type == "water") {
			prec = people.waterRatio;
			people.waterRatio = value;
		} else {
			prec = people.foodRatio;
			people.foodRatio = value;
		}

		if (population.isAlimentationProblem (resources)) {
			if (type == "food") {
				people.foodRatio = prec;
			} else if (type == "water") {
				people.waterRatio = prec;
			} else {
				people.foodRatio = prec;
			}
		}

		onResourcesChange (resources, population);
		onConsumptionChange (population);
	}
	
	public void changeTaskAssignment(float value, string age, string type){
		CPeople people;
		
		switch (age) {
		case "children":
			people = population.children;
			break;
		case "adults":
			people = population.adults;
			break;
		case "olds":
			people = population.olds;
			break;
		default:
			people = population.children;
			break;
		}


		switch (type) {
		case "exploration":
			people.ToExploration = (int)value;
			break;
		case "defense":
			people.ToDefense = (int)value;
			break;
		case "building":
			people.ToBuilding = (int)value;
			break;
		case "research":
			people.ToResearch = (int)value;
			break;
		default:
			break;
			
		}

		onTaskAssignmentChange (population);
		onExplorationChange (population, environment);
		onTechnologyBarChange (technology, population);
		onTechnologyChange ();
	}
}
