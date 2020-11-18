package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.Human;

public interface IRepository<T> {
	public T LoadFromTextFile(UUID entityId);
	public void SaveToTextFile(T entity);
	public void SaveToTextFile(ArrayList<T> entities);
	public ArrayList<T> LoadAllFromTextFile();
	public void Delete(UUID entityId);
	public void DeleteAll();
}
