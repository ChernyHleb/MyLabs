package Model;

import java.util.ArrayList;
import java.util.LinkedList;

import Services.ExperimentLogger;
import Services.Randomiser;

public class Experiment {
	private int _experimentsAmount;
	// 0 for 10 elements
	// 1st for 100 elements
	// 2nd for 1000 elements
	// etc...
	private ArrayList<ExperimentLogger> _loggers;
	//collection of results of all experiments
	private ArrayList<ExperimentResult> _results;

	public Experiment(int experimentsAmount) {
		this._experimentsAmount = experimentsAmount;
		//creating new logs
		_loggers = new ArrayList<ExperimentLogger>();
		int len = 1;
		for(int i = 0; i < experimentsAmount; i++) {
			len *= 10;
			_loggers.add(new ExperimentLogger(String.format("LogFor%d.txt", len)));
		}
		//initializing other stuff
		_results = new ArrayList<ExperimentResult>();
	}
	
	//default amount of experiments is 5 [10..100000]
	public Experiment() {
		this(5);
	}
	
	// defines amount of elements for each experiment and
	// collects data to result ArrayList
	public ArrayList<ExperimentResult> Run() {
		int elementsAmount = 1;
		for(int i = 0; i < this._experimentsAmount; i++) {
			elementsAmount *= 10;
			_results.add(RunExperiment(String.format("Experiment for %d elements", elementsAmount), elementsAmount));
		}
		
		return _results;
	}
	
	//Runs the concrete experiment
	private ExperimentResult RunExperiment(String name, int elementsAmount) {
		ArrayList<Human> arrayList;
		LinkedList<Human> linkedList;
		int AvgAddTime = 0;
		int TotalAddTime = 0;
		int AddCounter = 0;
		int AvgRemoveTime = 0;
		int TotalRemoveTime = 0;
		int RemoveCounter = 0;
		
		for(int i = 0; i < elementsAmount; i ++) {
			
		}
		
		return new ExperimentResult(name,
									AvgAddTime,
									TotalAddTime,
									AddCounter,
									AvgRemoveTime,
									TotalRemoveTime,
									RemoveCounter
									);
	}
	
	public static ArrayList<Human> SpawnArrayList(int capasity) {
		ArrayList<Human> humans = new ArrayList<Human>();
		for(int i = 0; i < capasity; i ++) {
			humans.add(Randomiser.rndHuman());
		}
		return humans;
	}
	
	public static LinkedList<Human> SpawnLinkedList(int capasity) {
		LinkedList<Human> humans = new LinkedList<Human>();
		for(int i = 0; i < capasity; i ++) {
			humans.add(Randomiser.rndHuman());
		}
		return humans;
	}
	
	private int MeasureAddTime() {
		
	}
	
	private int MeasureRemoveTime() {
		
	}
	
	public ArrayList<ExperimentLogger> get_loggers() {
		return _loggers;
	}

	public ArrayList<ArrayList<Human>> get_arrayLists() {
		return _arrayLists;
	}

	public ArrayList<LinkedList<Human>> get_linkedLists() {
		return _linkedLists;
	}

	public ArrayList<ExperimentResult> get_results() {
		return _results;
	}
}
