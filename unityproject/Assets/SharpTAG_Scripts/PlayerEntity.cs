using System;
using System.Collections;
using System.Collections.Generic;

public class PlayerEntity : GenericEntity {
  public PlayerEntity() {
    throw new Exception("GenericEntity constructor cannot be used by subclass");
  }
  public PlayerEntity(string location, Dictionary<string, Action> methods,
   Action turn) {
    this.name = "player";
    this.location = location;
    this.methods = methods;
    this.prevLocation = location;
    this.givenName = "player";
  }
}
