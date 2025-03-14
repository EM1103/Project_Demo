using UnityEngine;
using UnityEngine.UI;
using Ink.Runtime;

public class NPCDialogue : MonoBehaviour
{
    public TextAsset inkJSON; // The compiled Ink file
    private Story story;
    private bool isPlayerNearby = false;

    public GameObject interactionIcon;
    public GameObject dialoguePanel;
    public Text dialogueText;
    public Button nextButton;
    public Button talkButton;
    public Transform choicesContainer;
    public GameObject choiceButtonPrefab;

    void Start()
    {
        interactionIcon.SetActive(false);
        dialoguePanel.SetActive(false);
        talkButton.gameObject.SetActive(false);

        talkButton.onClick.AddListener(StartDialogue);
        nextButton.onClick.AddListener(DisplayNextLine);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("✅ Player entered NPC trigger zone!");
            isPlayerNearby = true;
            
            interactionIcon.SetActive(true);
            talkButton.gameObject.SetActive(true);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Debug.Log("❌ Player left NPC trigger zone!");
            isPlayerNearby = false;

            // Hide Interaction Icon when player leaves
            interactionIcon.SetActive(false);

            // Hide the Talk Button if the dialogue is NOT active
            if (!dialoguePanel.activeSelf)
            {
                talkButton.gameObject.SetActive(false);
            }
            else
            {
                EndDialogue(); // ✅ Close dialogue if it's still open
            }
        }
    }

    void StartDialogue()
    {
        story = new Story(inkJSON.text);
        dialoguePanel.SetActive(true);
        talkButton.gameObject.SetActive(false); // ❌ Hide Talk Button
        DisplayNextLine();
    }

    void DisplayNextLine()
    {
        if (story.canContinue)
        {
            dialogueText.text = story.Continue();
            DisplayChoices();
        }
        else
        {
            EndDialogue();
        }
    }

    void DisplayChoices()
    {
        foreach (Transform child in choicesContainer)
            Destroy(child.gameObject);

        foreach (Choice choice in story.currentChoices)
        {
            GameObject choiceButton = Instantiate(choiceButtonPrefab, choicesContainer);
            choiceButton.GetComponentInChildren<Text>().text = choice.text;
            choiceButton.GetComponent<Button>().onClick.AddListener(() => ChooseOption(choice.index));
        }
    }

    void ChooseOption(int choiceIndex)
    {
        story.ChooseChoiceIndex(choiceIndex);
        DisplayNextLine();
    }

    void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        talkButton.gameObject.SetActive(true); // ✅ Re-enable Talk Button
    }
}
