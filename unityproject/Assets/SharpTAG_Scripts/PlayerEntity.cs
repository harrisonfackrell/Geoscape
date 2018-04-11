using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class PlayerEntity : Interactable {
  public PlayerEntity() {
    throw new Exception("Interactable constructor cannot be used by subclass");
  }
  public PlayerEntity(string location, Dictionary<string, Action> methods,
   Action turn) {
    this.name = "player";
    this.location = location;
    this.methods = new Dictionary<string, Action> {
      { "nothing", () => {
        output("I'm afraid I don't understand");
      } },
      { "inventory", () => {
        Interactable[] entities = narrowInteractables(getEntities(), "Inventory");
        if (entities.Length > 0) {
          output("You have stuff");
        } else {
          output("You don't have stuff");
        }
      } },
    };
    this.methods = DataMutator.mergeDictionaries(this.methods, methods);
    this.prevLocation = location;
    this.givenName = "player";
  }
}
