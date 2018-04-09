using System;
using System.Collections;
using System.Collections.Generic;

public class Interactable {
  public string name;
  public string location;
  public string description;
  public Dictionary<string, Action> methods;
  public string givenName;
  public string prevLocation;
  public Action turn;
  public Interactable() {

  }
}
