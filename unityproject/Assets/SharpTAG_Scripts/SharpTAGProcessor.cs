using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
using UnityEngine.EventSystems;
using static SharpTAG;
using UnityEngine.SceneManagement;

public class SharpTAGProcessor : MonoBehaviour {
	public Text outputBox;
	public InputField inputBox;
	public static SharpTAGProcessor instance;
	// Use this for initialization
	void Awake() {
		SharpTAGProcessor.instance = this;
		this.inputBox = GameObject.Find("InputField").GetComponent<InputField>();
		this.outputBox = GameObject.Find("OutputField").GetComponent<Text>();
	}
	void Start() {
		SharpTAGConfiguration.world.greet();
	}
	// Update is called once per frame
	void Update() {

	}
	public void enterHandler() {
		outputUserText(getInput());
		InputProcessor.parseAndExecuteInput(getInput());
		inputBox.text = "";
		inputBox.ActivateInputField();
	}
	public static void loadWorld(World world) {
		SharpTAGConfiguration.world = world;
    SceneManager.LoadScene("SharpTAG UI", LoadSceneMode.Single);
	}
}
