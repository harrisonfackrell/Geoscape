using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class MovementHandler {
  public static void warp(Interactable entity, string roomName) {
    if (roomName != entity.prevLocation) {
      entity.prevLocation = entity.location;
    }
    entity.location = roomName;
  }
  public static void moveEntity(Interactable entity, string direction) {
    Room currentRoom = findByName(entity.location, getRooms());
    Dictionary<string, Exit> exits = currentRoom.exits;
    warp(entity, exits[direction].location);
  }
  public static void movePlayerByInput(string input) {
    PlayerEntity player = getPlayer();
    string direction = testForExits(getInput(), player.location);
    if (direction != null) {
      moveEntity(player, direction);
      DisplayManager.updateRoomDisplay(player.location);
    } else {
      output("You can't go that way.");
    }
  }
  public static string testForExits(string input, string roomName) {
    Room room = findByName(roomName, getRooms());
    foreach (string key in room.exits.Keys) {
      if (InputProcessor.testForWord(input, key)) {
        return key;
      }
    }
    return null;
  }
}
