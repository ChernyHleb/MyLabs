
enum SkipMode
{
	SkipToNext,
	SkipToPrev,
	DontSkip
}

public class Model {
	private int _maxNumber;
	private int _currentNumber;
	private int _attemptCounter;
	private boolean isLying;
	private boolean _isFound;
	private int _maxValue;
	private int _minValue;
	private int _prevMaxValue;
	private int _prevMinValue;
	
	public boolean GetIsFound()
	{
		return this._isFound;
	}
	
	public int GetCurrentNumber()
	{
		return this._currentNumber;
	}
	
	public int GetAttempts()
	{
		return this._attemptCounter;
	}
	
	public Model(int maxNumber)
	{
		this._maxNumber = maxNumber;
		this._currentNumber = maxNumber / 2;
		this._attemptCounter = 0;
		this.isLying = false;
		this._isFound = false;
		this._maxValue = maxNumber;
		this._minValue = 0;
	}
	
	private void SkipCurrentNumberToNext()
	{
		this._minValue = this._currentNumber;
		this._currentNumber +=(this._maxValue - this._minValue) / 2;
		if(this._currentNumber > this._minValue)
			this._currentNumber = this._maxValue;
	}
	
	private void SkipCurrentNumberToPrev()
	{
		this._maxValue = this._currentNumber;
		this._currentNumber -= (this._maxValue - this._minValue) / 2;
		if(this._currentNumber < this._minValue)
			this._currentNumber = this._minValue;
	}
	
	public int GuessNumber(SkipMode mode)
	{	
		if(this._isFound == true)
			return this._currentNumber;
		
		switch(mode)
		{
		case SkipToNext:
			this.SkipCurrentNumberToNext();
			break;
		case SkipToPrev:
			this.SkipCurrentNumberToPrev();
			break;
		case DontSkip:
			this._isFound = true;
			return this._currentNumber;
		}
		
		this._attemptCounter ++;
		
		this.CheckIfLying();
		
		if(!this.isLying)
			return this._currentNumber;
		else
			return -1;
	}
	
	private void CheckIfLying()
	{
		if(this._maxValue == this._minValue)
		{
			this.isLying = true;
			this._currentNumber = -1;
		}
			
	}
}
