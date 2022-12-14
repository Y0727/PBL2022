using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu( menuName = "Create Deck", fileName = "Deck")]
public class TestScriptableObject : ScriptableObject
{
    public List<string> cardlist;
}
