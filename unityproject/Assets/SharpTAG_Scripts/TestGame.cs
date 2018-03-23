using System;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class TestGame {
  public static World world = new World(
    new Dictionary<string, string[]> {
      {"look", new[] {"look", "examine"}},
      {"attack", new[] {"attack","kick","punch","fight","destroy","crush","break","smash","kill","bite"}},
    },
    new PlayerEntity("Nowhere",
      new Dictionary<string, Action> {
        {"Hello", () => { }}
      },
      () => { }
    ),
    new Room[] {
      new Room("Nowhere",
        "You are nowhere. It's quite a nice place, actually.",
        new Dictionary<string, string[]> {
          {"south", new[] {"Nowhere.south","go south of nowhere"}}
        },
        "Nowhere"
      )
    },
    new Entity[] {
      new Entity("Nowhere.polarbear",
        "Nowhere",
        "A POLAR BEAR FOR SOME REASON",
        new Dictionary<string, Action> {

        },
        "POLAR BEAR"
      )
    }
  );
  public static void init() {
    SharpTAGConfiguration.world = TestGame.world;
  }
}
