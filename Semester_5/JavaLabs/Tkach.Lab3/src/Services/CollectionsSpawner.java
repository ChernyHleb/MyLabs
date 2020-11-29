package Services;

import java.util.ArrayList;
import java.util.LinkedList;

import Model.Human;

public class CollectionsSpawner {
	public static ArrayList<Human> SpawnArrayList(int capasity) {
		ArrayList<Human> humans = new ArrayList<Human>();
		for(int i = 0; i < capasity; i ++) {
			humans.add(Randomiser.rndHuman());
		}
		return humans;
	}
	
	public static LinkedList<Human> SpawnLinkedList(int capasity) {
		LinkedList<Human> humans = new LinkedList<Human>();
		for(int i = 0; i < capasity; i ++) {
			humans.add(Randomiser.rndHuman());
		}
		return humans;
	}
}


