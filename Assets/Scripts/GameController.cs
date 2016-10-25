using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Text[] buttonList;
    private string playerSide;

    void Awake()
    {
        SetGameControllerReferenceOnButtons();
        playerSide = "X";
    }

    void SetGameControllerReferenceOnButtons()
    {
        foreach (Text t in buttonList)
        {
            t.GetComponentInParent<GridSpace>().SetGameControllerReference(this);
        }
    }

    public string GetPlayerSide()
    {
        return playerSide;
    }

    public void EndTurn()
    {
        if (CheckWinnerInRow(0) || CheckWinnerInRow(1) || CheckWinnerInRow(2) ||
            CheckWinnerInColumn(0) || CheckWinnerInColumn(1) || CheckWinnerInColumn(2) ||
            CheckWinnerMainDiagonal() || CheckWinnerSecDiagonal())
        {
            GameOver();
        }
        ChangeSides();
    }

    private bool CheckWinnerInRow(int row)
    {
        row = row * 3;
        return buttonList[row].text == playerSide && buttonList[row + 1].text == playerSide &&
               buttonList[row + 2].text == playerSide;
    }

    private bool CheckWinnerInColumn(int column)
    {
        return buttonList[column].text == playerSide && buttonList[column + 3].text == playerSide &&
               buttonList[column + 6].text == playerSide;
    }

    private bool CheckWinnerMainDiagonal()
    {
        return buttonList[0].text == playerSide && buttonList[4].text == playerSide &&
               buttonList[8].text == playerSide;
    }

    private bool CheckWinnerSecDiagonal()
    {
        return buttonList[2].text == playerSide && buttonList[4].text == playerSide &&
               buttonList[6].text == playerSide;
    }

    public void GameOver()
    {
        foreach (Text t in buttonList)
        {
            t.GetComponentInParent<Button>().interactable = false;
        }
    }

    public void ChangeSides()
    {
        playerSide = (playerSide == "X") ? "O" : "X";
    }
}