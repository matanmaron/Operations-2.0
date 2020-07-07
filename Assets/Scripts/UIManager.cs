using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject rowPrefab;

    internal void AddNewReshuma(Reshuma row)
    {
        var obj = Instantiate(rowPrefab, content);
        obj.GetComponent<Row>().SetInfo(row);
    }
}
