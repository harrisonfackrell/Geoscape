using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class World {
  public PlayerEntity player;
  public List<Room> rooms;
  public List<Interactable> entities;
  public Dictionary<string, string[]> synonyms;
  public Action greet;
  public World (Dictionary<string, string[]> synonyms, PlayerEntity player,
   List<Room> rooms, List<Interactable> entities, Action greet) {
    this.synonyms = synonyms;
    this.player = player;
    this.rooms = rooms.Concat(new List<Room> {
      new Room("Inventory",
        "Inventory",
        new Dictionary<string, Exit>(),
        "Inventory"
      )
    }).ToList();
    this.entities = entities;
    this.greet = greet;
  }
}
