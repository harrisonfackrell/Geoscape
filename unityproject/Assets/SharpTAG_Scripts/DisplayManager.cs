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
     output(""/*buildCompleteDescription(room)*/);
  }
  private static string describe(string roomName) {
    return findByName(roomName, getRooms()).description + ".";
  }
  private static string describeEntities(string roomName) {
    ArrayList descriptionList = new ArrayList();
    Interactable[] entities = narrowInteractables(getEntities(), roomName);
    for (int i = 0; i < entities.Length; i++) {
      descriptionList.Add(OutputPrinter.embolden(entities[i].description,
        entities[i].givenName));
    }
    return manageListGrammar(descriptionList, "and") + ".";
  }
  private static string describeExits(Dictionary<string, Exit> exits) {
    ArrayList descriptionList = new ArrayList();
    foreach (key in exits.Keys) {
      descriptionList.Add(embolden(exits[key].description, key));
    }
    return manageListGrammar(descriptionArray, "or") + ".";
  }
  private static string describeExits(string roomName) {
    Room room = findByName(roomName, getEntities())
    return describeExits(room.exits);
  }
  //UNFINISHED
  // public static string buildCompleteDescription(roomName) {
  //   string description = "";
  //   description += describe(room);
  //
  //   Interactable[] entities = narrowInteractables(getEntities(), roomName);
  //   if (entities.Length > 0) {
  //     description += " You see " + describeEntities(roomName);
  //   }
  // }
  //END UNFINISHED
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
