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

	//Runs the concrete experiment for some type of list
	private ExperimentResult RunExperiment(
										   String name,  
										   int elementsAmount,
										   ExperimentLogger logger,
										   List<Human> list
										   ) 
	{
		long avgAddTime = 0;
		long totalAddTime = 0;
		long addCounter = 0;
		long avgRemoveTime = 0;
		long totalRemoveTime = 0;
		long removeCounter = 0;
		
		// getting results for add operation
		for(int i = 0; i < elementsAmount; i ++) {
			addCounter ++;
			Human tempHuman = Randomiser.rndHuman();
			totalAddTime += MeasureListOperationExecutionTime(
								(List<Human> l)->l.add(tempHuman),
								list,
								"ADD",
								i,
								logger);
		}
		
		// getting results for remove operation
		for(int i = 0; i < elementsAmount / 10; i ++) {
			removeCounter ++;
			totalRemoveTime += MeasureListOperationExecutionTime(
								(List<Human> l)->l.remove(l.size() - 1),
								list,
								"REM",
								i,
								logger);
		}
		
		avgAddTime = totalAddTime / addCounter;
		avgRemoveTime = totalRemoveTime / removeCounter;
		
		ExperimentResult result = new ExperimentResult(
				name,
				avgAddTime,
				totalAddTime,
				addCounter,
				avgRemoveTime,
				totalRemoveTime,
				removeCounter
				);
		
		logger.WriteToLog(result);
		
		return result;
	}
	
	
	/// gets function and list - parameter of the given function
	/// returns time of execution
	public long MeasureListOperationExecutionTime(IListOperation<Human> func, 
												  List<Human> list,
												  String operationName,
												  int elementIndex,
												  ExperimentLogger logger) {
		long startTime, stopTime;
		startTime = System.nanoTime();
		
		func.execute(list);
		
		stopTime = System.nanoTime();
		
		logger.WriteToLog(operationName, elementIndex, stopTime - startTime);
		return stopTime - startTime;
		
	}
	
	/*public long MeasureArrayListADDExecutionTime(
			  ArrayList<Human> list,
			  int elementIndex,
			  ExperimentLogger logger) 
	{
		long startTime, stopTime;
		Human human = Randomiser.rndHuman();
		startTime = System.nanoTime();

		list.add(human);

		stopTime = System.nanoTime();

		logger.WriteToLog("ADD", elementIndex, stopTime - startTime);
		return stopTime - startTime;
	}*/
	
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
