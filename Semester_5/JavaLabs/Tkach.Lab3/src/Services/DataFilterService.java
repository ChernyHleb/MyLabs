package Services;

import java.util.ArrayList;

public class DataFilterService {
	public static ArrayList<String> FilterData(ArrayList<String> data, String pattern)
	{
		ArrayList<String> filteredData = new ArrayList<String>();
		for(String entity : data)
		{
			if (entity.split(" ")[0].equals(pattern))
				filteredData.add(entity);
		}
		return filteredData;
	}
}
