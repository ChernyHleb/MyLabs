package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.Human;

public interface IRepository<T> {
	public T Load(UUID entityId);
	public void Save(T entity);
	public void Save(ArrayList<T> entities);
	public ArrayList<T> LoadAll();
	public ArrayList<String> readFromDBFile();
	void writeToDBFile(ArrayList<T> data);
}
