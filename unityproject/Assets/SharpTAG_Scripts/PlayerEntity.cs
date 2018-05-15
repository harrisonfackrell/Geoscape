using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class PlayerEntity : Interactable {
  public PlayerEntity() {
    throw new Exception("Interactable constructor cannot be used by subclass");
  }
  public PlayerEntity(string location, Dictionary<string, Action> methods,
   Action turn) {
    this.name = "player";
    this.description = "a player character";
    this.location = location;
    this.methods = new Dictionary<string, Action> {
      { "nothing", () => {
        output("I'm afraid I don't understand");
      } },
      { "inventory", () => {
        List<Interactable> entities = findByName("Inventory", getRooms()).localize(getEntities());
        if (entities.Count > 0) {
          output("You have stuff");
        } else {
          output("You don't have stuff");
        }
      } },
      { "look", () => {
        DisplayManager.updateRoomDisplay(getPlayer().location);
      } },
      { "move", () => {
        MovementHandler.movePlayerByInput(getInput());
      } }
    };
    this.methods = DataMutator.mergeDictionaries(this.methods, methods);
    this.prevLocation = location;
    this.givenName = "player";
  }
}
