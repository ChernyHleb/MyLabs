package Services;

import java.util.ArrayList;

import Model.User;
import Repository.UserRepository;

public class Validator {
	public static boolean LogInValidation(String Login, String password) {
		UserRepository repo = new UserRepository();
		ArrayList<User> users = repo.LoadAllFromTextFile();
		for(User entity : users)
			if(entity.getName().equals(Login)) {
				if(entity.getPassword().equals(password)) {
					return true;
				} else {
					
				}
			} else {
				
			}
		return false;
	}
}
