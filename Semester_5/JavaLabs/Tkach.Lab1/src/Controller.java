
public class Controller {
	private Model _model;
	private View _view;
	
	public Controller(Model model, View view)
	{
		this._model = model;
		this._view = view;
	}
	
	public int GuessNumber()
	{
		while(!this._model.GetIsFound())
		{
			this._view.WriteText(String.join(" ",
					"is your number ", 
					Integer.toString(this._model.GetCurrentNumber()),
					"?"));
			String answer = this._view.ReadString();
			
			if(answer.equals("less"))
			{
				this._model.GuessNumber(SkipMode.SkipToPrev);
			}
			else if(answer.equals("more"))
			{
				this._model.GuessNumber(SkipMode.SkipToNext);
			}
			else if(answer.equals("yes"))
			{
				this._view.WriteText("Attempts: ");
				this._view.WriteText(Integer.toString(this._model.GetAttempts()));
			}
			if(this._model.GetCurrentNumber() == -1)
			{
				this._view.WriteText("You are Lying");
				return -1;
			}
				
		}
		
		return this._model.GetCurrentNumber();
	}
}
