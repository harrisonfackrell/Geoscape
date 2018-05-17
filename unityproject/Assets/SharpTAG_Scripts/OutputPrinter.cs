using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.UI;
//using UnityEditor;
using UnityEngine.EventSystems;

public class OutputPrinter {
	private static void reprintLines(string str) {
		//Print the first line, or throw it out if there are too many lines
		string[] lines = chopOutput(str);
		lines = lines.Skip(Math.Max(0, lines.Count() - calcLineLimit(str))).ToArray();
		for (int i = 0; i < lines.Length; i++) {
			outputRaw(lines[i] + "\n");
		}
	}
	private static void outputRaw(string str) {
		SharpTAGProcessor.instance.outputBox.text += str;
	}
	private static int calcCharLimit() {
		return ((Screen.width - 200) / 16);
	}
	private static int calcReduction(string str) {
		return (str.Length / (calcCharLimit()));
	}
	private static int calcLineLimit(string str) {
		return ((Screen.height / 70) - calcReduction(str));
	}
	private static string[] chopOutput(string str) {
		return str.Split(new string[] { "\n" }, System.StringSplitOptions.None);
	}
	public static void output(string str) {
		//Split the existing text into its component lines
		//reprint lines
		string text = SharpTAGProcessor.instance.outputBox.text;
		SharpTAGProcessor.instance.outputBox.text = "";
		reprintLines(text);
		//Print the new line
		outputRaw(str);
	}
	public static string tagify(string tagtext, string str) {
		return tagify(tagtext, str, str);
	}
	public static string tagify(string tagtext, string str, string substr) {
		return tagify(tagtext, str, substr, tagtext);
	}
	public static string tagify(string tagtext, string str, string substr,
	 string closetext) {
		 if (str.Contains(substr)) {
 			return str.Replace(substr, "<" + tagtext + ">" + substr + "</" + closetext + ">");
 		} else {
 			return str;
 		}
	}
	public static string embolden(string str) {
		return embolden(str, str);
	}
	public static string embolden(string str, string substr) {
		return colorize("green", tagify("i", tagify("b", str, substr), substr), substr);
	}
	public static string colorize(string color, string str) {
		return colorize(color, str, str);
	}
	public static string colorize(string color, string str, string substr) {
		return tagify("color=" + color, str, substr, "color");
	}
}
