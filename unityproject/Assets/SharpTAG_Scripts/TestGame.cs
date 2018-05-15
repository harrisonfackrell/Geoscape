using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static SharpTAG;

public class TestGame : MonoBehaviour {
  public static World world = new World(
    new Dictionary<string, string[]> {
      {"look", new[] {"look", "examine"}},
      {"attack", new[] {"attack","kick","punch","fight","destroy","crush","break","smash","kill","bite"}},
      {"inventory", new[] {"inventory","item"}},
      {"move", new[] {"move","go","walk","run","step","fly","head"}},
      {"polar bear", new[] {"polar", "bear"}}
    },
    new PlayerEntity("Nowhere",
      new Dictionary<string, Action> {
        {"Hello", () => { }}
      },
      () => { }
    ),
    new List<Room> {
      new Room("Nowhere",
        "You are nowhere. It's quite a nice place, actually",
        new Dictionary<string, Exit> {
          {"south", new Exit("Nowhere.south","go south of nowhere")}
        },
        "Nowhere"
      ),
      new Room("Nowhere.south",
        "You are now south of nowhere",
        new Dictionary<string, Exit> {
          {"north", new Exit("Nowhere","go back north")}
        },
        "South of Nowhere"
      )
    },
    new List<Interactable> {
      new Entity("Nowhere.polarbear",
        "Nowhere",
        "A POLAR BEAR FOR SOME REASON",
        new Dictionary<string, Action> {
          {"attack", () => {
            output("I don't think that attacking a *POLAR BEAR* is wise");
          } },
        },
        "POLAR BEAR"
      )
    },
    () => {
      getPlayer().methods["look"]();
    }
  );
  public void init() {
    SharpTAGProcessor.loadWorld(TestGame.world);
  }
}
