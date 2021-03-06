using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
using UnityEngine.EventSystems;

static class SharpTAG {
	public static void output(string str) {
		OutputPrinter.output("> " + str);
	}
	public static void outputUserText(string str) {
		str = (str == "") ? " " : str;
		str = str.Replace("<", "");
		str = OutputPrinter.colorize("green", str);
		output(str);
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
	public static List<Interactable> getEntities() {
		return getWorld().entities;
	}
	public static List<Room> getRooms() {
		return getWorld().rooms;
	}
	public static List<Interactable> getInteractables() {
		//Get all of the interactable collections. There will one day be more.
		List<Interactable> interactables = new List<Interactable>(getEntities());
		interactables.Add(getPlayer());
		//Return the new List<Interactable>
		return interactables;
	}
	public static void nextTurn() {
		List<Interactable> interactables = getInteractables().Where(interactable =>
		 interactable.location != "Nowhere").ToList();
		for (int i = 0; i < interactables.Count; i++) {
			interactables[i].age += 1;
			interactables[i].turn();
		}
	}
	public static Interactable findByName(string name, List<Interactable> arr) {
		for (int i = 0; i < arr.Count; i++) {
			if (arr[i].name == name) {
				return arr[i];
			}
		}
		return null;
	}
	public static Room findByName(string name, List<Room> arr) {
		for (int i = 0; i < arr.Count; i++) {
			if (arr[i].name == name) {
				return arr[i];
			}
		}
		return null;
	}
}
