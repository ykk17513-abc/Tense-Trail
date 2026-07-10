using UnityEngine;
using UnityEngine.InputSystem;

public class WordCard : MonoBehaviour
{
    [SerializeField] private string word;  // 이 카드의 단어

    [SerializeField] private MazeManager mazeManager; // GameManager의 MazeManager 연결

    private bool playerNearby = false; //플레이어가 카드 근처에 있는지?

    private void OnTriggerEnter(Collider other) // 플레이어가 카드 영역 안으로 들어오면 실행
    {
        if (other.CompareTag("Player")) // 들어온 물체가 플레이어인지 확인
        {
            playerNearby = true;
            Debug.Log("카드 근처!");
        }
    }

    private void OnTriggerExit(Collider other) //플레이어가 카드 영역 밖으로 나갔을 때 실행
    {
        if (other.CompareTag("Player")) // 나간 물체가 플레이어인지 확인
        {
            playerNearby = false;
            Debug.Log("카드에서 멀어짐!");
        }
    }

    private void Update()
    {
        if (playerNearby && Keyboard.current.enterKey.wasPressedThisFrame)
        // 플레이어가 카드 근처에 있고 Enter 키를 눌렀을 때, MazeManager 호출하기
        {
            mazeManager.CheckAnswer(word);
            
        }

    }
}

