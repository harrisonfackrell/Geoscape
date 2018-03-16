using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;
using static SharpTAG;

public class SharpTAG_Processor : MonoBehaviour {
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
}
