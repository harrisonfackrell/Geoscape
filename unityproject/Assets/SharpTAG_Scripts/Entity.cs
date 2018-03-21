using System;
using System.Collections;
using System.Collections.Generic;

public class Entity : GenericEntity {
  public Entity() {
    throw new Exception("GenericEntity constructor cannot be used by subclass");
  }
  public Entity(string name, string location, string description,
   Dictionary<string, Action> methods, string givenName, Action turn) {
    this.name = name;
    this.location = location;
    this.methods = methods;
    this.givenName = givenName;
    this.turn = turn;
  }
}
