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
      {"touch", new[] {"touch","feel"}},
      {"take", new[] {"take","pick up","steal","get","keep"}},
      {"polar bear", new[] {"polar", "bear"}}
    },
    new PlayerEntity("whiteroom",
      new Dictionary<string, Action> {
        {"die", () => {
          for (int i = 0; i < 4; i++) {
            output("You're not alone here; don't you forget that.");
          }
        } },
        {"quit", () => {
          Application.Quit();
        } }
      },
      () => { }
    ),
    new List<Room> {
      new Room("whiteroom",
        "You are in a room. It is white and barren--sterile, even--in its " +
        "construction",
        new Dictionary<string, Exit> {
          {"north", new Exit("blackroom","go north through a black door")}
        },
        "White Room"
      ),
      new Room("blackroom",
        "You are in a room. It is black and ominous, to an unnatural degree. " +
        "Where there should be walls, you see only a void; and yet, your hand " +
        "can feel that there is something there",
        new Dictionary<string, Exit> {
          {"south", new Exit("whiteroom","go south through a white door")}
        },
        "Black Room"
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
      ),
      new Entity("blackcube",
        "whiteroom",
        "a large, black cube in the center of the room",
        new Dictionary<string, Action> {
          {"attack", () => {
            output("The cube shimmers slightly, exuding waves of darkness. " +
            "You perceive this strange light oddly; it is not really light at " +
            "all, but is rather like the sensation of color to a blind man: indescribable");
          } },
          {"touch", () => {
            output("The cube is cool to the touch, rather like a cold metal " +
            "left to its own. The heat of your hand does not seem to warm it.");
          } },
          {"take", () => {
            output("You attempt to take the cube. It is too large, however, to " +
            "properly carry with you, so you leave it be");
          } }
        },
        "cube"
      ),
      new Entity("whitecube",
        "blackroom",
        "a large, white cube in the center of the room",
        new Dictionary<string, Action> {
          {"attack", () => {
            output("The cube shimmers slightly, exuding waves of light. " +
            "This radiant luminescence shines through the room, but is absorbed " +
            "entirely by the darkness of the walls. Briefly, however, it illuminates " +
            "a figure, some character standing within the corner of the room.");
          } },
          {"touch", () => {
            output("The cube is slightly warm to the touch. It feels like the " +
            "coalescence of sunlight on a Summer's afternoon.");
          } },
          {"take", () => {
            output("You attempt to take the cube. It is too large, however, to " +
            "properly carry with you, so you leave it be");
          } }
        },
        "cube"
      )
    },
    () => {
      DisplayManager.updateNameDisplay("G.I.U. v1.3.6");
      output("Welcome to the Geoscape Interaction Utility. This program is " +
       "designed to let you explore, through an intuitive interface, the worlds " +
       "created by users of the Geoscape simulation. This particular world was " +
       "created by lead programmer Thomas T. Sidus, and it will allow you to " +
       "explore the capabilities of the program.");
      output(OutputPrinter.embolden("You can issue commands through the box displayed below. " +
       "Look around now.", "look"));
    }
  );
  public void init() {
    SharpTAGProcessor.loadWorld(TestGame.world);
  }
  void Awake() {
    this.init();
  }
}
