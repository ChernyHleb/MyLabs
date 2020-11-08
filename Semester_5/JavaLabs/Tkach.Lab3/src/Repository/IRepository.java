package Repository;

import java.util.ArrayList;
import java.util.UUID;

import Model.Human;

public interface IRepository<T> {
	public T LoadFromTextFile(UUID entityId, String FileName);
	public void SaveToTextFile(T entity, String FileName);
	public void SaveToTextFile(ArrayList<T> entities, String FileName);
	public ArrayList<T> LoadAllFromTextFile(String FileName);
}
