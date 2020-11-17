package Services;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;

public class FileIOService {
	public static void WriteToFile(String fileName, ArrayList<String> data, boolean appendMode)
	{
		try {
			File file = new File(fileName);
			FileWriter fw = new FileWriter(file, appendMode);
			BufferedWriter writer = new BufferedWriter(fw);
			
			for(String entity : data){
				writer.write(entity + "\n");
			}
			writer.close();
			
		} 
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} 
		catch (IOException e)
		{
			
		}
	}
	
	public static void WriteToFile(String fileName, String data, boolean appendMode)
	{
		try {
			File file = new File(fileName);
			FileWriter fw = new FileWriter(file, appendMode);
			BufferedWriter writer = new BufferedWriter(fw);
			
			writer.write(data + "\n");
			writer.close();
			
		} 
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} 
		catch (IOException e)
		{
			
		}
	}
	
	public static ArrayList<String> ReadFromFile(String fileName)
	{
		try {
			File file = new File(fileName);
			FileReader fr = new FileReader(file);
			BufferedReader reader = new BufferedReader(fr);
			
			String line;
			ArrayList<String> result = new ArrayList<String>();
			while((line = reader.readLine()) != null)
			{
				result.add(line);
			}
			reader.close();
			return result;
		}
		catch (FileNotFoundException e) {
			e.printStackTrace();
		} 
		catch (IOException e)
		{
			
		}
		return null;
	}
}
