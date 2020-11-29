package Model;

public class ExperimentResult {
	public String experimentName;
	//results of full experiment for add operation
	private int AvgAddTime;
	private int TotalAddTime;
	private int AddCounter;
	//results of full experiment for remove operation
	private int AvgRemoveTime;
	private int TotalRemoveTime;
	private int RemoveCounter;
	
	public ExperimentResult(String name,
							int AvgAddTime,
							int TotalAddTime,
							int AddCounter,
							int AvgRemoveTime,
							int TotalRemoveTime,
							int RemoveCounter
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
		return String.format("%s\n%d\n%d\n%d\n%d\n%d\n%d", 
								this.experimentName,
								this.AvgAddTime,
								this.TotalAddTime,
								this.AddCounter,
								this.AvgRemoveTime,
								this.TotalRemoveTime,
								this.RemoveCounter);
	}

	public int getAvgAddTime() {
		return AvgAddTime;
	}

	public int getTotalAddTime() {
		return TotalAddTime;
	}

	public int getAddCounter() {
		return AddCounter;
	}

	public int getAvgRemoveTime() {
		return AvgRemoveTime;
	}

	public int getTotalRemoveTime() {
		return TotalRemoveTime;
	}

	public int getRemoveCounter() {
		return RemoveCounter;
	}
}
