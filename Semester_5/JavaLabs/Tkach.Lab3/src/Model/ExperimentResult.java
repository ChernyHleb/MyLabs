package Model;

public class ExperimentResult {
	public String experimentName;
	//results of full experiment for add operation
	private long AvgAddTime;
	private long TotalAddTime;
	private long AddCounter;
	//results of full experiment for remove operation
	private long AvgRemoveTime;
	private long TotalRemoveTime;
	private long RemoveCounter;
	
	public ExperimentResult(String name,
							long AvgAddTime,
							long TotalAddTime,
							long AddCounter,
							long AvgRemoveTime,
							long TotalRemoveTime,
							long RemoveCounter
							) 
	{
		this.experimentName = name;
		this.AvgAddTime = AvgAddTime;
		this.TotalAddTime = TotalAddTime;
		this.AddCounter = AddCounter;
		this.AvgRemoveTime = AvgRemoveTime;
		this.TotalRemoveTime = TotalRemoveTime;
		this.RemoveCounter = RemoveCounter;
	}
	
	public String ToString() {
		return String.format("%s\n"
				+ "AverageAddTime: %dns\n"
				+ "TotalAddTime: %dns\n"
				+ "AddCounter: %d\n"
				+ "AvgRemoveTime: %dns\n"
				+ "TotalRemoveTime: %dns\n"
				+ "RemoveCounter: %d", 
								this.experimentName,
								this.AvgAddTime,
								this.TotalAddTime,
								this.AddCounter,
								this.AvgRemoveTime,
								this.TotalRemoveTime,
								this.RemoveCounter);
	}

	public long getAvgAddTime() {
		return AvgAddTime;
	}

	public long getTotalAddTime() {
		return TotalAddTime;
	}

	public long getAddCounter() {
		return AddCounter;
	}

	public long getAvgRemoveTime() {
		return AvgRemoveTime;
	}

	public long getTotalRemoveTime() {
		return TotalRemoveTime;
	}

	public long getRemoveCounter() {
		return RemoveCounter;
	}
}
