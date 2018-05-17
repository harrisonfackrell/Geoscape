using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;

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
        string exit = MovementHandler.testForExits(getInput(), getPlayer().location);
        if (exit == getInput()) {
          getPlayer().methods["move"]();
        } else {
          output("Unrecognized command");
        }
      } },
      { "inventory", () => {
        List<Interactable> entities = findByName("Inventory", getRooms()).localize(getEntities());
        if (entities.Count > 0) {
          output(" You have " + DisplayManager.describeEntities("Inventory"));
        } else {
          output("You are not carrying anything.");
        }
      } },
      { "look", () => {
        DisplayManager.updateRoomDisplay(getPlayer().location);
      } },
      { "move", () => {
        MovementHandler.movePlayerByInput(getInput());
      } },
      {"wait", () => {
        output("You wait around for a moment.");
        nextTurn();
      } }
    };
    this.methods = DataMutator.mergeDictionaries(this.methods, methods);
    this.prevLocation = location;
    this.givenName = "player";
    this.turn = turn == null ? () => {} : turn;
    this.advanceTurn = false;
    this.displayInput = true;
  }
}
