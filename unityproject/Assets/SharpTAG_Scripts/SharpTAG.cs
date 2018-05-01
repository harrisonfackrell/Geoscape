using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

static class SharpTAG {
	public static void output(string str) {
		OutputPrinter.output("> " + str);
	}
	public static string getInput() {
		return SharpTAGProcessor.instance.inputBox.text;
	}
	public static World getWorld() {
		return SharpTAGConfiguration.world;
	}
	public static PlayerEntity getPlayer() {
		return getWorld().player;
	}
	public static Entity[] getEntities() {
		return getWorld().entities;
	}
	public static Room[] getRooms() {
		return getWorld().rooms;
	}
	public static Interactable[] getInteractables() {
		//Get all of the interactable collections
		Entity[] entities = getEntities();
		PlayerEntity player = getPlayer();
		//Make an empty Interactable[] with the appropriate length
		int length = entities.Length + 1;
		Interactable[] interactables = new Interactable[length];
		//Copy each interactable collection to the empty array in turn
		entities.CopyTo(interactables, 0);
		interactables[interactables.Length - 1] = player;
		//Return the new interactable[]
		return interactables;
	}
	public static Interactable[] narrowInteractables(Interactable[] entities,
	 string roomName) {
		List<Interactable> narrowedEntities = new List<Interactable>();
		for (int i = 0; i < entities.Length; i++) {
			if (entities[i].location == roomName) {
				narrowedEntities.Add(entities[i]);
			}
		}
		return narrowedEntities.ToArray();
	}
	public static Interactable findByName(string name, Interactable[] arr) {
		for (int i = 0; i < arr.Length; i++) {
			if (arr[i].name == name) {
				return arr[i];
			}
		}
		return null;
	}
	public static Room findByName(string name, Room[] arr) {
		for (int i = 0; i < arr.Length; i++) {
			if (arr[i].name == name) {
				return arr[i];
			}
		}
		return null;
	}
}
