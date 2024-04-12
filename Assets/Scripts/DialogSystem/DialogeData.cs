using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Data", menuName = "Dialoge", order = 0)]
public class DialogeData : ScriptableObject
{
    public List<TextAndAudio> Data;
}
