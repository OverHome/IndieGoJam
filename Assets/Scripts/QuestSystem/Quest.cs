using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "Quest", order = 1)]
public class Quest: ScriptableObject
{
    public int Id;
    public string Name;
    public string Descruption;
}
