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
  public int age = 0;
  public bool advanceTurn;
  public bool displayInput;
  public Interactable() {

  }
  public void warp(string roomName) {
    if (roomName != this.prevLocation) {
      this.prevLocation = this.location;
    }
    this.location = roomName;
  }
}
