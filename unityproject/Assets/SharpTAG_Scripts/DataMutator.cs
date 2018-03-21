using System;
using System.Collections;
using System.Collections.Generic;

public class DataMutator {
  public static Dictionary<string, Action> mergeDictionaries(
   Dictionary<string, Action> first, Dictionary<string, Action> second) {
    foreach (string key in second.Keys) {
      first[key] = second[key];
    }
    return first;
  }
}
