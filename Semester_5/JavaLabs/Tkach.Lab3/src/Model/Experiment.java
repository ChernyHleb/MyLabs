package Model;

import java.util.ArrayList;
import java.util.LinkedList;
import java.util.List;

import Services.ExperimentLogger;
import Services.Randomiser;

interface IListOperation<T> {
	void execute(List<T> list);
}

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
			ArrayList<Human> arrayList = new ArrayList<Human>();
			LinkedList<Human> linkedList  = new LinkedList<Human>();
			
			elementsAmount *= 10;
			_resultsForArrayList.add(RunExperiment(String.format("Experiment%d", elementsAmount), 
												   elementsAmount, 
												   _loggers.get(i),
												   arrayList));
			_resultsForLinkedList.add(RunExperiment(String.format("Experiment%d", elementsAmount), 
													elementsAmount, 
													_loggers.get(i),
													linkedList));
		}
	}

	//Runs the concrete experiment
	//The first result is for arrayList
	//The second result is for linkedList
	private ExperimentResult RunExperiment(
										   String name,  
										   int elementsAmount,
										   ExperimentLogger logger,
										   List<Human> list
										   ) 
	{
		long AvgAddTime = 0;
		long TotalAddTime = 0;
		long AddCounter = 0;
		long AvgRemoveTime = 0;
		long TotalRemoveTime = 0;
		long RemoveCounter = 0;
		
		// getting results for add operation
		for(int i = 0; i < elementsAmount; i ++) {
			AddCounter ++;
			TotalAddTime += MeasureListOperationExecutionTime(
								(List<Human> l)->l.add(Randomiser.rndHuman()),
								list);
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
	
	
	/// gets function and list - parameter of the given function
	/// returns time of execution
	public long MeasureListOperationExecutionTime(IListOperation<Human> func, 
												  List<Human> list) {
		long startTime, stopTime;
		startTime = System.nanoTime();
		
		func.execute(list);
		
		stopTime = System.nanoTime();
		return stopTime - startTime;
		
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
