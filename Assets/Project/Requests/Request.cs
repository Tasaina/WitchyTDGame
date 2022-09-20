using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Request : MonoBehaviour
{
    public int difficulty;
    public string title;
    public string displayTitle;
    public string description;
    public string requestee;
    public int reward;
    public List<Level> levels=new List<Level>();
}
