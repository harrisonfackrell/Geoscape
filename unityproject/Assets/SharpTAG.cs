using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

public class SharpTAG : MonoBehaviour {
	public Text outputBox;
	public InputField inputBox;
	// Use this for initialization
	void Start () {

	}
	// Update is called once per frame
	void Update () {

	}
	public void enterHandler() {
		output(getInput());
		inputBox.text = "";
		inputBox.ActivateInputField();
	}
	void output(string str) {
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
	void select() {

	}
	string getInput() {
		return inputBox.text;
	}
}
