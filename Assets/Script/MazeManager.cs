using UnityEngine;

public class MazeManager : MonoBehaviour
{
    private string[] correctOrder = { "Take", "Took", "Taken" };
    private int currentIndex = 0;

    public bool CheckAnswer(string selectedWord)
    {
        // 이미 모든 단어를 맞힌 경우
        if (currentIndex >= correctOrder.Length)
        {
            return false;
        }

        // 선택한 단어가 현재 목표 단어와 같으면 정답
        if (selectedWord == correctOrder[currentIndex])
        {
            Debug.Log("Correct!");
            currentIndex++;
            return true;
        }

        // 현재 순서에 맞지 않는 단어를 선택한 경우
        Debug.Log("Try again");
        return false;
    }
}