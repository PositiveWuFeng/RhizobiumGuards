using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using Game;
public class RootBreedingCenter : MonoBehaviour
{

    [System.Serializable]
    public class CharacterData
    {
        public int characterId;
        public GameObject character;
    }

	public GameObject breedingRoot;

    private List<GameObject> curCharacters = new List<GameObject>();

    public CharacterData[] characters;

    public Transform[] genPoints;

    private int Index = 0;

    private void OnEnable()
    {
        //breedingRoot.SetActive(false);
    }

    public void OnClickSingleBreeding(int characterId)
    {
        breedingRoot.SetActive(false);
        GenCharacter(characterId);
    }

    private void GenCharacter(int characterId)
    {
        if(PlayerData.peopleNum < PlayerData.maxPeopleNum && PlayerData.gold >= 3)
        {
            foreach (var item in characters)
            {
                if (item.characterId == characterId)
                {
                    var o = Instantiate(item.character);
                    o.AddComponent<CharacterMoveByMouse>();
                    FriendlyCharacterPool.Instance.friendlyCharacterList.Add(o);
                    if(Index >= genPoints.Length)
                    {
                        Index = 0;
                    }
                    o.transform.position =  genPoints[Index].position ;//transform.position + new Vector3 (100,0, 0);
                }
            }
            PlayerData.peopleNum++;
            PlayerData.gold -= 3;
        } 
    }

    void OnMouseUp()
	{
        if(GameManager.Instance.myGameState == GameManager.GameState.Prepare)
        {
			breedingRoot.SetActive(!breedingRoot.activeSelf);
        }
		
	}
}
