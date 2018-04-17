using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using System;
using static SharpTAG;

public class DisplayManager {
  public static void updateNameDisplay(string str) {
    Text titleField = GameObject.Find("TitleField").GetComponent<Text>();
    titleField.text = str;
  }
  public static void updateRoomDisplay(string roomName) {
     Room room = findByName(roomName, getRooms());
     updateNameDisplay(room.givenName);
     output(DisplayManager.buildCompleteDescription(roomName));
  }
  private static string describe(string roomName) {
    return findByName(roomName, getRooms()).description + ".";
  }
  private static string describeEntities(string roomName) {
    ArrayList descriptionList = new ArrayList();
    Interactable[] entities = narrowInteractables(getEntities(), roomName);
    if (entities.Length > 0) {
      for (int i = 0; i < entities.Length; i++) {
        descriptionList.Add(OutputPrinter.embolden(entities[i].description,
          entities[i].givenName));
      }
      return manageListGrammar(descriptionList, "and") + ".";
    } else {
      return "nothing worthy of note.";
    }
  }
  private static string describeExits(Dictionary<string, Exit> exits) {
    if (exits.Count > 0) {
      ArrayList descriptionList = new ArrayList();
      foreach (string key in exits.Keys) {
        descriptionList.Add(OutputPrinter.embolden(exits[key].description, key));
      }
      return manageListGrammar(descriptionList, "or") + ".";
    } else {
      return "not see any obvious exits.";
    }
  }
  private static string describeExits(string roomName) {
    Room room = findByName(roomName, getRooms());
    return describeExits(room.exits);
  }
  public static string buildCompleteDescription(string roomName) {
    string description = describe(roomName);
    description += " You see " + describeEntities(roomName);
    description += " You can " + describeExits(roomName);
    return description;
  }
  private static string manageListGrammar(ArrayList elements, string delimiter) {
    string description = "";
    for (var i = 0; i < elements.Count; i++) {
      if (i == 0) {
        description += elements[i];
      } else if (i < elements.Count - 1) {
        description += ", " + elements[i];
      } else if (i >= elements.Count - 1) {
        description += " " + delimiter + " " + elements[i];
      }
    }
    return description;
  }
}
