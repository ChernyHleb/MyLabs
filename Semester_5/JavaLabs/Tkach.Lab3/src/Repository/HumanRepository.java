package Repository;

import java.io.BufferedReader;
import java.io.BufferedWriter;
import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileReader;
import java.io.FileWriter;
import java.io.IOException;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.UUID;

import Model.Human;

public abstract class HumanRepository implements IRepository<Human> {
	private String _defaultHumanDBFile;

	@Override
	public Human Load(UUID entityId) {
		return null;
	}

	@Override
	public void Save(Human entity) {
		ArrayList<Human> list = new ArrayList<Human>(Arrays.asList(entity));
		writeToDBFile(list);
	}

	@Override
	public void Save(ArrayList<Human> people) {
		writeToDBFile(people);
	}

	@Override
	public ArrayList<Human> LoadAll() {
		
		return null;
	}

	@Override
	public ArrayList<String> readFromDBFile() {
		//try {
			//File file = new File("this");
			//FileReader fileReader = 
		//}
		
		return null;
	}

	@Override
	public void writeToDBFile(ArrayList<Human> data) {
		try {
			File file = new File(this._defaultHumanDBFile);
			FileWriter fw = new FileWriter(file);
			BufferedWriter writer = new BufferedWriter(fw);
			
			for(Human entity : data){
				writer.write(entity.toString() + "\n");
			}
			
		} 
		catch (FileNotFoundException e) {
			e.printStackTrace();
			
		} 
		catch (IOException e)
		{
			
		}
		
	}
}
