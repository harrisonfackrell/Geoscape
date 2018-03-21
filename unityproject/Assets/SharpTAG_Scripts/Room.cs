using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class Room {
  public string name;
  public string description;
  public Dictionary<string, string[]> exits;
  public string givenName;
  public Room(string name, string description,
   Dictionary<string, string[]> exits, string givenName) {
     this.name = name;
     this.description = description;
     this.exits = exits;
     this.givenName = givenName;
   }
}
