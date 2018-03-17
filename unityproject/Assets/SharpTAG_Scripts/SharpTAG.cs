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
}
