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
		InputField inputBox =
			GameObject.Find("InputField").GetComponent<InputField>();
		return inputBox.text;
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
	public static GenericEntity[] narrowEntities(GenericEntity[] entities,
	 string roomName) {
		List<GenericEntity> narrowedEntities = new List<GenericEntity>();
		for (int i = 0; i < entities.Length; i++) {
			if (entities[i].location == roomName) {
				narrowedEntities.Add(entities[i]);
			}
		}
		return narrowedEntities.ToArray();
	}
}
