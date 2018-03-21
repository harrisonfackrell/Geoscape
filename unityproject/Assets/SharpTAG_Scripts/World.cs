using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class World {
  public PlayerEntity player;
  public Room[] rooms;
  public Entity[] entities;
  public Dictionary<string, string[]> synonyms;
  public World (Dictionary<string, string[]> synonyms, PlayerEntity player,
   Room[] rooms, Entity[] entities) {
    this.synonyms = synonyms;
    this.player = player;
    this.rooms = rooms;
    this.entities = entities;
  }
}
