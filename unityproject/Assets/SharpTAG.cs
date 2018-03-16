using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

static class SharpTAG {
	// Use this for initialization
	public static void Start () {

	}
	// Update is called once per frame
	public static void Update () {

	}
	public static void output(string str) {
		Text outputBox = GameObject.Find("OutputField").GetComponent<Text>();
		string[] lines = outputBox.text.Split(new string[] { "\n" },
		System.StringSplitOptions.None);

		if (lines.Length < ((Screen.height + Screen.width) / 250) &&
				lines.Length > 1) {
			outputBox.text = lines[0] + "\n";
		} else {
			outputBox.text = "";
		}
		for (int i = 1; i < lines.Length - 1; i++) {
			outputBox.text += lines[i] + "\n";
		}
		outputBox.text += "> " + str + "\n";
	}
	public static void select() {

	}
	public static string getInput() {
		InputField inputBox = GameObject.Find("InputField").GetComponent<InputField>();
		return inputBox.text;
	}
}
