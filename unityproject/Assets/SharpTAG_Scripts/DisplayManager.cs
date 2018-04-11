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
  private static string describe(Room room) {
    return room.description;
  }
}
