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
      {"inventory", new[] {"inventory","item"}}
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
        new Dictionary<string, Exit> {
          {"south", new Exit("Nowhere.south","go south of nowhere")}
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
  public void init() {
    SharpTAGConfiguration.world = TestGame.world;
    SceneManager.LoadScene("SharpTAG UI", LoadSceneMode.Single);
  }
}
