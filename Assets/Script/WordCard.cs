using UnityEngine;
using UnityEngine.InputSystem;

public class WordCard : MonoBehaviour // CLASS PROPERTY, INHERITANCE
{
    [SerializeField] private string word;  // 문자열 변수 생성 
    [SerializeField] private MazeManager mazeManager; // GameManager의 MazeManager 연결
    [SerializeField] private Material wrongMaterial; 

    private bool playerNearby = false; // 플레이어가 카드 근처에 있는지?, 초기값 설정을 False로 설정 
    private Renderer cardRenderer; 

    private void Awake() // 게임이 실행될 때, 가장 먼저 실행되는 함수
    {
        cardRenderer = GetComponent<Renderer>(); // COLLECTION
    }

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
            bool isCorrect = mazeManager.CheckAnswer(word); 
            if (!isCorrect)
            {
                cardRenderer.material = wrongMaterial;
            }
        }
    }
}