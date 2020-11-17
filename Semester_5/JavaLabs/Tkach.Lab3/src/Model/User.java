package Model;

import java.util.UUID;

public class User {
	private UUID id;
	private String name;
	private String password;
	private UserType type;
	
	public User(String name, String password, UserType type) {
		this.name = name;
		this.password = password;
		this.type = type;
		this.id = UUID.randomUUID();
	}
	
	public String ToString() {
		return String.format("%s %s %s %s", 
				id.toString(),
				name,
				password,
				type.toString()
				);
	}
	
	
	
	public UUID getId() {
		return id;
	}

	public void setId(UUID id) {
		this.id = id;
	}

	public String getName() {
		return name;
	}

	public void setName(String name) {
		this.name = name;
	}

	public String getPassword() {
		return password;
	}

	public void setPassword(String password) {
		this.password = password;
	}

	public UserType getType() {
		return type;
	}

	public void setType(UserType type) {
		this.type = type;
	}
}
