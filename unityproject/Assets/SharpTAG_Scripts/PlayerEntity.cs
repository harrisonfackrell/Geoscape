using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class PlayerEntity : GenericEntity {
  public PlayerEntity() {
    throw new Exception("GenericEntity constructor cannot be used by subclass");
  }
  public PlayerEntity(string location, Dictionary<string, Action> methods,
   Action turn) {
    this.name = "player";
    this.location = location;
    this.methods = new Dictionary<string, Action> {
      { "nothing", () => {

      } }
    };
    this.methods = methods;
    this.prevLocation = location;
    this.givenName = "player";
  }
}