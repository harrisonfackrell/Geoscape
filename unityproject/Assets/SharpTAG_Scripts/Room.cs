using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class Room {
  public string name;
  public string description;
  public Dictionary<string, Exit> exits;
  public string givenName;
  public Room(string name, string description,
   Dictionary<string, Exit> exits, string givenName) {
     this.name = name;
     this.description = description;
     this.exits = exits;
     this.givenName = givenName;
  }
  public List<Interactable> localize(List<Interactable> entities) {
    List<Interactable> narrowedEntities = new List<Interactable>();
		for (int i = 0; i < entities.Count; i++) {
			if (entities[i].location == this.name) {
				narrowedEntities.Add(entities[i]);
			}
		}
		return narrowedEntities;
  }
}
