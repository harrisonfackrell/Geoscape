using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.EventSystems;

public class OutputPrinter {
	private static void reprintLines(string[] lines) {
		Text outputBox = GameObject.Find("OutputField").GetComponent<Text>();
		//Print the first line, or throw it out if there are too many lines
		if (lines.Length < calcLineLimit() && lines.Length > 1) {
			outputBox.text = lines[0] + "\n";
		} else {
			outputBox.text = "";
		}
		//Print all of the other lines
		for (int i = 1; i < lines.Length - 1; i++) {
			outputBox.text += lines[i] + "\n";
		}
	}
	private static void printNewLine(string str) {
		string[] newLines = chopOutput(str);
		if (newLines.Length <= 1) {
			outputRaw(newLines[0] + "\n");
		} else {
			for (int i = 0; i < newLines.Length; i++) {
				output(newLines[i]);
			}
		}
	}
	private static void outputRaw(string str) {
		Text outputBox = GameObject.Find("OutputField").GetComponent<Text>();
		outputBox.text += str;
	}
	private static int calcCharLimit() {
		return ((Screen.width - 200) / 16);
	}
	private static int calcLineLimit() {
		return (Screen.height / 70);
	}
	private static string[] chopOutput(string str) {
		int charLimit = calcCharLimit();
		for (int i = charLimit; i < str.Length; i += charLimit) {
			int index = str.LastIndexOf(' ', i, charLimit);
			if (index == -1) {
				str = str.Insert(i, "\n");
			} else {
				str = str.Insert(index, "\n");
			}
		}
		string[] lines = str.Split(new string[] { "\n" },
		System.StringSplitOptions.None);
		return lines;
	}
	public static void output(string str) {
		Text outputBox = GameObject.Find("OutputField").GetComponent<Text>();
		//Split the existing text into its component lines
		string[] lines = outputBox.text.Split(new string[] { "\n" },
		System.StringSplitOptions.None);
		//reprint lines
		reprintLines(lines);
		//Print the new line
		printNewLine(str);
	}
}
