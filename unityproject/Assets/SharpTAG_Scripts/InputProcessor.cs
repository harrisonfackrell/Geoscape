using System;
using UnityEngine;
//using UnityEditor;
using System.Collections;
using System.Collections.Generic;
using static SharpTAG;

public class InputProcessor {
  private static Dictionary<string, string[]> getSynonymDict() {
    return getWorld().synonyms;
  }
  private static string[] getSynonyms(string word) {
    //Get the dictionary of all synonyms
    Dictionary<string, string[]> synonymDict = getSynonymDict();
    //If synonyms exist
    if (synonymDict.ContainsKey(word)) {
      //Make a new array that is one element larger than the value in
      //synonymDict
      string[] synonyms = new string[synonymDict[word].Length + 1];
      //Copy the value of synonymDict over
      Array.Copy(synonymDict[word], synonyms, synonymDict[word].Length);
      //Add the original word
      synonyms[synonyms.Length - 1] = word;
      //Return the final array
      return synonyms;
    } else {
      //Return the original word wrapped in an array
      return new string[] { word };
    }
  }
  public static bool testForWord(string input, string word) {
    //Lowercase the input
    input = input.ToLower();
    word = word.ToLower();
    //Get the word's synonyms
    string[] synonyms = getSynonyms(word);
    //For each one
    for (int i = 0; i < synonyms.Length; i++) {
      //Test for it
      if (input.Contains(synonyms[i])) {
        return true;
      }
    }
    //Return false if the input contains no synonyms
    return false;
  }
  private static Interactable detectEntity(string input, List<Interactable> entities) {
    //For every entity
    for (int i = 0; i < entities.Count; i++) {
      //Test for its name in the input
      if (testForWord(input, entities[i].givenName)) {
        return entities[i];
      }
    }
    //If no input is found, return the player.
    return getPlayer();
  }
  private static Interactable detectEntity(string input) {
    //Parses input, returning an action to run.
    //Get the player and interactables
    PlayerEntity player = getPlayer();
    //Narrow the interactables according to the player's location
    List<Interactable> interactables = findByName(player.location,
     getRooms()).localize(getInteractables());
    //Find a subject
    Interactable subject = detectEntity(input, interactables);
    //If the subject is the player (default)
    if (subject == player) {
      //Try again with the inventory
      interactables = findByName("Inventory",
       getRooms()).localize(getInteractables());
      subject = detectEntity(input, interactables);
    }
    //Find and return an action on the subject.
    return subject;
  }
  private static Action detectAction(string input, Interactable subject) {
    //For each key in the subject's methods
    foreach (string key in subject.methods.Keys) {
      //Test to see if the input contains it
      if(testForWord(input, key)) {
        //return the action corresponding to the key.
        return subject.methods[key];
      }
    }
    //If nothing worked, return the "nothing" action.
    return subject.methods["nothing"];
  }
  public static void parseAndExecuteInput(string input) {
    //Parses and executes input. TAGjs adds some additional effects not yet
    //implemented in SharpTAG; these will come in a future update.
    Interactable subject = detectEntity(input);
    if (subject.displayInput) {
      outputUserText(input);
    }
    if (subject.advanceTurn) {
      nextTurn();
    }
    detectAction(input, subject)();
  }
}
