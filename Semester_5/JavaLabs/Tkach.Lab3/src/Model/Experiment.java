package Model;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

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
	private ArrayList<ExperimentResult> _resultsForArrayList;
	private ArrayList<ExperimentResult> _resultsForLinkedList;
	
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
		_resultsForArrayList = new ArrayList<ExperimentResult>();
		_resultsForLinkedList = new ArrayList<ExperimentResult>();
	}
	
	//default amount of experiments is 5 [10..100000]
	public Experiment() {
		this(5);
	}
	
	// defines amount of elements for each experiment and
	// collects data to result ArrayList
	public void Run() {
		int elementsAmount = 1;
		for(int i = 0; i < this._experimentsAmount; i++) {
			elementsAmount *= 10;
			ArrayList<ExperimentResult> results = RunExperiment(
													String.format("Experiment%d", elementsAmount), 
													elementsAmount, 
													_loggers.get(i)
													);
			_resultsForArrayList.add(results.get(0));
			_resultsForLinkedList.add(results.get(1));
		}
	}

	//Runs the concrete experiment
	//The first result is for arrayList
	//The second result is for linkedList
	private ArrayList<ExperimentResult> RunExperiment(String name,  
										   int elementsAmount,
										   ExperimentLogger logger
										   ) 
	{
		ArrayList<Human> arrayList = new ArrayList<Human>();
		LinkedList<Human> linkedList  = new LinkedList<Human>();
		long AvgAddTime = 0;
		long TotalAddTime = 0;
		long AddCounter = 0;
		long AvgRemoveTime = 0;
		long TotalRemoveTime = 0;
		long RemoveCounter = 0;
		
		long startTime, stopTime, time;
		
		// getting results for arrayList
		for(int i = 0; i < elementsAmount; i ++) {
			startTime = System.nanoTime();
			
			arrayList.add(Randomiser.rndHuman());
			
			stopTime = System.nanoTime();
			time = stopTime - startTime;
			
			AddCounter ++;
			TotalAddTime += time;
		}
		
		
		// getting results for linkedList
		for(int i = 0; i < elementsAmount; i ++) {
			linkedList.add(Randomiser.rndHuman());
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
	
	public ArrayList<ExperimentLogger> get_loggers() {
		return _loggers;
	}
	
	public int get_experimentsAmount() {
		return _experimentsAmount;
	}

	public ArrayList<ExperimentResult> get_resultsForArrayList() {
		return _resultsForArrayList;
	}

	public ArrayList<ExperimentResult> get_resultsForLinkedList() {
		return _resultsForLinkedList;
	}

}
