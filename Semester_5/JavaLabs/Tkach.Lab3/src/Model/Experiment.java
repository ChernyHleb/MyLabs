package Model;

import java.util.ArrayList;
import java.util.LinkedList;

import Services.ExperimentLogger;

public class Experiment {
	// 0 for 10 elements
	// 1st for 100 elements
	// 2nd for 1000 elements
	// etc...
	private ArrayList<ExperimentLogger> _loggers;
	//collections of experimental collections
	private ArrayList<ArrayList<Human>> _arrayLists;
	private ArrayList<LinkedList<Human>> _linkedLists;
	//collection of results of all experiments
	private ArrayList<ExperimentResult> _results;

	public Experiment(int experimentsAmount) {
		//creating new logs
		_loggers = new ArrayList<ExperimentLogger>();
		int len = 1;
		for(int i = 0; i < experimentsAmount; i++) {
			len *= 10;
			_loggers.add(new ExperimentLogger(String.format("LogFor%d.txt", len)));
		}
		//initializing other stuff
		_arrayLists = new ArrayList<ArrayList<Human>>();
		_linkedLists = new ArrayList<LinkedList<Human>>();
	}
	
	//default amount of experiments is 5 [10..100000]
	public Experiment() {
		this(5);
	}
	
	public void Run() {
		
	}
	
	
	private void RunExperiment() {
		
	}
	
	private void MeasureAddFunctionTime() {
		
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
