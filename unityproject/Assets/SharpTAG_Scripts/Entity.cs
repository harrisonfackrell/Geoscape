using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class Entity : GenericEntity {
  public Entity() {
    throw new Exception("GenericEntity constructor cannot be used by subclass");
  }
  public Entity(string name, string location, string description,
   Dictionary<string, Action> methods, string givenName, Action turn = null) {
    this.name = name;
    this.location = location;
    this.methods = new Dictionary<string, Action> {
      { "nothing", () => {
        output("Do what with the " + givenName + "?");
      } },
      { "look", () => {
        output("It's " + description + ".");
      } },
      { "attack", () => {
        output("ERROR: Object is Protected.");
      } }
    };
    this.methods = DataMutator.mergeDictionaries(this.methods, methods);
    this.givenName = givenName;
    this.turn = turn;
  }
}
