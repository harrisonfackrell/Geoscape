using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using static SharpTAG;

public class SharpTAGProcessor : MonoBehaviour {
	public Text outputBox;
	public InputField inputBox;
	public static SharpTAGProcessor instance;
	// Use this for initialization
	void Awake() {
		SharpTAGProcessor.instance = this;
	}
	// Update is called once per frame
	void Update() {

	}
	public void enterHandler() {
		output(getInput());
		inputBox.text = "";
		inputBox.ActivateInputField();
	}
}
