using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class HubUI : MonoBehaviour
{
    private Button nextLevelButton;

    void Start()
    {
        nextLevelButton = GetComponentsInChildren<Button>().First(b => b.name=="NextLevelButton");
        nextLevelButton.onClick.AddListener(NextLevel);
    }

    private void NextLevel()
    {
        GameManager.Instance.RunManager.NextLevel();
    }
}
